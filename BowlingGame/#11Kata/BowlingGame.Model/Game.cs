using System;

namespace BowlingGame.Model
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int current = 0;

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
                if (IsStrike(frameIndex))
                {
                    result += StrikeScore(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    result += SpareScore(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    result += rolls[frameIndex] + rolls[frameIndex + 1];
                    frameIndex += 2;
                }
            }
            return result;
        }

        private int SpareScore(int frameIndex)
        {
            return 10 + rolls[frameIndex + 2];
        }

        private int StrikeScore(int frameIndex)
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
