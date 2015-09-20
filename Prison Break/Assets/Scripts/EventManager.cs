using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class EventManager : MonoBehaviour
    {
        public static GameState State = GameState.Normal;

        public static List<Event> Events = new List<Event>();

        public static int CurrentEventIndex = -1;

        public void InitEvents()
        {
            var introEventNarator = new Event();
            introEventNarator.EventName = "introEventNarator";
                introEventNarator.OnStart += IntroEventNarator_OnStart;
            introEventNarator.OnComplete += IntroEventNarator_OnComplete;


            var introEventTalk = new Event();
            introEventTalk.EventName = "introEventTalk";
            introEventTalk.OnStart += IntroEventTalk_OnStart;
            introEventTalk.OnComplete += IntroEventTalk_OnComplete;

            Events.Add(introEventNarator);
            Events.Add(introEventTalk);
        }

        private void IntroEventTalk_OnStart()
        {
            var dialog = new Dialog();
            dialog.InitPara("Hmm, such misfortune. Even though dying is in fact on the top of my bucket list, I believe now is not the time for such trivia event. I still haven't tasted Burger King s oreo milkshake yet .That s it then, I shall break out of this place of confinement.");
            dialog.Type = DialogType.Normal;
            dialog.IsFinal = true;
            dialog.Position = new Vector2(Screen.width - 160, 0);
            DialogBehaviourScript.AddText(dialog);
            dialog.PlayText(ref DialogBehaviourScript.StaticTyper);


        }

        private void IntroEventTalk_OnComplete()
        {
        }


        private void IntroEventNarator_OnStart()
        {
            var InitText = new DisplayString();
            InitText.InitPara("Albie Wacko, self-proclaimed Albert Einstein the second, is found guilty for spreading damaging rumours about Quantum physics revolution. Prisoner Albie Wacko is to be transferred to the Asylum immediately.");

            var page = new DisplayString();
            page.InitPara("The Asylum is closed temporarily for innovation. The jury decided that in order to cut costs, prisoner Albie Wacko is to be executed in 2 days instead. The decision is final. Effective immediately.");
            page.IsFinal = true;
            AutoTypeBehaviourScript.AddText(InitText, page);
            InitText.PlayText(ref AutoTypeBehaviourScript.StaticTyper);
        }

        private void IntroEventNarator_OnComplete()
        {
            InvokeEvent("introEventTalk");
        }

        void Update()
        {

        }

        /// <summary>
        /// Play the next pending event
        /// </summary>
        public static void InvokeNextEvent()
        {
            do
            {

                CurrentEventIndex++;
            }
            while (Events[CurrentEventIndex].State == EventState.Completed);
            Events[CurrentEventIndex].InvokeEvent();
        }

        public static bool InvokeEvent(string eventName)
        {
            var _event = Events.Where(e => e.EventName == eventName || e.State == EventState.Pending).FirstOrDefault();
            if(_event != null)
            {
                _event.InvokeEvent();
                return true;
            }
            return false;
        }

        public static bool InvokeComplete()
        {
            var _event = Events.Where(e => e.State == EventState.Running).FirstOrDefault();
            if (_event != null)
            {
                _event.InvokeOnComplete();
                return true;
            }
            return false;
        }
    }

    public enum GameState
    {
        InEvent,
        Normal
    }
}
