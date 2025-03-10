namespace OneBitSoftware.Slovom
{
    public static class NumbersToWords
    {
        static string[] under20 = { "нула", "един", "два", "три", "четири", "пет", "шест", "седем", "осем", "девет", "десет", "единадесет", "дванадесет", "тринадесет", "четиринадесет", "петнадесет", "шестнадесет", "седемнадесет", "осемнадесет", "деветнадесет" };
        static string[] units = { "нула", "едно", "две", "три", "четири", "пет", "шест", "седем", "осем", "девет" };
        static string[] teens = { "десет", "единадесет", "дванадесет", "тринадесет", "четиринадесет", "петнадесет", "шестнадесет", "седемнадесет", "осемнадесет", "деветнадесет" };
        static string[] tens = { "", "десет", "двадесет", "тридесет", "четиридесет", "петдесет", "шестдесет", "седемдесет", "осемдесет", "деветдесет" };
        static string[] hundreds = { "", "сто", "двеста", "триста", "четиристотин", "петстотин", "шестстотин", "седемстотин", "осемстотин", "деветстотин" };

        static string AppendLvMale = " лев";
        static string AppendLvFemale = " лева";
        static string AppendStotinki = " стотинки";
        static string AppendStotinka = " стотинка";
        static string AppendStotinkaShort = "ст.";

        static string ConvertWholeNumber(int n)
        {
            if (n < 20)
                return under20[n];
            else if (n < 100)
                return Tens(n);
            else if (n < 1000)
                return Hundreds(n);
            else if (n < 10000)
                return Thousands(n);
            else if (n < 100000)
                return TensOfThousands(n);
            else
                return "Числото е твърде голямо";
        }

        private static string Tens(int n)
        {
            if (n < 20)
                return under20[n];

            var i = n / 10;
            var d = n % 10;

            return tens[i] + (d == 0 ? "" : " и " + under20[d]);
        }

        static string Hundreds(int n)
        {
            var i = n / 100;
            var d = n % 100;

            if (n < 120)
            {
                return hundreds[i] + " и " + under20[d];
            }
            else if (n >= 120 && n < 200)
            {
                return hundreds[i] + " " + ConvertWholeNumber(d);
            }
            else
            {
                if (d < 20)
                    return hundreds[i] + (d == 0 ? "" : " и " + ConvertWholeNumber(d));

                return hundreds[i] + (d == 0 ? "" : " " + ConvertWholeNumber(d));
            }
        }

        private static string Thousands(int n)
        {
            var i = n / 1000;
            var d = n % 1000;

            if (n == 1000) return "хиляда";

            if (n > 1000 && n < 1099) return "хиляда и " + Tens(d);

            if (n > 1099 && n < 2000) return "хиляда " + Hundreds(d);

            if (d == 0) return units[i] + " хиляди"; // 2000,3000,4000, etc

            if (d < 100) return units[i] + " хиляди и " + Tens(d);

            return units[i] + " хиляди " + Hundreds(d);
        }

        private static string TensOfThousands(int number)
        {
            var o = number / 10000;
            var n = number % 10000;
            var e = n % 1000;
            var b = n / 1000;
            var i = number / 1000;
            var t = i / 100;
            var s = i % 10;
            var of = e % 100;
            var tware = of % 10;

            if (number > 10000 && number < 10099)
            {
                return tens[o] + " хиляди и " + Tens(n);
            }

            if (number >= 10099 && number < 11000)
            {
                if (of == 0) // 10100, 10900, 10800 , etc
                {
                    return tens[o] + " хиляди и " + Hundreds(n);
                }

                return BuildThousandsWithoutAnd(tens[o], Hundreds(n));
            }

            if (number >= 11000 && number < 20000)
            {
                if (of == 0) // 11100, 11900, 11800 , etc
                {
                    if (e == 0) return teens[s] + " хиляди";

                    return BuildThousandsWithAnd(teens[s], Hundreds(e));
                }

                return BuildThousandsWithoutAnd(teens[s], Hundreds(e));
            }

            if (number > 20000 && number < 99999)
            {
                if (b == 1)
                {
                    if (e < 100)  return tens[o] + " и една хиляди и " + Tens(e);

                    if (tware == 0) return tens[o] + " и една хиляди и " + Hundreds(e);

                    if (tware > 0) return tens[o] + " и една хиляди " + Hundreds(e);
                }

                if (b == 2)
                {
                    if (e < 100) return tens[o] + " и две хиляди и " + Tens(e);

                    if (tware == 0) return tens[o] + " и две хиляди и " + Hundreds(e);

                    if (tware > 0) return tens[o] + " и две хиляди " + Hundreds(e);
                }

                return BuildThousandsWithAnd(Tens(i), Hundreds(e));
            }

            if (n == 0) return tens[o] + " хиляди"; // 10000,20000,30000, etc

            if (n < 100) return BuildThousandsWithAnd(tens[o], Tens(of));

            return BuildThousandsWithoutAnd(Tens(i), Hundreds(e));
        }

        static string BuildThousandsWithoutAnd(string thousands, string afterThousands)
        {
            return thousands + " хиляди " + afterThousands;
        }

        static string BuildThousandsWithAnd(string thousands, string afterThousands)
        {
            return thousands + " хиляди и " + afterThousands;
        }

        public static string Convert(decimal number)
        {
            if (number == 0 || number == 0.0m)  return under20[0] + AppendLvFemale; // нула лева

            number = Math.Abs(number); // Convert negative number to positive

            int leva = (int)number;
            int stotinki = (int)((number % 1.0m) * 100);

            if (number == 1 && stotinki == 0) return under20[leva] + AppendLvMale; // един лев

            string levaWords = leva != 1 ? ConvertWholeNumber(leva) + AppendLvFemale : "един" + AppendLvMale;

            string stotinkiWords;

            if (leva == 0)
            {
                if (stotinki == 0) return under20[leva] + AppendLvFemale;
                if (stotinki == 1) return "една" + AppendStotinka;
                if (stotinki == 2) return "две" + AppendStotinki;
                if (stotinki == 10) return under20[stotinki] + AppendStotinki;
                if (stotinki < 20) return under20[stotinki] + AppendStotinki;

                stotinkiWords = stotinki.ToString() + " " + AppendStotinkaShort;
            }
            else
            {
                stotinkiWords = stotinki.ToString() + " " + AppendStotinkaShort;
            }

            if (leva == 0)
                return stotinkiWords;
            else if (stotinki == 0)
                return levaWords;
            else
                return levaWords + " и " + stotinkiWords;
        }
    }
}
