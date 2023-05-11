using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tamagotchi
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int hungerLevel = 50;
        private int happinessLevel = 75;
        private int energyLevel = 25;
        private int moneyLevel = 25;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ActionTamagotchi(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            switch (button.Content)
            {
                case "Manger":
                    hungerLevel += 10;
                    moneyLevel -= 5;
                    break;
                case "Jouer":
                    happinessLevel += 10;
                    moneyLevel -= 5;
                    break;
                case "Dormir":
                    energyLevel += 10;
                  
                    break;
                case "Travailler":
                    moneyLevel += 10;
                    energyLevel -= 5;
                    break;
                default:
                    break;
            }

            UpdateLevels();
        }

        private void UpdateLevels()
        {
            // Vérifier si Tamagotchi est en vie
            if (hungerLevel <= 0 || happinessLevel <= 0 || energyLevel <= 0)
            {
                MessageBox.Show("Votre Tamagotchi est mort...");
                this.Close();
                return;
            }

            // mettre à jour les niveaux de progressBar
            HungerLevelProgressBar.Value = hungerLevel;
            HappinessLevelProgressBar.Value = happinessLevel;
            EnergyLevelProgressBar.Value = energyLevel;
            MoneyLevelProgressBar.Value = moneyLevel;
        }
        private void EatWithTamagotchi(object sender, RoutedEventArgs e)
        {
            hungerLevel += 10;
            moneyLevel -= 5;
            UpdateLevels();
        }
        private void PlayWithTamagotchi(object sender, RoutedEventArgs e)
        {
            happinessLevel += 10;
           moneyLevel -= 5;
            UpdateLevels();
        }

        private void SleepWithTamagotchi(object sender, RoutedEventArgs e)
        {
            energyLevel += 10;
           // happinessLevel -= 5;
            UpdateLevels();
        }

        private void WorkTamagotchi(object sender, RoutedEventArgs e)
        {
            moneyLevel += 10;
            energyLevel -= 5;
            UpdateLevels();
        }
    }

}

