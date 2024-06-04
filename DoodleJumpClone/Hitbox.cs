using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJumpClone
{
    internal class Hitbox
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public Hitbox(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public void MoveTo(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public void MoveTo(Vector vector)
        {
            if (this.X + (int)vector.X >= Settings.WidthOfFild)
                this.X = Settings.WidthOfFild;
            else
                this.X += (int)vector.X;

            if (this.Y + (int)vector.Y >= Settings.HeightOfFild)
                this.Y = Settings.HeightOfFild;
            else
                this.Y += (int) vector.Y;
        }

        public bool CollidesWith(Hitbox rect)
        {
            return ( this.X < (rect.X + rect.Width) && (this.X + this.Width) > rect.X ) &&
                ( this.Y < (rect.Y + rect.Height) || (this.Y + this.Height) > rect.Y );
        }
        public bool HasOnTop(Hitbox rect)
        {
            return (Math.Abs(rect.Y + rect.Height - this.Y) <= 5) && this.CollidesWith(rect);
        }
    }
}
