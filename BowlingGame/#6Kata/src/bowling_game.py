class Game():
    def __init__(self):
        self._rolls = []

    def roll(self, pins):
        self._rolls.append(pins)

    def score(self):
        frame_index = 0
        result = 0
        for frame in range(10):
            if self.is_strike(frame_index):
                result += self.strike_score(frame_index)
                frame_index += 1
            elif self.is_spare(frame_index):
                result += self.spare_score(frame_index)
                frame_index += 2
            else:
                result += self.commum_score(frame_index)
                frame_index += 2

        return result

    def is_strike(self, frame_index):
        return self._rolls[frame_index] == 10

    def is_spare(self, frame_index):
        return self._rolls[frame_index] + self._rolls[frame_index + 1] == 10

    def strike_score(self, frame_index):
        return 10 + self._rolls[frame_index + 1] + self._rolls[frame_index + 2]

    def spare_score(self, frame_index):
        return 10 + self._rolls[frame_index + 2]

    def commum_score(self, frame_index):
        return self._rolls[frame_index] + self._rolls[frame_index + 1]
