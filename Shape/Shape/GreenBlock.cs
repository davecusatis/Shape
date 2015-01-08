﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shape
{
    public partial class Grid
    {
        public class GreenBlock : Shape
        {
            public List<Vector2> OccupiedSquares()
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
            public void Update(float t)
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
            public void Move(float speed)
            {
                Acceleration = new Vector3(0, 0, speed);
                ShapeState = State.Moving;
            }
            public void Draw()
            {
                //
            }
        }
    }
}
