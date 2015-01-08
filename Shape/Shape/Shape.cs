using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shape
{
    public partial class Grid
    {
        class Shape
        {
            protected static float VELOCITY_DAMP = 0.95f;
            public enum State
            {
                Moving, Stopped
            }
            public enum Direction
            {
                Positive, Negative
            }

            protected Vector3 Position
            {
                public set
                { 
                    Position = value;
                    Stop();
                }
                public get;
            }
            protected Vector3 Size;
            protected Vector3 Velocity
            {
                public get;
                private set;
            }
            protected Vector3 Acceleration;
            protected State ShapeState;
            protected Direction ShapeDirection;

            public List<Vector2> OccupiedSquares();
            public List<Vector2> NextSquares();
            public void Move(float speed) { }
            public void Update(float t) { }
            public void Draw();
            public bool OccupiesSquare(Vector2 checkSquare)
            {
                List<Vector2> curSquares;
                curSquares = OccupiedSquares();
                foreach (var square in curSquares)
                {
                    if (square == checkSquare) return true;
                }
                return false;
            }
            public void Stop()
            {
                Velocity = new Vector3(0, 0, 0);
                Acceleration = new Vector3(0, 0, 0);
            }

        }
    }
}