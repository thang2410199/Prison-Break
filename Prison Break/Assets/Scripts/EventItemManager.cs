using System.Collections.Generic;
using UnityEngine;

public class EventItemManager : MonoBehaviour
{
    private class EventItemNumber
    {
        public EventItemNumber(int eventId, Dictionary<int, int> Items_Quantity)
        {
            this.eventId = eventId;
            this.Items_Quantity = Items_Quantity;
        }

        public int eventId { get; set; }
        public Dictionary<int, int> Items_Quantity { get; set; }
    }

    private List<EventItemNumber> eventItemNumbers;

    // Use this for initialization
    void Start()
    {
        eventItemNumbers = new List<EventItemNumber>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void addEventItemHash(int eventId, Dictionary<int, int> items_quantity)
    {
        eventItemNumbers.Add(new EventItemNumber(eventId, items_quantity));
    }

    EventItemNumber findEvent(int eventId)
    {
        return eventItemNumbers.Find(eventItemnumber => eventItemnumber.eventId == eventId);
    }

    bool compareRequirement(int eventId, Dictionary<int, int> items_quantity)
    {
        return findEvent(eventId).Items_Quantity.Comparer.Equals(items_quantity);
    }
}