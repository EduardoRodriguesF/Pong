using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        public int PlayerScores;
        public int EnemyScores;
        private SpriteFont gameFont;

        public GameManager(GraphicsDeviceManager _graphics, ContentManager content) {
            graphics = _graphics;

            texture = new Texture2D(graphics.GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.White });

            gameFont = content.Load<SpriteFont>("gameFont");

            StartGame();
        }

        public void StartGame() {
            player = new Player(16, graphics.PreferredBackBufferHeight/2 - 48);
            enemy = new Enemy(graphics.PreferredBackBufferWidth - 32, graphics.PreferredBackBufferHeight / 2 - 48);
            ball = new Ball(500, 250);
            enemy.ball = ball;

            ball.Entities = new List<Entity>();
            ball.Entities.Add(player);
            ball.Entities.Add(enemy);
        }

        public void Update(GameTime gameTime) {
            player.Update(gameTime);
            enemy.Update(gameTime);
            ball.Update(gameTime);

            if (ball.Hitbox.X < 0) {
                EnemyScores++;
                StartGame();
            } else if (ball.Hitbox.X > graphics.PreferredBackBufferWidth) {
                PlayerScores++;
                StartGame();
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, player.Hitbox, Color.White);
            spriteBatch.Draw(texture, enemy.Hitbox, Color.White);
            spriteBatch.Draw(texture, ball.Hitbox, Color.White);

            spriteBatch.DrawString(gameFont, PlayerScores.ToString(), new Vector2(100, 32), Color.White);
            spriteBatch.DrawString(gameFont, EnemyScores.ToString(), new Vector2(graphics.PreferredBackBufferWidth - 100, 32), Color.White);
        }
    }
}
