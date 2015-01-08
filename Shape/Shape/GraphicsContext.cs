using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shape
{
    public class GraphicsContext
    {

        public Matrix World;
        public Matrix View;
        public Matrix Projection;

        private List<List<VertexPositionColor>> Vertices;
        private List<VertexPositionColor> CurrentBuffer;
        private GraphicsDevice Device;
        private BasicEffect basicEffect;
        private RasterizerState rasterizerState;

        public GraphicsContext(GraphicsDevice device)
        {
            Device = device;
            World = new Matrix();
            View = new Matrix();
            Projection = new Matrix();
            basicEffect = new BasicEffect(Device);
            rasterizerState = new RasterizerState();
            Vertices = new List<List<VertexPositionColor>>();
            basicEffect.VertexColorEnabled = true;
        }

        public void SetCamera(Matrix world, Matrix view, Matrix projection)
        {
            World = world;
            View = view;
            Projection = projection;
            basicEffect.World = World;
            basicEffect.View = View;
            basicEffect.Projection = Projection;
        }

        public int AddBuffer()
        {
            var temp = new List<VertexPositionColor>();
            Vertices.Add(temp);
            return Vertices.IndexOf(temp);
        }

        public void SetCurrentBuffer(int handle)
        {
            CurrentBuffer = Vertices[handle];
        }

        public void AddPoints(List<VertexPositionColor> Points)
        {
            foreach(var p in Points)
            {
                CurrentBuffer.Add(p);
            }
        }

        public void Draw()
        {

            
            
            rasterizerState.CullMode = CullMode.None;
            Device.RasterizerState = rasterizerState;

            foreach (var list in Vertices)
            {
                VertexBuffer vb;
                        
                vb = new VertexBuffer(Device, typeof(VertexPositionColor), list.Count, BufferUsage.WriteOnly);
                vb.SetData<VertexPositionColor>(list.ToArray());

                Device.SetVertexBuffer(vb);

                foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    Device.DrawPrimitives(PrimitiveType.TriangleList, 0, list.Count / 3);
                }
            }
            Vertices.Clear();
        }
    }
}
