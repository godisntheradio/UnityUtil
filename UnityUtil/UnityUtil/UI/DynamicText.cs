using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicText : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        Initialize();
    }
    void Start()
    {
        Initialize();
    }
    public void UpdateText(int value)
    {
        text.text = value.ToString();
    }
    public void UpdateText(string value)
    {
        text.text = value;
    }

    public void UpdateText(float value, string format = "0.00")
    {
        text.text = value.ToString(format);
    }

    public void Initialize()
    {
        text = GetComponent<Text>();
        if (text == null)
            Debug.Log("Text component not found");
    }
}
