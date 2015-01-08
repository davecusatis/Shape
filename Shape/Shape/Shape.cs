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
            public Shape()
            {
                Position = new Vector3(0, 0, 0);
                Velocity = new Vector3(0, 0, 0);
                Acceleration = new Vector3(0, 0, 0);
                ShapeState = State.Stopped;
            }
            protected static float VELOCITY_DAMP = 0.95f;
            protected static float MIN_VELOCITY = 0.0001f;
            public enum State
            {
                Moving, Stopped
            }
            public Vector3 Position
            {
                public set
                { 
                    Position = value;
                    Stop();
                }
                public get;
            }
            public Vector3 Size
            {
                public get;
                private set;
            }
            protected Vector3 Velocity
            {
                public get;
                private set;
            }
            protected Vector3 Acceleration;
            public State ShapeState
            {
                public get;
                protected set;
            }

            public List<Vector2> OccupiedSquares();
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
                ShapeState = State.Stopped;
            }

        }
    }
}