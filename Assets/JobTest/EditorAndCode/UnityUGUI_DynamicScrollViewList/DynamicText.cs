using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace com.brainplus.jobtest.unityui.dynamicscrollviewlist
{
    /// <summary>
    /// You are not allowed to change this class.
    /// </summary>
    public class DynamicText : MonoBehaviour
    {
        public TextMeshProUGUI label;

        public List<string> textVariants = new List<string>();

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void Start()
        {
            StartCoroutine(SetRandomTextCoroutine());
        }

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        IEnumerator SetRandomTextCoroutine()
        {
            while (true)
            {
                // Change the text at regular intervals to simulate complex dynamic UI logic
                SetRandomText();
                yield return new WaitForSeconds(0.7f);
            }
        }

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        void SetRandomText()
        {
            int index = GetNextIndexAvoidingCurrent();
            string text = textVariants[index];
            label.text = text;
        }

        /// <summary>
        /// You are not allowed to change this function.
        /// </summary>
        int GetNextIndexAvoidingCurrent()
        {
            int offset = Random.Range(1, textVariants.Count); // Always move by at least one
            int currentIndex = textVariants.IndexOf(label.text);
            if (currentIndex == -1)
            {
                currentIndex = 0; // Default to first one
            }
            return (currentIndex + offset) % textVariants.Count;
        }
    }
}
