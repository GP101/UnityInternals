using System.Diagnostics;
using System.Numerics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Stopwatch _stopWatch;
        double _elapsedTime = 0;
        Vector2 _pos = Vector2.Zero;
        double _speed = 50;

        public Form1()
        {
            InitializeComponent();
            _stopWatch = Stopwatch.StartNew();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            _stopWatch.Start();
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Point pos = new Point((int)_pos.X, (int)_pos.Y);
            Rectangle rect = new Rectangle(pos.X, pos.Y, 40, 40);
            e.Graphics.DrawRectangle(Pens.Black, rect);
            TextRenderer.DrawText(e.Graphics, $"Hello {_elapsedTime}"
                , this.Font, pos, Color.Black);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _stopWatch.Stop();
            _elapsedTime = _stopWatch.ElapsedMilliseconds / 1000.0;
            _stopWatch.Restart();
            Form1_Update();
            this.Refresh();
        }

        private void Form1_Update()
        {
            float offset = (float)_elapsedTime * (float)_speed;
            Vector2 dir = new Vector2(offset, offset);
            _pos += dir;
        }
    }
}
