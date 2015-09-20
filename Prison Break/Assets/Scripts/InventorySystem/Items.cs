using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Items : MonoBehaviour {

    public List<Item> itemsList = new List<Item>();

    void Start()
    {
        Item cigarret = new Item("cigarette", 0, "used as money", 0);
        itemsList.Add(cigarret);
        Item key = new Item("key", 1, "used to open doors", 0);
        itemsList.Add(key);
        Item hammer = new Item("hammer", 2, "used to hit something", 0);
        itemsList.Add(hammer);
        Item chicken = new Item("chicken", 3, "used as money", 0);
        itemsList.Add(chicken);
        Item flatfile = new Item("flatfile", 4, "used to open doors", 0);
        itemsList.Add(flatfile);
        Item socks = new Item("socks", 5, "used to hit something", 0);
        itemsList.Add(socks);  
    }
}
