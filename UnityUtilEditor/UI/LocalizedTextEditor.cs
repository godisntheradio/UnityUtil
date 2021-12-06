using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityUtil.UI;

namespace UnityUtilEditor.UI
{

    [UnityEditor.CustomEditor(typeof(LocalizedText))]
    public class LocalizedTextEditor : UnityEditor.Editor
    {
        Text TextRef;
        LocalizedText LocalizedTextRef;

        private void OnEnable()
        {
            LocalizedTextRef = (LocalizedText)target;
            TextRef = LocalizedTextRef.GetComponent<Text>();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            TextRef.text = LocalizedTextRef.GetLocalizedText();
        }

    }
}