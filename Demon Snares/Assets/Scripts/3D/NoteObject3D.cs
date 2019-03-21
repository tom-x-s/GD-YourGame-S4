using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject3D : MonoBehaviour
{
    private bool canBePressed;

    public KeyCode keyToPress;

    private GameObject hitbox;
    private ParticleSystem Emitter;

    //public float spamTime;
    //public bool spamAvailable;

    void Start()
    {
        //spamAvailable = true;
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

                canBePressed = false;

                GameManager.instance.NoteHit();
                Emitter.Play();
            }

            //if (!canBePressed && spamAvailable)
            //{
            //    spamAvailable = false;
            //    spamTime = Time.time;
            //    GameManager.instance.HitNothing();
            //}
        }

        //if (spamTime <= Time.time - 0.5)
        //{
        //    spamAvailable = true;
        //}
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
