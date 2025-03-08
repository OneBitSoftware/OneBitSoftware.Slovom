# OneBitSoftware.Slovom
![test](https://github.com/OneBitSoftware/OneBitSoftware.Slovom/actions/workflows/dotnet.yml/badge.svg)
![](https://img.shields.io/badge/OneBit-Software-33ccff)

A .NET library that converts currency values into words in Bulgarian for accounting purposes.

Example: Input: `32048.27` Outpud: `тридесет и две хиляди и четиридесет и осем лева и 27 ст.`

## Functionality
- It takes into consideration the [grammatical gender](https://en.wikipedia.org/wiki/Grammatical_gender).
- It writes decimal fractions in the short form: `X лева и ст.` when the value is above zero, and the full word when it is under the value of `1`: `девет стотинки`.
- The current maximum value is `999999.99` and the minimum is `0.`.

## AI Story
This project is my first attempt to build something with GitHub Copilot. I did my best to not give up on it, however my patience was over at one point.
GitHub Copilot just couldn't get my requirements thoroughly enough and it never gave something that works without me intervening.
I made many attempts to improve functions with detailed prompts, but it never gave enough value.

Generating InlineData for the tests failed into an infinite loop (and the token limit kicked in).

Nothing generated as code passed all the tests no matter how I structured prompts.

I eventually had to correct the code myself. The end result is an abomination, but it works.

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

## Contributing
Feel free to raise a PR to improve the code quality or add new features.

## Credits
Inspired by:
- https://github.com/imalchev/Slovom
- https://georgi.unixsol.org/programs/num2bgmoney.php/view/
- https://github.com/stuckata/slovom-js
