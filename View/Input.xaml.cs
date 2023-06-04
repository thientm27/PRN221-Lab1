using System;
using System.Windows;
using BusinessObject.Models;
using Repository;
using Repository.Implemetation;

namespace View
{
    public partial class Input : Window
    {
        private readonly ICarRepository _carRepository;
        public Input()
        {
            _carRepository = new CarRepository();
            InitializeComponent();
        }
        private string IsValidData()
        {
            if (string.IsNullOrEmpty(txtCarName.Text))
            {
                return "Car name is required.";
            }

            if (string.IsNullOrEmpty(txtManufacturer.Text))
            {
                return "Manufacturer is required.";
            }


            if (!decimal.TryParse(txtPrice.Text, out _))
            {
                return "Invalid price.";
            }
            
            if (!int.TryParse(txtReleaseYear.Text, out _))
            {
                return "Invalid release year.";
            }
            return "";

        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var message = IsValidData();
                if (!string.IsNullOrEmpty(message))
                {
                    MessageBox.Show(message, "ERROR");
                    return;
                }
                // Create a new car object with the data from the UI
                var car = new Car
                {
                    CarName = txtCarName.Text,
                    Manufacturer = txtManufacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleaseYear = int.Parse(txtReleaseYear.Text)
                };

                // Insert the car into the repository
                _carRepository.CreateCar(car);
              
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            Close();
        }
    }
}