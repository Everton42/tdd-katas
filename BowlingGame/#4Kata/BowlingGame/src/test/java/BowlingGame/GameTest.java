package BowlingGame;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

/**
 * Unit test for simple App.
 */
public class GameTest 
{
    private Game game = new Game();
    @Test
    public void gutterGame()
    {
        rollMany(20, 0);
        assertEquals(0, game.score());
    }

    
    @Test
    public void allOnesGame()
    {
        rollMany(20, 1);
        assertEquals(20, game.score());
    }

    @Test
    public void spareGame() {
        rollMany(2, 5);
        game.roll(3);
        rollMany(17, 0);
        assertEquals(16, game.score());
    }

    private void rollMany(int rolls, int pins) {
        for (int i = 0; i < rolls; i++) {
            game.roll(pins);
        }    
    }
}
