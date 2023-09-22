namespace MD5window
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAutorize = new System.Windows.Forms.Button();
            this.buttonRegistre = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAutorize
            // 
            this.buttonAutorize.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAutorize.Location = new System.Drawing.Point(37, 12);
            this.buttonAutorize.Name = "buttonAutorize";
            this.buttonAutorize.Size = new System.Drawing.Size(220, 91);
            this.buttonAutorize.TabIndex = 0;
            this.buttonAutorize.Text = "Авторизоваться";
            this.buttonAutorize.UseVisualStyleBackColor = true;
            this.buttonAutorize.Click += new System.EventHandler(this.buttonAutorize_Click);
            // 
            // buttonRegistre
            // 
            this.buttonRegistre.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRegistre.Location = new System.Drawing.Point(37, 128);
            this.buttonRegistre.Name = "buttonRegistre";
            this.buttonRegistre.Size = new System.Drawing.Size(220, 91);
            this.buttonRegistre.TabIndex = 1;
            this.buttonRegistre.Text = "Зарегистрироваться";
            this.buttonRegistre.UseVisualStyleBackColor = true;
            this.buttonRegistre.Click += new System.EventHandler(this.buttonRegistre_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 235);
            this.Controls.Add(this.buttonRegistre);
            this.Controls.Add(this.buttonAutorize);
            this.Name = "MainForm";
            this.Text = "Главная страница";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAutorize;
        private System.Windows.Forms.Button buttonRegistre;
    }
}
