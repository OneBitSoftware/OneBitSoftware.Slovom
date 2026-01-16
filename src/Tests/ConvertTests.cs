namespace Tests;

using Xunit;
using OneBitSoftware.Slovom;
using OneBitSoftware.Slovom.Currencies;

public class ConvertTests
{
    [Theory]
    [InlineData(0, "нула лева")]
    [InlineData(1, "един лев")]
    [InlineData(2, "два лева")]
    [InlineData(2.0, "два лева")]
    [InlineData(9, "девет лева")]
    [InlineData(10, "десет лева")]
    [InlineData(11, "единадесет лева")]
    [InlineData(12, "дванадесет лева")]
    [InlineData(19, "деветнадесет лева")]
    [InlineData(0.0, "нула лева")]
    [InlineData(0.1, "десет стотинки")]
    [InlineData(1.20, "един лев и 20 ст.")]
    [InlineData(1.3, "един лев и 30 ст.")]
    [InlineData(1.02, "един лев и 2 ст.")]
    [InlineData(118, "сто и осемнадесет лева")]
    [InlineData(123, "сто двадесет и три лева")]
    [InlineData(1000, "хиляда лева")]
    [InlineData(2000, "две хиляди лева")]
    [InlineData(3000, "три хиляди лева")]
    [InlineData(9000, "девет хиляди лева")]
    [InlineData(123.00, "сто двадесет и три лева")]
    [InlineData(1234, "хиляда двеста тридесет и четири лева")]
    [InlineData(1234.78, "хиляда двеста тридесет и четири лева и 78 ст.")]
    [InlineData(1019.78, "хиляда и деветнадесет лева и 78 ст.")]
    [InlineData(1109.78, "хиляда сто и девет лева и 78 ст.")]
    [InlineData(1119.78, "хиляда сто и деветнадесет лева и 78 ст.")]
    [InlineData(2014.78, "две хиляди и четиринадесет лева и 78 ст.")]
    [InlineData(4314.18, "четири хиляди триста и четиринадесет лева и 18 ст.")]
    [InlineData(123.45, "сто двадесет и три лева и 45 ст.")]
    [InlineData(0.01, "една стотинка")]
    [InlineData(1.01, "един лев и 1 ст.")]
    [InlineData(1.10, "един лев и 10 ст.")]
    [InlineData(999.99, "деветстотин деветдесет и девет лева и 99 ст.")]
    [InlineData(9999.99, "девет хиляди деветстотин деветдесет и девет лева и 99 ст.")]
    [InlineData(10000, "десет хиляди лева")]
    [InlineData(10012, "десет хиляди и дванадесет лева")]
    [InlineData(10112, "десет хиляди сто и дванадесет лева")]
    [InlineData(10912, "десет хиляди деветстотин и дванадесет лева")]
    [InlineData(10900, "десет хиляди и деветстотин лева")]
    [InlineData(11900, "единадесет хиляди и деветстотин лева")]
    [InlineData(18900, "осемнадесет хиляди и деветстотин лева")]
    [InlineData(20900, "двадесет хиляди и деветстотин лева")]
    [InlineData(21900, "двадесет и една хиляди и деветстотин лева")]
    [InlineData(22900, "двадесет и две хиляди и деветстотин лева")]
    [InlineData(23901, "двадесет и три хиляди и деветстотин и един лева")]
    [InlineData(12000, "дванадесет хиляди лева")]
    [InlineData(11112, "единадесет хиляди сто и дванадесет лева")]
    [InlineData(32478.27, "тридесет и две хиляди четиристотин седемдесет и осем лева и 27 ст.")]
    [InlineData(32048.27, "тридесет и две хиляди и четиридесет и осем лева и 27 ст.")]
    [InlineData(32008.27, "тридесет и две хиляди и осем лева и 27 ст.")]
    [InlineData(99999.99, "деветдесет и девет хиляди деветстотин деветдесет и девет лева и 99 ст.")]
    public void NumberToWordsBG_ShouldReturnCorrectWords(decimal number, string expected)
    {
        // Act
        var result = NumbersToWords.Convert(number, CurrencyDescriptor.Bgn);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(-1, "един лев")] // Assuming negative values are treated as positive
    [InlineData(-0.01, "една стотинка")] // Assuming negative values are treated as positive
    [InlineData(-32478.27, "тридесет и две хиляди четиристотин седемдесет и осем лева и 27 ст.")]
    public void NumberToWordsBG_ShouldReturnCorrectWordsForNegativeValues(decimal number, string expected)
    {
        // Act
        var result = NumbersToWords.Convert(number, CurrencyDescriptor.Bgn);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, "нула евро")]
    [InlineData(1, "едно евро")]
    [InlineData(2, "две евро")]
    [InlineData(9, "девет евро")]
    [InlineData(10, "десет евро")]
    [InlineData(11, "единадесет евро")]
    [InlineData(12, "дванадесет евро")]
    [InlineData(19, "деветнадесет евро")]
    [InlineData(0.0, "нула евро")]
    [InlineData(0.1, "десет евроцента")]
    [InlineData(1.20, "едно евро и 20 ц.")]
    [InlineData(1.3, "едно евро и 30 ц.")]
    [InlineData(1.02, "едно евро и 2 ц.")]
    [InlineData(118, "сто и осемнадесет евро")]
    [InlineData(123, "сто двадесет и три евро")]
    [InlineData(1000, "хиляда евро")]
    [InlineData(2000, "две хиляди евро")]
    [InlineData(3000, "три хиляди евро")]
    [InlineData(9000, "девет хиляди евро")]
    [InlineData(123.00, "сто двадесет и три евро")]
    [InlineData(1234, "хиляда двеста тридесет и четири евро")]
    [InlineData(1234.78, "хиляда двеста тридесет и четири евро и 78 ц.")]
    [InlineData(1019.78, "хиляда и деветнадесет евро и 78 ц.")]
    [InlineData(1109.78, "хиляда сто и девет евро и 78 ц.")]
    [InlineData(1119.78, "хиляда сто и деветнадесет евро и 78 ц.")]
    [InlineData(2014.78, "две хиляди и четиринадесет евро и 78 ц.")]
    [InlineData(4314.18, "четири хиляди триста и четиринадесет евро и 18 ц.")]
    [InlineData(123.45, "сто двадесет и три евро и 45 ц.")]
    [InlineData(0.01, "един евроцент")]
    [InlineData(0.02, "две евроцента")]
    [InlineData(1.01, "едно евро и 1 ц.")]
    [InlineData(1.10, "едно евро и 10 ц.")]
    [InlineData(999.99, "деветстотин деветдесет и девет евро и 99 ц.")]
    [InlineData(9999.99, "девет хиляди деветстотин деветдесет и девет евро и 99 ц.")]
    [InlineData(10000, "десет хиляди евро")]
    [InlineData(10012, "десет хиляди и дванадесет евро")]
    [InlineData(10112, "десет хиляди сто и дванадесет евро")]
    [InlineData(10912, "десет хиляди деветстотин и дванадесет евро")]
    [InlineData(10900, "десет хиляди и деветстотин евро")]
    [InlineData(11900, "единадесет хиляди и деветстотин евро")]
    [InlineData(18900, "осемнадесет хиляди и деветстотин евро")]
    [InlineData(20900, "двадесет хиляди и деветстотин евро")]
    [InlineData(21900, "двадесет и една хиляди и деветстотин евро")]
    [InlineData(22900, "двадесет и две хиляди и деветстотин евро")]
    [InlineData(23901, "двадесет и три хиляди и деветстотин и едно евро")]
    [InlineData(12000, "дванадесет хиляди евро")]
    [InlineData(11112, "единадесет хиляди сто и дванадесет евро")]
    [InlineData(32478.27, "тридесет и две хиляди четиристотин седемдесет и осем евро и 27 ц.")]
    [InlineData(32048.27, "тридесет и две хиляди и четиридесет и осем евро и 27 ц.")]
    [InlineData(32008.27, "тридесет и две хиляди и осем евро и 27 ц.")]
    [InlineData(99999.99, "деветдесет и девет хиляди деветстотин деветдесет и девет евро и 99 ц.")]
    public void NumberToWordsEuro_ShouldReturnCorrectWords(decimal number, string expected)
    {
        // Act
        var result = NumbersToWords.Convert(number, CurrencyDescriptor.Euro);

        // Assert
        Assert.Equal(expected, result);
    }
}