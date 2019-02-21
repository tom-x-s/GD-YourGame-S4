using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private Rail rail;
    public PlayMode mode;

    private float speed;
    private bool isReversed;

    private int currentSeg;
    private float transition;
    private bool buttonPressed;

    private void Start()
    {
        speed = 0.05f;
    }

    private void Update()
    {
        if (!rail)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            buttonPressed = true; 
        }

        if (buttonPressed)
        {
            Play(!isReversed);
        }
        
    }

    private void Play(bool forward = true)
    {
        float s = Time.deltaTime * 1 / speed;
        transition += (forward) ? s : -s;
        
        if (transition > 1)
        {
            transition = 0;
            currentSeg++;
            if(currentSeg == rail.nodes.Length - 1)
            { 
                transition = 1;
                currentSeg = rail.nodes.Length - 2;
                isReversed = !isReversed;
            }
        }
        else if (transition <0)
        {
            transition = 1;
            currentSeg--;
            if (currentSeg == -1)
            {
                buttonPressed = false;
                isReversed = false;
                return;
            }
        }
        transform.position = rail.PositionOnRail(currentSeg, transition, mode);
        transform.rotation = rail.Orientation(currentSeg, transition);
    }
}
