using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossFight
{
    public class GamePlay
    {
        public List<Item> DroppableItems;
        public GamePlay()
        {
            DroppableItems = new List<Item>();

            for (int i = 0; i < 10; i++)
                DroppableItems.Add(new Item("Item"));
        }
        public Item GetHealthPotion()
        {
            return new Item("HealthPotion");
        }
    }
}
