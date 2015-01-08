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
            List<Vector2> OccupiedSquare();
            List<Vector2> NextSquares();
        }
    }
}