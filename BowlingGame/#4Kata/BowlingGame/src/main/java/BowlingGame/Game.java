package BowlingGame;

/**
 * Hello world!
 *
 */
public class Game {
    private final int[] rolls = new int[21];
    private int current = 0;

    public void roll(final int pins) {
        this.rolls[current++] = pins;
    }

    public int score() {
        int score = 0;
        int frameIndex = 0;
        for (int frame = 0; frame < 10; frame++) {
            if (rolls[frameIndex] + rolls[frameIndex + 1] == 10) {
                score += 10 + rolls[frameIndex + 2];
                frameIndex+=2;
            }
            else{
                score += rolls[frameIndex] + rolls[frameIndex + 1];
                frameIndex+=2;
            }
        }
        return score;
    }
}