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

    public void Start()
    {
        list.text = "";

        string temp = PlayerPrefs.GetString("score");
        List<string> tempList = temp.Split(new char[] { '*' }).ToList();

        tempList = tempList.OrderBy(x => x.Length).ThenBy(number => number).Reverse().ToList();

        foreach (string line in tempList)
        {
            list.text += line + Environment.NewLine;
        }
    }

    //public void ShowList()
    //{
    //    list.text = "";

    //    string temp = PlayerPrefs.GetString("score");
    //    List<string> tempList = temp.Split(new char[] { '*' }).ToList();

    //    tempList = tempList.OrderBy(x => x.Length).ThenBy(number => number).Reverse().ToList();

    //    foreach (string line in tempList)
    //    {
    //        list.text += line + Environment.NewLine;
    //    }
    //}
}
