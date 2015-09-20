using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

    public int slotsX, slotsY;
    public GUISkin skin;
    public List<Item> inventory = new List<Item>();
    public List<Item> slots = new List<Item>();
    private bool showInventory;
    private Items database;

    private bool isItemDragging;
    private Item draggedItem;
    private int prevIndex;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < (slotsX * slotsY); ++i)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }
        database = GameObject.FindGameObjectWithTag("Items").GetComponent<Items>();
        showInventory = false;

        GameInit.Context.inventory = this;
    }

    void Update()
    {

    }

    void OnGUI()
    {
        GUI.skin = skin;
        if (showInventory)
        {
            DrawInventory();
        }
        
        if (isItemDragging)
        {
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), draggedItem.itemIcon);
        }
    }

    void DrawInventory()
    {
        Event e = Event.current;
        int i = 0;
        for (int x = 0; x < slotsX; ++x)
        {
            for (int y = 0; y < slotsY; ++y)
            {
                Rect slotRect = new Rect(x * 55, y * 55, 50, 50);
                GUI.Box(slotRect, "", skin.GetStyle("Slot"));
                slots[i] = inventory[i];
                if (slots[i].itemName != null)
                {
                    GUI.DrawTexture(slotRect, slots[i].itemIcon);
                    if (slotRect.Contains(e.mousePosition))
                    {
                        if (e.button == 0 && e.type == EventType.mouseDrag && !isItemDragging)
                        {
                            isItemDragging = true;
                            prevIndex = i;
                            draggedItem = slots[i];
                            inventory[i] = new Item();
                        }
                        if (e.type == EventType.mouseUp && isItemDragging)
                        {
                            inventory[prevIndex] = inventory[i];
                            inventory[i] = draggedItem;
                            isItemDragging = false;
                            draggedItem = null;
                        }
                    } 
                    
                } else
                {
                    if (slotRect.Contains(e.mousePosition))
                    {
                        if (e.type == EventType.mouseUp && isItemDragging)
                        {
                            inventory[i] = draggedItem;
                            isItemDragging = false;
                            draggedItem = null;
                        }
                    }
                }

                i++;
            }
        }
    }

    public void AddItem(int id)
    {
        for (int i = 0; i < inventory.Count; ++i)
        {
            if (inventory[i].itemName == null)
            {
                for (int j = 0; j < database.itemsList.Count; ++j)
                {
                    if (database.itemsList[j].itemId == id)
                    {
                        inventory[i] = database.itemsList[j];
                    }
                }
                break;
            }
        }
    }

    public void RemoveItem(int id)
    {
        for (int i = 0; i < inventory.Count; ++i)
        {
            if(inventory[i].itemId == id)
            {
                inventory[i] = new Item();
                break;
            }
        }
    }

    bool InventoryContains(int id)
    {
        bool result = false;
        for (int i = 0; i < inventory.Count; ++i)
        {
            result = inventory[i].itemId == id;
            if (result)
            {
                break;
            }
        }
        return result;
    }
}
