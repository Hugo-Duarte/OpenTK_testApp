using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTK_test
{
    class Game
    {
        private GameWindow window;

        public Game(GameWindow window)
        {
            this.window = window;
            this.Start();
        }

        public void Start()
        {
            window.Load += Loaded;
            window.Resize += Resize;
            window.RenderFrame += RenderF;
            window.Run(1.0, 60.0);
        }

        void Resize(object o, EventArgs e)
        {
            GL.Viewport(0,0, window.Width,window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0.0,50.0,0.0,50.0, -1.0, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        void RenderF(object o, EventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Begin(BeginMode.Triangles);
            GL.Vertex2(1.0, 1.0);
            GL.Vertex2(49.0, 1.0);
            GL.Vertex2(25.0, 49.0);
            GL.End();
            window.SwapBuffers();
        }

        void Loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}
