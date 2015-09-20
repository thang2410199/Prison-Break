using UnityEngine;
using System.Collections;


[System.Serializable]
public class Item {
    public string itemName;
    public int itemId;
    public string itemDesc;
    public int itemQuantity;
    public Texture2D itemIcon;
    public string itemType;

    public Item (string name, int id, string desc, int quantity)
    {
        itemName = name;
        itemId = id;
        itemIcon = Resources.Load<Texture2D>("Item Icons/" + name );
        itemQuantity = quantity;
        desc = itemDesc;
        itemType = "Collectible";
    }

    public Item ()
    {

    }

}
