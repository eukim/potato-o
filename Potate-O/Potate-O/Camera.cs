﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Potate_O
{
    class Camera
    {
        private Matrix transform;
        public Matrix Transform
        {
            get { return transform; }
        }

        public Vector2 center;
        private Viewport viewport;

        public Camera(Viewport newViewport)
        {
            viewport = newViewport;
        }

        public void Update(Vector2 position, int xOffset, int yOffset)
        {
            if (position.X < viewport.Width / 2)
                center.X = viewport.Width / 2;
            else if (position.X > xOffset - (viewport.Width / 2))
                center.X = xOffset - (viewport.Width / 2);
            else center.X = position.X;

            if (position.Y < viewport.Width / 2)
                center.Y = viewport.Width / 4;
            else if (position.Y > yOffset - (viewport.Height / 2))
                center.Y = yOffset - (viewport.Height / 2);
            else center.Y = position.Y;

            transform = Matrix.CreateTranslation(new Vector3(-center.X + (viewport.Width / 2),
                                                             -center.Y + (viewport.Height / 2), 0));
        }
    }
}
