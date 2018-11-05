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
using System.Windows.Shapes;
using ToysRoom.Toys;

namespace ToysRoom
{
    /// <summary>
    /// Interaction logic for AddToy.xaml
    /// </summary>
    public partial class AddToy : Window
    {
        private Dictionary<string, bool> buttonsChecked;
        private int priceInt = 0;
        private Dictionary<string, string> valueChecked;
        public AddToy()
        {
            InitializeComponent();

            buttonsChecked = new Dictionary<string, bool>();
            buttonsChecked.Add("toy", false);
            buttonsChecked.Add("age", false);
            buttonsChecked.Add("size", false);
            buttonsChecked.Add("material", false);
            buttonsChecked.Add("color", false);
            buttonsChecked.Add("gameorsport", false);
            buttonsChecked.Add("type", false);
            buttonsChecked.Add("mechanic", false);
            buttonsChecked.Add("speaking", false);

            valueChecked = new Dictionary<string, string>();
            valueChecked.Add("toy", null);
            valueChecked.Add("age", null);
            valueChecked.Add("size", null);
            valueChecked.Add("material", null);
            valueChecked.Add("color", null);
            valueChecked.Add("gameorsport", null);
            valueChecked.Add("type", null);
            valueChecked.Add("mechanic", null);
            valueChecked.Add("speaking", null);
        }

        private void RadioButtonToy_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string toyName = radioButton.Content.ToString();
            switch (toyName)
            {
                case "Ball":
                    {
                        this.tabBall.Visibility = Visibility.Visible;
                        this.tabBall.IsSelected = true;
                        this.tabCar.Visibility = Visibility.Collapsed;
                        this.tabDoll.Visibility = Visibility.Collapsed;
                        buttonsChecked["mechanic"] = false;
                        buttonsChecked["type"] = false;
                        buttonsChecked["speaking"] = false;
                        break;
                    }
                case "Car":
                    {
                        this.tabBall.Visibility = Visibility.Collapsed;
                        this.tabCar.Visibility = Visibility.Visible;
                        this.tabCar.IsSelected = true;
                        this.tabDoll.Visibility = Visibility.Collapsed;
                        buttonsChecked["color"] = false;
                        buttonsChecked["gameorsport"] = false;
                        buttonsChecked["speaking"] = false;
                        break;
                    }
                case "Doll":
                    {
                        this.tabBall.Visibility = Visibility.Collapsed;
                        this.tabCar.Visibility = Visibility.Collapsed;
                        this.tabDoll.Visibility = Visibility.Visible;
                        this.tabDoll.IsSelected = true;
                        buttonsChecked["color"] = false;
                        buttonsChecked["gameorsport"] = false;
                        buttonsChecked["mechanic"] = false;
                        buttonsChecked["type"] = false;
                        break;
                    }
            }
            buttonsChecked["toy"] = true;
            priceInt = Toy.PriceToy(toyName);
            valueChecked["toy"] = toyName;
            if (buttonsChecked["age"])
                priceInt += Toy.PriceAge(valueChecked["age"]);
            if (buttonsChecked["size"])
                priceInt += Toy.PriceSize(valueChecked["size"]);
            if (buttonsChecked["material"])
                priceInt += Toy.PriceMaterial(valueChecked["material"]);
            price.Content = priceInt.ToString();
        }

