using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Solution
{


    class Program
    {




        static void Main(string[] args)
        {

            string urlKyiv = "https://goweather.herokuapp.com/weather/Kyiv";
            string urlOdessa = "https://goweather.herokuapp.com/weather/Odesa";

            
            HttpWebRequest webRequestKyiv = (HttpWebRequest)WebRequest.Create(urlKyiv);
            HttpWebRequest webRequestOdessa = (HttpWebRequest)WebRequest.Create(urlOdessa);
            
            
            HttpWebResponse webResponseKyiv = (HttpWebResponse)webRequestKyiv.GetResponse();
            HttpWebResponse webResponseOdessa = (HttpWebResponse)webRequestOdessa.GetResponse();

            
            
            string responseKyiv;
            string responseOdessa;

            
            
            using (StreamReader streamKyiv = new StreamReader(webResponseKyiv.GetResponseStream()))
            {
                responseKyiv = streamKyiv.ReadToEnd();
            }            
            
            using (StreamReader streamOdessa = new StreamReader(webResponseOdessa.GetResponseStream()))
            {
                responseOdessa = streamOdessa.ReadToEnd();
            }



            WeatherResponseKyiv weatherKyiv = JsonConvert.DeserializeObject<WeatherResponseKyiv>(responseKyiv);
            WeatherResponseOdessa weatherOdessa = JsonConvert.DeserializeObject<WeatherResponseOdessa>(responseOdessa);



            Console.WriteLine("Temperature in Kyiv: " + weatherKyiv.temperature);
            Console.WriteLine("Temperature in Odessa: " + weatherOdessa.temperature);

        }
    }
}
