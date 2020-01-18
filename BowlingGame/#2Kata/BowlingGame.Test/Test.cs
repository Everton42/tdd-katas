using Xunit;
using BowlingGame.Model;
using System;

namespace BowlingGame.Test
{
    public class Test
    {
        private Game game = new Game();

        public Test()
        {
            game = new Game();
        }
        [Fact]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.Equal(20, game.GetScore());
        }

        [Fact]
        public void TestOneSpare()
        {
            RollSpare();
            game.Roll(3);
            RollMany(17, 0);
            Assert.Equal(16, game.GetScore());
        }
        [Fact]
        public void TestOneStrike()
        {
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            RollMany(16,0);
            Assert.Equal(24, game.GetScore());
        }
        [Fact]
        public void TestPerfectGame()
        {
            RollMany(12,10);
            Assert.Equal(300, game.GetScore());
        }

        private void RollStrike()
        {
            game.Roll(10);
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }
        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }
    }
}
