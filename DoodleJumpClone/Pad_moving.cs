using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJumpClone
{
    internal class Pad_moving : Pad
    {
        public Direction Direction;
        public Pad_moving(int x, int y, int width, int height, Direction d)
        {
            this.Hitbox = new Hitbox(x, y, width, height);
            this.Direction = d;
            this.FlagTouched = false;
        }
        public Pad_moving(int x, int y, Direction d)
        {
            this.Hitbox = new Hitbox(x, y, Settings.WidthOfPad_defoult, Settings.HeightOfPad_defoult);
            this.Direction = d;
            this.FlagTouched = false;
        }
        public Pad_moving()
        {
            this.Hitbox = new Hitbox(0, 0, Settings.WidthOfPad_defoult, Settings.HeightOfPad_defoult);
            this.Direction = Direction.Left;
            this.FlagTouched = false;
        }
    }
}
