namespace OneBitSoftware.Slovom;

public static class NumbersToWords
{
    private const string AppendLvMale = " лев";
    private const string AppendLvFemale = " лева";
    private const string AppendStotinki = " стотинки";
    private const string AppendStotinka = " стотинка";
    private const string AppendStotinkaShort = "ст.";
    
    private static readonly string[] NumbersZeroToNineteen = ["нула", "един", "два", "три", "четири", "пет", "шест", "седем", "осем", "девет", "десет", "единадесет", "дванадесет", "тринадесет", "четиринадесет", "петнадесет", "шестнадесет", "седемнадесет", "осемнадесет", "деветнадесет"];
    private static readonly string[] SingleDigitsNeutral = ["нула", "едно", "две", "три", "четири", "пет", "шест", "седем", "осем", "девет"];
    private static readonly string[] NumbersTenToNineteen = ["десет", "единадесет", "дванадесет", "тринадесет", "четиринадесет", "петнадесет", "шестнадесет", "седемнадесет", "осемнадесет", "деветнадесет"];
    private static readonly string[] TensMultiples = ["", "десет", "двадесет", "тридесет", "четиридесет", "петдесет", "шестдесет", "седемдесет", "осемдесет", "деветдесет"];
    private static readonly string[] HundredsMultiples = ["", "сто", "двеста", "триста", "четиристотин", "петстотин", "шестстотин", "седемстотин", "осемстотин", "деветстотин"];

    private static string ConvertWholeNumber(int number)
    {
        return number switch
        {
            < 20 => NumbersZeroToNineteen[number],
            < 100 => Tens(number),
            < 1000 => Hundreds(number),
            < 10000 => Thousands(number),
            < 100000 => TensOfThousands(number),
            _ => "Числото е твърде голямо"
        };
    }

    private static string Tens(int n)
    {
        if (n < 20) return NumbersZeroToNineteen[n];

        var i = n / 10;
        var d = n % 10;

        return TensMultiples[i] + (d == 0 ? "" : " и " + NumbersZeroToNineteen[d]);
    }

    private static string Hundreds(int n)
    {
        var i = n / 100;
        var d = n % 100;

        switch (n)
        {
            case < 120: return HundredsMultiples[i] + " и " + NumbersZeroToNineteen[d];
            case < 200: return HundredsMultiples[i] + " " + ConvertWholeNumber(d);
        }

        if (d < 20) return HundredsMultiples[i] + (d == 0 ? "" : " и " + ConvertWholeNumber(d));
        
        return HundredsMultiples[i] + (d == 0 ? "" : " " + ConvertWholeNumber(d));
    }

    private static string Thousands(int n)
    {
        var i = n / 1000;
        var d = n % 1000;

        if (n == 1000) return "хиляда";

        if (n is > 1000 and < 1099) return "хиляда и " + Tens(d);

        if (n is > 1099 and < 2000) return "хиляда " + Hundreds(d);

        if (d == 0) return SingleDigitsNeutral[i] + " хиляди"; // 2000,3000,4000, etc

        if (d < 100) return SingleDigitsNeutral[i] + " хиляди и " + Tens(d);

        return SingleDigitsNeutral[i] + " хиляди " + Hundreds(d);
    }

    private static string TensOfThousands(int number)
    {
        var o = number / 10000;
        var n = number % 10000;
        var e = n % 1000;
        var b = n / 1000;
        var i = number / 1000;
        var t = i % 10;
        var soft = e % 100;
        var ware = soft % 10;

        if (number is > 10000 and < 10099) return TensMultiples[o] + " хиляди и " + Tens(n);

        if (number is >= 10099 and < 11000)
        {
            if (soft == 0) // 10100, 10900, 10800 , etc
            {
                return TensMultiples[o] + " хиляди и " + Hundreds(n);
            }

            return BuildThousandsWithoutAnd(TensMultiples[o], Hundreds(n));
        }

        if (number is >= 11000 and < 20000)
        {
            if (soft != 0) return BuildThousandsWithoutAnd(NumbersTenToNineteen[t], Hundreds(e)); // 11100, 11900, 11800 , etc
            if (e == 0) return NumbersTenToNineteen[t] + " хиляди";

            return BuildThousandsWithAnd(NumbersTenToNineteen[t], Hundreds(e));
        }

        if (number is > 20000 and < 99999)
        {
            if (b == 1)
            {
                if (e < 100)  return TensMultiples[o] + " и една хиляди и " + Tens(e);

                if (ware == 0) return TensMultiples[o] + " и една хиляди и " + Hundreds(e);

                if (ware > 0) return TensMultiples[o] + " и една хиляди " + Hundreds(e);
            }

            if (b == 2)
            {
                if (e < 100) return TensMultiples[o] + " и две хиляди и " + Tens(e);

                if (ware == 0) return TensMultiples[o] + " и две хиляди и " + Hundreds(e);

                if (ware > 0) return TensMultiples[o] + " и две хиляди " + Hundreds(e);
            }

            return BuildThousandsWithAnd(Tens(i), Hundreds(e));
        }

        if (n == 0) return TensMultiples[o] + " хиляди"; // 10000,20000,30000, etc

        if (n < 100) return BuildThousandsWithAnd(TensMultiples[o], Tens(soft));

        return BuildThousandsWithoutAnd(Tens(i), Hundreds(e));
    }

    private static string BuildThousandsWithoutAnd(string thousands, string afterThousands)
    {
        return thousands + " хиляди " + afterThousands;
    }

    private static string BuildThousandsWithAnd(string thousands, string afterThousands)
    {
        return thousands + " хиляди и " + afterThousands;
    }

    public static string Convert(decimal number)
    {
        if (number is 0 or 0.0m)  return NumbersZeroToNineteen[0] + AppendLvFemale; // нула лева

        number = Math.Abs(number); // Convert negative number to positive

        var leva = (int)number;
        var stotinki = (int)((number % 1.0m) * 100);

        if (number == 1 && stotinki == 0) return NumbersZeroToNineteen[leva] + AppendLvMale; // един лев

        var levaWords = leva != 1 ? ConvertWholeNumber(leva) + AppendLvFemale : "един" + AppendLvMale;

        string stotinkiWords;

        if (leva == 0)
        {
            if (stotinki == 0) return NumbersZeroToNineteen[leva] + AppendLvFemale;
            if (stotinki == 1) return "една" + AppendStotinka;
            if (stotinki == 2) return "две" + AppendStotinki;
            if (stotinki == 10) return NumbersZeroToNineteen[stotinki] + AppendStotinki;
            if (stotinki < 20) return NumbersZeroToNineteen[stotinki] + AppendStotinki;

            stotinkiWords = stotinki + " " + AppendStotinkaShort;
        }
        else
        {
            stotinkiWords = stotinki + " " + AppendStotinkaShort;
        }

        if (leva == 0) return stotinkiWords;
        if (stotinki == 0) return levaWords;
        
        return levaWords + " и " + stotinkiWords;
    }
}