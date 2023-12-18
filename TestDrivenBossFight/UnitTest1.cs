using BossFight;

namespace TestDrivenBossFightTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestValidInitialization()
        {
            var expectedHealth = 100;
            var expectedStrength = 20;
            var expectedStamina = 40;
            GameCharacter gameCharacter = new(100, 20, 40);
            Assert.Equal(expectedStrength, gameCharacter.Strength);
            Assert.Equal(expectedStamina, gameCharacter.Stamina);
            Assert.Equal(expectedHealth, gameCharacter.Health);
        }

        [Fact]
        public void TestFightTakesEnemyHealth()
        {
            GameCharacter boss = new(400, 20, 10);
            GameCharacter hero = new(100, 20, 40);
            var expectedBossHealthAfterFight = 380;
            var expectedHeroHealthAfterFight = 80;

            hero.Fight(boss);
            boss.Fight(hero);

            Assert.Equal(expectedBossHealthAfterFight, boss.Health);
            Assert.Equal(expectedHeroHealthAfterFight, hero.Health);
        }

        [Fact]
        public void TestDrainStamina()
        {
            GameCharacter hero = new(100, 20, 40);

            hero.DrainStamina(30);

            Assert.Equal(10, hero.Stamina);
        }

        [Fact]
        public void TestStaminaLossAfterFight()
        {
            GameCharacter boss = new(400, 20, 10);
            GameCharacter hero = new(100, 20, 40);

            var expectedBossStaminaAfterFight = 0;
            var expectedHeroStaminaAfterFight = 30;

            boss.Fight(hero);
            hero.Fight(boss);

            Assert.Equal(expectedBossStaminaAfterFight, boss.Stamina);
            Assert.Equal(expectedHeroStaminaAfterFight, hero.Stamina);
        }

        [Fact]
        public void TestRechargeBoss()
        {
            GameCharacter boss = new(400, 20, 10);
            GameCharacter hero = new(100, 20, 40);

            var expectedBossStaminaAfterRecharge = 10;

            boss.DrainStamina(10);
            boss.Recharge();

            Assert.Equal(expectedBossStaminaAfterRecharge, boss.Stamina);
        }

        [Fact]
        public void TestRechargeHero()
        {
            GameCharacter boss = new(400, 20, 10);
            GameCharacter hero = new(100, 20, 40);

            var expectedHeroStaminaAfterRecharge = 40;

            hero.DrainStamina(40);
            hero.Recharge();

            Assert.Equal(expectedHeroStaminaAfterRecharge, hero.Stamina);
        }

        [Fact]
        public void TestFightWithZeroStaminaRechargesHero()
        {
            GameCharacter boss = new(400, 20, 10);
            GameCharacter hero = new(100, 20, 40);

            hero.DrainStamina(40);
            hero.Fight(boss);

            var expectedHeroStaminaAfterRecharge = 40;

            Assert.Equal(expectedHeroStaminaAfterRecharge, hero.Stamina);
        }

        [Fact]
        public void TestFightTakesZeroHealthFromEnemyWhenRecharging()
        {
            GameCharacter boss = new(400, 20, 10);
            GameCharacter hero = new(100, 20, 40);

            hero.DrainStamina(40);
            var expectedHealthAfterFight = 400;

            hero.Fight(boss);

            Assert.Equal(expectedHealthAfterFight, boss.Health);
        }

        [Fact]
        public void TestFightTakesEnemyHealthWithStrenghtInput()
        {
            GameCharacter boss = new(400, 10, 10);
            GameCharacter hero = new(100, 20, 40);
            var expectedHeroHealthAfterFight = 90;

            boss.Fight(hero);

            Assert.Equal(expectedHeroHealthAfterFight, hero.Health);
        }

        [Fact]
        public void TestItemInitialization()
        {
            GamePlay gameplay = new();

            int expectedListCountAfterInit = 10;

            Assert.Equal(expectedListCountAfterInit, gameplay.DroppableItems.Count);
        }

        [Fact]
        public void TestFindHealthPotion()
        {
            GamePlay gameplay = new GamePlay();
            Item expectedItem = new Item("HealthPotion");

            Item actualItem = gameplay.GetHealthPotion();

            Assert.Equal(expectedItem.ItemName, actualItem.ItemName);
        }

        [Fact]
        public void TestDrinkPotionRestoresHealth()
        {
            GameCharacter boss = new GameCharacter(400, 20, 10);
            GameCharacter hero = new GameCharacter(100, 20, 40);

            boss.Fight(hero);
            Assert.Equal(10, hero.Health);

            hero.DrinkHealthPotion();

            Assert.Equal(100, hero.Health);
        }

        [Fact]
        public void TestFindRandomItem()
        {
            GamePlay gameplay = new GamePlay();

            Item droppedItem = gameplay.GetRandomItemToDrop();

            Assert.NotNull(droppedItem);
        }

        [Fact]
        public void TestDrinkStaminaPotionRestoresStamina()
        {
            GameCharacter hero = new GameCharacter(100, 20, 40);

            hero.DrainStamina(40);
            hero.DrinkStaminaPotion();

            Assert.Equal(40, hero.Stamina);
        }


        [Fact]
        public void TestDrinkStrengthPotionTakesAdditionalDamage()
        {
            GameCharacter hero = new GameCharacter(100, 20, 40);
            GameCharacter boss = new GameCharacter(400, 20, 10);

            hero.DrinkStrengthPotion();
            hero.Fight(boss);

            Assert.Equal(370, boss.Health);
        }
    }
}