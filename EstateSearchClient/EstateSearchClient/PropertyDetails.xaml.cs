using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

namespace EstateSearchClient
{
    /// <summary>
    /// Interaction logic for PropertyDetails.xaml
    /// </summary>
    public partial class PropertyDetails : Window
    {
        public PropertyDetails()
        {
            InitializeComponent();
        }

        public void setDetails(DataTable property) 
        {
            DataRow dr = property.Rows[0];
            idText.Text = dr["EstateId"].ToString();
            propertyDescriptionTextBox.Text = dr["EstateDescription"].ToString();
            furnishedCheckBox.IsChecked = (bool) dr["EstateFurnished"];
            marketCheckBox.IsChecked = (bool) dr["EstateNew"];
            areaTextBox.Text = dr["EstateArea"].ToString();
            bedroomTextBox.Text = dr["EstateBedrooms"].ToString();
            floorsTextBox.Text = dr["EstateFloors"].ToString();
            typeTextBox.Text = dr["EstateType"].ToString();
            offerTextBox.Text = dr["EstateOffer"].ToString();
            streetTextBox.Text = dr["EstateStreetName"].ToString();
            cityTextBox.Text = dr["CityName"].ToString();
            countryTextBox.Text = dr["EstateCountry"].ToString();
            priceTextBox.Text =dr["EstatePrice"].ToString();

            agentNameTextBox.Content = dr["AgentName"].ToString();
            agentAddressTextBox.Text = dr["AgentAddress"].ToString();
            agentSecureCheckBox.IsChecked = (bool) dr["AgentVerified"];
        }

    }
}
