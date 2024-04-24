//*****************************************************************************************
//*                                                                                       *
//* This is an auto-generated file by Microsoft ML.NET CLI (Command-Line Interface) tool. *
//*                                                                                       *
//*****************************************************************************************

using System;
using InclusiveCodeReviews.Model;

namespace InclusiveCodeReviews.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter some text:");

                // Create single instance of sample data from first line of dataset for model input
                ModelInput sampleData = new ModelInput()
                {
                    Text = Console.ReadLine(),
                };

                // Make a single prediction on the sample data and print results
                var predictionResult = ConsumeModel.Predict(sampleData);

                Console.WriteLine("Using model to make single prediction -- Comparing actual Istoxic with predicted Istoxic from sample data...\n\n");
                Console.WriteLine($"Text: {sampleData.Text}");
                Console.WriteLine($"\n\nPredicted Istoxic value {predictionResult.Prediction} \nPredicted Istoxic scores: [{String.Join(",", predictionResult.Score)}]\n\n");
                Console.WriteLine("=============== End of process, hit any key to finish ===============");
            }
        }
    }
}
