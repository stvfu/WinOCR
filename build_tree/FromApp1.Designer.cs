

namespace FromApp1
{
    partial class Form1
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
            button_A = new System.Windows.Forms.Button();
            button_B = new System.Windows.Forms.Button();
            button_C = new System.Windows.Forms.Button();

            textBox_A   = new System.Windows.Forms.TextBox();
            textBox_B = new System.Windows.Forms.TextBox();

            button_A.Location   = new System.Drawing.Point(5, 35);
            button_A.ClientSize = new System.Drawing.Size(200, 20);
            button_A.Click     += new System.EventHandler(button_A_Click);
            button_A.Text       = "文字辨識";

            button_B.Location   = new System.Drawing.Point(210, 35);
            button_B.ClientSize = new System.Drawing.Size(100, 20);
            button_B.Click     += new System.EventHandler(button_B_Click);
            button_B.Text       = "小畫家開圖片";

            button_C.Location   = new System.Drawing.Point(320, 35);
            button_C.ClientSize = new System.Drawing.Size(100, 20);
            button_C.Click     += new System.EventHandler(button_C_Click);
            button_C.Text       = "全螢幕截圖";


            textBox_B.Location   = new System.Drawing.Point(5, 5);
            textBox_B.ClientSize = new System.Drawing.Size(200, 100);
            textBox_B.Text       = "test.png";

            textBox_A.Location   = new System.Drawing.Point(5, 60);
            textBox_A.ClientSize = new System.Drawing.Size(600, 400);
            textBox_A.Multiline  = true;
            textBox_A.Text       = "文字將會顯示在此";

            // Form1
            //
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 111F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize    = new System.Drawing.Size(700, 500);
            this.Load         += new System.EventHandler(Form1_Load);

            this.Controls.Add(button_A);
            this.Controls.Add(button_B);
            this.Controls.Add(button_C);
            this.Controls.Add(textBox_B);
            this.Controls.Add(textBox_A);
            this.Name = "Form1";
            this.Text = "OCR Local 文字辨識器 v1.0";
            //this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button button_A;
        private System.Windows.Forms.Button button_B;
        private System.Windows.Forms.Button button_C;

        private System.Windows.Forms.TextBox textBox_B;
        private System.Windows.Forms.TextBox textBox_A;
        }
}


