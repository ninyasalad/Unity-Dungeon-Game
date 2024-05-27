using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : Collectable
{
    public Sprite emptyChest;
    public int pesosAmount = 5;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            // ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration); Vector3.up*50, 50 means 50 pixels for screen.
            GameManager.instance.ShowText("+ " + pesosAmount + " pesos!", 25, Color.white, transform.position, Vector3.up * 25, 1.0f);
        }
        
    }
}
