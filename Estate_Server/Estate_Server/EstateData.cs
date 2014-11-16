using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate_Server
{
    public class EstateData
    {
        private DataTable MyEstates;
        private DataSet EstateDB { get; set; }
        private DataTable[] test;

        public EstateData()
        {
            // inicjalizuję dane
            DataTable estates = new DataTable("Estates");
            DataTable agents = new DataTable("Agents");
            DataTable cities = new DataTable("Cities");

            DataColumn[] columnEstates = new DataColumn[14];
            DataColumn[] columnAgents = new DataColumn[4];
            DataColumn[] columnCities = new DataColumn[2];

            columnCities[0] = new DataColumn("CityId", Type.GetType("System.Int32"));
            columnCities[0].AutoIncrement = true;
            columnCities[1] = new DataColumn("CityName", Type.GetType("System.String"));

            cities.Columns.AddRange(columnCities);

            columnAgents[0] = new DataColumn("AgentId", Type.GetType("System.Int32"));
            columnAgents[0].AutoIncrement = true;
            columnAgents[1] = new DataColumn("AgentName", Type.GetType("System.String"));
            columnAgents[2] = new DataColumn("AgentAddress", Type.GetType("System.String"));
            columnAgents[3] = new DataColumn("AgentVerified", Type.GetType("System.Boolean"));

            agents.Columns.AddRange(columnAgents);

            columnEstates[0] = new DataColumn("EstateId", Type.GetType("System.Int32"));
            columnEstates[0].AutoIncrement = true;
            columnEstates[1] = new DataColumn("EstateArea", Type.GetType("System.Double")); //powierzchnia nieruchomości
            columnEstates[2] = new DataColumn("EstateBedrooms", Type.GetType("System.Int32")); //ilość sypialni
            columnEstates[3] = new DataColumn("EstateFloors", Type.GetType("System.Int32")); //liczba pięter - domyślnie 1
            columnEstates[3].DefaultValue = 1;
            columnEstates[4] = new DataColumn("EstateType", Type.GetType("System.String")); //mieszkanie, dom
            columnEstates[5] = new DataColumn("EstateOffer", Type.GetType("System.String")); //rodzaj oferty: sprzedaż, wynajem
            columnEstates[6] = new DataColumn("EstateFurnished", Type.GetType("System.Boolean")); //umeblowany
            columnEstates[7] = new DataColumn("EstateStreetName", Type.GetType("System.String")); //ulica i numer
            columnEstates[8] = new DataColumn("EstateCountry", Type.GetType("System.String")); //państwo - domyślnie Polska
            columnEstates[8].DefaultValue = "Polska";
            columnEstates[9] = new DataColumn("EstateDescription", Type.GetType("System.String")); //opis nieruchomości
            columnEstates[10] = new DataColumn("EstateNew", Type.GetType("System.Boolean")); //czy rynek pierwotny?
            columnEstates[11] = new DataColumn("EstatePrice", Type.GetType("System.Double")); // CENA!
            columnEstates[12] = new DataColumn("CityId", Type.GetType("System.Int32"));
            columnEstates[13] = new DataColumn("AgentId", Type.GetType("System.Int32"));

            estates.Columns.AddRange(columnEstates);

            // generuję same dane
            generateData(agents, cities, estates);

            // tworzę zbiór danych
            EstateDB = new DataSet("EstateDB");
            EstateDB.Tables.Add(estates);
            EstateDB.Tables.Add(agents);
            EstateDB.Tables.Add(cities);

            // tworzę relacje
            DataRelation CityToEstate = new DataRelation("CityToEstate", EstateDB.Tables["Cities"].Columns["CityId"], EstateDB.Tables["Estates"].Columns["CityId"]);
            DataRelation AgentToEstate = new DataRelation("AgentToEstate", EstateDB.Tables["Agents"].Columns["AgentId"], EstateDB.Tables["Estates"].Columns["AgentId"]);
            EstateDB.Relations.Add(AgentToEstate);
            EstateDB.Relations.Add(CityToEstate);

            test = new DataTable[3];
            test[0] = estates;
            test[1] = cities;
            test[2] = agents;
            
            //MyEstates = new DataTable("MyEstates");
            //MyEstates.Columns.Add("EstateId", "");

        }

        private void generateData(DataTable agents, DataTable cities, DataTable estates)
        {
            generateAgents(agents);
            generateCities(cities);
            generateEstates(estates);
        }

        private void generateCities(DataTable cities)
        {
            DataRow city = cities.NewRow();
            city["CityName"] = "Poznań"; cities.Rows.Add(city);

            city = cities.NewRow();
            city["CityName"] = "Warszawa"; cities.Rows.Add(city);

            city = cities.NewRow();
            city["CityName"] = "Wrocław"; cities.Rows.Add(city);

            city = cities.NewRow();
            city["CityName"] = "Opole"; cities.Rows.Add(city);

            city = cities.NewRow();
            city["CityName"] = "Bydgoszcz"; cities.Rows.Add(city);

            city = cities.NewRow();
            city["CityName"] = "Rzeszów"; cities.Rows.Add(city);

            city = cities.NewRow();
            city["CityName"] = "Szczecin"; cities.Rows.Add(city);

            city = cities.NewRow();
            city["CityName"] = "Gdańsk"; cities.Rows.Add(city);

            city = cities.NewRow();
            city["CityName"] = "Gdynia"; cities.Rows.Add(city);

            city = cities.NewRow();
            city["CityName"] = "Sopot"; cities.Rows.Add(city);

            city = cities.NewRow();
            city["CityName"] = "Białystok"; cities.Rows.Add(city);

            city = cities.NewRow();
            city["CityName"] = "Nysa"; cities.Rows.Add(city);

            city = cities.NewRow();
            city["CityName"] = "Katowice"; cities.Rows.Add(city);

            city = cities.NewRow();
            city["CityName"] = "Kraków"; cities.Rows.Add(city);

            city = cities.NewRow();
            city["CityName"] = "Toruń"; cities.Rows.Add(city);
        }

        private void generateAgents(DataTable agents)
        {
            DataRow agent = agents.NewRow();
            agent["AgentName"] = "Apartament Poznań";
            agent["AgentAddress"] = "Wyspiańskiego 14/5";
            agent["AgentVerified"] = true;
            agents.Rows.Add(agent);

            agent = agents.NewRow();
            agent["AgentName"] = "Apartament Zielona Góra";
            agent["AgentAddress"] = "Kupiecka 45/4";
            agent["AgentVerified"] = false; 
            agents.Rows.Add(agent);

            agent = agents.NewRow();
            agent["AgentName"] = "Galeria Imperium";
            agent["AgentAddress"] = "Wojska Polskiego 4";
            agent["AgentVerified"] = true;
            agents.Rows.Add(agent);

            agent = agents.NewRow();
            agent["AgentName"] = "Sielanka Nieruchomości";
            agent["AgentAddress"] = "Stary Port 9/6";
            agent["AgentVerified"] = false;
            agents.Rows.Add(agent);

            agent = agents.NewRow();
            agent["AgentName"] = "Agencja Nieruchomości Reja8";
            agent["AgentAddress"] = "Reja 8/1";
            agent["AgentVerified"] = true;
            agents.Rows.Add(agent);

            agent = agents.NewRow();
            agent["AgentName"] = "Talarczyk / Cheller";
            agent["AgentAddress"] = "Grochowe Łąki 7";
            agent["AgentVerified"] = false;
            agents.Rows.Add(agent);

            agent = agents.NewRow();
            agent["AgentName"] = "PTAK";
            agent["AgentAddress"] = "Ślusarska 10";
            agent["AgentVerified"] = false;
            agents.Rows.Add(agent);

        }

        private void generateEstates(DataTable estates)
        {
            DataRow estate = estates.NewRow();
            estate["EstateArea"] = 53.12;
            estate["EstateBedrooms"] = 3;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "mieszkanie";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Szarych Szeregów 1/1";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "Mieszkanie 3-pokojowe na osiedlu Podolany";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 275000;
            estate["CityId"] = 1;
            estate["AgentId"] = 3;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 200.00;
            estate["EstateBedrooms"] = 4;
            estate["EstateFloors"] = 3;
            estate["EstateType"] = "dom";
            estate["EstateOffer"] = "wynajem";
            estate["EstateFurnished"] = true;
            estate["EstateStreetName"] = "Nowe Miasto";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "DUŻY, TRZY POZIOMOWY DOM W ZABUDOWIE SZEREGOWEJ BEZPOŚREDNIO NAD JEZIOREM SWARZĘDZKIM.";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 2700;
            estate["CityId"] = 1;
            estate["AgentId"] = 1;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 157.00;
            estate["EstateBedrooms"] = 6;
            estate["EstateFloors"] = 2;
            estate["EstateType"] = "dom";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Luboń ";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "BLIŹNIAK DWURODZINNY, 6 POKOI, LUBOŃ Dom w zabudowie bliźniaczej o powierzchni użytkowej 157 m2 mieści się na działce 214 m2 w podpoznańskim Luboniu. Budynek wybudowany w latach '60, rozbudowany o 3/4 wielkości w latach '80. ";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 395000;
            estate["CityId"] = 1;
            estate["AgentId"] = 2;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 97.50;
            estate["EstateBedrooms"] = 4;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "mieszkanie";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Zielona Góra, Osiedle Łużyckie";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "CZTEROPOKOJOWE MIESZKANIE W BLOKU Z WINDĄ. Mieszkanie dwupoziomowe położone na III piętrze bloku trzypiętrowego z windą. Możliwość dokupienia garażu ( 18,3m2) w podziemiu budynku za kwotę 28 500zł.";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 320000;
            estate["CityId"] = 12;
            estate["AgentId"] = 3;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 294.00;
            estate["EstateBedrooms"] = 6;
            estate["EstateFloors"] = 2;
            estate["EstateType"] = "dom";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Kiekrz, Kiekrz";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "Dom wolnostojący o powierzchni 294 m2, oddany do użytku w 2011 roku. Budynek usytuowany na ogrodzonej i zagospodarowanej działce o powierzchni 880 m2. ";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 2500000;
            estate["CityId"] = 2;
            estate["AgentId"] = 4;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 63.20;
            estate["EstateBedrooms"] = 3;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "mieszkanie";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Zielona Góra, Osiedle Dolina Zielona";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "Mieszkanie o pow. 64 m2 położone jest na IV piętrze niskiego bloku zlokalizowanego na terenie Doliny Zielonej. Blok oddany do użytkowania w 1991 roku. Budynek w bardzo dobrym stanie, ma wymieniony i ocieplony dach. Klatka schodowa przestronna, wygodna, czysta, również po remoncie m.in. wstawiono okna PCV i grzejniki panelowe. Do mieszkania przynależy duża piwnica (ok. 10 m2) oraz balkon.";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 230000;
            estate["CityId"] = 2;
            estate["AgentId"] = 5;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 66.60;
            estate["EstateBedrooms"] = 4;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "mieszkanie";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Osiedle Tajne Zielona Góra";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "Mieszkanie o powierzchni 66,6m2 usytuowane na III piętrze w niskim bloku. ";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 209000;
            estate["CityId"] = 3;
            estate["AgentId"] = 6;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 157.31;
            estate["EstateBedrooms"] = 3;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "dom";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Lubuskie, Zielona Góra m., Zielona Góra, Chynów";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "DOM WOLNOSTOJĄCY z jednostanowiskowym garażem w bryle budynku. NA NOWYM OSIEDLU DOMÓW CHYNÓW, osiedle Kolorowe. Budynek położony na prostokątnej działce o powierzchni 700 mkw budowany według projektu Dora pracowni tooba.pl. Jest to budynek wolnostojący, parterowy, niepodpiwniczony z użytkowym poddaszem o powierzchni całkowitej 175,44mkw. W metraż domu wliczono powierzchnię 18,13 mkw garażu jednostanowiskowego. ";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 550000;
            estate["CityId"] = 3;
            estate["AgentId"] = 0;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 59.80;
            estate["EstateBedrooms"] = 3;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "mieszkanie";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Lubuskie, Zielona Góra m., Zielona Góra, Osiedle Zacisze";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "Mieszkanie o powierzchni 59,8 m2 położone jest na ostatnim piętrze IV piętrowego bloku zlokalizowanego na osiedlu Zacisze w Zielonej Górze. Osiedle bardzo dobrze zorganizowane, w pobliżu wszystko co potrzebne do codziennego funkcjonowania, czyli: sklepy, przystanek autobusowy, uczelnia, a jednocześnie w bliskiej odległości las, stadnina koni.";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 199000;
            estate["CityId"] = 4;
            estate["AgentId"] = 1;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 62.00;
            estate["EstateBedrooms"] = 2;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "mieszkanie";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Lubuskie, Zielona Góra m., Zielona Góra, Osiedle Zacisze";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "Mieszkanie o powierzchni 62 m2 położone jest na IV piętrze niskiego bloku zlokalizowanego na osiedlu Zacisze w Zielonej Górze. Budynek jest odremontowany, po termomodernizacji. Jest to bardzo dobrze zorganizowane osiedle, w pobliżu wszystko co potrzebne do codziennego życia, czyli: sklepy, przystanek autobusowy, uczelnia, a jednocześnie w bliskiej odległości las, stadnina koni. Do mieszkania przynależy piwnica. Blok po remoncie - termoocieplenie oraz klatka schodowa odnowiona, położone płytki w grudniu 2013.";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 238000;
            estate["CityId"] = 4;
            estate["AgentId"] = 2;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 39.00;
            estate["EstateBedrooms"] = 1;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "mieszkanie";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Wielkopolskie, Poznań m., Poznań, Dębiec";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "Mieszkanie o powierzchni 39 m2 mieści się na parterze czteropiętrowej kamienicy powstałej ok 1910 roku w Poznaniu przy ul. Krzyżowej. Kamienica po rewitalizacji, z wymienionymi pionami. ";
            estate["EstateNew"] = true;
            estate["EstatePrice"] = 250000;
            estate["CityId"] = 5;
            estate["AgentId"] = 3;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 34.58;
            estate["EstateBedrooms"] = 1;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "mieszkanie";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Wielkopolskie, Poznań m., Poznań, Centrum";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "KAWALERKA NA PODDASZU - ZREWITALIZOWANA KAMIENICA W CENTRUM MIASTA \n Lokal o pow. całkowitej 34,58 m2 / pow. uzytkowa 27,90 m2 na IV piętrze kamienicy. Mieszkanie w stanie deweloperskim - do wykończenia wg własnej aranżacji. Wysokość pomieszczeń 3m. Pełna własność z KW. Kamienica została całkowicie zrewitalizowana. Architekci zadbali o zachowanie klasycznego stylu i stworzenie nowoczesnej funkcjonalności wnętrzom. Wymieniono wszystkie instalacje, podłączono budynek do cieplika miejskiego, odnowiono elewację, wymieniono pokrycie dachowe."; 
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 180000;
            estate["CityId"] = 5;
            estate["AgentId"] = 4;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 30.00;
            estate["EstateBedrooms"] = 1;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "mieszkanie";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = true;
            estate["EstateStreetName"] = " Wielkopolskie, Poznań m., Poznań, Centrum";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "KAWALERKA 30m2, POZNAŃ ŁAZARZ Wyjątkowa stylowa i klimatyczna kawalerka w centrum Poznania (dzielnica Łazarz), 30m2. MIESZKANIE SPRZEDAWANE W PEŁNI WYPOSAŻONE!";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 196000;
            estate["CityId"] = 6;
            estate["AgentId"] = 5;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 35.73;
            estate["EstateBedrooms"] = 1;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "mieszkanie";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Wielkopolskie, Poznań m., Poznań, Centrum";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "KAWALERKA Z BALKONEM - ZREWITALIZOWANA KAMIENICA W CENTRUM MIASTA Lokal o pow. 35,73 m2 na II piętrze kamienicy. Mieszkanie w stanie deweloperskim - do wykończenia wg własnej aranżacji. Wysokość pomieszczeń 3m. Pełna własność z KW. Kamienica została całkowicie zrewitalizowana. Architekci zadbali o zachowanie klasycznego stylu i stworzenie nowoczesnej funkcjonalności wnętrzom. Wymieniono wszystkie instalacje, podłączono budynek do cieplika miejskiego, odnowiono elewację, wymieniono pokrycie dachowe.";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 220000;
            estate["CityId"] = 6;
            estate["AgentId"] = 6;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 54.00;
            estate["EstateBedrooms"] = 2;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "mieszkanie";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Lubuskie, Zielona Góra m., Zielona Góra, Osiedle Przyjaźni";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "Mieszkanie o pow. 54 m2 położone jest na II piętrze 3-piętrowego bloku zlokalizowanego na terenie Osiedla Przyjaźni. Do mieszkania przynależy piwnica. Lokal położony na terenie jednego z najpopularniejszych osiedli w Zielonej Górze";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 177000;
            estate["CityId"] = 7;
            estate["AgentId"] = 0;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 50.70;
            estate["EstateBedrooms"] = 2;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "mieszkanie";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = true;
            estate["EstateStreetName"] = "Lubuskie, Zielona Góra m., Zielona Góra, Osiedle Zacisze";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "Mieszkanie o powierzchni 50,8 m2 położone jest na II piętrze IV piętrowego bloku zlokalizowanego na osiedlu Zacisze w Zielonej Górze. Budynek jest odremontowany, po termomodernizacji. Jest to bardzo dobrze zorganizowane osiedle, w pobliżu wszystko co potrzebne do codziennego życia, czyli: sklepy, przystanek autobusowy, uczelnia, a jednocześnie w bliskiej odległości las, stadnina koni. Do mieszkania przynależy piwnica.";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 168000;
            estate["CityId"] = 7;
            estate["AgentId"] = 1;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 50.10;
            estate["EstateBedrooms"] = 2;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "mieszkanie";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Lubuskie, Zielona Góra m., Zielona Góra, Centrum, Centrum";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "Mieszkanie o pow. 50,10 m2 położone jest na II piętrze niskiego bloku tzw. punktowca w Centrum Zielonej Góry. W mieszkaniu zostały wymienione wszystkie okna. Przed blokiem plac zabaw oraz parking. Teren wokół bloku zadbany.Spokojna i zielona okolica bardzo dobrze skomunikowana z innymi rejonami miasta. ";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 160000;
            estate["CityId"] = 8;
            estate["AgentId"] = 2;
            estates.Rows.Add(estate);
            
            estate = estates.NewRow();
            estate["EstateArea"] = 33.10;
            estate["EstateBedrooms"] = 2;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "mieszkanie";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Lubuskie, Zielona Góra m., Zielona Góra, Centrum";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "Mieszkanie po modernizacji o pow. 33m2 na I piętrze w kamienicy. Mieszkanie jest po generalnym remoncie: nowa instalacja elektryczna, gazowa i kanalizacyjna. Do mieszkania przynależy wspólny strych (z jednym sąsiadem), piwnica oraz komórka idealna na przechowywanie np. rowerów.Nieruchomość znajduje się na dużej posesji, na której znajduje się duże podwórko, komórki lokatorskie, parking.";
            estate["EstateNew"] = true;
            estate["EstatePrice"] = 129500;
            estate["CityId"] = 8;
            estate["AgentId"] = 3;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 98.20;
            estate["EstateBedrooms"] = 3;
            estate["EstateFloors"] = 2;
            estate["EstateType"] = "mieszkanie";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Lubuskie, Zielona Góra m., Zielona Góra, Centrum";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "NOWE MIESZKANIE W KAMERALNYM BUDYNKU W OKOLICACH CENTRUM W ZIELONEJ GÓRZE. NOWOCZESNA KAMIENICA WYKOŃCZONA W NAJWYŻSZYM STANDARDZIE W ZIELONEJ GÓRZE. OSTATNIE MIESZKANIE W BUDYNKU - OKAZYJNA CENA!!! Oferujemy dwupoziomowe mieszkanie o powierzchni 98,2m2 usytuowane na czwartym piętrze.";
            estate["EstateNew"] = true;
            estate["EstatePrice"] = 330000;
            estate["CityId"] = 9;
            estate["AgentId"] = 4;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 60.60;
            estate["EstateBedrooms"] = 4;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "dom";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "SLubuskie, zielonogórski, Stary Kisielin";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "MIESZKANIA NA KAŻDĄ KIESZEŃ! WYJĄTKOWA OFERTA MIESZKAŃ DEWELOPERSKICH W OKAZYJNYCH CENACH. Oferujemy mieszkania w jednopiętrowym budynku w Starym Kisielinie, 5 km od centrum Zielonej Góry. Posiadamy w ofercie 17 mieszkań o powierzchniach od 24,82m2 do 60,95m2. Na parterze znajdują się mieszkania z własnymi ogródkami, a na piętrze z balkonami. Pod budynkiem duży parking do wyłącznego korzystania przez mieszkańców. Mieszkania bezczynszowe ? opłaty tylko za zużyte media.";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 163620;
            estate["CityId"] = 9;
            estate["AgentId"] = 5;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 199.12;
            estate["EstateBedrooms"] = 5;
            estate["EstateFloors"] = 2;
            estate["EstateType"] = "dom";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Lubuskie, Zielona Góra m., Zielona Góra, Jędrzychów";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "Dom wolnostojący o pow. użytkowej ok. 199 m2 położony jest na działce o pow. 751 m2 zlokalizowanej na spokojnym prestiżowym zielonogórskim osiedlu na Jędrzychowie. Dom posiada przytulny ogródek, taras, samodzielny garaż. Cała posesja jest ogrodzona, a sam dom odsunięty w głąb ogrodu. Nasadzenia wzdłuż granicy działki dodatkowo wyciszają otoczenie.";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 519100;
            estate["CityId"] = 10;
            estate["AgentId"] = 6;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 242.70;
            estate["EstateBedrooms"] = 4;
            estate["EstateFloors"] = 2;
            estate["EstateType"] = "dom";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Lubuskie, Zielona Góra m., Zielona Góra, Jędrzychów";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "Dom - segement o pow. ogólnej 242,7 m2, a powieszchni użytkowej wynoszącej 161,8 m2 położony na terenie prestiżowego Osiedla Kamieni Szlachetnych na zielonogórskim Jędrzychowie. Budynek dwukondygnacyjny, całkowicie podpiwniczony z garażem jednostanowiskowym i zagospodarowanym ogrodem leży na działce o pow. 252 m2. Doskonała lokalizacja, dogodny dojazd do centrum miasta.";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 560000;
            estate["CityId"] = 10;
            estate["AgentId"] = 0;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 136.10;
            estate["EstateBedrooms"] = 5;
            estate["EstateFloors"] = 2;
            estate["EstateType"] = "dom";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Wielkopolskie, poznański, Swarzędz, Łowęcin";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "DOM WOLONOSTOJĄCY, 5 POKOI, STAN DEWELOPERSKI PLUS, ŁOWĘCIN k.SWARZĘDZA Dom wolnostojący, piętrowy o powierzchni całkowitej 136,1 m2 (powierzchnia użytkowa 118,76 m2 ) z poddaszem do użytkowania jako strych. Budynek usytuowany na działce 1000 m2 w podpoznańskim Łowęcinie. ";
            estate["EstateNew"] = true;
            estate["EstatePrice"] = 275000;
            estate["CityId"] = 11;
            estate["AgentId"] = 1;
            estates.Rows.Add(estate);
            
            estate = estates.NewRow();
            estate["EstateArea"] = 124.44;
            estate["EstateBedrooms"] = 5;
            estate["EstateFloors"] = 2;
            estate["EstateType"] = "dom";
            estate["EstateOffer"] = "sprzedaż";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Wielkopolskie, poznański, Tarnowo Podgórne, Chyby";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "BLIŹNIAK W STANIE DEWELOPERSKIM, 5 POKOI Z GARAŻEM I OGRODEM, NA PN-ZACH. OD POZNANIA Dom w zabudowie bliźniaczej o powierzchni całkowitej 124,44 m2 (lewa strona bliźniaka) z garażem. Budynek usytuowany na działce 228 m2 w miejscowości położonej na pn-zach. od Poznania. ";
            estate["EstateNew"] = true;
            estate["EstatePrice"] = 460000;
            estate["CityId"] = 11;
            estate["AgentId"] = 2;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 112.00;
            estate["EstateBedrooms"] = 3;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "mieszkanie";
            estate["EstateOffer"] = "wynajem";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Łazarz";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "NIERUCHOMOŚĆ Z MOŻLIWOŚCIĄ STAŁEGO ZAMELDOWANIA, idealna dla osób, które szukają bez czynszowego mieszkania do wynajęcia do stałego zamieszkania.Oferta skierowana do osób pracujących. Wymagane zaświadczenie o zatrudnieniu i dochodach. Bez czynszowe trzypokojowe mieszkanie do remontu w Poznaniu w dzielnicy Łazarz. Nieruchomość o powierzchni 112 m2, położone jest na parterze, w pięciopiętrowej kamienicy z ok. 1900 roku. OPIS TECHNICZNYBudynek w dobrym stanie technicznym, szeroka klatka schodowa utrzymana w względnym stanie. Mieszkanie częściowo wyremontowane (ściany instalacja, częściowo wymienione okna na plastikowe, założone rolety antywłamaniowe). Mieszkanie nie posiada ogrzewania, preferowane ogrzewanie gazowe. Istnieje możliwość zwolnienia Najemcy z kilku miesięcy kwoty najmu w ramach częściowej rekompensaty kosztów remontu.";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 900;
            estate["CityId"] = 12;
            estate["AgentId"] = 3;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 50.00;
            estate["EstateBedrooms"] = 2;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "mieszkanie";
            estate["EstateOffer"] = "wynajem";
            estate["EstateFurnished"] = true;
            estate["EstateStreetName"] = "Wielkopolskie, Poznań m., Poznań, Stare Miasto";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "DO WYNAJĘCIA PRZESTRONNE MIESZKANIE W SPOKOJNEJ DZIELNICY, 2 POKOJE, POZNAŃ, WINIARY, ul. KORONNA Mieszkanie o powierzchni 50mkw mieści się na IV piętrze czteropiętrowego bloku z 1960 roku, wyremontowanego w 2010r. Budynek w bardzo dobrym stanie technicznym, z domofonem. Z parkingiem po dwóch stronach bloku.";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 1400;
            estate["CityId"] = 12;
            estate["AgentId"] = 4;
            estates.Rows.Add(estate);

            estate = estates.NewRow();
            estate["EstateArea"] = 60.00;
            estate["EstateBedrooms"] = 2;
            estate["EstateFloors"] = 1;
            estate["EstateType"] = "mieszkanie";
            estate["EstateOffer"] = "wynajem";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Wielkopolskie, Poznań m., Poznań, Rataje";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "Mieszkanie o powierzchni użytkowej 59,93 m2 mieści się na pierwszym piętrze czteropiętrowego budynku z 2000 roku. Blok w bardzo dobrym stanie technicznym, z szeroką klatką schodową. OPIS TECHNICZNY: Mieszkanie składa się z 2 POKOI (ok 18 m2, 10 m2), gdzie z większego jest wyjście na BALKON, KUCHNI z pełną zabudową, ŁAZIENKI z wanną GARDEROBY z półkami oraz KORYTARZA. Standard wykończenia: ściany - malowane; podłogi - panele, terakota; drzwi - drewniane; okna - nowe PCV. ";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 1500;
            estate["CityId"] = 13;
            estate["AgentId"] = 5;
            estates.Rows.Add(estate);
            
            estate = estates.NewRow();
            estate["EstateArea"] = 150.00;
            estate["EstateBedrooms"] = 3;
            estate["EstateFloors"] = 2;
            estate["EstateType"] = "dom";
            estate["EstateOffer"] = "wynajem";
            estate["EstateFurnished"] = true;
            estate["EstateStreetName"] = "Wielkopolskie, Poznań m., Poznań, Winogrady";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "ŚWIETNA OFERTA, BLISKO CENTRUM NOWOCZEŚNIE WYKOŃCZONY DOM NA STARYCH WINOGRADACH - BLIŹNIAK DOM JEST BEZPOŚREDNIO PO REMONCIE! OPIS BUDYNKU: bliźniak o powierzchni użytkowej 120m2, usytuowany na pięknie zagospodarowanej działce Dom po generalnym remoncie, wykończony i wyposażony w wysokim standardzie. UKŁAD POMIESZCZEŃ: Przyziemie: osobne mieszkanie z wyjściem na ogród, łazienką i kuchnią wyposażoną w meble wraz ze sprzętem; ponadto w przyziemiu znajduje się garaż oraz pralnia z kotłownią Parter: salon z jadalnią, kuchnia z wyjściem na taras, wc. Piętro: trzy sypialnie, łazienka. CENA NIERUCHOMOŚCI OBEJMUJE UMEBLOWANIE DOMU MEBLAMI WYSOKIEJ JAKOŚCI, WIDOCZNYMI NA ZDJĘCIACH. LOKALIZACJA: Blisko do przystanków tramwajowych i autobusowych.";
            estate["EstateNew"] = true;
            estate["EstatePrice"] = 8000;
            estate["CityId"] = 13;
            estate["AgentId"] = 6;
            estates.Rows.Add(estate);
            
            estate = estates.NewRow();
            estate["EstateArea"] = 228.00;
            estate["EstateBedrooms"] = 4;
            estate["EstateFloors"] = 2;
            estate["EstateType"] = "dom";
            estate["EstateOffer"] = "wynajem";
            estate["EstateFurnished"] = true;
            estate["EstateStreetName"] = "Wielkopolskie, Poznań m., Poznań, Zieliniec";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "Dom z użytkowym poddaszem o powierzchni całkowitej 228 m2, użytkowej: 125 m2, oddany do użytku w 2009 roku. Budynek usytuowany na działce o powierzchni 695 m2. Działka obsadzona roślinnością, ogród jest zadbany. Od frontu dom ogrodzony kutą bramą i słupkami z klinkieru. ";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 5000;
            estate["CityId"] = 14;
            estate["AgentId"] = 0;
            estates.Rows.Add(estate);
            
            estate = estates.NewRow();
            estate["EstateArea"] = 200.00;
            estate["EstateBedrooms"] = 7;
            estate["EstateFloors"] = 4;
            estate["EstateType"] = "dom";
            estate["EstateOffer"] = "wynajem";
            estate["EstateFurnished"] = false;
            estate["EstateStreetName"] = "Wielkopolskie, Poznań m., Poznań, Zieliniec";
            estate["EstateCountry"] = "Polska";
            estate["EstateDescription"] = "OFERTA BEZPOŚREDNIA. Wynagrodzenie pośrednika ponosi wynajmujący.PRZY DŁUGOTRWAŁYM NAJMIE, MOŻLIWOŚĆ ZNACZNEJ NEGOCJACJI CENY!DUŻY, TRZY POZIOMOWY DOM W ZABUDOWIE SZEREGOWEJ BEZPOŚREDNIO NAD JEZIOREM SWARZĘDZKIM.Dom o powierzchni 200 m2 mieści się na działce o powierzchni 120 m2 w bezpośrednim sąsiedztwie Jeziora Swarzędzkiego. Budynek wybudowany w latach 90-tych, w bardzo dobrym stanie technicznym.";
            estate["EstateNew"] = false;
            estate["EstatePrice"] = 2700;
            estate["CityId"] = 0;
            estate["AgentId"] = 1;
            estates.Rows.Add(estate);
        }

        public DataSet getDataSet()
        {
            return EstateDB.Clone();
        }

        public DataTable getAllData(string tableName)
        {
            switch (tableName)
            {
                case "cities":
                    return test[1];
                    break;
                case "agents":
                    return test[2];
                    break;
                case "estates":
                    return test[0];
                    break;
                default:
                    return new DataTable();
                    break;
            }
        }
    }
}
