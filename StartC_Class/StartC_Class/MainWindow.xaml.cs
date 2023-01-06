using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using Newtonsoft.Json;

namespace StartC_Class
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            addButton.Visibility = Visibility.Hidden;
            deleteButton.Visibility = Visibility.Hidden;
            firstBox.Visibility = Visibility.Hidden;
            middleBox.Visibility = Visibility.Hidden;
            lastBox.Visibility = Visibility.Hidden;
            passportBox.Visibility = Visibility.Hidden;
            numPassport.DisplayMemberBinding = new Binding("hidePassport");

            SerializeJsonFile();  // <- Можно убрать чтобы каждый раз не появлялись новые сотрудники
            DeserializeJsonFile();
        }

        string path = @"..\Debug\Program_Consultant.json";

        public void SerializeJsonFile()
        {
            List<Consultant> consultantSerialize = new List<Consultant>();

            Random random = new Random();
            int value = random.Next(10, 50);
            for (int i = 0; i < value; i++)
            {
                consultantSerialize.Add(new Consultant(Faker.Name.First(), Faker.Name.Middle(),
                    Faker.Name.Last(), Faker.Phone.Number(), Faker.RandomNumber.Next().ToString()));
            }

            File.WriteAllText(path, String.Empty);
            for (int i = 0; i < consultantSerialize.Count; i++)
            {
                File.AppendAllText(path, JsonConvert.SerializeObject(consultantSerialize[i], Formatting.Indented));
            }
        }

        public void DeserializeJsonFile()
        {
            ObservableCollection<Consultant> consultantDesirealize = new ObservableCollection<Consultant>();
            JsonTextReader reader = new JsonTextReader(new StreamReader(path));
            reader.SupportMultipleContent = true;
            while (true)
            {
                if (!reader.Read())
                {
                    break;
                }
                JsonSerializer serializer = new JsonSerializer();
                Consultant consDesirealize = serializer.Deserialize<Consultant>(reader);
                consultantDesirealize.Add(consDesirealize);
                listView.Items.Add(consDesirealize);
            }
        }

        private void SelectionChanged_comboBox(object sender, SelectionChangedEventArgs e)
        {

            if (managerBox.IsSelected == true)
            {
                textBlock.Text = "Менеджер";
                numPassport.DisplayMemberBinding = new Binding("numberPassport");
                addButton.Visibility = Visibility.Visible;
                deleteButton.Visibility = Visibility.Visible;
                firstBox.Visibility = Visibility.Visible;
                middleBox.Visibility = Visibility.Visible;
                lastBox.Visibility = Visibility.Visible;
                passportBox.Visibility = Visibility.Visible;
            }
            else
            {
                textBlock.Text = "Консультант";
                numPassport.DisplayMemberBinding = new Binding("hidePassport");
                addButton.Visibility = Visibility.Hidden;
                deleteButton.Visibility = Visibility.Hidden;
                firstBox.Visibility = Visibility.Hidden;
                middleBox.Visibility = Visibility.Hidden;
                lastBox.Visibility = Visibility.Hidden;
                passportBox.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            Manager manager = new Manager(firstBox.Text, middleBox.Text, lastBox.Text, numberPhoneBox.Text, passportBox.Text);
            File.AppendAllText(path, JsonConvert.SerializeObject(manager, Formatting.Indented));
            listView.Items.Add(manager);
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            listView.Items.Remove(listView.SelectedItem);
        }
    }
}
