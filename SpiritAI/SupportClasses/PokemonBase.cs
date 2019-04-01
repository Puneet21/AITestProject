using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpiritAI
{
    public class PokemonBase
    {
        public static IWebDriver _driver;
        string endPoint = "https://pokeapi.co/api/v2/";

        public int getAbility(int number)
        {
            try
            {
                
                string url = endPoint + "ability/" + number + "/";
                JObject rss = getResponse(url);
                JArray categories = (JArray)rss["pokemon"];
                return categories.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string getAbilityOnPosition(int number)
        {
            try
            {
                string url = endPoint + "ability/" + number + "/";
                JObject rss = getResponse(url);
                string abilityName = rss["name"].Value<string>();
                return abilityName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public JArray pokemonsWithAbility(int number)
        {
            try
            {
                string url = endPoint + "ability/" + number + "/";
                //Saving JSON response
                JObject jsonResponse = getResponse(url);
                //Getting Pokemon list in JsonARRAY
                JArray pokemonAttributes = (JArray)jsonResponse["pokemon"];
                //Creating new Array to save just names of Pokemon
                JArray pokemonNames = new JArray();
                //Iterating Pokemon List and added Names to pokemonNames
                foreach (var attribute in pokemonAttributes)
                {
                    pokemonNames.Add(attribute["pokemon"]["name"].Value<string>());
                }
                //Returning Array
                return pokemonNames;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Enum to provide standard set of inputs
        public enum Browser
        {
            Chrome, Mozilla, IE

        }

        //Method to return Browser Driver based on Preference
        public void OpenBrowser(Browser browser)
        {
            try
            {
                switch(browser)
                {
                    case Browser.Chrome:
                        _driver = new ChromeDriver();
                        _driver.Navigate().GoToUrl("http://google.com");
                        break;
                    default:
                        break;
                }                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<string> searchAndGetResultListFor(string pokemonName)
        {
            try
            {
                List<string> resultList = new List<string>();
                _driver.FindElement(By.Name("q")).SendKeys(pokemonName + Keys.Return);
                IList<IWebElement> results = _driver.FindElements(By.XPath("//div[@class='srg']/div[@class='g']//a/h3"));
                foreach (var res in results)
                {
                    resultList.Add(res.Text);
                }
                return resultList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }




        public JObject getResponse(string requestURL)
        {
            try
            {
                //Creating JSON Object
                JObject jsonResponse = new JObject();
                //Creating WebRequest with URL (endPoint plus API path)
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestURL);
                //Type of Request
                request.Method = "Get";
                //Content Tyoe
                request.ContentType = "application/json";
                //Generating Response
                WebResponse webResponse = request.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                //Reading Response 
                StreamReader responseReader = new StreamReader(webStream);
                //Convert response from String to Json
                jsonResponse = JObject.Parse(responseReader.ReadToEnd());
                responseReader.Close();
                //Returning Json Response
                return jsonResponse;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
