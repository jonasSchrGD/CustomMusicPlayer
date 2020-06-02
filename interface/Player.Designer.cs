namespace musicPlayer
{
    partial class Player
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Player));
            this.panel1 = new System.Windows.Forms.Panel();
            this.previousButton = new System.Windows.Forms.PictureBox();
            this.playPauseButton = new System.Windows.Forms.PictureBox();
            this.skipButton = new System.Windows.Forms.PictureBox();
            this.customTrackBar1 = new CustomTrackBar();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previousButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playPauseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skipButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = Settings.settings.BottomBarColor;
            this.panel1.Controls.Add(this.previousButton);
            this.panel1.Controls.Add(this.playPauseButton);
            this.panel1.Controls.Add(this.skipButton);
            this.panel1.Controls.Add(this.customTrackBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 457);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(824, 121);
            this.panel1.TabIndex = 0;
            // 
            // previousButton
            // 
            this.previousButton.Image = ((System.Drawing.Image)(resources.GetObject("previousButton.Image")));
            this.previousButton.Location = new System.Drawing.Point(127, 4);
            this.previousButton.Margin = new System.Windows.Forms.Padding(4);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(123, 113);
            this.previousButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previousButton.TabIndex = 5;
            this.previousButton.TabStop = false;
            this.previousButton.Click += new System.EventHandler(this.PrevButton_Click);
            // 
            // playPauseButton
            // 
            this.playPauseButton.Image = ((System.Drawing.Image)(resources.GetObject("playPauseButton.Image")));
            this.playPauseButton.Location = new System.Drawing.Point(257, 4);
            this.playPauseButton.Margin = new System.Windows.Forms.Padding(4);
            this.playPauseButton.Name = "playPauseButton";
            this.playPauseButton.Size = new System.Drawing.Size(123, 113);
            this.playPauseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playPauseButton.TabIndex = 4;
            this.playPauseButton.TabStop = false;
            this.playPauseButton.Click += new System.EventHandler(this.PlayPauseButton_Click);
            // 
            // skipButton
            // 
            this.skipButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.skipButton.Image = ((System.Drawing.Image)(resources.GetObject("skipButton.Image")));
            this.skipButton.InitialImage = null;
            this.skipButton.Location = new System.Drawing.Point(388, 4);
            this.skipButton.Margin = new System.Windows.Forms.Padding(4);
            this.skipButton.Name = "skipButton";
            this.skipButton.Size = new System.Drawing.Size(123, 113);
            this.skipButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.skipButton.TabIndex = 3;
            this.skipButton.TabStop = false;
            this.skipButton.Click += new System.EventHandler(this.skipButton_Click);
            // 
            // customTrackBar1
            // 
            this.customTrackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.customTrackBar1.DrawState = CustomTrackBar.DrawingState.SmallBar;
            this.customTrackBar1.Location = new System.Drawing.Point(681, 41);
            this.customTrackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.customTrackBar1.Name = "customTrackBar1";
            this.customTrackBar1.ProgressColor = System.Drawing.Color.White;
            this.customTrackBar1.Size = new System.Drawing.Size(139, 37);
            this.customTrackBar1.TabIndex = 1;
            this.customTrackBar1.Text = "customTrackBar1";
            this.customTrackBar1.ThumbColor = System.Drawing.Color.CornflowerBlue;
            this.customTrackBar1.TrackColor = System.Drawing.Color.Gray;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Gray;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Items.AddRange(new object[] {
            "test",
            "test",
            "test"});
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(824, 457);
            this.listBox1.TabIndex = 3;
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Player";
            this.Size = new System.Drawing.Size(824, 578);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previousButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playPauseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skipButton)).EndInit();
            this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomTrackBar customTrackBar1;
        private System.Windows.Forms.PictureBox skipButton;
        private System.Windows.Forms.PictureBox previousButton;
        private System.Windows.Forms.PictureBox playPauseButton;
        private System.Windows.Forms.ListBox listBox1;
    }
}
