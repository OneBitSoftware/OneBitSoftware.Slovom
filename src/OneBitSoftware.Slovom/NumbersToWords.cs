namespace OneBitSoftware.Slovom;

using OneBitSoftware.Slovom.Currencies;

public static class NumbersToWords
{
    private static string ConvertWholeNumber(int number, NumberWordsVocabulary numberWordsVocabulary) =>
        number switch
        {
            < 20 => numberWordsVocabulary.NumbersZeroToNineteen[number],
            < 100 => Tens(number, numberWordsVocabulary),
            < 1000 => Hundreds(number, numberWordsVocabulary),
            < 10000 => Thousands(number, numberWordsVocabulary),
            < 100000 => TensOfThousands(number, numberWordsVocabulary),
            _ => "Числото е твърде голямо"
        };

    private static string Tens(int n, NumberWordsVocabulary numberWordsVocabulary)
    {
        if (n < 20) return numberWordsVocabulary.NumbersZeroToNineteen[n];

        var i = n / 10;
        var d = n % 10;

        return numberWordsVocabulary.TensMultiples[i] + (d == 0 ? "" : " и " + numberWordsVocabulary.NumbersZeroToNineteen[d]);
    }

    private static string Hundreds(int n, NumberWordsVocabulary numberWordsVocabulary)
    {
        var i = n / 100;
        var d = n % 100;

        if (n < 120)
        {
            if (d == 0) return numberWordsVocabulary.HundredsMultiples[i];
            
            return numberWordsVocabulary.HundredsMultiples[i] + " и " + numberWordsVocabulary.NumbersZeroToNineteen[d];
        }

        if (n < 200) return numberWordsVocabulary.HundredsMultiples[i] + " " + ConvertWholeNumber(d, numberWordsVocabulary);

        if (d < 20) return numberWordsVocabulary.HundredsMultiples[i] + (d == 0 ? "" : " и " + ConvertWholeNumber(d, numberWordsVocabulary));
        
        return numberWordsVocabulary.HundredsMultiples[i] + (d == 0 ? "" : " " + ConvertWholeNumber(d, numberWordsVocabulary));
    }

    private static string Thousands(int n, NumberWordsVocabulary numberWordsVocabulary)
    {
        var i = n / 1000;
        var d = n % 1000;

        if (n == 1000) return "хиляда";

        if (n is > 1000 and < 1099) return "хиляда и " + Tens(d, numberWordsVocabulary);

        if (n is > 1099 and < 2000) return "хиляда " + Hundreds(d, numberWordsVocabulary);

        if (d == 0) return numberWordsVocabulary.SingleDigitsNeutral[i] + " хиляди"; // 2000,3000,4000, etc

        if (d < 100) return numberWordsVocabulary.SingleDigitsNeutral[i] + " хиляди и " + Tens(d, numberWordsVocabulary);

        return numberWordsVocabulary.SingleDigitsNeutral[i] + " хиляди " + Hundreds(d, numberWordsVocabulary);
    }

    private static string TensOfThousands(int number, NumberWordsVocabulary numberWordsVocabulary)
    {
        var o = number / 10000;
        var n = number % 10000;
        var e = n % 1000;
        var b = n / 1000;
        var i = number / 1000;
        var t = i % 10;
        var soft = e % 100;
        var ware = soft % 10;

        if (number is > 10000 and < 10099) return numberWordsVocabulary.TensMultiples[o] + " хиляди и " + Tens(n, numberWordsVocabulary);

        if (number is >= 10099 and < 11000)
        {
            if (soft == 0) // 10100, 10900, 10800 , etc
            {
                return numberWordsVocabulary.TensMultiples[o] + " хиляди и " + Hundreds(n, numberWordsVocabulary);
            }

            return BuildThousandsWithoutAnd(numberWordsVocabulary.TensMultiples[o], Hundreds(n, numberWordsVocabulary));
        }

        if (number is >= 11000 and < 20000)
        {
            if (soft != 0) return BuildThousandsWithoutAnd(numberWordsVocabulary.NumbersTenToNineteen[t], Hundreds(e, numberWordsVocabulary)); // 11100, 11900, 11800 , etc
            if (e == 0) return numberWordsVocabulary.NumbersTenToNineteen[t] + " хиляди";

            return BuildThousandsWithAnd(numberWordsVocabulary.NumbersTenToNineteen[t], Hundreds(e, numberWordsVocabulary));
        }

        if (number is > 20000 and < 99999)
        {
            if (b == 1)
            {
                if (e < 100)  return numberWordsVocabulary.TensMultiples[o] + " и една хиляди и " + Tens(e, numberWordsVocabulary);

                if (ware == 0) return numberWordsVocabulary.TensMultiples[o] + " и една хиляди и " + Hundreds(e, numberWordsVocabulary);

                if (ware > 0) return numberWordsVocabulary.TensMultiples[o] + " и една хиляди " + Hundreds(e, numberWordsVocabulary);
            }

            if (b == 2)
            {
                if (e < 100) return numberWordsVocabulary.TensMultiples[o] + " и две хиляди и " + Tens(e, numberWordsVocabulary);

                if (ware == 0) return numberWordsVocabulary.TensMultiples[o] + " и две хиляди и " + Hundreds(e, numberWordsVocabulary);

                if (ware > 0) return numberWordsVocabulary.TensMultiples[o] + " и две хиляди " + Hundreds(e, numberWordsVocabulary);
            }

            return BuildThousandsWithAnd(Tens(i, numberWordsVocabulary), Hundreds(e, numberWordsVocabulary));
        }

        if (n == 0) return numberWordsVocabulary.TensMultiples[o] + " хиляди"; // 10000,20000,30000, etc

        if (n < 100) return BuildThousandsWithAnd(numberWordsVocabulary.TensMultiples[o], Tens(soft, numberWordsVocabulary));

        return BuildThousandsWithoutAnd(Tens(i, numberWordsVocabulary), Hundreds(e, numberWordsVocabulary));
    }

