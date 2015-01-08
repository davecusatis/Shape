using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shape
{
    public partial class Grid
    {
        private List<Shape> Shapes;

        public void Update(float t)
        {
            Vector3 initialPos;
            List<Vector2> squareTest;
            List<Vector2> compareSquareTest;
            bool earlyOut;

            foreach (var shapeBlock in Shapes)
            {
                initialPos = shapeBlock.Position;
                shapeBlock.Update(t);

                if (shapeBlock.ShapeState == Shape.State.Moving)
                {
                    earlyOut = false;
                    squareTest = shapeBlock.OccupiedSquares();
                    foreach (var compareShape in Shapes)
                    {
                        if (compareShape != shapeBlock)
                        {
                            compareSquareTest = compareShape.OccupiedSquares();
                            foreach (var firstSquare in squareTest)
                            {
                                foreach (var secondSquare in compareSquareTest)
                                {
                                    if (firstSquare == secondSquare)
                                    {
                                        shapeBlock.Stop();
                                        shapeBlock.Position = new Vector3((int)initialPos.X, 0, (int)initialPos.Y);
                                        earlyOut = true;
                                    }
                                    if (earlyOut) break;
                                }
                                if (earlyOut) break;
                            }
                        }
                        if (earlyOut) break;
                    }
                }
            }
        }
        public bool IsGrounded(Vector3 pos, ref Shape groundingShape)
        {
            foreach (var compareShape in Shapes)
            {
                if((pos.X >= compareShape.Position.X) && 
                   (pos.Z >= compareShape.Position.Z) &&
                   (pos.X < (compareShape.Position.X + compareShape.Size.X)) &&
                   (pos.Z < (compareShape.Position.Z + compareShape.Size.Z)))
                {
                    groundingShape = compareShape;
                    return true;
                }
            }
            return false;
        }
        public void AddShape(Shape s)
        {
            Shapes.Add(s);
        }
        public void Clear()
        {
            Shapes.Clear();
        }
        public void Draw(GraphicsContext context)
        {
            
            foreach (var shapeBlock in Shapes)
            {
                shapeBlock.Draw(context);
            }
        }
    }
}
