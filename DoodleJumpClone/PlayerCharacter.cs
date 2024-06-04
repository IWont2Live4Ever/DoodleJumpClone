using DoodleJumpClone.Properties;

namespace DoodleJumpClone
{
    internal class PlayerCharacter
    {
        public bool IsOnPad;
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
            this.Velosity = new Vector();
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
            this.Velosity = new Vector();
            this.FlagJumpOpportunity = true;
        }
        public void MoveRight()
        {
            this.Direction = Direction.Right;
            this.Velosity.X += 1;
        }
        public void MoveLeft()
        {
            this.Direction = Direction.Left;
            this.Velosity.X -= 1;
        }
        public void Jump()
        {
            if (this.FlagJumpOpportunity)
            {
                this.FlagJumpOpportunity = false;
                this.Velosity.Y -= 15;
            }
        }
        public void Correct()
        {
            if (!this.IsOnPad)
                this.Velosity.GravityCorrection();

            if (this.Hitbox.X >= Settings.WidthOfFild - 3)
            {
                this.Hitbox.MoveTo(0, this.Hitbox.Y);
            }
            if (this.Hitbox.X <= 3)
            {
                this.Hitbox.MoveTo(Settings.WidthOfFild, this.Hitbox.Y);
            }
        }
    }
}
