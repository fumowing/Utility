namespace My.Util.Organizer
{
    partial class Flight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Flight));
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnAddress = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.numAdult = new System.Windows.Forms.NumericUpDown();
            this.numChildren = new System.Windows.Forms.NumericUpDown();
            this.txtSrc = new System.Windows.Forms.TextBox();
            this.txtDest = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numAdult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChildren)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(24, 332);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(580, 26);
            this.txtAddress.TabIndex = 18;
            this.txtAddress.Text = resources.GetString("txtAddress.Text");
            // 
            // btnAddress
            // 
            this.btnAddress.Location = new System.Drawing.Point(610, 327);
            this.btnAddress.Name = "btnAddress";
            this.btnAddress.Size = new System.Drawing.Size(204, 37);
            this.btnAddress.TabIndex = 17;
            this.btnAddress.Text = "Download";
            this.btnAddress.UseVisualStyleBackColor = true;
            this.btnAddress.Click += new System.EventHandler(this.btnAddress_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(83, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(246, 49);
            this.button1.TabIndex = 19;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(83, 64);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(246, 26);
            this.dtpFrom.TabIndex = 20;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(83, 96);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(246, 26);
            this.dtpTo.TabIndex = 21;
            // 
            // numAdult
            // 
            this.numAdult.Location = new System.Drawing.Point(83, 32);
            this.numAdult.Name = "numAdult";
            this.numAdult.Size = new System.Drawing.Size(120, 26);
            this.numAdult.TabIndex = 22;
            // 
            // numChildren
            // 
            this.numChildren.Location = new System.Drawing.Point(209, 32);
            this.numChildren.Name = "numChildren";
            this.numChildren.Size = new System.Drawing.Size(120, 26);
            this.numChildren.TabIndex = 23;
            // 
            // txtSrc
            // 
            this.txtSrc.Location = new System.Drawing.Point(83, 128);
            this.txtSrc.Name = "txtSrc";
            this.txtSrc.Size = new System.Drawing.Size(246, 26);
            this.txtSrc.TabIndex = 24;
            // 
            // txtDest
            // 
            this.txtDest.Location = new System.Drawing.Point(83, 160);
            this.txtDest.Name = "txtDest";
            this.txtDest.Size = new System.Drawing.Size(246, 26);
            this.txtDest.TabIndex = 25;
            // 
            // Flight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 389);
            this.Controls.Add(this.txtDest);
            this.Controls.Add(this.txtSrc);
            this.Controls.Add(this.numChildren);
            this.Controls.Add(this.numAdult);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnAddress);
            this.Name = "Flight";
            this.Text = "Flight";
            ((System.ComponentModel.ISupportInitialize)(this.numAdult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChildren)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnAddress;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.NumericUpDown numAdult;
        private System.Windows.Forms.NumericUpDown numChildren;
        private System.Windows.Forms.TextBox txtSrc;
        private System.Windows.Forms.TextBox txtDest;
    }
}