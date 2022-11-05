using System.Windows.Forms;

namespace View
{
    partial class Form1
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
            this.gamePanel1 = new View.GamePanel();
            this.gamePanel2 = new View.GamePanel();
            this.gamePanel3 = new View.GamePanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.NewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveGame = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadGame = new System.Windows.Forms.ToolStripMenuItem();
            this.PassButton = new System.Windows.Forms.Button();
            this.gamePanel1.SuspendLayout();
            this.gamePanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gamePanel1
            // 
            this.gamePanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gamePanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gamePanel1.Controls.Add(this.gamePanel2);
            this.gamePanel1.Index = 0;
            this.gamePanel1.Location = new System.Drawing.Point(10, 40);
            this.gamePanel1.Name = "gamePanel1";
            this.gamePanel1.Size = new System.Drawing.Size(700, 700);
            this.gamePanel1.TabIndex = 0;
            this.gamePanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintLines);
            // 
            // gamePanel2
            // 
            this.gamePanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gamePanel2.Controls.Add(this.gamePanel3);
            this.gamePanel2.Index = 8;
            this.gamePanel2.Location = new System.Drawing.Point(100, 100);
            this.gamePanel2.Name = "gamePanel2";
            this.gamePanel2.Size = new System.Drawing.Size(500, 500);
            this.gamePanel2.TabIndex = 0;
            this.gamePanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintLines);
            // 
            // gamePanel3
            // 
            this.gamePanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gamePanel3.Index = 16;
            this.gamePanel3.Location = new System.Drawing.Point(100, 100);
            this.gamePanel3.Name = "gamePanel3";
            this.gamePanel3.Size = new System.Drawing.Size(300, 300);
            this.gamePanel3.TabIndex = 0;
            this.gamePanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintRectangle);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(716, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 84);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of White pieces: 0";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(716, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 90);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of Black Pieces: 0";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(716, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 80);
            this.label3.TabIndex = 3;
            this.label3.Text = "Current Phase: PHASE1";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(716, 392);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 70);
            this.label4.TabIndex = 4;
            this.label4.Text = "Players Turn: White";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "New Game";
            // 
            // Menu
            // 
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGame,
            this.SaveGame,
            this.LoadGame});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(62, 24);
            this.Menu.Text = "Game";
            // 
            // NewGame
            // 
            this.NewGame.Name = "NewGame";
            this.NewGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewGame.Size = new System.Drawing.Size(218, 26);
            this.NewGame.Text = "New Game";
            this.NewGame.Click += new System.EventHandler(this.Form1_NewGame);
            // 
            // SaveGame
            // 
            this.SaveGame.Name = "SaveGame";
            this.SaveGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveGame.Size = new System.Drawing.Size(218, 26);
            this.SaveGame.Text = "Save Game";
            this.SaveGame.Click += new System.EventHandler(this.Form1_SaveGame);
            // 
            // LoadGame
            // 
            this.LoadGame.Name = "LoadGame";
            this.LoadGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.LoadGame.Size = new System.Drawing.Size(218, 26);
            this.LoadGame.Text = "Load Game";
            this.LoadGame.Click += new System.EventHandler(this.Form1_LoadGame);
            // 
            // PassButton
            // 
            this.PassButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PassButton.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PassButton.Location = new System.Drawing.Point(716, 470);
            this.PassButton.Name = "PassButton";
            this.PassButton.Size = new System.Drawing.Size(152, 70);
            this.PassButton.TabIndex = 6;
            this.PassButton.Text = "Pass";
            this.PassButton.UseVisualStyleBackColor = true;
            this.PassButton.Visible = false;
            this.PassButton.Click += new System.EventHandler(this.PassButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 753);
            this.Controls.Add(this.PassButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gamePanel1);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(900, 750);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gamePanel1.ResumeLayout(false);
            this.gamePanel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GamePanel gamePanel1;
        private GamePanel gamePanel2;
        private GamePanel gamePanel3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem Menu;
        private ToolStripMenuItem NewGame;
        private ToolStripMenuItem SaveGame;
        private ToolStripMenuItem LoadGame;
        private Button PassButton;
    }
}