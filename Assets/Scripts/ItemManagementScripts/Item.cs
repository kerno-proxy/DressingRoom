using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Item
{
    public enum slotType { Helm = 0, Head = 1, Face = 2, Torso = 3, Armor = 4, Legs = 5, Weapon = 6, Shield = 7, Empty = 8 };
    public slotType slot;
    public Sprite itemPic;
    public string itemName;
    public bool isObtained = false;


   public Item(string itemName, Sprite itemPic, slotType slot, bool isObtained)
    {
        this.itemName = itemName;
        this.itemPic = itemPic;
        this.slot = slot;
        this.isObtained = isObtained;
    }
}
