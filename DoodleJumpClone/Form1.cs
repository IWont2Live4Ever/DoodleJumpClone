using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoodleJumpClone
{
    public partial class DoodleJumpClone : Form
    {
        int score;
        int highScore;

        Vector velosity;

        bool goLeft, goRight, Jump;

        bool instructionsReadFlag = true;
        bool gameIsGoingOnFlag = false;

        Graphics graphics;

        PlayerCharacter player;

        List<Pad> pads;

        public DoodleJumpClone()
        {
            InitializeComponent();
            RestartTheGame();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (instructionsReadFlag)
            {
                instructionsReadFlag = false;
                listBoxWithInstructions.Visible = false;
                return;
            }

            if (!gameIsGoingOnFlag && e.KeyCode == Keys.Enter)
            {
                RestartTheGame();
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    GameOver();
                    break;
                case Keys.A:
                case Keys.Left:
                    goLeft = true;
                    break;
                case Keys.D:
                case Keys.Right:
                    goRight = true;
                    break;
                case Keys.W:
                case Keys.Space:
                case Keys.Up:
                    Jump = true;
                    break;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    goLeft = false;
                    break;
                case Keys.D:
                case Keys.Right:
                    goRight = false;
                    break;
            }
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft)
                player.MoveLeft();
            if (goRight)
                player.MoveRight();
            if (Jump)
            {
                Jump = false;
                player.Jump();
            }

            player.Hitbox.MoveTo(player.Velosity);
            player.Correct();
            /*
            if (player.Hitbox.Y < Settings.HeightOfShear)
            {
                velosity = new Vector(0, -player.Velosity.Y);
                player.Velosity.Y = 0;
            }

            if (velosity.Y < 0)
            {
                player.Velosity.Y = velosity.Y;
                velosity = new Vector();
            }
            */
            bool isOnPad = false;
            foreach (var pad in pads)
            {
                if (!Equals(velosity, Vector.ZeroVector))
                    pad.Hitbox.MoveTo(velosity);

                if (pad.Hitbox.Y > (int)(Settings.HeightOfFild * 0.9))
                {
                    pads.Remove(pad);
                    pads.AddGeneratedPad();
                }

                if (pad.Hitbox.HasOnTop(player.Hitbox) && player.Velosity.Y > 0)
                {
                    PadWasTouched(pad);
                    isOnPad = true;
                }
            }
            if (!isOnPad)
                player.IsOnPad = false;
            
            if (player.Hitbox.Y > (int)(Settings.HeightOfFild * 0.95))
                GameOver();

            pictureBox.Invalidate();
        }

        
        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;

            foreach (var pad in pads)
            {
                graphics.FillRectangle(
                    Brushes.Black,
                    pad.Hitbox.X,
                    pad.Hitbox.Y,
                    pad.Hitbox.Width,
                    pad.Hitbox.Height);
            }

            graphics.FillRectangle(
                Brushes.Red,
                player.Hitbox.X,
                player.Hitbox.Y,
                player.Hitbox.Width,
                player.Hitbox.Height);
        }
        
        private void RestartTheGame()
        {
            gameIsGoingOnFlag = true;
            (goLeft, goRight, Jump) = (false, false, false);

            Settings.SetSettings(
                435,  // widthOfFild
                760,  // heightOfFild
                30,   // widthOfFPad
                10,   // heightOfFPad
                10,   // widthOfPlayerCharacter
                15,   // heightOfPlayerCharacter
                0.6); // heightOfShearСoefficient

            score = 0;
            txtScore.Text = "Score: " + score.ToString();

            velosity = Vector.GetZeroVector();

            player = new PlayerCharacter();

            pads = PadsGenerator.GeneratePads(10);

            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Enabled = true;
            gameTimer.Start();
        }

        private void PadWasTouched(Pad pad)
        {
            player.IsOnPad = true;
            player.FlagJumpOpportunity = true;
            player.Velosity.Y = 0;
            velosity = new Vector();

            if (!pad.FlagTouched)
            {
                pad.FlagTouched = true;
                score += 1;
                txtScore.Text = "Score: " + score.ToString();
            }
        }

        private void GameOver()
        {
            gameIsGoingOnFlag = false;
            gameTimer.Stop();
            gameTimer.Enabled = false;

            highScore = Math.Max(highScore, score);
            txtHighScore.Text = "High Score: " + highScore.ToString();
            txtHighScore.ForeColor = Color.Black;
        }

        private void DoodleJumpClone_Load(object sender, EventArgs e) {}
    }
}
