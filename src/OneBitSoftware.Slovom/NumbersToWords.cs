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

        static string ConvertWholeNumber(int n)
        {
            if (n < 10)
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
            var i = n / 10;
            var d = n % 10;

            if (n < 20)
            {
                return under20[n];
            }
            else
            {
                return tens[i] + (d == 0 ? "" : " и " + ConvertWholeNumber(d));
            }
        }

        static string Hundreds(int n)
        {
            var i = n / 100;
            var d = n % 100;

            if (n < 120)
            {
                return "сто и " + under20[d];
            }
            else if (n >= 120 && n < 200)
            {
                return "сто " + ConvertWholeNumber(d);
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

            if (n > 1000 && n < 1099)
            {
                return "хиляда и " + Tens(d);
            }

            if (n > 1099 && n < 2000)
            {
                return "хиляда " + Hundreds(d);
            }

            if (d == 0) // 2000,3000,4000, etc
            {
                return units[i] + " хиляди";
            }

            if (d < 100)
            {
                return units[i] + " хиляди и " + Tens(d);
            }

            return units[i] + " хиляди " + Hundreds(d);
        }

        private static string TensOfThousands(int n)
        {
            var i = n / 10000;
            var d = n % 10000;
            var e = d % 1000;
            var j = d / 1000;
            var g = n / 1000;
            var h = n / 10;
            var f = g % 10;
            var r = e % 100;
            var t = r % 10;

            //if (n == 10000) return "десет хиляди";

            if (n > 10000 && n < 10099)
            {
                return tens[i] + " хиляди и " + Tens(d);
            }

            if (n >= 10099 && n < 11000)
            {
                if (r == 0) // 10100, 10900, 10800 , etc
                {
                    return tens[i] + " хиляди и " + Hundreds(d);
                }

                return tens[i] + " хиляди " + Hundreds(d);
            }

            if (n >= 11000 && n < 20000)
            {
                if (r == 0) // 11100, 11900, 11800 , etc
                {
                    if (e == 0)
                    {
                        return teens[f] + " хиляди";
                    }

                    return teens[f] + " хиляди и " + Hundreds(e);
                }

                return teens[f] + " хиляди " + Hundreds(e);
            }

            if (n > 20000 && n < 99999)
            {
                if (j == 1)
                {
                    if (e < 100)
                    {
                        return tens[i] + " и една хиляди и " + Tens(e); 
                    }

                    if (t == 0)
                    {
                        return tens[i] + " и една хиляди и " + Hundreds(e);
                    }

                    if (t > 0)
                    {
                        return tens[i] + " и една хиляди " + Hundreds(e);
                    }
                }

                if (j == 2)
                {
                    if (e < 100)
                    {
                        return tens[i] + " и две хиляди и " + Tens(e);
                    }

                    if (t == 0)
                    {
                        return tens[i] + " и две хиляди и " + Hundreds(e); 
                    }

                    if (t > 0)
                    {
                        return tens[i] + " и две хиляди " + Hundreds(e);
                    }
                }

                return Tens(g) + " хиляди и " + Hundreds(e);
            }

            if (d == 0) // 10000,20000,30000, etc
            {
                return tens[i] + " хиляди";
            }

            if (d < 100)
            {
                return tens[i] + " хиляди и " + Tens(r);
            }

            return Tens(g) + " хиляди " + Hundreds(e);
        }


        public static string Convert(decimal number)
        {
            if (number == 0 || number == 0.0m)
            {
                return under20[0] + AppendLvFemale; // нула лева
            }

            int leva = (int)number;
            int stotinki = (int)((number % 1.0m) * 100);

            if (number == 1 && stotinki == 0)
            {
                return under20[leva] + AppendLvMale; // един лев
            }

            string levaWords = leva != 1 ? ConvertWholeNumber(leva) + " лева" : "един лев";

            string stotinkiWords;

            if (leva == 0)
            {
                if (stotinki == 0) return "нула лева";
                if (stotinki == 1) return "една" + AppendStotinka;
                if (stotinki == 2) return "две" + AppendStotinki;
                if (stotinki == 10) return "десет" + AppendStotinki;
                if (stotinki < 20) return under20[stotinki] + AppendStotinki;

                stotinkiWords = stotinki.ToString() + " ст.";
            }
            else
            {
                stotinkiWords = stotinki.ToString() + " ст.";
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
