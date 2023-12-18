using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossFight
{
    public class GameCharacter
    {
        public int Health {  get; set; }
        public int Strength {  get; set; }
        public int Stamina {  get; set; }

        public int MaxHealth { get; set; }
        public int MaxStamina { get; set; }

        public GameCharacter(int health, int strength, int stamina)
        {
            Health = health;
            Strength = strength;
            Stamina = stamina;
            MaxHealth = health;
            MaxStamina = Stamina;
        }

        public void Fight(GameCharacter enemy)
        {
            if (Stamina >= 10)
            {
                DrainStamina(10);
                enemy.Health -= Strength;
            }
            else
            {
                Recharge();
            }
        }
        public void DrainStamina(int drainedStamina)
        {
            if (Stamina >= drainedStamina)
                Stamina -= drainedStamina;
            else if (Stamina < drainedStamina)
                Stamina = 0;

        }
        public void Recharge()
        {
            Stamina = MaxStamina;
        }
        public void DrinkHealthPotion()
        {
            Health = MaxHealth;
        }
        public void DrinkStaminaPotion()
        {
            Recharge();
        }
        public void DrinkStrengthPotion()
        {
            Strength += 10;
        }
    }
}
