using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace weatherApp
{
    internal class weatherApi
    {
        private static String api = "92b87b907bc245d768b29aa895323423";

        private String name,temp,description;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Temp
        {
            get { return temp; }
            set { temp = value; }
        }
        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public weatherApi()
        {

        }
        public void getApi(String city)
        {
            String conApi = "https://api.openweathermap.org/data/2.5/weather?q=" + city +"&mode=xml&appid=" + api + "&units=metric&lang=tr";
            XDocument weather=XDocument.Load(conApi);

             Name=weather.Descendants("city").ElementAt(0).Attribute("name").Value;
             Temp = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
             Description = weather.Descendants("weather").ElementAt(0).Attribute("value").Value;
        }

    }
}
