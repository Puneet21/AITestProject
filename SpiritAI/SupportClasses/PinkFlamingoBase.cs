using System;
using SpiritAI.Utilities;

namespace SpiritAI
{
    public class PinkFlamingoBase
    {
        string errorMessage = string.Empty;
        // method to test if a number is multiple of 3 and is between 0 and 100
        public bool isX3(int number)
        {
            try
            {
                Logger.Info("Checking if number is multiple of 3 or not");
                //not considering 0 for multiple of 3
                if (number>0 && number<=100 && number % 3 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e) {

                throw new Exception(e.Message);
            }
        }

        // method to test if a number is multiple of 5 and is between 0 and 100
        public bool isX5(int number)
        {
            try
            {
                //not considering 0 as a multiple of 5
                Logger.Info("Checking if number is multiple of 5 or not");
                if (number > 0 && number <= 100 && number % 5 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        // method to test if a number is Fibonacci and is between 0 and 100
        public bool isFibonacci(int number)
        {
            try
            {
                //Considering zero in Fibonacci Series
                Logger.Info("Checking if number is multiple of fibonacii or not");
                if (number >= 0 && number <= 100 &&(isPerfectSquare(5 * number * number + 4) ||
              isPerfectSquare(5 * number * number - 4)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public bool isPerfectSquare(int number)
        {
            // Calculating SQ
            int s = (int)Math.Sqrt(number);
            return (s * s == number);

        }




    }
}
