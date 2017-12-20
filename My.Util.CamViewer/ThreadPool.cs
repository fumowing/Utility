using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace My.Util.CamViewer
{
    public class StreamParam
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Folder { get; set; }
    }
    public class Logger
    {
        public static void Error(Exception ex)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
            StreamWriter sw = new StreamWriter(filePath, true);
            sw.Write(string.Format("{0} - {1} - {2} \r\n",DateTime.Now.ToString("yyyyMMddHHmmss"), ex.Message, ex.StackTrace));
            sw.Flush();
            sw.Close();
        }
    }
    public class ThreadPool
    {
        private IList<Thread> _threads;
        private readonly int MAX_THREADS = 25;

        public ThreadPool()
        {
            _threads = new List<Thread>();
        }

        public void LaunchThreads(string folder, string name, string url)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(ThreadEntry));
            thread.IsBackground = true;
            thread.Name = string.Format("MyThread{0}", name);

            _threads.Add(thread);
            thread.Start(new StreamParam { Name = name, Url = url, Folder = folder });
        }

        public void KillThread(string name)
        {
            string id = string.Format("MyThread{0}",name);
            foreach (Thread thread in _threads)
            {
                if (thread.Name == id)
                    thread.Abort();
            }
        }
       
        void ThreadEntry(object param)
        {
            try
            {
                StreamParam stParam = param as StreamParam;
                WebClient webClient = new WebClient();
                webClient.Credentials = new NetworkCredential("admin", "Elyssia1602");

                //var url = "http://192.168.0.25/video/mjpg.cgi";
                //var url = "http://192.168.0.16/video/mjpg.cgi";
                //url = "http://192.168.0.16/video.cgi?resolution=VGA";
                stParam.Folder = Path.Combine(stParam.Folder, DateTime.Now.ToString("yyyyMMdd"));
                TryCreateDir(stParam.Folder);
                string outputFile = stParam.Folder + "\\recording" + stParam.Name + DateTime.Now.ToString("yyyyMMddHHmmss") + ".mp4";
                // Download the file and write it to disk
                using (Stream webStream = webClient.OpenRead(stParam.Url))
                using (FileStream fileStream = new FileStream(outputFile, FileMode.Create))
                {
                    var buffer = new byte[32768];
                    int bytesRead;
                    Int64 bytesReadComplete = 0;  // Use Int64 for files larger than 2 gb

                    // Get the size of the file to download
                    Int64 bytesTotal = Convert.ToInt64(webClient.ResponseHeaders["Content-Length"]);

                    // Download file in chunks
                    while ((bytesRead = webStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        bytesReadComplete += bytesRead;
                        fileStream.Write(buffer, 0, bytesRead); fileStream.FlushAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        private void TryCreateDir(string p)
        {
            if (!Directory.Exists(p))
            {
                Directory.CreateDirectory(p);
            }

        }
    }

}
