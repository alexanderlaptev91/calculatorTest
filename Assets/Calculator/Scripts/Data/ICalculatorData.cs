namespace Calculator.Data
{
    public interface ICalculatorData
    {
        void SaveState(string key,string value);
        string LoadState(string key);
    }
}