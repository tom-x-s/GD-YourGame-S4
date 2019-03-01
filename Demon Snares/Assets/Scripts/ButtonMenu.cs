using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMenu : MonoBehaviour
{
    public class Bouton123 : MonoBehaviour
    {
        public Button button;
        public Sprite defaultImage;
        public Sprite pressedImage;

        public KeyCode keyToPress;


        void Start()
        {

        }

        void Update()
        {
            if (Input.GetKeyDown(keyToPress))
            {
                button.GetComponent<Image>().sprite = pressedImage;
            }

            if (Input.GetKeyUp(keyToPress))
            {
                button.GetComponent<Image>().sprite = defaultImage;
            }
        }
    }
}
