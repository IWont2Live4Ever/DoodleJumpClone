using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJumpClone
{

    internal class Pad
    {
        public Hitbox Hitbox { get; protected set; }
        public bool FlagTouched { get; set; }
        public Pad(int x, int y, int width, int height)
        {
            this.Hitbox = new Hitbox(x, y, width, height);
            this.FlagTouched = false;
        }
        public Pad(int x, int y)
        {
            this.Hitbox = new Hitbox(x, y, Settings.WidthOfPad_defoult, Settings.HeightOfPad_defoult);
            this.FlagTouched = false;
        }   
        public Pad()
        {
            this.Hitbox = new Hitbox(0, 0, Settings.WidthOfPad_defoult, Settings.HeightOfPad_defoult);
            this.FlagTouched = false;
        }
    }
}
