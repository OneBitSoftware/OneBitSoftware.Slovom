# OneBitSoftware.Slovom
![test](https://github.com/OneBitSoftware/OneBitSoftware.Slovom/actions/workflows/dotnet.yml/badge.svg)

A .NET library that converts currency values into words in Bulgarian for accounting purposes.

## Functionality
- It takes into consideration the [grammatical gender](https://en.wikipedia.org/wiki/Grammatical_gender).
- It writes decimal fractions in the short form: `X лева и ст.` when the value is above zero, and the full word when it is under the value of `1`: `девет стотинки`.
- The current maximum value is `999999.99` and the minimum is `0.`.

## Installation
You can install the OneBitSoftware.Slovom assembly through the NuGet package [NuGet](https://www.nuget.org/packages/OneBitSoftware.Slovom):
```
Install-Package OneBitSoftware.Slovom
```
Or via the .NET Core command line interface:
```
dotnet add package OneBitSoftware.Slovom
```

## Examples

|Input|Output|
|--------|-------|
|0|нула лева|
|1|един лев|
|2|два лева|
|19|деветнадесет лева|
|0.1|десет стотинки|
|1.20|един лев и 20 ст.|
|1019.78|хиляда и деветнадесет лева и 78 ст.|
|1119.78|хиляда сто и деветнадесет лева и 78 ст.|
|32478.27|тридесет и две хиляди четиристотин седемдесет и осем лева и 27 ст.|

## Credits
Inspired by:
- https://github.com/imalchev/Slovom
- https://georgi.unixsol.org/programs/num2bgmoney.php/view/
- https://github.com/stuckata/slovom-js
