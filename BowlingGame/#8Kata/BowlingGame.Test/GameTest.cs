using BowlingGame.Model;
using Xunit;

namespace BowlingGame.Test
{
    public class GameTest
    {
        public Game Game { get; set; }
        public GameTest()
        {
            Game = new Game();
        }

        [Fact]
        public void GivenGameRollWhenNoPinsDownThenReturnScoreZero()
        {
            int pins = 0;
            int rolls = 20;

            RollMany(rolls, pins);

            int result = Game.score();
            Assert.Equal(0, result);
        }

        [Fact]
        public void GivenGameRollWhenAllRollsHitOnePinThenReturnScoreTwenty()
        {
            int pins = 1;
            int rolls = 20;

            RollMany(rolls, pins);

            int result = Game.score();
            Assert.Equal(20, result);
        }

        [Fact]
        public void GivenGameRollWhenHitTenPinsInTwoRollThenReturnScoreWithOneBonusRoll()
        {
            SpareRoll();
            Game.roll(4);
            RollMany(17, 0);

            int result = Game.score();
            Assert.Equal(18, result);
        }

        [Fact]
        public void GivenGameRollWhenHitTenPinsInOneRollThenReturnScoreWithTwoBonusRoll()
        {
            StrikeRoll();
            Game.roll(4);
            Game.roll(4);
            RollMany(17, 0);

            int result = Game.score();
            Assert.Equal(26, result);
        }

        [Fact]
        public void GivenGameRollWhenHitTenPinsInAllRollsThenReturnMaximumScore()
        {
            RollMany(12, 10);

            int result = Game.score();
            Assert.Equal(300, result);
        }

        private void StrikeRoll()
        {
            Game.roll(10);
        }

        private void SpareRoll()
        {
            Game.roll(5);
            Game.roll(5);
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                Game.roll(pins);
            }
        }
    }
}
