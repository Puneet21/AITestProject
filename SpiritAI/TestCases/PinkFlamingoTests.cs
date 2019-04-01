using System;
using System.Collections.Generic;
using System.Diagnostics;
using SpiritAI.Utilities;
using Xunit;

namespace SpiritAI.TestCases
{

    public class PinkFlamingoTests : PinkFlamingoBase
    {

        //Data driven test to unit test the Fibanocci Code
        [Theory]
        [InlineData(0, true)]
        [InlineData(2, true)]
        [InlineData(4)]
        [InlineData(5, true)]
        [InlineData(9)]
        [InlineData(13, true)]
        public void TestFibonacci(int number, Boolean result = false)
        {
            Logger.Info("Starting test case " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            Assert.Equal(result, isFibonacci(number));
        }

        //Data driven test to unit test the Multiple of 3
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3, true)]
        [InlineData(5)]
        [InlineData(9, true)]
        [InlineData(13)]
        public void TestX3(int number, Boolean result = false)
        {
            Logger.Info("Starting test case "+ System.Reflection.MethodBase.GetCurrentMethod().Name +" with input "+number +" "+result );
            Assert.Equal(result, isX3(number));
            Logger.Info("Ending test case " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        //Data driven test to unit test the Multiple of 5
        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(15, true)]
        [InlineData(9)]
        [InlineData(13)]
        public void TestX5(int number, Boolean result = false)
        {
            Logger.Info("Starting test case " + System.Reflection.MethodBase.GetCurrentMethod().Name + " with input " + number + " " + result);
            Assert.Equal(result, isX5(number));
            Logger.Info("Ending test case " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        //Data driven test to unit test the Multiple of 3 and 5
        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(15, true)]
        [InlineData(9)]
        [InlineData(13)]
        public void TestX5X3(int number, Boolean result = false)
        {
            Logger.Info("Starting test case " + System.Reflection.MethodBase.GetCurrentMethod().Name + " with input " + number + " " + result);
            Assert.Equal(result, isX5(number) && isX3(number));
            Logger.Info("Ending test case " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        //Data driven test to unit test the Multiple of 3 and 5 plys Fibonacci
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(8)]
        [InlineData(9)]
        public void TestX5X3PlusFibonacci(int number, Boolean result = false)
        {
            Logger.Info("Starting test case " + System.Reflection.MethodBase.GetCurrentMethod().Name + " with input " + number + " " + result);
            Assert.Equal(result, isX5(number) && isX3(number) && isFibonacci(number));
            Logger.Info("Ending test case " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        public void Print0to100()
        {
            //for multiples of three print "Fizz" instead of the number and 
            //for multiples of five print "Buzz".
            //For numbers which are multiples of both three and five print "FizzBuzz".
            //Then extend the program to say "Flamingo" when a number is a member of the Fibonacci sequence, 
            //and "Pink Flamingo" when it is a multiple of 3 and 5 and a member of the Fibonacci sequence.

            //Instead of creating Console Application I am creating a List which will have 101 records 
            //and it will display Fizz, buzz, FizzBuzz, Flamingo, PinkFlamingo or just number as 
            //per the conditon stated above
            Logger.Info("Starting test case " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<string> a = new List<string>();
            
            for (int i = 0; i <= 100; i++)
            {
                if (isX3(i) && isX5(i) && isFibonacci(i))
                {
                    a.Add("PinkFlamingo");
                }
                else if (isFibonacci(i))
                {
                    a.Add("Flamingo");
                }
                else if (isX3(i) && isX5(i))
                {
                    a.Add("FizzBuzz");
                }
                else if (isX3(i))
                {
                    a.Add("Fizz");
                }
                else if (isX5(i))
                {
                    a.Add("Buzz");
                }
                else
                {
                    a.Add(i.ToString());
                }    

            }
            Console.WriteLine(a);
            Logger.Info("Ending test case " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

    }
}
