using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Collectible : MonoBehaviour {

    //public List<Item> collectibleItems = new List<Item>();

    //void OnCollisionEnter2D(Collision2D col)
    //{
    //    if(col.gameObject.tag == "Player")
    //    {
    //        Destroy(this.gameObject);
    //        Debug.Log("collided");
    //    }

    //}
    public int Id;

    void OnMouseDown()
    {
        Debug.Log("clicked");
        Destroy(this.gameObject);
        {
            if (Id == 3)
                Application.LoadLevel("Backyard_Scene");
        }
        if(GameInit.Context.inventory != null)
            GameInit.Context.inventory.AddItem(this.Id);

    }
}
