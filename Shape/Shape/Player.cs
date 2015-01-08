﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shape
{
    class Player
    {
        public Player()
        {
            Position = new Vector3(0, 0, 0);
            Velocity = new Vector3(0, 0, 0);
        }
        public void Update(float t)
        {
            Velocity += Acceleration * t;
            Position += (Velocity + FloorVelocity) * t;
            Acceleration = new Vector3(0, 0, 0);
        }
        public void Draw()
        {

        }

        public Texture2D image;
        public Texture2D shadow;
        public Vector3 Position;
        public Vector3 Velocity;
        public Vector3 Acceleration;
        public Vector3 FloorVelocity;

    }
}
