﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Managers {
    class GameManager {
        private Texture2D texture;
        private Player player;
        private Player enemy;
        private GraphicsDeviceManager graphics;

        public GameManager(GraphicsDeviceManager _graphics) {
            player = new Player(16, 16);
            enemy = new Player(_graphics.PreferredBackBufferWidth - 16, 16);

            graphics = _graphics;

            texture = new Texture2D(graphics.GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.White });
        }

        public void Update(GameTime gameTime) {
            player.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, player.Hitbox, Color.White);
        }
    }
}
