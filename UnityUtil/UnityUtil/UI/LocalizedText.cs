using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityUtil.UI
{
    [RequireComponent(typeof(UnityEngine.UI.Text))]
    public class LocalizedText : MonoBehaviour
    {
        #region Global State

        private static Language lang = Language.EN;
        public static Language Lang
        {
            get { return lang; }
            private set
            {
                lang = value;
            }
        }

        private static List<LocalizedText> Texts = new List<LocalizedText>();

        #endregion

        #region Properties

        [Header("Text localization")]
        [SerializeField]
        public List<string> TextDictionary = new List<string>() { "", "" };

        private Text TextComponent;

        #endregion

        protected void Awake()
        {
            Texts.Add(this);
        }

        protected void Start()
        {
            TextComponent = GetComponent<Text>();
            UpdateText();
        }

        public void UpdateText()
        {
            TextComponent.text = GetLocalizedText();
        }

        public string GetLocalizedText()
        {
            return TextDictionary[(int)lang];
        }

        public static void ChangeLanguage(Language language)
        {
            Lang = language;
            foreach (var item in Texts)
            {
                item.UpdateText();
            }
        }

        protected void OnDestroy()
        {
            Texts.Remove(this);
        }

        public enum Language
        {
            EN = 0,
            PTBR = 1
        }
    }

    public class LocalizedString : MonoBehaviour
    {
        [Header("Text localization")]
        [SerializeField]
        public List<string> TextDictionary = new List<string>() { "", "" };

        public string GetLocalizedText()
        {
            return TextDictionary[(int)LocalizedText.Lang];
        }
    }

    public static class LanguageExtensions
    {

        public static string ToFriendlyString(this LocalizedText.Language me)
        {
            string result = "";
            switch (me)
            {
                case LocalizedText.Language.EN:
                    result = "en-US";
                    break;
                case LocalizedText.Language.PTBR:
                    result = "pt-BR";
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}