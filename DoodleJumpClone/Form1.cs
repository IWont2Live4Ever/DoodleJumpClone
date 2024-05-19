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

        int heightOfShear;

        Vector velosity = Vector.GetZeroVector();

        bool goLeft, goRight, Jump;

        bool instructionsReadFlag = true;

        Graphics graphics;

        PlayerCharacter player;

        List<Pad> pads;

        public DoodleJumpClone()
        {
            RestartTheGame();
            InitializeComponent();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (instructionsReadFlag)
            {
                instructionsReadFlag = false;
                listBoxWithInstructions.Visible = false;
                gameTimer = new System.Windows.Forms.Timer();
                gameTimer.Start();
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
                player.Jump();

            player.Hitbox.MoveTo(player.Velosity);
            player.Correct();

            if (player.Hitbox.Y < heightOfShear)
            {
                if (Equals(velosity, Vector.ZeroVector))
                {
                    velosity = new Vector(0, -player.Velosity.Y);
                    player.Velosity.Y = 0;
                }
                else
                {
                    velosity.GravityCorrection();
                }
            }

            if (velosity.Y < 0)
            {
                player.Velosity.Y = velosity.Y;
                velosity = Vector.GetZeroVector();
            }

            if (player.Hitbox.Y > (int)(Settings.HeightOfFild * 0.95))
                GameOver();

            foreach (var pad in pads)
            {
                if (!Equals(velosity, Vector.ZeroVector))
                    pad.Hitbox.MoveTo(velosity);

                if (pad.Hitbox.Y > (int)(Settings.HeightOfFild * 0.9))
                {
                    pads.Remove(pad);
                    pads.AddGeneratedPad();
                }
                if (pad.Hitbox.HasOnTop(player.Hitbox))
                {
                    player.FlagJumpOpportunity = true;
                    player.Velosity.Y = 0;
                    velosity = Vector.GetZeroVector();
                    PadWasTouched(pad);
                }
                if (pad.Hitbox.CollidesWith(player.Hitbox))
                {
                    player.Velosity.Rotate(Math.PI);
                }
            }

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
            Settings.SetSettings(
                435, // widthOfFild
                760, // heightOfFild
                20,  // widthOfFPad
                5,   // heightOfFPad
                10,  // widthOfPlayerCharacter
                15); // heightOfPlayerCharacter

            score = 0;

            heightOfShear = (int)(Settings.HeightOfFild * 0.6);

            player = new PlayerCharacter();

            pads = PadsGenerator.GeneratePads(10);
        }
        private void PadWasTouched(Pad pad)
        {
            if (!pad.FlagTouched)
            {
                pad.FlagTouched = true;
                score += 1;
                txtScore.Text = "Score: " + score.ToString();
            }
        }
        private void GameOver()
        {
            gameTimer.Stop();

            if (score > highScore)
            {
                highScore = score;
                txtHighScore.Text = "High Score: " + highScore.ToString();
                txtHighScore.ForeColor = Color.Black;
            }
        }

        private void DoodleJumpClone_Load(object sender, EventArgs e) {}
    }
}
