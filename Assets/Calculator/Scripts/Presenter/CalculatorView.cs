using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.Presenter
{
    public class CalculatorView: MonoBehaviour, ICalculatorView
    {
        [SerializeField] 
        private TMP_Text _title;
        [SerializeField] 
        private ScrollRect _scrollRect;
        [SerializeField] 
        private TMP_InputField _inputField;
        [SerializeField] 
        private RectTransform _contentDebug;
        [SerializeField] 
        private TMP_Text _textDebug;
        [SerializeField] 
        private Button _resultButton;

        public void Init(string title, string inputText, Action<string> resultClick)
        {
            _title.text = title;
            _inputField.text = inputText;
            _resultButton.onClick.AddListener(()=>
            {
                resultClick.Invoke(_inputField.text);
            });
        }

        public void AddLogResult(string text)
        {
            var textLog = Instantiate(_textDebug, _contentDebug, false);
            textLog.GetComponent<RectTransform>().SetAsFirstSibling();
            textLog.text = text;
            textLog.gameObject.SetActive(true);
            _scrollRect.verticalNormalizedPosition = 1f;
        }

        public string GetText()
        {
            return _inputField.text;
        }
    }
}