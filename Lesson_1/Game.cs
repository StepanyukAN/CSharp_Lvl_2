using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Lesson_1
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;
        private static Random rand = new Random();
        


        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        /// <summary>
        /// Фоновая картинка.
        /// </summary>
        static Image image = Image.FromFile("Galactic.jpg");
        static Bitmap background;

        static Game()
        {
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для
            //текущего приложения
        _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
            background = new Bitmap(image, Width, Height);

            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в
            //буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            Timer timer = new Timer { Interval = 40 };
            timer.Start();
            timer.Tick += Timer_Tick;


        }
        public static void Draw()
        {
            Buffer.Graphics.DrawImage(background, 0, 0);
            foreach (BaseObject obj in _objs)
            obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }


        /// <summary>
        /// Добавил рандома
        /// </summary>
        public static void Load()
        {
            _objs = new BaseObject[30];
            for (int i = 0; i < _objs.Length / 2; i++)
                _objs[i] = new Asteroid(new Point(rand.Next(0,Width), rand.Next(0, Height)), new Point(rand.Next(-5,5), rand.Next(-5, 5)), new Size(30, 30));
            for (int i = _objs.Length / 2; i < _objs.Length; i++)
                _objs[i] = new Star(new Point(rand.Next(0, Width), rand.Next(0, Height)), new Point(rand.Next(1, 3), rand.Next(1, 3)), new Size(50, 50));
        }

    }
}
