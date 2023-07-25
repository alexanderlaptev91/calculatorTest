using System;

namespace Calculator.Presenter
{
    public interface ICalculatorView
    {
        void Init(string title, string inputText, Action<string> resultClick);
        void AddLogResult(string text);
        string GetText();
    }
}