using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject3D : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    private GameObject hitbox;
    private ParticleSystem Emitter;

    void Start()
    {
        
    }

    void Update()
    {
        // check which button is pushed (for calibrating guitar hero controller)
        /*
        if (Input.anyKey)
        {
            System.Array values = System.Enum.GetValues(typeof(KeyCode));
            foreach (KeyCode code in values)
            {
                if (Input.GetKeyDown(code)) { print(System.Enum.GetName(typeof(KeyCode), code)); }
            }
        }
        */

        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                GameManager.instance.NoteHit();
                Emitter.Play();
            }
            //else if (!canBePressed) //First note is always missed for some reason. Update: ALL notes pretty much always hit and miss.
            //{
            //    GameManager.instance.NoteMissed();
            //}
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        hitbox = other.gameObject;
        Emitter = hitbox.GetComponentInChildren<ParticleSystem>();

        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;

            GameManager.instance.NoteMissed();

            gameObject.SetActive(false);

        }
    }
}
