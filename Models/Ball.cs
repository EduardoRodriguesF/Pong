using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Models {
    class Ball : Entity {
        public List<Entity> Entities;

        public Ball(int x, int y) {
            Position = new Vector2(x, y);
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, 16, 16);

            Speed = 3f;
            Velocity = new Vector2(-Speed, Speed);
        }

        public override void Update(GameTime gameTime) {
            if ((Velocity.Y < 0 && Position.Y <= 4) || (Velocity.Y > 0 && Position.Y >= 460)) {
                Velocity.Y *= -1;
            }

            if (Entities != null) {
                var predictHitbox = Hitbox;
                predictHitbox.X += (int)Velocity.X;
                predictHitbox.Y += (int)Velocity.Y;

                foreach (Entity e in Entities) {
                    if (predictHitbox.Intersects(e.Hitbox)) {
                        Velocity.X *= -1;

                        if (predictHitbox.Y - 48 < e.Hitbox.Y) {
                            Velocity.Y = -Speed;
                        } else {
                            Velocity.Y = Speed;
                        }
                    }
                }
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
