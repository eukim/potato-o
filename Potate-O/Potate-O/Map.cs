﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Potate_O
{
    class Map
    {
        public List<CollisionTiles> collisionTiles = new List<CollisionTiles>();

        public List<CollisionTiles> CollisionTiles
        {
            get { return collisionTiles; }
        }

        private int width, height;
        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public Map() { }

        public void Generate(int[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];

                    if (number > 0)
                        collisionTiles.Add(new CollisionTiles(number, new Rectangle(x * size, y * size, size, size)));

                    width = (x + 1) * size;
                    height = (y + 1) * size;
                }
        }
        public void Dispose()
        {
            foreach (CollisionTiles tile in collisionTiles)
            {
                tile.rectangle.Width = 0;
                tile.rectangle.Height = 0;
                tile.rectangle.X = 100000;
                tile.rectangle.Y = 100000;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollisionTiles tile in collisionTiles)
                tile.Draw(spriteBatch);
        }
    }
}
