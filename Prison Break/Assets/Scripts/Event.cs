using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Event
    {
        public int Id = 0;
        public string EventName = "";
        public EventState State = EventState.Pending;

        public delegate void OnStartHandler();
        public event OnStartHandler OnStart;
        
        public event OnStartHandler OnComplete;

        public void InvokeEvent()
        {
            State = EventState.Running;
            EventManager.State = GameState.InEvent;

            if (OnStart != null)
                OnStart.Invoke();
        }

        public void InvokeOnComplete()
        {
            State = EventState.Completed;
            EventManager.State = GameState.Normal;
            if (OnComplete != null)
                OnComplete.Invoke();
        }
    }

    public enum EventState
    {
        Pending,
        Running,
        Completed
    }
}
