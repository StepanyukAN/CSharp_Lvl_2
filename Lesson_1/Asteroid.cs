using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1
{
    class Asteroid : BaseObject
    {
        private Bitmap asteroid;
        private static Random random = new Random();

        /// <summary>
        /// В конструкторе добавляем к каждому астероиду картинку
        /// </summary>
        /// <param name="pos">Позиция на экране</param>
        /// <param name="dir">Приращение</param>
        /// <param name="size">Размер</param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            asteroid = new Bitmap(AddAsteroid(),size);
            
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(asteroid, Pos.X, Pos.Y);

        }

        public override void Update()
        {
            base.Update();
        }

        /// <summary>
        /// Метод загрузки случайной картинки астероида
        /// </summary>
       private static Image AddAsteroid()
        {
            Image i= Image.FromFile($"0{random.Next(1, 5)}.png");
            return i;
        }
    }
}
