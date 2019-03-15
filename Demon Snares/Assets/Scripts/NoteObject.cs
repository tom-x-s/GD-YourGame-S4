using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{

    public bool canBePressed;

    public KeyCode keyToPress;

    private GameObject HitBox;
    private ParticleSystem boem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    /*    if (Input.anyKey)
        {
            System.Array values = System.Enum.GetValues(typeof(KeyCode));
            foreach (KeyCode code in values)
            {
                if(Input.GetKeyDown(code)) { print(System.Enum.GetName(typeof(KeyCode), code)); }
            }
        } */


        if(Input.GetKeyDown(keyToPress))
        {

            if (canBePressed)
            {
                boem.Play();

                gameObject.SetActive(false);

                GameManager.instance.NoteHit();

                

            }
            //else if (!canBePressed) //First note is always missed for some reason. Update: ALL notes pretty much always hit and miss.
            //{
            //    GameManager.instance.NoteMissed();
            //}
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HitBox = other.gameObject;
        boem = HitBox.GetComponentInChildren<ParticleSystem>();
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;

            GameManager.instance.NoteMissed();

            gameObject.SetActive(false);

        }
    }
}