        private void RadioButtonAge_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string age = radioButton.Content.ToString();
            if (buttonsChecked["age"])
            {
                priceInt -= Toy.PriceAge(valueChecked["age"]);
            }
            else
            {
                buttonsChecked["age"] = true;
            }
            valueChecked["age"] = age;
            priceInt += Toy.PriceAge(age);
            price.Content = priceInt.ToString();
        }

        private void RadioButtonSize_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string size = radioButton.Content.ToString();
            if (buttonsChecked["size"])
            {
                priceInt -= Toy.PriceSize(valueChecked["size"]);
            }
            else
            {
                buttonsChecked["size"] = true;
            }
            valueChecked["size"] = size;
            priceInt += Toy.PriceSize(size);
            price.Content = priceInt.ToString();
        }

        private void RadioButtonMaterial_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string material = radioButton.Content.ToString();
            if (buttonsChecked["material"])
            {
                priceInt -= Toy.PriceMaterial(valueChecked["material"]);
            }
            else
            {
                buttonsChecked["material"] = true;
            }
            valueChecked["material"] = material;
            priceInt += Toy.PriceMaterial(material);
            price.Content = priceInt.ToString();
        }
        private void RadioButtonColor_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string color = radioButton.Content.ToString();
            if (buttonsChecked["color"])
            {
                priceInt -= Ball.PriceColor(valueChecked["color"]);
            }
            else
            {
                buttonsChecked["color"] = true;
            }
            valueChecked["color"] = color;
            priceInt += Ball.PriceColor(color);
            price.Content = priceInt.ToString();
        }
        private void RadioButtonGame_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string gameorsport = radioButton.Content.ToString();
            if (buttonsChecked["gameorsport"])
            {
                if (valueChecked["gameorsport"] == "Game")
                    priceInt -= Ball.PriceGame(true);
                else priceInt -= Ball.PriceGame(false);
            }
            else
            {
                buttonsChecked["gameorsport"] = true;
            }
            valueChecked["gameorsport"] = gameorsport;
            if (gameorsport == "Game")
                priceInt += Ball.PriceGame(true);
            else priceInt += Ball.PriceGame(false);
            price.Content = priceInt.ToString();
        }
        private void RadioButtonMechanic_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string mechanic = radioButton.Content.ToString();
            if (buttonsChecked["mechanic"])
            {
                if (valueChecked["mechanic"] == "Inercic")
                    priceInt -= Car.PriceInercic(true);
                else priceInt -= Car.PriceInercic(false);
            }
            else
            {
                buttonsChecked["mechanic"] = true;
            }
            valueChecked["mechanic"] = mechanic;
            if (mechanic == "Inercic")
                priceInt += Car.PriceInercic(true);
            else priceInt += Car.PriceInercic(false);
            price.Content = priceInt.ToString();
        }
        private void RadioButtonTypeCar_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string type = radioButton.Content.ToString();
            if (buttonsChecked["type"])
            {
                priceInt -= Car.PriceType(valueChecked["type"]);
            }
            else
            {
                buttonsChecked["type"] = true;
            }
            valueChecked["type"] = type;
            priceInt += Car.PriceType(type);
            price.Content = priceInt.ToString();
        }
        private void RadioButtonSpeaking_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string speaking = radioButton.Content.ToString();
            if (buttonsChecked["speaking"])
            {
                if (valueChecked["speaking"] == "Yes")
                    priceInt -= Doll.PriceSpeaking(true);
                else priceInt -= Doll.PriceSpeaking(false);
            }
            else
            {
                buttonsChecked["speaking"] = true;
            }
            valueChecked["speaking"] = speaking;
            if (speaking == "Yes")
                priceInt += Doll.PriceSpeaking(true);
            else priceInt += Doll.PriceSpeaking(false);
            price.Content = priceInt.ToString();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(buttonsChecked["toy"]
                && buttonsChecked["age"]
                && buttonsChecked["size"]
            && buttonsChecked["material"]))
                MessageBox.Show("Please choose some more parametrs",
                "Wrong input",
                MessageBoxButton.OK,
                MessageBoxImage.Error,
                MessageBoxResult.OK,
                MessageBoxOptions.DefaultDesktopOnly);
            else
            {
                switch (valueChecked["toy"])
                {
                    case "Ball":
                        {
                            if (!(buttonsChecked["color"] && buttonsChecked["gameorsport"]))
                                MessageBox.Show("Please choose some more parameters",
                "Wrong input",
                MessageBoxButton.OK,
                MessageBoxImage.Error,
                MessageBoxResult.OK,
                MessageBoxOptions.DefaultDesktopOnly);
                            else
                            {
                                Ball ball = new Ball();
                                if (valueChecked["gameorsport"] == "Game")
                                    ball.SetParameters(valueChecked["age"], valueChecked["size"], valueChecked["material"],
                                        valueChecked["color"], true);
                                else ball.SetParameters(valueChecked["age"], valueChecked["size"], valueChecked["material"],
                                    valueChecked["color"], false);
                                ToyRoom toyRoom = (this.Owner as MainWindow).toyRoom;
                                if (!toyRoom.AddNewToy(ball))
                                {
                                    MessageBox.Show("It costs too much.",
                "Max price",
                MessageBoxButton.OK,
                MessageBoxImage.Error,
                MessageBoxResult.OK,
                MessageBoxOptions.DefaultDesktopOnly);
                                }
                                this.DialogResult = true;
                                this.Close();
                            }
                            break;
                        }
                    case "Car":
                        {
                            if (!(buttonsChecked["type"] && buttonsChecked["mechanic"]))
                                MessageBox.Show("Please choose some more parameters",
                "Wrong input",
                MessageBoxButton.OK,
                MessageBoxImage.Error,
                MessageBoxResult.OK,
                MessageBoxOptions.DefaultDesktopOnly);
                            else
                            {
                                Car car = new Car();
                                if (valueChecked["mechanic"] == "Inercic")
                                    car.SetParameters(valueChecked["age"], valueChecked["size"], valueChecked["material"],
                                        true, valueChecked["type"]);
                                else car.SetParameters(valueChecked["age"], valueChecked["size"], valueChecked["material"],
                                    false, valueChecked["color"]);
                                ToyRoom toyRoom = (this.Owner as MainWindow).toyRoom;
                                if (!toyRoom.AddNewToy(car))
                                {
                                    MessageBox.Show("It costs too much.",
                "Max price",
                MessageBoxButton.OK,
                MessageBoxImage.Error,
                MessageBoxResult.OK,
                MessageBoxOptions.DefaultDesktopOnly);
                                }
                                this.DialogResult = true;
                                this.Close();
                            }
                            break;
                        }
                    case "Doll":
                        {
                            if (!buttonsChecked["speaking"])
                                MessageBox.Show("Please choose some more parameters",
                "Wrong input",
                MessageBoxButton.OK,
                MessageBoxImage.Error,
                MessageBoxResult.OK,
                MessageBoxOptions.DefaultDesktopOnly);
                            else
                            {
                                Doll doll = new Doll();
                                if (valueChecked["mechanic"] == "Yes")
                                    doll.SetParameters(valueChecked["age"], valueChecked["size"], valueChecked["material"],
                                        true);
                                else doll.SetParameters(valueChecked["age"], valueChecked["size"], valueChecked["material"],
                                    false);
                                ToyRoom toyRoom = (this.Owner as MainWindow).toyRoom;
                                if (!toyRoom.AddNewToy(doll))
                                {
                                    MessageBox.Show("It costs too much.",
                "Max price",
                MessageBoxButton.OK,
                MessageBoxImage.Error,
                MessageBoxResult.OK,
                MessageBoxOptions.DefaultDesktopOnly);
                                }
                                this.DialogResult = true;
                                this.Close();
                            }
                            break;
                        }
                }
            }
        }
    }
}
