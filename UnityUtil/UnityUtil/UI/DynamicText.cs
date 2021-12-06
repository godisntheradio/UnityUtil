using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace UnityUtil.UI
{
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
            if (text == null)
                Initialize();

            text.text = value.ToString();
        }
        public void UpdateText(string value)
        {
            if (text == null)
                Initialize();

            text.text = value;
        }

        public void UpdateText(float value, string format = "0.00")
        {
            if (text == null)
                Initialize();

            text.text = value.ToString(format);
        }

        public void UpdateColor(Color color)
        {
            if (text == null)
                Initialize();

            text.color = color;
        }

        public Color GetColor()
        {
            if (text == null)
                Initialize();

            return text.color; 
        }

        public void Initialize()
        {
            text = GetComponent<Text>();
            if (text == null)
                Debug.Log("Text component not found");
        }
    }
}
