using Xunit;
using BowlingGame.Model;
using System;

namespace BowlingGame.Test
{
    public class GameTest
    {
        private Game game;
        public GameTest()
        {
            game = new Game();
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 20)]
        public void ShouldReturnPinsKnockedDownWhenAllRollsWithoutBonus(int pins, int expect)
        {
            RollMany(20, pins);

            var result = game.Score();

            Assert.Equal(expect , result);
        }

        [Fact]
        public void ShouldReturnPinsKnockedDownWithNextRollBonusWhenSpareRollHappened()
        {
            Spare();
            game.Roll(3);
            RollMany(17, 0);

            var result = game.Score();

            Assert.Equal(16 , result);
        }

        [Fact]
        public void ShouldReturnPinsKnockedDownWithTwoNextRollBonusWhenStrikeRollHappened()
        {
            Strike();
            game.Roll(3);
            game.Roll(3);

            RollMany(17, 0);

            var result = game.Score();

            Assert.Equal(22 , result);
        }

        [Fact]
        public void ShouldReturnMaximumScoreWhenStrikeAllRolls()
        {
            RollMany(12, 10);

            var result = game.Score();
            Assert.Equal(300, result);
        }
        private void Strike()
        {
            game.Roll(10);
        }

        private void Spare()
        {
            game.Roll(5);
            game.Roll(5);
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
