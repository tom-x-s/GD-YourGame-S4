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

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<MeshRenderer>();
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
    }
}
