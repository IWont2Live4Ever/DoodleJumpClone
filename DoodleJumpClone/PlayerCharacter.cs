using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJumpClone
{
    internal class PlayerCharacter
    {
        public Hitbox Hitbox { get; private set; }
        public Direction Direction;
        public Vector Velosity { get; set; }
        public bool FlagJumpOpportunity;
        public PlayerCharacter(int x, int y)
        {
            this.Hitbox = new Hitbox(
                x,
                y,
                Settings.WidthOfPlayerCharacter_defoult,
                Settings.HeightOfPlayerCharacter_defoult);
            this.Direction = Direction.Left;
            this.Velosity = Vector.GetZeroVector();
            this.FlagJumpOpportunity = true;
        }
        public PlayerCharacter()
        {
            this.Hitbox = new Hitbox(
                (Settings.WidthOfFild - Settings.WidthOfPlayerCharacter_defoult) / 2,
                Settings.StartingHeight - Settings.HeightOfPlayerCharacter_defoult,
                Settings.WidthOfPlayerCharacter_defoult,
                Settings.HeightOfPlayerCharacter_defoult);
            this.Direction = Direction.Left;
            this.Velosity = Vector.GetZeroVector();
            this.FlagJumpOpportunity = true;
        }
        public void MoveRight()
        {
            this.Direction = Direction.Right;
            this.Velosity.X += 10;
        }
        public void MoveLeft()
        {
            this.Direction = Direction.Left;
            this.Velosity.X -= 10;
        }
        public void Jump()
        {
            if (this.FlagJumpOpportunity)
            {
                this.FlagJumpOpportunity = false;
                this.Velosity.Y += 100;
            }
        }
        public void Correct()
        {
            Velosity.GravityCorrection();

            if (this.Hitbox.X >= Settings.WidthOfFild)
            {
                this.Hitbox.X = 0;
            }
            if (this.Hitbox.X <= 0)
            {
                this.Hitbox.X = Settings.WidthOfFild;
            }
        }
    }
}
