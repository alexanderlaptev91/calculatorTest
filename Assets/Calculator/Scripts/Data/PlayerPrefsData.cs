using UnityEngine;

namespace Calculator.Data
{
    public class PlayerPrefsData : ICalculatorData
    {
        public void SaveState(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
            PlayerPrefs.Save();
        }

        public string LoadState(string key)
        {
            return PlayerPrefs.GetString(key);
        }
    }
}