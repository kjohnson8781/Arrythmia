using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer spriteRend;
    public Sprite defaultImg;
    public Sprite pressedImg;

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
     spriteRend = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
   //   if(Input.GetKeyDown(keyToPress))
   //   {
   //      spriteRend.sprite = pressedImg;
   //   }
   //   if(Input.GetKeyUp(keyToPress))
   //   {
   //      spriteRend.sprite = defaultImg;
   //   }
    }
}
