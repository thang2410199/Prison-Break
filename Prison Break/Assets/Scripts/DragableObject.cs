using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.EventSystems;
using UnityEngine;

namespace Assets.Scripts
{
    public class DragableObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        void Start()
        {
            //Store init position / seed random position
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("OnDrag");
            this.transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("OnEndDrag");
        }
    }
}
