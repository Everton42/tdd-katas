package BowlingGame;

public class Game {
    private final int[] rolls = new int[21];
    private int current = 0;

    public void roll(final int pins) {
        this.rolls[current++] = pins;
    }

    public int score() {
        int result = 0;
        int frameIndex = 0;
        for (int frame = 0; frame < 10; frame++) {

            if (isStrike(frameIndex)) {
                result += strikeScore(frameIndex);
                frameIndex++;
            } else if (isSpare(frameIndex)) {
                result += spareScore(frameIndex);
                frameIndex += 2;
            } else {
                result += rolls[frameIndex] + rolls[frameIndex + 1];
                frameIndex += 2;
            }
        }
        return result;
    }

    private int strikeScore(int frameIndex) {
        return 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
    }

    private int spareScore(int frameIndex) {
        return 10 + rolls[frameIndex + 2];
    }

    private boolean isSpare(int frameIndex) {
        return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
    }

    private boolean isStrike(int frameIndex) {
        return rolls[frameIndex] == 10;
    }
}
