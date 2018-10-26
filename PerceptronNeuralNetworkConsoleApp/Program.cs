using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronNeuralNetworkConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[,] imputs = {
                         {0,0},
                         {0,1},
                         {1,0},
                         {1,0},
        };
            int[] outputs = { 0, 1, 1, 1 };

          
            Random random = new Random();

            double[] weights = {
                random.NextDouble(),
                random.NextDouble(),
                random.NextDouble(),
            };
        

            double learningRate = 0.1;
            double totalError = 1;


            while (totalError > 0)
            {
                totalError = 0;
                for (int sample = 0; sample < outputs.Length; ++sample)
                {
                    int x1 = imputs[sample, 0];
                    int x2 = imputs[sample, 1];
                    int output = CalculateOutput(x1, x2, weights);

                    int error = outputs[sample] - output;

                    weights[0] += learningRate * error * 1;
                    weights[1] += learningRate * error * x1;
                    weights[2] += learningRate * error * x2;


                    totalError += Math.Abs(error);
                }

                Console.WriteLine("Results: [{0:0.0}|{1:0.0}|{2:0.0}]", weights[0], weights[1], weights[2]);
                for (int i = 0; i < outputs.Length; ++i)
                {
                    int x1 = imputs[i, 0];
                    int x2 = imputs[i, 1];
                    int y = CalculateOutput(x1, x2, weights);

                    Console.WriteLine("{0},{1} = {2}", x1, x2, y);
                }

                Console.WriteLine();

            }

            Console.ReadKey();
        
        }
        
        private static int CalculateOutput(int x1, int x2, double[] weights)
        {
            double sum = weights [1] * x1 + weights[2] * x2 + weights[0] * 1;
            return (sum >= 0) ? 1 : 0;
        }
    }
}
