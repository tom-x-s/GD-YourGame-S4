using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteNumber : MonoBehaviour
{
    public void Delete()
    {
        PlayerPrefs.DeleteAll();
    }
}
