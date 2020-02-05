using System;

namespace BowlingGame.Model
{
    public class Game
    {
        private int current = 0;
        private int[] rolls = new int[21];

        public void Roll(int pins)
        {
            rolls[current++] = pins;
        }

        public int Score()
        {
            int result = 0;
            int frameIndex = 0;

            for (int i = 0; i < 10; i++)
            {
                if(isStrike(frameIndex)){
                    result += StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if(isSpare(frameIndex)){
                    result += SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else{
                    result += rolls[frameIndex] + rolls[frameIndex + 1];
                    frameIndex += 2;
                }
            }
            return result;
        }

        private int StrikeBonus(int frameIndex)
        {
            return 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private bool isStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        private int SpareBonus(int frameIndex)
        {
            return 10 + rolls[frameIndex + 2];
        }

        private bool isSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }
    }
}
