namespace OneBitSoftware.Slovom.Currencies;

/// <summary>
/// Represents a descriptor for a currency, providing information about major and minor currency units
/// in both singular and plural forms, as well as an abbreviated symbol for minor currency units.
/// </summary>
public sealed record CurrencyDescriptor
{
    private CurrencyDescriptor() { }
    
    /// <summary>
    /// Gets the singular form of the major currency unit.
    /// </summary>
    public required string MajorCurrencyUnitSingular { get; init; }

    /// <summary>
    /// Gets the plural form of the major currency unit.
    /// </summary>
    public required string MajorCurrencyUnitPlural { get; init; }

    /// <summary>
    /// Gets the plural form of the minor currency unit.
    /// </summary>
    public required string MinorCurrencyUnitPlural { get; init; }

    /// <summary>
    /// Gets the singular form of the minor currency unit.
    /// </summary>
    public required string MinorCurrencyUnitSingular { get; init; }

    /// <summary>
    /// Gets the abbreviated form of the minor currency unit.
    /// </summary>
    public required string MinorCurrencyUnitAbbreviated { get; init; }

    /// <summary>
    /// Gets the vocabulary containing word representations for numbers and units in a specific language or currency context.
    /// </summary>
    public required NumberWordsVocabulary Vocabulary { get; init; }

    /// <summary>
    /// Gets the currency descriptor for Bulgarian Lev (BGN).
    /// </summary>
    public static CurrencyDescriptor Bgn => new()
    {
        MajorCurrencyUnitSingular = " лев",
        MajorCurrencyUnitPlural = " лева",
        MinorCurrencyUnitPlural = " стотинки",
        MinorCurrencyUnitSingular = " стотинка",
        MinorCurrencyUnitAbbreviated = "ст.",
        Vocabulary = new NumberWordsVocabulary
        {
            MinorCurrencyUnitSingular = "една",
            NumbersZeroToNineteen = ["нула", "един", "два", "три", "четири", "пет", "шест", "седем", "осем", "девет", "десет", "единадесет", "дванадесет", "тринадесет", "четиринадесет", "петнадесет", "шестнадесет", "седемнадесет", "осемнадесет", "деветнадесет"],
            SingleDigitsNeutral = ["нула", "едно", "две", "три", "четири", "пет", "шест", "седем", "осем", "девет"],
            NumbersTenToNineteen = ["десет", "единадесет", "дванадесет", "тринадесет", "четиринадесет", "петнадесет", "шестнадесет", "седемнадесет", "осемнадесет", "деветнадесет"],
            TensMultiples = ["", "десет", "двадесет", "тридесет", "четиридесет", "петдесет", "шестдесет", "седемдесет", "осемдесет", "деветдесет"],
            HundredsMultiples = ["", "сто", "двеста", "триста", "четиристотин", "петстотин", "шестстотин", "седемстотин", "осемстотин", "деветстотин"]
        }
    };

    /// <summary>
    /// Gets the currency descriptor for Euro (EUR).
    /// </summary>
    public static CurrencyDescriptor Euro => new()
    {
        MajorCurrencyUnitSingular = " евро",
        MajorCurrencyUnitPlural = " евро",
        MinorCurrencyUnitPlural = " евроцента",
        MinorCurrencyUnitSingular = " евроцент",
        MinorCurrencyUnitAbbreviated = "ц.",
        Vocabulary = new NumberWordsVocabulary
        {
            MinorCurrencyUnitSingular = "един",
            NumbersZeroToNineteen = ["нула", "едно", "две", "три", "четири", "пет", "шест", "седем", "осем", "девет", "десет", "единадесет", "дванадесет", "тринадесет", "четиринадесет", "петнадесет", "шестнадесет", "седемнадесет", "осемнадесет", "деветнадесет"],
            SingleDigitsNeutral = ["нула", "едно", "две", "три", "четири", "пет", "шест", "седем", "осем", "девет"],
            NumbersTenToNineteen = ["десет", "единадесет", "дванадесет", "тринадесет", "четиринадесет", "петнадесет", "шестнадесет", "седемнадесет", "осемнадесет", "деветнадесет"],
            TensMultiples = ["", "десет", "двадесет", "тридесет", "четиридесет", "петдесет", "шестдесет", "седемдесет", "осемдесет", "деветдесет"],
            HundredsMultiples = ["", "сто", "двеста", "триста", "четиристотин", "петстотин", "шестстотин", "седемстотин", "осемстотин", "деветстотин"]
        }
    };
}