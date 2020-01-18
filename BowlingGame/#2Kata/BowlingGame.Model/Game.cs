using System;
using System.Collections.Generic;

namespace BowlingGame.Model
{
    public class Game
    {
        public int CurrentRoll { get; private set; }
        public int[] Rolls = new int[21];

        public void Roll(int pins)
        {
            Rolls[CurrentRoll++] = pins;
        }

        public int GetScore()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (isStrike(frameIndex))
                {
                    score += 10 + Rolls[frameIndex + 1] + Rolls[frameIndex + 2];
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + Rolls[frameIndex + 2];
                    frameIndex += 2;
                }
                else
                {
                    score += Rolls[frameIndex] + Rolls[frameIndex + 1];
                    frameIndex += 2;
                }
            }
            return score;
        }

        private bool isStrike(int frameIndex)
        {
            return Rolls[frameIndex] == 10;
        }

        public Boolean IsSpare(int frameIndex)
        {
            return Rolls[frameIndex] + Rolls[frameIndex + 1] == 10;
        }
    }
}