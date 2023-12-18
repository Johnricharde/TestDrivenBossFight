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
        public int MaxStamina { get; set; }
        public GameCharacter(int health, int strength, int stamina)
        {
            Health = health;
            Strength = strength;
            Stamina = stamina;
            MaxStamina = Stamina;
        }

        public void Fight(GameCharacter enemy)
        {
            if (Stamina >= 10)
            {
                DrainStamina(10);
                enemy.Health -= 20;
            }
            else
            {
                Recharge();
            }
        }
        public void Fight(GameCharacter enemy, int damage)
        {
            if (Stamina >= 10)
            {
                enemy.DrainStamina(10);
                enemy.Health -= damage;
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
    }
}
