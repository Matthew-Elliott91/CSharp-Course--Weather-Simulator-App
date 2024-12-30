using System.Diagnostics;

namespace CSharp_Course__Weather_Simulator_App
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            // Ask user the amount of days to simulate
            Console.WriteLine("Enter the number of days to simulate:");
            // Stores user input to an int 
            int days = int.Parse(Console.ReadLine());

            // Intialises an array with the amount of days as its length
            int[] temperature = new int[days];
            // Declares an array with the possible conditions
            string[] conditions = { "Sunny", "Rainy", "Cloudy", "Snowy" };
            // Declares an empty array of strings with days as its lenght
            string[] weatherConditions = new string[days];

            // Creatges a new class of random
            Random random = new Random();


            // For loop with the number of days as its length
            for (int i = 0; i < days; i++)
            {
                // Fills the temperature array with random temps between -10 and 40
                temperature[i] = random.Next(-10, 40);
                // If temp is higher than 2 the condition cant be snowy
                if (temperature[i] > 2)
                {
                    weatherConditions[i] = conditions[random.Next(conditions.Length -1)];
                } 
                // If the temp is lower than 5 it cant be sunny
                else if (temperature[i] < 5)
                {
                    weatherConditions[i] = conditions[random.Next(1, conditions.Length)];
                }
                else
                {
                    weatherConditions[i] = conditions[random.Next(conditions.Length)];
                }
            }

            
            

                


            

            // Prints to console
            for (int i = 0;i < days; i++)
            {
                Console.WriteLine($"The temp on day {i + 1} is {temperature[i]} the conditons were {weatherConditions[i]}");
            }
            Console.WriteLine($"The average temperature was {CalculateAverageTemp(temperature)}");
            Console.WriteLine($"The maximum temperature was {temperature.Max()}");
            Console.WriteLine($"The minimum temperature was {MinTemperature(temperature)}");
            Console.WriteLine($"The most common condition was {MostCommonCondition(weatherConditions)}");
             
        }

        static string MostCommonCondition(string[] array)
        {
            int counter = 0;
            string mostCommonCondition = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                int tempCount = 0;
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] == array[i])
                    {
                        tempCount++;
                    }
                }
                if (tempCount > counter)
                {
                    counter = tempCount;
                    mostCommonCondition = array[i];
                }
            }
            return mostCommonCondition;
        }
        static double CalculateAverageTemp(int[] array)
        {
            int sumOfArray = 0;
            foreach (int number in array)
            {
                sumOfArray += number;
            }
            double averageTemp = (double)sumOfArray / array.Length;
            return averageTemp;
        }
        static int MinTemperature(int[] array)
        {
            int lowestNumber = 0;
            foreach(int temp in array)
            {
                if (temp < lowestNumber)
                {
                    lowestNumber = temp;
                }
            }
            return lowestNumber;
        }

       
    }
}
