import random

class Character:
    def __init__(self, name, hp, skills):
        self.name = name
        self.hp = hp
        self.skills = skills
        self.status = {}
    def is_alive(self):
        return self.hp > 0
    def apply_status(self):
       if "burn" in self.status:
           burn_dmg = 5
           self.hp -= burn_dmg
           print(f"{self.name} is burned")
           self.status["burn"] -= 1
           if self.status["burn"] <= 0:
               del self.status["burn"]
               print(f"no longer burned")

def enemy_ai(enemy, player):
    best_skill= None
    best_score= -999

    for skill in enemy.skills:
        score = 0
        if skill.power < 0 :
            if enemy.hp <= 40:
                score += 50
            else:
                continue
        elif skill.power > 0:
            score += skill.power * skill.accuracy

            if player.hp <= skill.power:
                score += 100
            
            if skill.effect:
                if skill.effect not in player.status:
                    score += skill.effect_chance* 30
                else:
                    score -= 10

            score += random.randint(-5,5)
            if score > best_score:
                best_score = score
                best_skill = skill