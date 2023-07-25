using System;
using System.Collections.Generic;
using System.Linq;
using Calculator.Data;
using Calculator.Domain;
using Calculator.Presenter;
using UnityEngine;

namespace Calculator
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] 
        private CalculatorView _calculatorView;
        [SerializeField] 
        private RectTransform _canvas;
        
        private CalculatorDomain _calculatorDomain;
        private List<string> _history = new();

        private void Start()
        {
            var view = Instantiate(_calculatorView, _canvas, false);
            view.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            _calculatorDomain = new CalculatorDomain(view);
            Init();
        }

        private void Init()
        {
            var save = _calculatorDomain.CalculatorData.LoadState();
            _calculatorDomain.CalculatorPresenter.Init("Calculator Pro", save.inputText, ResultClick);
            _history = new List<string>(save.history);
            foreach (var text in _history)
            {
                _calculatorDomain.CalculatorPresenter.AddLogResult(text);
            }
        }

        private void ResultClick(string text)
        {
            var resultText = "";
            try
            {
                var splitValues = text.Split("+");
                if (splitValues.Length < 2)
                {
                    throw new Exception();
                }
                var sum = splitValues.Sum(Convert.ToInt32);
                resultText = $"{text} = {sum}";
                _calculatorDomain.CalculatorPresenter.AddLogResult(resultText);
            }
            catch
            {
                resultText = $"{text} = ERROR";
                _calculatorDomain.CalculatorPresenter.AddLogResult(resultText);
            }
            
            _history.Add(resultText);

        }
        
        private void OnApplicationQuit()
        {
            _calculatorDomain.CalculatorData.SaveState(new CalculatorData.Save
            {
                inputText = _calculatorDomain.CalculatorPresenter.GetText(), 
                history = _history.ToArray()
            });
        }
    }
}