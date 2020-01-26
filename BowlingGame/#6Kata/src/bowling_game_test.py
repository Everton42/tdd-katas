import unittest
from bowling_game import Game


class game_test(unittest.TestCase):
    def setUp(self):
        self._game = Game()

    def test_given_gutter_game_must_return_score_zero(self):
        rolls = 20
        pins = 0

        self.roll_many(rolls, pins)
        result = self._game.score()

        self.assertEqual(0, result)

    def test_given_all_ones_rolls_must_return_score_twenty(self):
        rolls = 20
        pins = 1

        self.roll_many(rolls, pins)
        result = self._game.score()

        self.assertEqual(20, result)

    def test_given_spare_roll_must_return_score_with_one_bonus_roll(self):
        self.spare_roll()
        self._game.roll(7)
        self.roll_many(17, 0)

        result = self._game.score()

        self.assertEqual(24, result)

    def test_given_strike_roll_must_return_score_with_two_bonus_roll(self):
        self._game.roll(10)
        self._game.roll(5)
        self._game.roll(3)
        self.roll_many(17, 0)

        result = self._game.score()

        self.assertEqual(26, result)

    def test_given_perfect_game_must_return_three_hundred(self):
        self.roll_many(20, 10)

        result = self._game.score()

        self.assertEqual(300, result)

    def roll_many(self, rolls, pins):
        for r in range(rolls):
            self._game.roll(pins)

    def spare_roll(self):
        self._game.roll(5)
        self._game.roll(5)