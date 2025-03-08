# OneBitSoftware.Slovom
![test](https://github.com/OneBitSoftware/OneBitSoftware.Slovom/actions/workflows/dotnet.yml/badge.svg)

A .NET library that converts currency values into words in Bulgarian for accounting purposes.

It takes into consideration the [grammatical gender](https://en.wikipedia.org/wiki/Grammatical_gender).

It writes our decimal fractions in the short form: "X лева и ст".

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

## Credits
Inspired by:
- https://github.com/imalchev/Slovom
- https://georgi.unixsol.org/programs/num2bgmoney.php/view/
- https://github.com/stuckata/slovom-js
