using System;
using System.Collections.Generic;
using System.Data;
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
        }
    }
}
