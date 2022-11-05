using Model;
using Persistence;
using Persistence.Text;
using System.Windows.Forms;

namespace View
{
    public partial class Form1 : Form
    {
        #region Private fields
        
        private const Int32 penWidth = 3;
        private const Int32 circleRadius = 25;
        private Button[] buttons;
        private MalomGame Game;
        private Boolean PositionSelected = false;
        private Int32 FirstClick;
        private Int32 SecondClick;

        #endregion

        #region Constructor
        public Form1()
        {

            InitializeComponent();
            gamePanel1.Paint += PaintRectangle;
            gamePanel2.Paint += PaintRectangle;
            buttons = new Button[24];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new ButtonRounded(i);
                buttons[i].MouseClick += ButtonRoundedMouseClicked;
            }
            Game = new MalomGame(new MillTextFileDataAccess());
            Game.Mill += MalomGame_Mill;
            Game.TableChanged += UpdateLabels;
            Game.TableChanged += updateButtons;
            Game.GameOver += MalomGame_GameOver;        }

        #endregion

        #region MalomGame Event Handlers

        private void MalomGame_GameOver(object? sender, EventArgs e)
        {
            if (Game.NumberOfBlackPieces < 3) 
            {
                MessageBox.Show($"Congratulations!\n{Players.White.ToString()} won the game!");
            }
            else
            {
                MessageBox.Show($"Congratulations!\n{Players.Black.ToString()} won the game!");
            }
        }

        private void MalomGame_Mill(object? sender, EventArgs e)
        {
            MessageBox.Show("Mill! You can remove a piece from the opponent.");
        }

        private void updateButtons(object? sender, EventArgs e)
        {
            Edge<Players>[] players = Game.GameGraph;
            for (int i = 0; i < players.Length; ++i)
            {
                switch (players[i].Data)
                {
                    case Players.NoPlayer:
                        buttons[i].BackColor = Color.Yellow;
                        break;
                    case Players.White:
                        buttons[i].BackColor = Color.White;
                        break;
                    case Players.Black:
                        buttons[i].BackColor = Color.Black;
                        break;
                }
            }
            PassButton.Visible = Game.phaseCounter > 17 ? true : false;
        }

        private void UpdateLabels(object? sender, EventArgs e)
        {
            label1.Text = $"Number of White pieces: \n{Game.NumberOfWhitePieces}";
            label2.Text = $"Number of Black pieces: \n{Game.NumberOfBlackPieces}";
            label3.Text = $"Current Phase: {Game.Phase.ToString()}";
            label4.Text = $"Player's turn: {Game.CurrentPlayer.ToString()}";
        }
        #endregion

        #region Initial map creation
        private void PaintRectangle(object? sender, PaintEventArgs e)
        {
           if (sender is GamePanel p)
           {
               Bitmap bitmap = new Bitmap(p.Width, p.Height);
               Pen pen = new Pen(Color.Black, 2 * penWidth);
        
               Graphics graphics = Graphics.FromImage(bitmap);
               graphics.Clear(Color.Empty);
        
               graphics.DrawRectangle(pen, circleRadius, circleRadius,
                   p.Width - 2 * circleRadius, p.Height - 2 * circleRadius);
               e.Graphics.DrawImage(bitmap, 0, 0);
        
               PutButtons(p, new IndexEventArgs(p.Index));
           }
        }
        
        private void PaintLines(object? sender, PaintEventArgs e)
        {
           if (sender is GamePanel p)
           {
               Bitmap bitmap = new Bitmap(p.Width, p.Height);
               Pen pen = new Pen(Color.Black, 2 * penWidth);
        
               Graphics graphics = Graphics.FromImage(bitmap);
               graphics.Clear(Color.Empty);
        
               graphics.DrawLine(pen, p.Width / 2, 0 + circleRadius, p.Width / 2, p.Height - circleRadius);
               graphics.DrawLine(pen, circleRadius, p.Height / 2, p.Width - circleRadius, p.Height / 2);
               e.Graphics.DrawImage(bitmap, 0, 0);
           }
        }
        
        private void PutButtons(object? sender, IndexEventArgs e)
        {
           if (sender is GamePanel p)
           {
               Position[] circlePositions = PositionCalculator.GetCenterPositions(p.Width, p.Height, circleRadius + 1);
               for (int i = e.Index; i < e.Index + 8; ++i)
               {
                   buttons[i].Location = new Point(circlePositions[i % 8].X, circlePositions[i % 8].Y);
                   p.Controls.Add(buttons[i]);
               }
           }
        }
        #endregion

        #region Game step handler
        private void ButtonRoundedMouseClicked(object? sender, EventArgs e)
        {
            if (sender is ButtonRounded b)
            {
                if (Game.Phase == Phases.PHASE1)
                {
                    Game.stepGamePhase1(b.Position);
                }
                else if (Game.Phase == Phases.PHASE2)
                {
                    if (!PositionSelected)
                    {
                        FirstClick = b.Position;
                        buttons[FirstClick].BackColor = Color.Gray;
                        PositionSelected = true;
                    }
                    else
                    {
                        SecondClick = b.Position;
                        Game.stepGamePhase2(FirstClick, SecondClick);
                        PositionSelected = false;
                    }
                }
                else if (Game.Phase == Phases.REMOVE)
                {
                    Game.RemovePiece(b.Position);
                }
            }
        }
#endregion

        #region Form event handlers

        private void Form1_LoadGame(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Game.LoadGame(openFileDialog.FileName);
                }
                catch (MillDataException)
                {
                    MessageBox.Show("An error occured while loading.", "Mill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_SaveGame(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Game.SaveGame(saveFileDialog.FileName);
                }
                catch (MillDataException)
                {
                    MessageBox.Show("An error occured while saving.", "Mill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_NewGame(object sender, EventArgs e)
        {
            Game.resetGame();
        }

        private void PassButton_Click(object sender, EventArgs e)
        {
            Game.PassTurn();
        }
        #endregion

    }
}