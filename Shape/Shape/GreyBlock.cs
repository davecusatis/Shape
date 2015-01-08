using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shape
{
    public partial class Grid
    {
        public class GreyBlock : Shape
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
            
            public void Draw()
            {
                //
            }
        }
    }
}
