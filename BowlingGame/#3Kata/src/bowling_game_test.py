import unittest
from bowling_game import Game


class TestGame(unittest.TestCase):
    def setUp(self):
        self._game = Game()

    def test_gutter(self):
        self.roll_many(20, 0)
        self.assertEqual(0, self._game.score())

    def test_all_one(self):
        self.roll_many(20, 1)
        self.assertEqual(20, self._game.score())

    def test_one_spare(self):
        self.spare_roll()
        self._game.roll(3)
        self.roll_many(17, 0)
        self.assertEqual(16, self._game.score())
    
    def test_one_strike(self):
        self.strike_roll()
        self._game.roll(3)
        self._game.roll(5)
        self.roll_many(17, 0)
        self.assertEqual(26, self._game.score())

    def test_perfect_game(self):
        self.roll_many(12, 10)
        self.assertEqual(300, self._game.score())

    def test_all_spare_game(self):
        self.roll_many(21, 5)
        self.assertEqual(150, self._game.score())

    def roll_many(self, rolls, pins):
        for i in range(rolls):
            self._game.roll(pins)

    def spare_roll(self):
        self.roll_many(2,5)
    
    def strike_roll(self):
        self.roll_many(1,10)