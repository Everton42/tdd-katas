using System;
using BowlingGame.Model;
using Xunit;

namespace BowlingGame.Test
{
    public class GameTest
    {
        private Game game = new Game();

        [Fact]
        public void GutterGame()
        {
            rollMany(20, 0);
            Assert.Equal(0, game.Score());
        }
        [Fact]
        public void AllOneGame()
        {
            rollMany(20, 1);
            Assert.Equal(20, game.Score());
        }
        [Fact]
        public void SpareTest()
        {
            game.roll(5);
            game.roll(5);
            game.roll(3);
            rollMany(17, 0);
            Assert.Equal(16, game.Score());
        }
        [Fact]
        public void OneStrikeTest()
        {
            game.roll(10);
            game.roll(4);
            game.roll(4);
            rollMany(17, 0);
            Assert.Equal(26, game.Score());
        }
        [Fact]
        public void PerfectGame()
        {
            rollMany(20, 10);
            Assert.Equal(300, game.Score());
        }

        private void rollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.roll(pins);
            }
        }
    }
}
