using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
using Est = EstateSearchClient.Estate;

namespace EstateSearchClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected Est.EstateClient cl;

        public MainWindow()
        {
            InitializeComponent();
            getAllButton.Background = Brushes.Green;
            showSelectedButton.Background = Brushes.Blue;
            cityNameCombo.SelectionChanged += new SelectionChangedEventHandler(agentNameComboBoxChanged);
            cl = new Est.EstateClient();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var propertyDetails = new PropertyDetails();
            DataRow dr = (DataRow) ggrrr.SelectedItem;
            Int32 id = Int32.Parse(dr["ID"].ToString());

            getDetailsForPopup(propertyDetails, id);

            propertyDetails.ShowDialog();
        }

        private void getAllButton_Click(object sender, RoutedEventArgs e)
        {
            getDD();
        }

        private async void getDetailsForPopup(PropertyDetails popup, Int32 id)
        {
            DataTable property = XmlStringToDataTable(await cl.GetAllEstatesAsync());

            popup.setDetails(property);
        }

        private async void getDD()
        {
            DataTable CityDt = XmlStringToDataTable(await cl.GetCitiesAsync());
            DataTable AgentDt = XmlStringToDataTable(await cl.GetAgentsAsync());
            DataTable EstateDt = XmlStringToDataTable(await cl.GetEstatesAsync());

            cityNameCombo.SelectedValuePath = "CityId";
            cityNameCombo.DisplayMemberPath = "CityName";

            agentNameCombo.SelectedValuePath = "AgentId";
            agentNameCombo.DisplayMemberPath = "AgentName";

            cityNameCombo.ItemsSource = CityDt.DefaultView;
            agentNameCombo.ItemsSource = AgentDt.DefaultView;

            BindDataGridView(ggrrr, EstateDt);
        }

        private DataTable XmlStringToDataTable(String s) {
            DataTable dt = new DataTable();

            try
            {
                StringReader theReader = new StringReader(s);
                dt.ReadXml(theReader);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Nie można pobrać danych", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dt;
        }

        /**
         * binduje DataTable do GridView
         */
        public void BindDataGridView(DataGrid dgv, DataTable dt)
        {
            dgv.ItemsSource = dt.AsDataView();

        }

        private async void agentNameComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            int CityId = (sender as ComboBox).SelectedIndex;
            DataTable dt = XmlStringToDataTable(await cl.GetEstatesByCityIdAsync(CityId));
            BindDataGridView(ggrrr, dt);
        }

        private async void searchCityButton_Click(object sender, RoutedEventArgs e)
        {
            String partialCityName = cityNameInput.Text;
            if (partialCityName.Length >= 3)
            {
                DataTable dt = XmlStringToDataTable(await cl.GetEstatesByCityNameAsync(partialCityName));
                BindDataGridView(ggrrr, dt);
            }
            else
            {
                MessageBox.Show("Musisz wpisać minimum 3 znaki!", "Za krótka wartość", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private async void searchAgentButton_Click(object sender, RoutedEventArgs e)
        {
            String partialAgentName = agentNameInput.Text;

            if (partialAgentName.Length >= 3)
            {
                DataTable dt = XmlStringToDataTable(await cl.GetEstatesByAgentNameAsync(partialAgentName));
                BindDataGridView(ggrrr, dt);
            }
            else
            {
                MessageBox.Show("Musisz wpisać minimum 3 znaki!", "Za krótka wartość", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

    }
}
