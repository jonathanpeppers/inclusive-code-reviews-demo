//*****************************************************************************************
//*                                                                                       *
//* This is an auto-generated file by Microsoft ML.NET CLI (Command-Line Interface) tool. *
//*                                                                                       *
//*****************************************************************************************

using System;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using InclusiveCodeReviews.Model;

namespace InclusiveCodeReviews.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new OpenAIClient(Environment.GetEnvironmentVariable("MY_OPENAI_KEY"));

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
                Console.WriteLine("=============== End of ML.NET output ===============");

                var chatCompletionsOptions = new ChatCompletionsOptions
                {
                    DeploymentName = "gpt-3.5-turbo",
                    ResponseFormat = ChatCompletionsResponseFormat.JsonObject,
                    Messages =
                    {
                        new ChatRequestSystemMessage("You are an assistant that only replies with exactly three options as a JSON array, which is not indented and contains no new lines. For example: { \"suggestions\" : [ \"1\", \"2\", \"3\" ] }"),
                        new ChatRequestSystemMessage("You are expert software engineer that is particularly good at writing inclusive, well-written, thoughtful code reviews."),
                        new ChatRequestUserMessage($"Suggest three polite alternatives to the code review comment: {sampleData.Text}"),
                    }
                };

                var response = await client.GetChatCompletionsAsync(chatCompletionsOptions);
                Console.WriteLine(response.Value.Choices[0].Message.Content);
                Console.WriteLine("=============== End of OpenAI output ===============");
            }
        }
    }
}
