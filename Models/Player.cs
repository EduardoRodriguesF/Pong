using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Models {
    class Player : Entity {
        public Player(int x, int y) {
            Position = new Vector2(x, y);
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, 32, 128);
        }

        public override void Update(GameTime gameTime) {
            Hitbox.X = (int)Position.X;
            Hitbox.Y = (int)Position.Y;
        }
    }
}
