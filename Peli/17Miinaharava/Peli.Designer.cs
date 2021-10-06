namespace _17Miinaharava
{
    partial class Peli
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
            this.ajastinTimer = new System.Windows.Forms.Timer(this.components);
            this.ajastinLabel = new System.Windows.Forms.Label();
            this.flagbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ajastinTimer
            // 
            this.ajastinTimer.Enabled = true;
            this.ajastinTimer.Interval = 1000;
            this.ajastinTimer.Tick += new System.EventHandler(this.ajastinTimer_Tick);
            // 
            // ajastinLabel
            // 
            this.ajastinLabel.AutoSize = true;
            this.ajastinLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ajastinLabel.Location = new System.Drawing.Point(515, 12);
            this.ajastinLabel.Name = "ajastinLabel";
            this.ajastinLabel.Size = new System.Drawing.Size(49, 24);
            this.ajastinLabel.TabIndex = 1;
            this.ajastinLabel.Text = "0:00";
            // 
            // flagbutton
            // 
            this.flagbutton.BackgroundImage = global::_17Miinaharava.Properties.Resources.miina;
            this.flagbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flagbutton.Location = new System.Drawing.Point(23, 3);
            this.flagbutton.Name = "flagbutton";
            this.flagbutton.Size = new System.Drawing.Size(56, 52);
            this.flagbutton.TabIndex = 2;
            this.flagbutton.UseVisualStyleBackColor = true;
            this.flagbutton.Click += new System.EventHandler(this.flagButton_Click);
            // 
            // Peli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 678);
            this.Controls.Add(this.flagbutton);
            this.Controls.Add(this.ajastinLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Peli";
            this.Text = "Miinaharava";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer ajastinTimer;
        private System.Windows.Forms.Label ajastinLabel;
        private System.Windows.Forms.Button flagbutton;
    }
}