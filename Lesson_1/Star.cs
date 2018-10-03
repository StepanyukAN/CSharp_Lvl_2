using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1
{
    class Star : BaseObject
    {
        private Bitmap star;

        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            star = new Bitmap(Image.FromFile("star.png"), size);
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(star, Pos);
        }

        public override void Update()
        {
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.Y > Game.Height) Pos.Y = 0;
        }

       
    }
}
