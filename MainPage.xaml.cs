using Microsoft.Maui.Controls;

namespace SorochanLab3Var19
{
    public partial class MainPage : ContentPage
    {
        string selectedAccelerationUnit = string.Empty;

        public MainPage()
        {
            InitializeComponent();

            studentInfoLabel.Text = "Сорочан Максим Лабораторна робота №3 Варіант 19";
        }

        void OnAccelerationUnitChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                RadioButton selectedRadioButton = sender as RadioButton;

                if (selectedRadioButton != null)
                {
                    selectedAccelerationUnit = selectedRadioButton.Value.ToString();
                    header.Text = $"Оберіть одиниці прискорення (Вибрано: {selectedRadioButton.Content})";
                }
            }
        }

        void OnConvertClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputValue.Text) || string.IsNullOrEmpty(selectedAccelerationUnit))
            {
                resultLabel.Text = "Будь ласка, введіть значення та оберіть одиниці.";
                inputValue.BackgroundColor = Colors.LightCoral;
                return;
            }

            if (!double.TryParse(inputValue.Text, out double valueToConvert))
            {
                resultLabel.Text = "Недійсне числове значення.";
                inputValue.BackgroundColor = Colors.LightCoral;
                return;
            }

            if (valueToConvert < 0)
            {
                resultLabel.Text = "Значення не може бути від'ємним.";
                inputValue.BackgroundColor = Colors.LightCoral;
                return;
            }

            inputValue.BackgroundColor = null;

            double ms2 = 0;

            switch (selectedAccelerationUnit)
            {
                case "MetersPerSecondSquared":
                    ms2 = valueToConvert;
                    break;

                case "G_Force":
                    ms2 = valueToConvert * 9.80665;
                    break;

                case "FeetPerSecondSquared":
                    ms2 = valueToConvert * 0.3048;
                    break;

                case "KilometersPerHourSquared":
                    ms2 = valueToConvert * (1000.0 / (3600.0 * 3600.0));
                    break;

                case "MilesPerHourSquared":
                    ms2 = valueToConvert * (1609.34 / (3600.0 * 3600.0));
                    break;

                default:
                    resultLabel.Text = "Невідома одиниця прискорення.";
                    return;
            }

            resultLabel.Text = $"Результат (в м/с²): {ms2:F4}";
        }
    }
}
