using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shape
{
    public partial class Grid
    {
        public class GreyBlock : Shape
        {
            private static Color COLOR_TOP = new Color(64, 64, 64);
            private static Color COLOR_FRONT = new Color(48, 48, 48);
            private static Color COLOR_LEFT = new Color(32, 32, 32);
            private static Color COLOR_RIGHT = new Color(32, 32, 32);

            public GreyBlock(Vector3 pos, Vector3 sz)
            {
                Position = pos;
                Size = sz;
                Size.Y = 1000.0f;
            }

            public override List<Vector2> OccupiedSquares()
            {
                int x;
                int z;
                List<Vector2> ret;
                ret = new List<Vector2>();
                for (x = (int)Position.X; x <= (int)(Position.X + Size.X); x++)
                {
                    for (z = (int)Position.Z; z <= (int)(Position.Z + Size.Z); z++)
                    {
                        ret.Add(new Vector2(x, z));
                    }
                }
                return ret;
            }

            public override void Move(float speed)
            {
                //
            }
            public override void Update(float t)
            {
                //
            }

            public override void Draw(GraphicsContext context)
            {
                List<VertexPositionColor> points = new List<VertexPositionColor>();
                points.Add(new VertexPositionColor(Position, COLOR_TOP));
                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y, Position.Z), COLOR_TOP));
                points.Add(new VertexPositionColor(new Vector3(Position.X, Position.Y, Position.Z + Size.Z), COLOR_TOP));

                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y, Position.Z), COLOR_TOP));
                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y, Position.Z + Size.Z), COLOR_TOP));
                points.Add(new VertexPositionColor(new Vector3(Position.X, Position.Y, Position.Z + Size.Z), COLOR_TOP));

                points.Add(new VertexPositionColor(Position, COLOR_FRONT));
                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y, Position.Z), COLOR_FRONT));
                points.Add(new VertexPositionColor(new Vector3(Position.X, Position.Y - Size.Y, Position.Z), COLOR_FRONT));

                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y, Position.Z), COLOR_FRONT));
                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y - Size.Y, Position.Z), COLOR_FRONT));
                points.Add(new VertexPositionColor(new Vector3(Position.X, Position.Y - Size.Y, Position.Z), COLOR_FRONT));

                points.Add(new VertexPositionColor(Position, COLOR_LEFT));
                points.Add(new VertexPositionColor(new Vector3(Position.X, Position.Y, Position.Z + Size.Z), COLOR_LEFT));
                points.Add(new VertexPositionColor(new Vector3(Position.X, Position.Y - Size.Y, Position.Z), COLOR_LEFT));

                points.Add(new VertexPositionColor(new Vector3(Position.X, Position.Y - Size.Y, Position.Z), COLOR_LEFT));
                points.Add(new VertexPositionColor(new Vector3(Position.X, Position.Y, Position.Z + Size.Z), COLOR_LEFT));
                points.Add(new VertexPositionColor(new Vector3(Position.X, Position.Y - Size.Y, Position.Z + Size.Z), COLOR_LEFT));

                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y, Position.Z), COLOR_RIGHT));
                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y - Size.Y, Position.Z), COLOR_RIGHT));
                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y, Position.Z + Size.Z), COLOR_RIGHT));

                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y - Size.Y, Position.Z), COLOR_RIGHT));
                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y - Size.Y, Position.Z + Size.Z), COLOR_RIGHT));
                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y, Position.Z + Size.Z), COLOR_RIGHT));

                context.AddPoints(points);
            }
        }
    }
}
