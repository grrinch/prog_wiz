using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Estate_Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Estate : IEstate
    {
        protected EstateData myEstateData;
        private DataTable _tempTable;

        public Estate()
        {
            this.myEstateData = new EstateData();
            this._tempTable = new DataTable("Nieruchomości");
            this._tempTable.Columns.Add("ID", Type.GetType("System.Int32"));
            this._tempTable.Columns.Add("Typ", Type.GetType("System.String"));
            this._tempTable.Columns.Add("Powierzchnia", Type.GetType("System.Double"));
            this._tempTable.Columns.Add("Miasto", Type.GetType("System.String"));
            this._tempTable.Columns.Add("Ulica", Type.GetType("System.String"));
            this._tempTable.Columns.Add("Cena", Type.GetType("System.Double"));
            this._tempTable.Columns.Add("Agencja", Type.GetType("System.String"));
        }

        public String echo()
        {
            string _ = "Działam!";
            return _;
        }

        public String test()
        {
            DataTable dt = new DataTable("Test");
            DataColumn dc = new DataColumn("k", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("v", typeof(string));
            dt.Columns.Add(dc);
            DataRow dr = null;

            dr = dt.NewRow();
            dr["k"] = "test";
            dr["v"] = "test2";
            dt.Rows.Add(dr);

            System.IO.StringWriter writer = new System.IO.StringWriter();
            dt.WriteXml(writer, XmlWriteMode.WriteSchema);
            return writer.ToString();
        }

        private String _DataTableToXmlString(DataTable dt)
        {
            System.IO.StringWriter writer = new System.IO.StringWriter();
            dt.WriteXml(writer, XmlWriteMode.WriteSchema);
            return writer.ToString();
        }

        public String GetAllEstates()
        {
            DataTable estateDt = myEstateData.getAllData("estates");
            return _DataTableToXmlString(estateDt);
        }

        public String GetEstateById(int id)
        {
            var nier = from est in myEstateData.getAllData("estates").AsEnumerable()
                       join city in myEstateData.getAllData("cities").AsEnumerable()
                        on est["CityId"] equals city["CityId"]
                       join agent in myEstateData.getAllData("agents").AsEnumerable()
                        on est["AgentId"] equals agent["AgentId"]
                       where est.Field<Int32>("EstateId") == id
                       orderby est.Field<Int32>("CityId"), est.Field<String>("EstateStreetName")
                       select new
                       {
                           ID = est["EstateId"],
                           Typ = est["EstateType"],
                           Powierzchnia = est["EstateArea"],
                           Miasto = city["CityName"],
                           Ulica = est["EstateStreetName"],
                           Cena = est["EstatePrice"],
                           Agencja = agent["AgentName"]
                       };

            foreach (var estate in nier)
            {
                _tempTable.Rows.Add(estate.ID, estate.Typ, estate.Powierzchnia, estate.Miasto, estate.Ulica, estate.Cena, estate.Agencja);
            }

            return _DataTableToXmlString(_tempTable);
        }

        public String GetEstatesByAgentId(int id)
        {
            var nier = from est in myEstateData.getAllData("estates").AsEnumerable()
                       join city in myEstateData.getAllData("cities").AsEnumerable()
                        on est["CityId"] equals city["CityId"]
                       join agent in myEstateData.getAllData("agents").AsEnumerable()
                        on est["AgentId"] equals agent["AgentId"]
                       where est.Field<Int32>("AgentId") == id
                       orderby est.Field<Int32>("CityId"), est.Field<String>("EstateStreetName")
                       select new
                       {
                           ID = est["EstateId"],
                           Typ = est["EstateType"],
                           Powierzchnia = est["EstateArea"],
                           Miasto = city["CityName"],
                           Ulica = est["EstateStreetName"],
                           Cena = est["EstatePrice"],
                           Agencja = agent["AgentName"]
                       };

            foreach (var estate in nier)
            {
                _tempTable.Rows.Add(estate.ID, estate.Typ, estate.Powierzchnia, estate.Miasto, estate.Ulica, estate.Cena, estate.Agencja);
            }

            return _DataTableToXmlString(_tempTable);
        }

        public String GetEstatesByAgentName(string partialAgentName)
        {
            var nier = from est in myEstateData.getAllData("estates").AsEnumerable()
                       join city in myEstateData.getAllData("cities").AsEnumerable()
                        on est["CityId"] equals city["CityId"]
                       join agent in myEstateData.getAllData("agents").AsEnumerable()
                        on est["AgentId"] equals agent["AgentId"]
                       where agent["AgentName"].ToString().ToLower().Contains(partialAgentName.ToLower())
                       orderby est.Field<Int32>("CityId"), est.Field<String>("EstateStreetName")
                       select new
                       {
                           ID = est["EstateId"],
                           Typ = est["EstateType"],
                           Powierzchnia = est["EstateArea"],
                           Miasto = city["CityName"],
                           Ulica = est["EstateStreetName"],
                           Cena = est["EstatePrice"],
                           Agencja = agent["AgentName"]
                       };

            foreach (var estate in nier)
            {
                _tempTable.Rows.Add(estate.ID, estate.Typ, estate.Powierzchnia, estate.Miasto, estate.Ulica, estate.Cena, estate.Agencja);
            }

            return _DataTableToXmlString(_tempTable);
        }

        public String GetEstatesByCityId(int id)
        {
            var nier = from est in myEstateData.getAllData("estates").AsEnumerable()
                       join city in myEstateData.getAllData("cities").AsEnumerable()
                        on est["CityId"] equals city["CityId"]
                       join agent in myEstateData.getAllData("agents").AsEnumerable()
                        on est["AgentId"] equals agent["AgentId"]
                       where est.Field<Int32>("CityId") == id
                       orderby est.Field<Int32>("CityId"), est.Field<String>("EstateStreetName")
                       select new
                       {
                           ID = est["EstateId"],
                           Typ = est["EstateType"],
                           Powierzchnia = est["EstateArea"],
                           Miasto = city["CityName"],
                           Ulica = est["EstateStreetName"],
                           Cena = est["EstatePrice"],
                           Agencja = agent["AgentName"]
                       };

            foreach (var estate in nier)
            {
                _tempTable.Rows.Add(estate.ID, estate.Typ, estate.Powierzchnia, estate.Miasto, estate.Ulica, estate.Cena, estate.Agencja);
            }

            return _DataTableToXmlString(_tempTable);
        }

        public String GetEstatesByCityName(string partialCityName)
        {
            var nier = from est in myEstateData.getAllData("estates").AsEnumerable()
                       join city in myEstateData.getAllData("cities").AsEnumerable()
                        on est["CityId"] equals city["CityId"]
                       join agent in myEstateData.getAllData("agents").AsEnumerable()
                        on est["AgentId"] equals agent["AgentId"]
                       where (
                        city["CityName"].ToString().ToLower().Contains(partialCityName.ToLower()) ||
                        est["EstateStreetName"].ToString().ToLower().Contains(partialCityName.ToLower())
                       )
                       orderby est.Field<Int32>("CityId"), est.Field<String>("EstateStreetName")
                       select new
                       {
                           ID = est["EstateId"],
                           Typ = est["EstateType"],
                           Powierzchnia = est["EstateArea"],
                           Miasto = city["CityName"],
                           Ulica = est["EstateStreetName"],
                           Cena = est["EstatePrice"],
                           Agencja = agent["AgentName"]
                       };

            foreach (var estate in nier)
            {
                _tempTable.Rows.Add(estate.ID, estate.Typ, estate.Powierzchnia, estate.Miasto, estate.Ulica, estate.Cena, estate.Agencja);
            }

            return _DataTableToXmlString(_tempTable);
        }

        public String GetCities()
        {
            DataTable citiesDt = myEstateData.getAllData("cities");
            return _DataTableToXmlString(citiesDt);
        }

        public String GetAgents()
        {
            DataTable agentsDt = myEstateData.getAllData("agents");
            return _DataTableToXmlString(agentsDt);
        }

        public String GetEstates()
        {
            //_tempTable.Reset();
            var nier = from est in myEstateData.getAllData("estates").AsEnumerable()
                       join city in myEstateData.getAllData("cities").AsEnumerable()
                        on est["CityId"] equals city["CityId"]
                       join agent in myEstateData.getAllData("agents").AsEnumerable()
                        on est["AgentId"] equals agent["AgentId"]
                       orderby est.Field<Int32>("CityId"), est.Field<String>("EstateStreetName")
                       select new
                       {
                           ID = est["EstateId"],
                           Typ = est["EstateType"],
                           Powierzchnia = est["EstateArea"],
                           Miasto = city["CityName"],
                           Ulica = est["EstateStreetName"],
                           Cena = est["EstatePrice"],
                           Agencja = agent["AgentName"]
                       };

            foreach (var estate in nier)
            {
                _tempTable.Rows.Add(estate.ID, estate.Typ, estate.Powierzchnia, estate.Miasto, estate.Ulica, estate.Cena, estate.Agencja);
            }

            return _DataTableToXmlString(_tempTable);
        }
    }
}
