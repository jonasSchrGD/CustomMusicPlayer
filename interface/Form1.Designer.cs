namespace musicPlayer
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.optionsButton = new System.Windows.Forms.Button();
            this.homeButton = new System.Windows.Forms.Button();
            this.player = new musicPlayer.Player();
            this.optionsBoard1 = new musicPlayer.optionsBoard();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.optionsButton);
            this.panel3.Controls.Add(this.homeButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(182, 574);
            this.panel3.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "random",
            "shuffle",
            "fisher-yates shuffle",
            "none"});
            this.comboBox1.Location = new System.Drawing.Point(0, 412);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(182, 24);
            this.comboBox1.TabIndex = 2;
            // 
            // optionsButton
            // 
            this.optionsButton.BackColor = System.Drawing.Color.DimGray;
            this.optionsButton.FlatAppearance.BorderSize = 0;
            this.optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionsButton.Location = new System.Drawing.Point(0, 121);
            this.optionsButton.Margin = new System.Windows.Forms.Padding(4);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(184, 98);
            this.optionsButton.TabIndex = 1;
            this.optionsButton.Text = "options";
            this.optionsButton.UseVisualStyleBackColor = false;
            // 
            // homeButton
            // 
            this.homeButton.BackColor = System.Drawing.Color.Gray;
            this.homeButton.FlatAppearance.BorderSize = 0;
            this.homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeButton.Location = new System.Drawing.Point(0, 15);
            this.homeButton.Margin = new System.Windows.Forms.Padding(4);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(184, 98);
            this.homeButton.TabIndex = 0;
            this.homeButton.Text = "home";
            this.homeButton.UseVisualStyleBackColor = false;
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Gray;
            this.player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.player.Location = new System.Drawing.Point(182, 0);
            this.player.Margin = new System.Windows.Forms.Padding(4);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(798, 574);
            this.player.TabIndex = 8;
            // 
            // optionsBoard1
            // 
            this.optionsBoard1.AutoScroll = true;
            this.optionsBoard1.BackColor = System.Drawing.Color.Gray;
            this.optionsBoard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsBoard1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optionsBoard1.Location = new System.Drawing.Point(182, 0);
            this.optionsBoard1.Margin = new System.Windows.Forms.Padding(0);
            this.optionsBoard1.Name = "optionsBoard1";
            this.optionsBoard1.Size = new System.Drawing.Size(798, 574);
            this.optionsBoard1.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DimGray;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.textBox1.Location = new System.Drawing.Point(0, 384);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(285, 19);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "randomize type";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(980, 574);
            this.Controls.Add(this.player);
            this.Controls.Add(this.optionsBoard1);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Music Player";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Button homeButton;
        private optionsBoard optionsBoard1;
        private Player player;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

