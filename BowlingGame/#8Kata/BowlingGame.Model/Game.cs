namespace BowlingGame.Model
{
    public class Game
    {
        private int[] Rolls = new int[21];
        private int Current = 0;

        public int Score { get; set; }
        public void roll(int pins)
        {
            Rolls[Current++] += pins;
        }

        public int score()
        {
            int result = 0;
            int frameIndex = 0;

            for (int frame = 0; frame < 10; frame++)
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
                    result += CommonScore(frameIndex);
                    frameIndex += 2;
                }
            }

            return result;
        }

        private int CommonScore(int frameIndex)
        {
            return Rolls[frameIndex] + Rolls[frameIndex + 1];
        }

        private int SpareScore(int frameIndex)
        {
            return 10 + Rolls[frameIndex + 2];
        }

        private int StrikeScore(int frameIndex)
        {
            return 10 + Rolls[frameIndex + 1] + Rolls[frameIndex + 2];
        }

        private bool IsSpare(int frameIndex)
        {
            return Rolls[frameIndex] + Rolls[frameIndex + 1] == 10;
        }

        private bool IsStrike(int frameIndex)
        {
            return Rolls[frameIndex] == 10;
        }
    }
}
