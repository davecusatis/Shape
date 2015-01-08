using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shape
{
    public partial class Grid
    {
        interface IShape
        {
            enum State
            {
                Moving, Stopped
            }
            enum Direction
            {
                Positive, Negative
            }

            Vector3 Position;
            Vector2 Size;
            Vector3 Velocity;
            Vector3 Acceleration ;
            State ShapeState;
            Direction ShapeDirection;

            List<Vector2> OccupiedSquare();
            List<Vector2> NextSquares();
        }
    }
}