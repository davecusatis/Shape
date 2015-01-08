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
        public class GreenBlock : Shape
        {
            private static Color COLOR_TOP = new Color(0, 255, 0);
            private static Color COLOR_FRONT = new Color(0, 255, 0);
            private static Color COLOR_LEFT = new Color(0, 255, 0);
            private static Color COLOR_RIGHT = new Color(0, 255, 0);

            public GreenBlock(Vector3 pos, Vector3 sz)
            {
                Position = pos;
                Size = sz;
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
            public override void Update(float t)
            {
                Velocity += Acceleration * t;
                Position += Velocity * t;
                Acceleration = new Vector3(0, 0, 0);
                Velocity *= VELOCITY_DAMP;
                if (Velocity.Length() < MIN_VELOCITY)
                {
                    Velocity = new Vector3(0, 0, 0);
                    ShapeState = State.Stopped;
                }
            }
            public override void Move(float speed)
            {
                Acceleration = new Vector3(0, 0, speed);
                ShapeState = State.Moving;
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
                points.Add(new VertexPositionColor(new Vector3(Position.X, Position.Y + Size.Y, Position.Z), COLOR_FRONT));

                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y, Position.Z), COLOR_FRONT));
                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y + Size.Y, Position.Z), COLOR_FRONT));
                points.Add(new VertexPositionColor(new Vector3(Position.X, Position.Y + Size.Y, Position.Z), COLOR_FRONT));

                points.Add(new VertexPositionColor(Position, COLOR_LEFT));
                points.Add(new VertexPositionColor(new Vector3(Position.X, Position.Y, Position.Z + Size.Z), COLOR_LEFT));
                points.Add(new VertexPositionColor(new Vector3(Position.X, Position.Y + Size.Y, Position.Z), COLOR_LEFT));

                points.Add(new VertexPositionColor(new Vector3(Position.X, Position.Y + Size.Y, Position.Z), COLOR_LEFT));
                points.Add(new VertexPositionColor(new Vector3(Position.X, Position.Y, Position.Z + Size.Z), COLOR_LEFT));
                points.Add(new VertexPositionColor(new Vector3(Position.X, Position.Y + Size.Y, Position.Z + Size.Z), COLOR_LEFT));

                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y, Position.Z), COLOR_RIGHT));
                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y + Size.Y, Position.Z), COLOR_RIGHT));
                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y, Position.Z + Size.Z), COLOR_RIGHT));

                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y + Size.Y, Position.Z), COLOR_RIGHT));
                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y + Size.Y, Position.Z + Size.Z), COLOR_RIGHT));
                points.Add(new VertexPositionColor(new Vector3(Position.X + Size.X, Position.Y, Position.Z + Size.Z), COLOR_RIGHT));

                context.AddPoints(points);
            }
        }
    }
}
