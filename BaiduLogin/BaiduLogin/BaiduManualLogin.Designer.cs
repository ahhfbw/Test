namespace BaiduLogin
{
    partial class BaiduManualLogin
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
            this.picValidate = new System.Windows.Forms.PictureBox();
            this.btnReValidate = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValidateCode = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picValidate)).BeginInit();
            this.SuspendLayout();
            // 
            // picValidate
            // 
            this.picValidate.Location = new System.Drawing.Point(237, 122);
            this.picValidate.Name = "picValidate";
            this.picValidate.Size = new System.Drawing.Size(183, 63);
            this.picValidate.TabIndex = 12;
            this.picValidate.TabStop = false;
            this.picValidate.Click += new System.EventHandler(this.picValidate_Click);
            // 
            // btnReValidate
            // 
            this.btnReValidate.Location = new System.Drawing.Point(237, 195);
            this.btnReValidate.Name = "btnReValidate";
            this.btnReValidate.Size = new System.Drawing.Size(75, 23);
            this.btnReValidate.TabIndex = 10;
            this.btnReValidate.Text = "换验证码";
            this.btnReValidate.UseVisualStyleBackColor = true;
            this.btnReValidate.Click += new System.EventHandler(this.btnReValidate_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(92, 195);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 11;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "验证码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "用户名";
            // 
            // txtValidateCode
            // 
            this.txtValidateCode.Location = new System.Drawing.Point(92, 122);
            this.txtValidateCode.Name = "txtValidateCode";
            this.txtValidateCode.Size = new System.Drawing.Size(144, 19);
            this.txtValidateCode.TabIndex = 4;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(92, 75);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(144, 19);
            this.txtPassWord.TabIndex = 5;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(92, 34);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(144, 19);
            this.txtUserName.TabIndex = 6;
            // 
            // BaiduManualLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 360);
            this.Controls.Add(this.picValidate);
            this.Controls.Add(this.btnReValidate);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValidateCode);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.txtUserName);
            this.Name = "BaiduManualLogin";
            this.Text = "BaiduManualLogin";
            this.Load += new System.EventHandler(this.BaiduManualLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picValidate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picValidate;
        private System.Windows.Forms.Button btnReValidate;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValidateCode;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.TextBox txtUserName;
    }
}