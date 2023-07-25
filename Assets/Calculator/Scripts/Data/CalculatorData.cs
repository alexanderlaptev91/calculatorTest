using System;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator.Data
{
    public class CalculatorData
    {
        [Serializable]
        public struct Save
        {
            public string inputText;
            public string[] history;
        }
        private readonly string _keySave = "calculator.save";
        private readonly ICalculatorData _calculatorData;

        public CalculatorData(ICalculatorData data)
        {
            _calculatorData = data;
        }

        public Save LoadState()
        {
            try
            {
                var json = _calculatorData.LoadState(_keySave);
                return JsonUtility.FromJson<Save>(json);
            }
            catch
            {
                return new Save
                {
                    inputText =  "",
                    history = Array.Empty<string>()
                };
            }
        }

        public void SaveState(Save value)
        {
            _calculatorData.SaveState(_keySave, JsonUtility.ToJson(value));
        }
    }
}