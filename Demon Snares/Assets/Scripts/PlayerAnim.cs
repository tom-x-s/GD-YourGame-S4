using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnim;

    void Update()
    {
        if (playerAnim)
        {
            if (Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d") || Input.GetKeyDown("f") || 
                Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button3))
            {
                playerAnim.SetBool("HittingNote", true);
            }
            else
            {
                playerAnim.SetBool("HittingNote", false);
            }
        }
    }
}
