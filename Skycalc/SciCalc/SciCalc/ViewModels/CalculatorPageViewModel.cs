using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace SciCalc.ViewModels
{
    [INotifyPropertyChanged]
    internal partial class CalculatorPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string inputText = string.Empty;

        [ObservableProperty]
        private string calculatedResult = "0";

        private bool isSciOpWaiting = false;

        [RelayCommand]
        private void Reset()
        {
            calculatedResult = "0";
            inputText = string.Empty;
            isSciOpWaiting = false;
        }

        [RelayCommand]
        private void Calculate()
        {

            if (inputText.Length == 0)
            {
                return;
            }

            if (isSciOpWaiting)
            {
                inputText += ")";
                isSciOpWaiting = false;
            }

            try
            {
                var inputString = NormalizeInputString();
                var expression = new NCalc.Expression(inputString);
                var result = expression.Evaluate();

                calculatedResult = result.ToString();
            }
            catch (Exception ex)
            {
                calculatedResult = "NaN";
            }
        }

        private string NormalizeInputString()
        {
            Dictionary<string, string> _opMapper = new()
            {
                {"×", "*" },
                {"÷", "/" },
                {"SIN", "Sin" },
                {"COS", "Cos" },
                {"TAN", "Tan" },
                {"ASIN", "Asin" },
                {"ACOS", "Acos" },
                {"ATAN", "Atan" },
                {"LOG", "Log" },
                {"LOG10", "Log10" },
                {"EXP", "Exp" },
                {"POW", "Pow" },
                {"SQRT", "Sqrt" },
                {"ABS", "Abs" },
            };

            var retString = inputText;
            foreach (var key in _opMapper.Keys)
            {
                retString = retString.Replace(key, _opMapper[key]);
            }
            return retString;
        }

        [RelayCommand]
        private void BackSpace()
        {
            if (inputText.Length > 0)
            {
                inputText = inputText.Substring(0, inputText.Length - 1);
            }
        }

        [RelayCommand]
        private void NumberInput(string key)
        {
            inputText += key;

        }

        [RelayCommand]
        private void MathOperator(string op)
        {
            if (isSciOpWaiting)
            {
                inputText += ")";
                isSciOpWaiting = false;
            }
            inputText += $" {op}";
        }

        [RelayCommand]
        private void RegionOperator(string op)
        {
            if (isSciOpWaiting)
            {
                inputText += ")";
                isSciOpWaiting = false;
            }
            inputText += $" {op}";
        }

        [RelayCommand]
        private void ScientificOperator(string op)
        {
            if (isSciOpWaiting)
            {
                inputText += $" {op}";
                isSciOpWaiting = false;
            }
        }
    }
}
