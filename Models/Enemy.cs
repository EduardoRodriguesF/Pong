using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Models {
    class Enemy : Entity {
        public Ball ball;

        public Enemy(int x, int y) {
            Position = new Vector2(x, y);
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, 24, 96);

            Speed = 2.5f;
        }

        public override void Update(GameTime gameTime) {
            if (ball != null && ball.Velocity.X > 0) {
                if (ball.Hitbox.Y > Hitbox.Y + Hitbox.Height/2) {
                    Velocity.Y = Speed;
                } else if (ball.Hitbox.Y < Hitbox.Y + Hitbox.Height / 2) {
                    Velocity.Y = -Speed;
                } else {
                    Velocity.Y = 0;
                }
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
