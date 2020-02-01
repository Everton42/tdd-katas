import org.junit.Assert;
import org.junit.Test;

public class GameTest {
    private Game game = new Game();

    @Test
    public void gutterGameShouldReturnZero() {
        int pins = 0;
        int rolls = 20;

        rollMany(rolls, pins);

        int result = game.score();
        Assert.assertEquals(0, result);
    }
    
    @Test
    public void allOnesShouldReturnTwenty() {
        int pins = 1;
        int rolls = 20;
        
        rollMany(rolls, pins);
        
        int result = game.score();
        Assert.assertEquals(20, result);
    }
    @Test
    public void spareGameShouldReturnOneBonusRoll() {
        spareRoll();
        game.roll(4);
        rollMany(17, 0);

        int result = game.score();
        Assert.assertEquals(18, result);
    }
    
    @Test
    public void strikeGameShouldReturnTwoBonusRoll() {
        strikeRoll();
        game.roll(5);
        game.roll(4);
        rollMany(17, 0);
        
        int result = game.score();
        Assert.assertEquals(28, result);
    }

    @Test
    public void perfectGameShouldReturnThreeHundred() {
        rollMany(12, 10);
        
        int result = game.score();
        Assert.assertEquals(300, result);
    }

    private void rollMany(int rolls, int pins) {
        for (int i = 0; i < rolls; i++) {
            game.roll(pins);
        } 
    }
    
    private void spareRoll() {
        game.roll(5);
        game.roll(5);
    }

    private void strikeRoll() {
        game.roll(10);
    }
}