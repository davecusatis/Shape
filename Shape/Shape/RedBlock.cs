using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shape
{
    public partial class Grid
    {
        public class RedBlock : Shape
        {
            private static Color COLOR_TOP = new Color(1, 0, 0);
            private static Color COLOR_LEFT = new Color(0.5f, 0, 0);
            private static Color COLOR_RIGHT = new Color(0.5f, 0, 0);
            private static Color COLOR_FRONT = new Color(0.75f, 0, 0);

            public override List<Vector2> OccupiedSquares()
            {
                int x;
                int z;
                List<Vector2> ret;
                ret = new List<Vector2>();
                for (x = (int)Position.X; x <= (int)(Position.X + Size.X); x++)
                {
                    for (z = (int)Position.Z; x <= (int)(Position.Z + Size.Z); z++)
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
                Acceleration = new Vector3(speed, 0, 0);
                ShapeState = State.Moving;
            }
            public override void Draw(GraphicsContext context)
            {
                //
            }
        }
    }
}
