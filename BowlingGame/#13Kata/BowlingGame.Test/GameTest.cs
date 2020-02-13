using BowlingGame.Model;
using Xunit;

namespace BowlingGame.Test
{
    public class GameTest
    {
        private Game _game;

        public GameTest()
        {
            _game = new Game();
        }

        [Theory]
        [InlineData(0, 20, 0)]
        [InlineData(1, 20, 20)]
        public void ShouldScoreTotalPinsKnockedDownWhenAllRollsWithoutBonus(int pins, int rolls, int expected)
        {
            RollMany(rolls, pins);
            int result = _game.Score();
            Assert.Equal(expected, result);
            Assert.True(result == expected);
        }

        [Fact]
        public void ShouldScoreWithOneBonusRollWhenSpareRoll()
        {
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(3);

            RollMany(17, 0);
            int result = _game.Score();
            Assert.Equal(16, result);
            Assert.True(result == 16);
        }

        [Fact]
        public void ShouldScoreWithTwoBonusRollWhenStrikeRoll()
        {
            _game.Roll(10);
            _game.Roll(3);
            _game.Roll(4);

            RollMany(17, 0);

            int result = _game.Score();
            Assert.Equal(24, result);
            Assert.True(result == 24);
        }

        [Fact]
        public void ShouldScore300WhenPerfectGame()
        {
            RollMany(12, 10);

            int result = _game.Score();
            Assert.Equal(300, result);
            Assert.True(result == 300);
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                _game.Roll(pins);
            }
        }
    }
}
