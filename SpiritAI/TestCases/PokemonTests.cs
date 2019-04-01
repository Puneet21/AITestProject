using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SpiritAI.Utilities;
using Xunit;

namespace SpiritAI.TestCases
{
    public class PokemonTests : PokemonBase
    {
        //Theory is used to write data driven test cases so running 
        // the same test case for two sets of data that is 51 and 22 
        [Theory]
        [InlineData(51)]
        [InlineData(22)]
        public void PokemonAbilitySearch(int number)
        {
            Logger.Info("Starting test case " + System.Reflection.MethodBase.GetCurrentMethod().Name + " with ability number "+number.ToString());
            try
            {
                //Step1 : Get ablility on Particular position and save in string
                Logger.Info("Step1:  Get ablility on Particular position and save in string");
                String abilityName = getAbilityOnPosition(number);

                //Step2 : Get no of pokemon using this ability
                //a  - List of pokemon with ability and saving in Json Array
                Logger.Info("Step2a: List of pokemon with ability and saving in Json Array");
                JArray listPokemonsWithAbility = pokemonsWithAbility(number);

                //b - count of Pokemon with ability
                Logger.Info("Step2b: Count of Pokemon with ability");
                int noOfPokemonWithAbility = listPokemonsWithAbility.Count;

                //Step3: Get Last pokemon in the list of Pokemon with ability
                Logger.Info("Step3: Get Last pokemon in the list of Pokemon with ability");
                string lastPokemonNameinList = listPokemonsWithAbility[noOfPokemonWithAbility - 1].ToString();

                //Step4: Open Browser - Search for lastPokemon from the list on Google
                Logger.Info("Step4: Open Browser - Search for lastPokemon from the list on Google");
                Logger.Info("Step4a: Open Browser");
                OpenBrowser(Browser.Chrome);
                Logger.Info("Step4b: Search for lastPokemon from the list on Google");
                List<string> searchResults = searchAndGetResultListFor(lastPokemonNameinList);

                //Step5: Assert on Results
                Logger.Info("Step5: Assertion on Results");
                // Getting name of the pokemon without "-female" stuff for comparison
                string textForAssertion = lastPokemonNameinList.Substring(0, lastPokemonNameinList.IndexOf("-"));
                Logger.Info("Searching for " + textForAssertion);
                foreach (string result in searchResults)
                {
                    Logger.Info("Results shows " + result.ToString().ToLower());
                    //checking for the text in search headers after converting it to Lower
                    Assert.Contains(textForAssertion.ToLower(), result.ToLower());
                }
                
            }
            catch(Exception e)
            {
                Assert.True(false, e.Message);
            }
            finally
            {
                _driver.Quit();
                Logger.Info("Ending test case " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }


    }
}
