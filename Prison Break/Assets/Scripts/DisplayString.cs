using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class DisplayString
    {
        List<string> texts = new List<string>();
        public int currentIndex = 0;
        public DisplayStringState State = DisplayStringState.Pause;

        public bool IsFinal = false;

        public void Init(params string[] items)
        {
            foreach (var item in items)
            {
                texts.Add(item);
            }
        }

        public void InitPara(string para)
        {
            var list = GetNextChars(para, 97);
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

        public void PlayText(ref AutoType typer)
        {
            //typer.Stop();
            State = DisplayStringState.Running;
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

    public enum DisplayStringState
    {
        Running,
        Ended,
        Pause
    }
}
