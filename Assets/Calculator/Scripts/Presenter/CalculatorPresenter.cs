using System;

namespace Calculator.Presenter
{
    public class CalculatorPresenter
    {
        private readonly ICalculatorView _view;
        
        public CalculatorPresenter(ICalculatorView view)
        {
            _view = view;
        }

        public void Init(string title, string inputValue, Action<string> resultClick)
        {
            _view.Init(title, inputValue, resultClick);
        }

        public void AddLogResult(string text)
        {
            _view.AddLogResult(text);
        }

        public string GetText()
        {
            return _view.GetText();
        }
    }
}