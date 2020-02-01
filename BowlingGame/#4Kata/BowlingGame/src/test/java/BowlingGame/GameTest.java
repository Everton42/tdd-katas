package BowlingGame;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

public class GameTest {
    private Game game = new Game();

    @Test
    public void gutterGame() {
        rollMany(20, 0);
        assertEquals(0, game.score());
    }

    @Test
    public void allOnesGame() {
        rollMany(20, 1);
        assertEquals(20, game.score());
    }

    @Test
    public void oneSpareGame() {
        spare();
        game.roll(3);
        rollMany(17, 0);
        assertEquals(16, game.score());
    }

    @Test
    public void allSpareGame() {
        rollMany(21, 5);
        assertEquals(150, game.score());
    }

    @Test
    public void oneStrikeGame() {
        strike();
        game.roll(4);
        game.roll(4);
        rollMany(17, 0);
        assertEquals(26, game.score());
    }

    @Test
    public void perfectGame() {
        rollMany(12, 10);
        assertEquals(300, game.score());
    }

    private void strike() {
        game.roll(10);
    }

    private void spare() {
        game.roll(5);
        game.roll(5);
    }

    private void rollMany(int rolls, int pins) {
        for (int i = 0; i < rolls; i++) {
            game.roll(pins);
        }
    }
}
