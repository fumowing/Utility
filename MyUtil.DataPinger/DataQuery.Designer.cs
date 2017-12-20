namespace MyUtil.DataPinger
{
    partial class DataQuery
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtConSTr = new System.Windows.Forms.TextBox();
            this.txtQry = new System.Windows.Forms.TextBox();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lvResult = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Conn String";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Query";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Log Path";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtConSTr
            // 
            this.txtConSTr.Location = new System.Drawing.Point(112, 10);
            this.txtConSTr.Multiline = true;
            this.txtConSTr.Name = "txtConSTr";
            this.txtConSTr.Size = new System.Drawing.Size(591, 54);
            this.txtConSTr.TabIndex = 3;
            this.txtConSTr.Text = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=STB_stb_Port" +
    "al;Data Source=STB-APP\\STBSQL";
            // 
            // txtQry
            // 
            this.txtQry.Location = new System.Drawing.Point(112, 70);
            this.txtQry.Multiline = true;
            this.txtQry.Name = "txtQry";
            this.txtQry.Size = new System.Drawing.Size(591, 68);
            this.txtQry.TabIndex = 4;
            this.txtQry.Text = "select top 1 * from AllLists with(nolock)";
            // 
            // txtLogPath
            // 
            this.txtLogPath.Location = new System.Drawing.Point(112, 143);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(591, 26);
            this.txtLogPath.TabIndex = 5;
            this.txtLogPath.Text = "E:\\DataQuery.log";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(691, 34);
            this.button1.TabIndex = 6;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lvResult
            // 
            this.lvResult.Location = new System.Drawing.Point(12, 271);
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(691, 218);
            this.lvResult.TabIndex = 7;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            this.lvResult.View = System.Windows.Forms.View.List;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Interval";
            // 
            // nudInterval
            // 
            this.nudInterval.Location = new System.Drawing.Point(112, 183);
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(120, 26);
            this.nudInterval.TabIndex = 9;
            this.nudInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(727, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(362, 479);
            this.dataGridView1.TabIndex = 10;
            // 
            // DataQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 505);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.nudInterval);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lvResult);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLogPath);
            this.Controls.Add(this.txtQry);
            this.Controls.Add(this.txtConSTr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DataQuery";
            this.Text = "Data Query";
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtConSTr;
        private System.Windows.Forms.TextBox txtQry;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lvResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

