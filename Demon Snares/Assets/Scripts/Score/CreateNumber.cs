using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CreateNumber : MonoBehaviour
{
    private int number;
    private List<int> numbers = new List<int>();

    private string numberText;

    private string temp;

    [SerializeField] 
    private Text textBox;

    private void Start()
    {
        temp = "";
        
    }

    public void GenerateNumber()
    {
        number = Random.Range(0, 10000);
        numberText = number.ToString();

        numbers.Add(number);
    }

    public void AddNumber()
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            if (i != numbers.Count - 1)
                temp += numbers[i].ToString() + "*";
                                                    
            else
                temp += numbers[i].ToString();
        }

        PlayerPrefs.DeleteKey("score");
        PlayerPrefs.SetString("score", temp);
        PlayerPrefs.Save();
        temp = "";
    }

    private void Update()
    {
        textBox.text = numberText;
    }
}
