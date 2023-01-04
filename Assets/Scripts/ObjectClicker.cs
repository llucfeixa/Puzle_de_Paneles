using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    public Sprite Crate1;
    public Sprite Crate2;

    void OnMouseDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x > 4.5)
        {
            if (gameObject.GetComponent<SpriteRenderer>().sprite == Crate1)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Crate2;
            }
            else if (gameObject.GetComponent<SpriteRenderer>().sprite == Crate2)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Crate1;
            }
        }
    }
}