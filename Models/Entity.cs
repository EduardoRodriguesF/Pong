using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Models {
    abstract class Entity {
        public Rectangle Hitbox;
        protected float Speed;
        public Vector2 Velocity;

        public Vector2 Position { get; protected set; }

        public abstract void Update(GameTime gameTime);

        public abstract void PostUpdate(GameTime gameTime);
    }
}
