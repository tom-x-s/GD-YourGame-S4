using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    public Sprite originalSprite;
    public Sprite pressedSprite;

    Image myImageComponent;

    public KeyCode keyToPress;

    void Start() //Lets start by getting a reference to our image component.
    {
        myImageComponent = GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            myImageComponent.sprite = pressedSprite;
        }
        if (Input.GetKeyUp(keyToPress))
        {
            myImageComponent.sprite = originalSprite;
        }
    }
}
