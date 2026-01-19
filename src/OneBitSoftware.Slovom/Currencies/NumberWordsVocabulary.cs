namespace OneBitSoftware.Slovom.Currencies;

/// <summary>
/// Represents a vocabulary collection for converting numbers and currency into words.
/// </summary>
/// <remarks>
/// This class defines the language-specific words used for numbers, single digits, tens,
/// hundreds, and numbers between zero and nineteen. It is intended to support currency and
/// numeric transformation into word representations.
/// </remarks>
public sealed record NumberWordsVocabulary
{
    internal NumberWordsVocabulary() { }
    
    /// <summary>
    /// Gets or inits the word representation for the singular form of the minor currency unit.
    /// </summary>
    public required string MinorCurrencyUnitSingular { get; init; }
    
    /// <summary>
    /// Gets or inits the words for numbers from zero to nineteen.
    /// </summary>
    public required string[] NumbersZeroToNineteen { get; init; }

    /// <summary>
    /// Gets or inits the words for single digits in neutral form.
    /// </summary>
    public required string[] SingleDigitsNeutral { get; init; }

    /// <summary>
    /// Gets or inits the words for numbers from ten to nineteen.
    /// </summary>
    public required string[] NumbersTenToNineteen { get; init; }

    /// <summary>
    /// Gets or inits the words for multiples of ten.
    /// </summary>
    public required string[] TensMultiples { get; init; }

    /// <summary>
    /// Gets or inits the words for multiples of a hundred.
    /// </summary>
    public required string[] HundredsMultiples { get; init; }
}