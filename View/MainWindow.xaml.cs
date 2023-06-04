
using System;
using System.Windows;
using BusinessObject.Models;
using Repository;
using Repository.Implemetation;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICarRepository _carRepository;
        public MainWindow()
        {
            _carRepository = new CarRepository();
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            // Load cars from the repository and display them in the UI
            try
            {
                lvCars.ItemsSource = _carRepository.GetAllCar();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Input form2 = new Input();
            form2.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                var message = IsValidData();
                if (!string.IsNullOrEmpty(message))
                {
                    MessageBox.Show(message, "ERROR");
                    return;
                }
                // Retrieve the car ID from the UI
                int carId = int.Parse(txtCarId.Text);

                // Retrieve the car from the repository using the ID
                var car = _carRepository.GetCarById(carId);

                // Update the car object with the data from the UI
                car.CarName = txtCarName.Text;
                car.Manufacturer = txtManufacturer.Text;
                car.Price = decimal.Parse(txtPrice.Text);
                car.ReleaseYear = int.Parse(txtReleaseYear.Text);

                // Update the car in the repository
                _carRepository.UpdateCar(car);
                lvCars.ItemsSource = _carRepository.GetAllCar();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
          
            try
            {
             

                // Retrieve the car ID from the UI
                int carId = int.Parse(txtCarId.Text);

                // Display a confirmation dialog
                var confirmationResult = MessageBox.Show("Are you sure you want to delete this car?", "Confirmation", MessageBoxButton.YesNo);
                if (confirmationResult == MessageBoxResult.Yes)
                {
                    // Delete the car from the repository
                    _carRepository.DeleteCar(carId);
                }
                lvCars.ItemsSource = _carRepository.GetAllCar();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            Close();
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
    }
}