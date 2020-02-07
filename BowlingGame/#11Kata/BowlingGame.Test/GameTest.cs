using Xunit;
using BowlingGame.Model;
using System;

namespace BowlingGame.Test
{
    public class GameTest
    {
        Game game;

        public GameTest()
        {
            game = new Game();
        }

        [Theory]
        [InlineData(20, 0, 0)]
        [InlineData(20, 1, 20)]
        public void ShouldReturnScoreWithoutBonusRollWhenRemainPinsInAllRolls(int rolls, int pins, int expect)
        {
            RollMany(rolls, pins);

            var result = game.Score();

            Assert.Equal(expect, result);
        }

        [Fact]
        public void ShouldReturnScoreWithOneBonusRollWhen10KnockedDownInTwoRolls()
        {
            Spare();
            game.Roll(4);

            RollMany(17, 0);

            var result = game.Score();
            Assert.Equal(18, result);
        }


        [Fact]
        public void ShouldReturnScoreWithTwoBonusRollWhen10KnockedDownInOneRolls()
        {
            Strike();
            game.Roll(3);
            game.Roll(5);
            RollMany(17, 0);

            var result = game.Score();
            Assert.Equal(26, result);
        }

        [Fact]
        public void ShouldReturn300WhenStrikeAllRolls()
        {
            RollMany(12, 10);

            var result = game.Score();
            Assert.Equal(300, result);
        }
        private void Spare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        private void Strike()
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
    }
}
