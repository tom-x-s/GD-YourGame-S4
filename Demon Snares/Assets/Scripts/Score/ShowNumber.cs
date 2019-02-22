using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Linq;

public class ShowNumber : MonoBehaviour
{
    [SerializeField]
    private Text list;

    private List<int> numbers = new List<int>();

    public void ShowList()
    {
        string temp = PlayerPrefs.GetString("score");
        List<string> tempList = temp.Split(new char[] { '*' }).ToList();

        foreach (string line in tempList)
        {
            list.text += line + Environment.NewLine;
        }
    }
}
