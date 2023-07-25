using Calculator.Data;
using Calculator.Presenter;

namespace Calculator.Domain
{
    public class CalculatorDomain
    {
        public CalculatorData CalculatorData { get; }
        public CalculatorPresenter CalculatorPresenter { get; }

        public CalculatorDomain(ICalculatorView view)
        {
            CalculatorData = new CalculatorData(new PlayerPrefsData());
            CalculatorPresenter = new CalculatorPresenter(view);
        }
    }
}