    private static string BuildThousandsWithoutAnd(string thousands, string afterThousands) => thousands + " хиляди " + afterThousands;

    private static string BuildThousandsWithAnd(string thousands, string afterThousands) => thousands + " хиляди и " + afterThousands;

    private static string AppendNegativePrefix(string numberAsWords, bool isNegativeNumber)
    {
        if (!isNegativeNumber) return numberAsWords;

        return "Минус " + numberAsWords;
    }

    public static string Convert(decimal number, CurrencyDescriptor currencyDescriptor)
    {
        ArgumentNullException.ThrowIfNull(currencyDescriptor);
        
        if (number is 0 or 0.0m)  return currencyDescriptor.Vocabulary.NumbersZeroToNineteen[0] + currencyDescriptor.MajorCurrencyUnitPlural; // нула лева, нула евро

        var isNegativeNumber = number < 0;
        number = Math.Abs(number); // Convert negative number to positive

        var leva = (int)number;
        var stotinki = (int)((number % 1.0m) * 100);

        if (number == 1 && stotinki == 0) return AppendNegativePrefix(currencyDescriptor.Vocabulary.NumbersZeroToNineteen[leva] + currencyDescriptor.MajorCurrencyUnitSingular, isNegativeNumber); // един лев, едно евро

        var levaWords = leva != 1 ? ConvertWholeNumber(leva, currencyDescriptor.Vocabulary) + currencyDescriptor.MajorCurrencyUnitPlural : currencyDescriptor.Vocabulary.NumbersZeroToNineteen[leva] + currencyDescriptor.MajorCurrencyUnitSingular;

        string stotinkiWords;

        if (leva == 0)
        {
            if (stotinki == 0) return AppendNegativePrefix(currencyDescriptor.Vocabulary.NumbersZeroToNineteen[leva] + currencyDescriptor.MajorCurrencyUnitPlural, isNegativeNumber);
            if (stotinki == 1) return AppendNegativePrefix(currencyDescriptor.Vocabulary.MinorCurrencyUnitSingular + currencyDescriptor.MinorCurrencyUnitSingular, isNegativeNumber);
            if (stotinki == 2) return AppendNegativePrefix("две" + currencyDescriptor.MinorCurrencyUnitPlural, isNegativeNumber);
            if (stotinki == 10) return AppendNegativePrefix(currencyDescriptor.Vocabulary.NumbersZeroToNineteen[stotinki] + currencyDescriptor.MinorCurrencyUnitPlural, isNegativeNumber);
            if (stotinki < 20) return AppendNegativePrefix(currencyDescriptor.Vocabulary.NumbersZeroToNineteen[stotinki] + currencyDescriptor.MinorCurrencyUnitPlural, isNegativeNumber);

            stotinkiWords = stotinki + " " + currencyDescriptor.MinorCurrencyUnitAbbreviated;
        }
        else stotinkiWords = stotinki + " " + currencyDescriptor.MinorCurrencyUnitAbbreviated;

        if (leva == 0) return AppendNegativePrefix(stotinkiWords, isNegativeNumber);
        if (stotinki == 0) return AppendNegativePrefix(levaWords, isNegativeNumber);
        
        return AppendNegativePrefix(levaWords + " и " + stotinkiWords, isNegativeNumber);
    }
}