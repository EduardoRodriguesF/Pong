using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Models {
    class Player : Entity {
        private KeyboardState ks;

        public Player(int x, int y) {
            Position = new Vector2(x, y);
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, 24, 96);

            Speed = 5f;
        }

        public override void Update(GameTime gameTime) {
            ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Up) && Position.Y > 8) {
                Velocity.Y = -Speed;
            } else if (ks.IsKeyDown(Keys.Down) && Position.Y < 364) {
                Velocity.Y = Speed;
            } else {
                Velocity.Y = 0;
            }

            PostUpdate(gameTime);
        }

        public override void PostUpdate(GameTime gameTime) {
            Position += Velocity;

            Hitbox.X = (int)Position.X;
            Hitbox.Y = (int)Position.Y;
        }
    }
}
