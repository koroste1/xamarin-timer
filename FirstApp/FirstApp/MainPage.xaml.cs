using System;
using Xamarin.Forms;

namespace FirstApp
{
    public partial class MainPage : ContentPage
    {
        bool isAlive = false;
        double currentSeconds = 0;
        int currentMinutes = 0;
        int currentHours = 0;

        TimeSpan currentTimer = TimeSpan.FromSeconds(1);
        public MainPage()
        {
            InitializeComponent();
        }

        private bool OnTimerTick() {
            currentSeconds += 1;

            if (currentSeconds == 60)
            {
                currentMinutes += 1;
                currentSeconds = 0;
            }
            if (currentMinutes == 60)
            {
                currentHours += 1;
                currentMinutes = 0;
            }
          
            formattedTime();
            return isAlive;
        }

        private void formattedTime() {
            hours.Text = currentHours < 10 ? $"0{currentHours.ToString()}" : currentHours.ToString();
            minutes.Text = currentMinutes < 10 ? $"0{currentMinutes.ToString()}" : currentMinutes.ToString();
            seconds.Text = currentSeconds < 10 ? $"0{currentSeconds.ToString()}" : currentSeconds.ToString();
        }

        private void OnStartButtonClicked(object sender, EventArgs e)
        {
            if (isAlive == true)
            {
                isAlive = false;
                startButton.Text = "Старт"; 
            }
            else
            {
                isAlive = true;
                startButton.Text = "Пауза";
                Device.StartTimer(currentTimer, OnTimerTick);
            }
        }
        private void OnResetButtonClicked(object sender, EventArgs e)
        {
            isAlive = false;
            currentHours = 0;
            currentMinutes = 0;
            currentSeconds = 0;
            startButton.Text = "Старт";
            formattedTime();
        }
    }
}
