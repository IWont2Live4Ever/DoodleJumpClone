using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJumpClone
{
    internal class Hitbox
    {
        public int X { get; set; }
        public int Y { get; set; }
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
            this.X += (int) vector.X;
            this.Y += (int) vector.Y;
        }

        public bool CollidesWith(Hitbox rect)
        {
            return this.X < (rect.X + rect.Width) &&
                this.Y < (rect.Y + rect.Height) &&
                (this.  X + this.Width) > rect.X &&
                (this.Y + this.Height) > rect.Y;
        }
        public bool HasOnTop(Hitbox rect)
        {
            return rect.Y + rect.Width == this.Y;
        }
    }
}
