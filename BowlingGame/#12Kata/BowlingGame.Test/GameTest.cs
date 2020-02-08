using System;
using BowlingGame.Model;
using Xunit;

namespace BowlingGame.Test
{
    public class GameTest
    {
        private Game _game;

        public GameTest(){
            _game = new Game();
        }

        [Theory]
        [InlineData (0 , 20, 0)]
        [InlineData (1 , 20, 20)]
        public void WhenNoBonusRollsThenPinsKnockedDown(int pins, int rolls, int expected)
        {
            RollMany(pins, rolls);
            var result = _game.Score();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void WhenSpareGameThenPinsKnockedDownWithNextBonusRoll()
        {
            Spare();
            _game.Roll(3);

            RollMany(0, 17);
            
            var result = _game.Score();
            Assert.Equal(16, result);
        }

        [Fact]
        public void WhenStrikeGameThenPinsKnockedDownWithTwoNextBonusRoll()
        {
            Strike();
            _game.Roll(3);
            _game.Roll(4);
            RollMany(0, 17);
            
            var result = _game.Score();
            Assert.Equal(24, result);
        }

        [Fact]
        public void WhenPerfectGameThen300()
        {
            RollMany(10, 12);
            
            var result = _game.Score();
            Assert.Equal(300, result);
        }

        private void RollMany(int pins, int rolls)
        {
            for (int i = 0; i < rolls; i++)
            {
                _game.Roll(pins);
            }
        }

        private void Strike()
        {
            _game.Roll(10);
        }

        private void Spare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }
    }
}
