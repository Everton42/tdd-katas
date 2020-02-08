using System;

namespace BowlingGame.Model
{
    public class Game
    {
        private int current = 0;
        private int[] rolls = new int[21];

        public void Roll(int pins)
        {
            rolls[current++] += pins;
        }

        public int Score()
        {
            int result = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex)){
                    result += StrikeBonus(frameIndex);
                    frameIndex++;
                    continue;
                }
                if (IsSpare(frameIndex))
                    result += SpareBonus(frameIndex);
                else
                    result += rolls[frameIndex] + rolls[frameIndex + 1];
                frameIndex += 2;
            }
            return result;
        }

        private int SpareBonus(int frameIndex)
        {
            return 10 + rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private bool IsSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }

        private bool IsStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }
    }
}
