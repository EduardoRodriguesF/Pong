using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Managers {
    class GameManager {
        private Texture2D texture;
        private Player player;
        private Enemy enemy;
        private Ball ball;
        private GraphicsDeviceManager graphics;

        public GameManager(GraphicsDeviceManager _graphics) {
            player = new Player(16, 16);
            enemy = new Enemy(_graphics.PreferredBackBufferWidth - 32, 16);
            ball = new Ball(500, 100);
            enemy.ball = ball;

            ball.Entities = new List<Entity>();
            ball.Entities.Add(player);
            ball.Entities.Add(enemy);

            graphics = _graphics;

            texture = new Texture2D(graphics.GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.White });
        }

        public void Update(GameTime gameTime) {
            player.Update(gameTime);
            enemy.Update(gameTime);
            ball.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, player.Hitbox, Color.White);
            spriteBatch.Draw(texture, enemy.Hitbox, Color.White);
            spriteBatch.Draw(texture, ball.Hitbox, Color.White);
        }
    }
}
