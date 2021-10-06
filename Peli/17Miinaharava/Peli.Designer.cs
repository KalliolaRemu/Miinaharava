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
            this.miinatLabel = new System.Windows.Forms.Label();
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
            this.ajastinLabel.Font = new System.Drawing.Font("Quartz MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ajastinLabel.Location = new System.Drawing.Point(715, 16);
            this.ajastinLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ajastinLabel.Name = "ajastinLabel";
            this.ajastinLabel.Size = new System.Drawing.Size(39, 18);
            this.ajastinLabel.TabIndex = 1;
            this.ajastinLabel.Text = "0:00";
            // 
            // flagbutton
            // 
            this.flagbutton.BackgroundImage = global::_17Miinaharava.Properties.Resources.miina;
            this.flagbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flagbutton.Location = new System.Drawing.Point(17, 2);
            this.flagbutton.Margin = new System.Windows.Forms.Padding(2);
            this.flagbutton.Name = "flagbutton";
            this.flagbutton.Size = new System.Drawing.Size(42, 42);
            this.flagbutton.TabIndex = 2;
            this.flagbutton.UseVisualStyleBackColor = true;
            this.flagbutton.Click += new System.EventHandler(this.flagButton_Click);
            // 
            // miinatLabel
            // 
            this.miinatLabel.AutoSize = true;
            this.miinatLabel.Font = new System.Drawing.Font("Quartz MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miinatLabel.Location = new System.Drawing.Point(353, 16);
            this.miinatLabel.Name = "miinatLabel";
            this.miinatLabel.Size = new System.Drawing.Size(40, 25);
            this.miinatLabel.TabIndex = 3;
            this.miinatLabel.Text = "00";
            // 
            // Peli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 551);
            this.Controls.Add(this.miinatLabel);
            this.Controls.Add(this.flagbutton);
            this.Controls.Add(this.ajastinLabel);
            this.Name = "Peli";
            this.Text = "Miinaharava";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer ajastinTimer;
        private System.Windows.Forms.Label ajastinLabel;
        private System.Windows.Forms.Button flagbutton;
        private System.Windows.Forms.Label miinatLabel;
    }
}