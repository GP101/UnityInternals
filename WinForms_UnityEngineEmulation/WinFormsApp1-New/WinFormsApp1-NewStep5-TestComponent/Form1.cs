using System.Diagnostics;
using System.Numerics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Stopwatch _stopWatch;
        double _elapsedTime = 0;
        string _message = "Press 'A' to generate a sprite: ";
        List<GameObject> _gameObjects = new List<GameObject>();

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
            foreach (GameObject go in _gameObjects)
            {
                go.OnRenderObject(e.Graphics);
            }
            TextRenderer.DrawText(e.Graphics, $"{_message} {_elapsedTime}"
                , this.Font, new Point(0, 0), Color.Black);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 'A')
            {
                GameObject go = CreateGameObject();
                //{{ automatically manged by Unity Engine
                Debug.WriteLine($"Create GameObject {go}");
                go.AddComponent<SpriteRenderer>();
                go.AddComponent<Test>();
                go.BroadcastMessage("Start");
                //}} automatically manged by Unity Engine
            }
            else if (e.KeyValue == 27)
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _stopWatch.Stop();
            _elapsedTime = _stopWatch.ElapsedMilliseconds / 1000.0;
            _stopWatch.Restart();
            Time.deltaTime = _elapsedTime;
            Form1_Update();
            this.Refresh();
        }

        private void Form1_Update()
        {
            foreach (GameObject go in _gameObjects)
            {
                go.BroadcastMessage("Update");
                go.UpdateCoroutine();
            }
        }
        private GameObject CreateGameObject()
        {
            GameObject go = new GameObject();
            _gameObjects.Add(go);
            return go;
        }
    }
}
