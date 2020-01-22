
class Game(object):
    def __init__(self):
        self._rolls = []

    def roll(self, pins):
        self._rolls.append(pins)

    def score(self):
        result = 0
        roll_index = 0

        for i in range(10):
            if (self.is_strike(roll_index)):
                result += self.strike_score(roll_index)
                roll_index += 1
            elif(self.is_spare(roll_index)):
                result += self.spare_score(roll_index)
                roll_index += 2
            else:
                result += self.without_bonus_score(roll_index)
                roll_index += 2
        return result

    def is_spare(self, roll_index):
        return self._rolls[roll_index] + self._rolls[roll_index + 1] == 10

    def is_strike(self, roll_index):
        return self._rolls[roll_index] == 10

    def without_bonus_score(self, roll_index):
        return self._rolls[roll_index] + self._rolls[roll_index + 1]
    
    def spare_score(self, roll_index):
        return 10 + self._rolls[roll_index + 2]
    
    def strike_score(self, roll_index):
        return 10 + self._rolls[roll_index + 1] + self._rolls[roll_index + 2]

