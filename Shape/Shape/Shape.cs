using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shape
{
    public partial class Grid
    {
        public abstract class Shape
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
            public Vector3 Position;
            public Vector3 Size;
            public Vector3 Velocity;
            public Vector3 UpdateVelocity;
            protected Vector3 Acceleration;
            public State ShapeState;
            public abstract List<Vector2> OccupiedSquares();
            public abstract void Move(float speed);
            public abstract void Update(float t);
            public abstract void Draw(GraphicsContext context);
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