using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;

namespace FlightSimulator
{
    class FlightSimulator
    {
        public GameWindow window;

        Vector2[] vertBuffer;
        int VBO;

        public FlightSimulator(GameWindow window)
        {
            this.window = window;

            window.Load += Window_Load;
            window.RenderFrame += Window_RenderFrame;
            window.UpdateFrame += Window_UpdateFrame;
            window.Closing += Window_Closing;
        }
        
        private void Window_Load(object sender, System.EventArgs e)
        {
            GL.ClearColor(Color.DarkBlue);

            vertBuffer = new Vector2[4]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(1, 1),
                new Vector2(0, 1)
            };

            VBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(
                BufferTarget.ArrayBuffer,
                (IntPtr)(Vector2.SizeInBytes * vertBuffer.Length),
                vertBuffer,
                BufferUsageHint.StaticDraw
            );
                
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void Window_UpdateFrame(object sender, FrameEventArgs e)
        {
        }

        private void Window_RenderFrame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.EnableClientState(ArrayCap.VertexArray);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.VertexPointer(2, VertexPointerType.Float, Vector2.SizeInBytes, 0);

            GL.DrawArrays(PrimitiveType.Quads, 0, vertBuffer.Length);

            GL.Flush();
            window.SwapBuffers();
        }
    }
}
