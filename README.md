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
```
