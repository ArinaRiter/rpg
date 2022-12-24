using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item=>item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

    void BuildDatabase()
    {
        items = new List<Item>() {
                new Item(0, "Axe", "An axe to fight monsters.",
                new Dictionary<string, int>
                {
                    {"Power",15},
                    {"Defence",10 }
                }),
                new Item(1, "Armor", "Armor made to protect you.",
                new Dictionary<string, int>
                {
                    {"Power", 5 },
                    {"Defence",30 }
                }),
                new Item(2, "Gem", "A precious gem.",
                new Dictionary<string, int>
                {
                    {"Value", 100 }
                }),
                new Item(3, "Coins", "A bunch of coins.",
                new Dictionary<string, int>
                {
                    {"Value", 50 }
                }),
            };
    }
}
