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
            private const Color COLOR_TOP = new Color(1, 1, 1);
            private const Color COLOR_LEFT = new Color(0.5f, 0.5f, 0.5f);
            private const Color COLOR_RIGHT = new Color(0.5f, 0.5f, 0.5f);
            private const Color COLOR_FRONT = new Color(0.75f, 0.75f, 0.75f);

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
