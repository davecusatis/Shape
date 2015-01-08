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

        private List<Texture2D> Textures;
        private List<VertexPositionTexture> SpriteTriangles;

        private List<VertexPositionColor> CurrentBuffer;
        private GraphicsDevice Device;
        private BasicEffect basicEffect;
        private BasicEffect spriteEffect;
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
            spriteEffect = new BasicEffect(Device);
            SpriteTriangles = new List<VertexPositionTexture>();
            Textures = new List<Texture2D>();

            basicEffect.VertexColorEnabled = true;
            spriteEffect.TextureEnabled = true;
        }

        public void SetCamera(Matrix world, Matrix view, Matrix projection)
        {
            World = world;
            View = view;
            Projection = projection;
            spriteEffect.World = World;
            spriteEffect.View = View;
            spriteEffect.Projection = Projection;
            

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

        public void AddSprite(Texture2D image, Vector3 pos, Vector2 scale, bool frontFacing = false)
        {
            Vector3[] pts = new Vector3[4];
            Vector2 imgSize;

            imgSize = new Vector2(image.Width, image.Height) * 0.5f * scale;

            if (frontFacing)
            {
                pts[0] = new Vector3(pos.X - imgSize.X, pos.Y - imgSize.Y, pos.Z);
                pts[1] = new Vector3(pos.X + imgSize.X, pos.Y - imgSize.Y, pos.Z);
                pts[2] = new Vector3(pos.X + imgSize.X, pos.Y + imgSize.Y, pos.Z);
                pts[3] = new Vector3(pos.X - imgSize.X, pos.Y + imgSize.Y, pos.Z);
            }
            else
            {
                pts[0] = new Vector3(pos.X - imgSize.X, pos.Y, pos.Z - imgSize.Y);
                pts[1] = new Vector3(pos.X + imgSize.X, pos.Y, pos.Z - imgSize.Y);
                pts[2] = new Vector3(pos.X + imgSize.X, pos.Y, pos.Z + imgSize.Y);
                pts[3] = new Vector3(pos.X - imgSize.X, pos.Y, pos.Z + imgSize.Y);
            }

            Textures.Add(image);

            SpriteTriangles.Add(new VertexPositionTexture(pts[0], new Vector2(0, 0)));
            SpriteTriangles.Add(new VertexPositionTexture(pts[3], new Vector2(0, 1)));
            SpriteTriangles.Add(new VertexPositionTexture(pts[1], new Vector2(1, 0)));
            SpriteTriangles.Add(new VertexPositionTexture(pts[1], new Vector2(1, 0)));
            SpriteTriangles.Add(new VertexPositionTexture(pts[3], new Vector2(0, 1)));
            SpriteTriangles.Add(new VertexPositionTexture(pts[2], new Vector2(1, 1)));

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
            int i;
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

            for (i = 0; i < Textures.Count; i++)
            {
                spriteEffect.Texture = Textures[i];
                foreach (EffectPass pass in spriteEffect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    Device.DrawPrimitives(PrimitiveType.TriangleList, i * 2, 2);
                }

            }

            Vertices.Clear();
            Textures.Clear();
            SpriteTriangles.Clear();
        }
    }
}
