param
(
    [string] $name = 'InclusiveCodeReviews',
    [int] $seconds = 60
)

$ErrorActionPreference = 'Stop'

& mlnet classification --dataset data/train.csv --label-col 1 --has-header true --train-time $seconds --name $name
