namespace My.Util.Organizer
{
    partial class FileOrganizer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileOrganizer));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gvList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadMissingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchMissingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchGoogleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSearchKeyword = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.chkWriteLog = new System.Windows.Forms.CheckBox();
            this.chkPrompt = new System.Windows.Forms.CheckBox();
            this.txtTorrentFolder = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.txtSearchUrl = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnAddress = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gvList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 222);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1179, 383);
            this.panel2.TabIndex = 1;
            // 
            // gvList
            // 
            this.gvList.AllowUserToOrderColumns = true;
            this.gvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvList.ContextMenuStrip = this.contextMenuStrip1;
            this.gvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvList.Location = new System.Drawing.Point(0, 0);
            this.gvList.Name = "gvList";
            this.gvList.RowTemplate.Height = 28;
            this.gvList.Size = new System.Drawing.Size(1179, 383);
            this.gvList.TabIndex = 1;
            this.gvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvList_CellDoubleClick);
            this.gvList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvList_CellFormatting);
            this.gvList.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvList_ColumnHeaderMouseClick);
            this.gvList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvList_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadMissingToolStripMenuItem,
            this.searchMissingToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.searchGoogleToolStripMenuItem,
            this.markEndToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(233, 154);
            // 
            // downloadMissingToolStripMenuItem
            // 
            this.downloadMissingToolStripMenuItem.Name = "downloadMissingToolStripMenuItem";
            this.downloadMissingToolStripMenuItem.Size = new System.Drawing.Size(232, 30);
            this.downloadMissingToolStripMenuItem.Text = "Download Missing";
            this.downloadMissingToolStripMenuItem.Click += new System.EventHandler(this.downloadMissingToolStripMenuItem_Click);
            // 
            // searchMissingToolStripMenuItem
            // 
            this.searchMissingToolStripMenuItem.Name = "searchMissingToolStripMenuItem";
            this.searchMissingToolStripMenuItem.Size = new System.Drawing.Size(232, 30);
            this.searchMissingToolStripMenuItem.Text = "Search Missing";
            this.searchMissingToolStripMenuItem.Click += new System.EventHandler(this.searchMissingToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(232, 30);
            this.searchToolStripMenuItem.Text = "Search Title";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // searchGoogleToolStripMenuItem
            // 
            this.searchGoogleToolStripMenuItem.Name = "searchGoogleToolStripMenuItem";
            this.searchGoogleToolStripMenuItem.Size = new System.Drawing.Size(232, 30);
            this.searchGoogleToolStripMenuItem.Text = "Search Google";
            this.searchGoogleToolStripMenuItem.Click += new System.EventHandler(this.searchGoogleToolStripMenuItem_Click);
            // 
            // markEndToolStripMenuItem
            // 
            this.markEndToolStripMenuItem.Name = "markEndToolStripMenuItem";
            this.markEndToolStripMenuItem.Size = new System.Drawing.Size(232, 30);
            this.markEndToolStripMenuItem.Text = "Mark End";
            this.markEndToolStripMenuItem.Click += new System.EventHandler(this.markEndToolStripMenuItem_Click);
            // 
            // txtSearchKeyword
            // 
            this.txtSearchKeyword.Location = new System.Drawing.Point(18, 146);
            this.txtSearchKeyword.Name = "txtSearchKeyword";
            this.txtSearchKeyword.Size = new System.Drawing.Size(580, 26);
            this.txtSearchKeyword.TabIndex = 11;
            this.txtSearchKeyword.Text = "{0} {1:00} [480p]";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(18, 26);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(580, 26);
            this.txtPath.TabIndex = 0;
            this.txtPath.Text = "D:\\Anime";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(604, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(685, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 39);
            this.button2.TabIndex = 2;
            this.button2.Text = "Go!";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(890, 72);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 39);
            this.button3.TabIndex = 3;
            this.button3.Text = "All List";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(766, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 39);
            this.button4.TabIndex = 4;
            this.button4.Text = "decode";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // chkWriteLog
            // 
            this.chkWriteLog.AutoSize = true;
            this.chkWriteLog.Location = new System.Drawing.Point(847, 28);
            this.chkWriteLog.Name = "chkWriteLog";
            this.chkWriteLog.Size = new System.Drawing.Size(62, 24);
            this.chkWriteLog.TabIndex = 5;
            this.chkWriteLog.Text = "Log";
            this.chkWriteLog.UseVisualStyleBackColor = true;
            // 
            // chkPrompt
            // 
            this.chkPrompt.AutoSize = true;
            this.chkPrompt.Location = new System.Drawing.Point(905, 28);
            this.chkPrompt.Name = "chkPrompt";
            this.chkPrompt.Size = new System.Drawing.Size(121, 24);
            this.chkPrompt.TabIndex = 6;
            this.chkPrompt.Text = "Prompt New";
            this.chkPrompt.UseVisualStyleBackColor = true;
            // 
            // txtTorrentFolder
            // 
            this.txtTorrentFolder.Location = new System.Drawing.Point(18, 78);
            this.txtTorrentFolder.Name = "txtTorrentFolder";
            this.txtTorrentFolder.Size = new System.Drawing.Size(580, 26);
            this.txtTorrentFolder.TabIndex = 7;
            this.txtTorrentFolder.Text = "D:\\Anime\\Torrent";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(989, 72);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(147, 39);
            this.button5.TabIndex = 8;
            this.button5.Text = "Missing List";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(604, 72);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 39);
            this.button6.TabIndex = 9;
            this.button6.Text = "Open";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // txtSearchUrl
            // 
            this.txtSearchUrl.Location = new System.Drawing.Point(18, 114);
            this.txtSearchUrl.Name = "txtSearchUrl";
            this.txtSearchUrl.Size = new System.Drawing.Size(580, 26);
            this.txtSearchUrl.TabIndex = 10;
            this.txtSearchUrl.Text = "https://animetosho.org/search?q={0}";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddress);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.txtSearchKeyword);
            this.panel1.Controls.Add(this.txtSearchUrl);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.txtTorrentFolder);
            this.panel1.Controls.Add(this.chkPrompt);
            this.panel1.Controls.Add(this.chkWriteLog);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtPath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1179, 222);
            this.panel1.TabIndex = 0;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(604, 117);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(204, 37);
            this.button9.TabIndex = 14;
            this.button9.Text = "Download First Page";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(890, 132);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(119, 37);
            this.button8.TabIndex = 13;
            this.button8.Text = "Folder Sizes";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1032, 24);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(121, 31);
            this.button7.TabIndex = 12;
            this.button7.Text = "Remove Ext";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnAddress
            // 
            this.btnAddress.Location = new System.Drawing.Point(604, 179);
            this.btnAddress.Name = "btnAddress";
            this.btnAddress.Size = new System.Drawing.Size(204, 37);
            this.btnAddress.TabIndex = 15;
            this.btnAddress.Text = "Search Flight";
            this.btnAddress.UseVisualStyleBackColor = true;
            this.btnAddress.Click += new System.EventHandler(this.btnAddress_Click);
            // 
            // FileOrganizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 605);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileOrganizer";
            this.Text = "My File Organizer";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gvList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchMissingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadMissingToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSearchKeyword;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox chkWriteLog;
        private System.Windows.Forms.CheckBox chkPrompt;
        private System.Windows.Forms.TextBox txtTorrentFolder;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txtSearchUrl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem searchGoogleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markEndToolStripMenuItem;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnAddress;
    }
}

