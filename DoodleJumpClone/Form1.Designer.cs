namespace DoodleJumpClone
{
    partial class DoodleJumpClone
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoodleJumpClone));
            this.txtScore = new System.Windows.Forms.Label();
            this.txtHighScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.listBoxWithInstructions = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // txtScore
            // 
            resources.ApplyResources(this.txtScore, "txtScore");
            this.txtScore.BackColor = System.Drawing.Color.PeachPuff;
            this.txtScore.ForeColor = System.Drawing.Color.Black;
            this.txtScore.Name = "txtScore";
            // 
            // txtHighScore
            // 
            resources.ApplyResources(this.txtHighScore, "txtHighScore");
            this.txtHighScore.BackColor = System.Drawing.Color.PeachPuff;
            this.txtHighScore.ForeColor = System.Drawing.Color.Black;
            this.txtHighScore.Name = "txtHighScore";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 40;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.PeachPuff;
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdatePictureBoxGraphics);
            // 
            // listBoxWithInstructions
            // 
            this.listBoxWithInstructions.BackColor = System.Drawing.Color.IndianRed;
            this.listBoxWithInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.listBoxWithInstructions, "listBoxWithInstructions");
            this.listBoxWithInstructions.FormattingEnabled = true;
            this.listBoxWithInstructions.Items.AddRange(new object[] {
            resources.GetString("listBoxWithInstructions.Items"),
            resources.GetString("listBoxWithInstructions.Items1"),
            resources.GetString("listBoxWithInstructions.Items2"),
            resources.GetString("listBoxWithInstructions.Items3"),
            resources.GetString("listBoxWithInstructions.Items4"),
            resources.GetString("listBoxWithInstructions.Items5"),
            resources.GetString("listBoxWithInstructions.Items6")});
            this.listBoxWithInstructions.Name = "listBoxWithInstructions";
            // 
            // DoodleJumpClone
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.listBoxWithInstructions);
            this.Controls.Add(this.txtHighScore);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.pictureBox);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MinimizeBox = false;
            this.Name = "DoodleJumpClone";
            this.Load += new System.EventHandler(this.DoodleJumpClone_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label txtHighScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ListBox listBoxWithInstructions;
    }
}

