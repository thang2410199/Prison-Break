using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class DragableSprite : MonoBehaviour
    {

        void Update()
        {

        }

        private Vector3 screenPoint;
        private Vector3 offset;

        void OnMouseDown()
        {
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }


        void OnMouseDrag()
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }

    }
}
