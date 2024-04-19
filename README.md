# inclusive-code-reviews-demo

Source code for my presentation "Using ML.NET and LLMs in C#"

## Prerequisites

* Install the [.NET SDK](https://dotnet.microsoft.com/download)
* Some IDE like Visual Studio or Visual Studio Code
* Install the `mlnet` .NET global tool

```sh
$ dotnet tool install -g mlnet
Tool 'mlnet' was reinstalled with the stable version (version '16.2.0').
```

## Data

This came from a dataset on Hugging Face, with the Creative Commons license:

* https://huggingface.co/datasets/OxAISH-AL-LLM/wiki_toxic

The only thing I did to the dataset was remove a column and rename column titles.

## Train the model

We want to use the "classification" option:

```sh
$ mlnet --help
Usage:
  mlnet [options] [command]

Options:
  --version         Show version information.
  -?, -h, --help    Show help and usage information.

Commands:
  classification          Train a custom ML.NET model for classification. Learn more about classification at
                          aka.ms/cli-classification.
  regression              Train a custom ML.NET model for regression. Learn more about regression at
                          aka.ms/cli-regression.
  recommendation          Train a custom ML.NET model for recommendation. Learn more about recommendation at
                          aka.ms/cli-recommendation.
  image-classification    Train a custom ML.NET model for image classification. Learn more about classification at      
                          aka.ms/cli-image-classification.
```

You can run the command yourself, or see `train.ps1` for a script that
does it for you:

```sh
$ mlnet classification --dataset data/train.csv --label-col 1 --has-header true --train-time 60 --name InclusiveCodeReviews
Start Training
|     Trainer                              MicroAccuracy  MacroAccuracy  Duration #Iteration                     |
|1    AveragedPerceptronOva                       0.9542         0.8230      38.5          1                     |      
|2    SdcaMaximumEntropyMulti                     0.9496         0.7931      29.6          2                     |      
|3    LightGbmMulti                               0.9572         0.8375     203.6          3                     |      
|4    SymbolicSgdLogisticRegressionOva            0.9497         0.7868      47.2          4                     |      
|5    FastTreeOva                                 0.9579         0.8244     242.2          5                     |      
|6    LinearSvmOva                                0.9517         0.8361      27.7          6                     |      
                                                                                                                        
===============================================Experiment Results=================================================      
------------------------------------------------------------------------------------------------------------------
|                                                     Summary                                                    |
------------------------------------------------------------------------------------------------------------------      
|ML Task: multiclass-classification                                                                              |      
|Dataset: D:\src\inclusive-code-reviews-demo\data\train.csv                                                      |      
|Label : istoxic                                                                                                 |      
|Total experiment time : 588.8074398 Secs                                                                        |      
|Total number of models explored: 6                                                                              |      
------------------------------------------------------------------------------------------------------------------      

|                                              Top 5 models explored                                             |      
------------------------------------------------------------------------------------------------------------------      
|     Trainer                              MicroAccuracy  MacroAccuracy  Duration #Iteration                     |      
|1    FastTreeOva                                 0.9579         0.8244     242.2          1                     |      
|2    LightGbmMulti                               0.9572         0.8375     203.6          2                     |      
|3    AveragedPerceptronOva                       0.9542         0.8230      38.5          3                     |      
|4    LinearSvmOva                                0.9517         0.8361      27.7          4                     |      
|5    SymbolicSgdLogisticRegressionOva            0.9497         0.7868      47.2          5                     |      
------------------------------------------------------------------------------------------------------------------      

Code Generated
Generated C# code for model consumption: D:\src\inclusive-code-reviews-demo\InclusiveCodeReviews\InclusiveCodeReviews.ConsoleApp
Check out log file for more information: D:\temp\mlnet\log.txt
Exiting ...
```
