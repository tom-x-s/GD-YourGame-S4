using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController3D : MonoBehaviour
{
    public KeyCode keyToPress;

    [SerializeField]
    private Material defaultMaterial;

    [SerializeField]
    private Material pressedMaterial;

    private MeshRenderer theSR;

    [SerializeField]
    private bool canBePressed;

    private GameObject nootObject;

    private GameObject hitbox;
    private ParticleSystem emitter;

    private float spamTime;
    private bool spamAvailable;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<MeshRenderer>();
        spamAvailable = true;
        emitter = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            theSR.material = pressedMaterial;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            theSR.material = defaultMaterial;
        }

        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                nootObject.SetActive(false);

                canBePressed = false;

                GameManager.instance.NoteHit();
                emitter.Play();
            }
            else if (!canBePressed && spamAvailable)
            {
                spamAvailable = false;
                spamTime = Time.time;
                GameManager.instance.HitNothing();
            }
        }

        if (spamTime <= Time.time - 0.5)
        {
            spamAvailable = true;
        }

        if (nootObject != null)
        {
            if (nootObject.activeSelf == false)
            {
                canBePressed = false;
            }
        }
    }

    private void OnTriggerStay(Collider noot)
    {
        if (noot.tag == "Song-notes")
        {
            canBePressed = true;
            nootObject = noot.gameObject;
        }
    }

    private void OnTriggerExit(Collider noot)
    {
        if (noot.tag == "Song-notes")
        {
            GameManager.instance.NoteMissed();
            noot.gameObject.SetActive(false);
        }
    }
}
