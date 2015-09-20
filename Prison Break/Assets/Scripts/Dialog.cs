using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Dialog
    {
        List<string> texts = new List<string>();
        public int currentIndex = 0;
        public DisplayStringState State = DisplayStringState.Pause;
        public Vector2 Position = new Vector2(0,0);
        public DialogType Type = DialogType.Normal;
        internal bool IsFinal = false;

        public void Init(params string[] items)
        {
            foreach (var item in items)
            {
                texts.Add(item);
            }
        }

        public void InitPara(string para)
        {
            var list = GetNextChars(para, 40);
            foreach (var item in list)
            {
                texts.Add(item);
            }
        }

        IEnumerable<string> GetNextChars(string str, int iterateCount)
        {
            var words = new List<string>();

            for (int i = 0; i < str.Length; i += iterateCount)
                if (str.Length - i >= iterateCount) words.Add(str.Substring(i, iterateCount));
                else words.Add(str.Substring(i, str.Length - i));

            return words;
        }

        public Dialog()
        {

        }

        public Dialog(string para)
        {
            InitPara(para);
        }

        public void PlayText(ref AutoType typer)
        {
            //typer.Stop();
            State = DisplayStringState.Running;
            typer.SetPosition(this.Position);
            typer.SetText(texts[currentIndex]);
            typer.PlayText();
        }

        public void Continue(ref AutoType typer)
        {
            
            if(State == DisplayStringState.Pause)
            {
                currentIndex++;

                if (currentIndex >= texts.Count)
                {
                    State = DisplayStringState.Ended;
                    typer.Stop();
                    return;
                }
                PlayText(ref typer);
                return;
            }
            if(State == DisplayStringState.Running)
            {
                State = DisplayStringState.Pause;
                typer.Skip();
            }
        }
    }

    public enum DialogType
    {
        Normal,
        Shocking,
        Telling,
        Thinking
    }
}
