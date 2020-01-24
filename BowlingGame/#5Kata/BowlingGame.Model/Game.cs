using System;
using System.Collections.Generic;

namespace BowlingGame.Model
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int CurrentRoll = 0;

        public void roll(int pins)
        {
            rolls[CurrentRoll++] += pins;
        }

        public int Score()
        {
            int result = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (isStrike(frameIndex))
                {
                    result += StrikeScore(frameIndex);
                    frameIndex++;
                }
                else if (isSpare(frameIndex))
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

        private bool isSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }

        private int StrikeScore(int frameIndex)
        {
            return 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private bool isStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }
    }
}
