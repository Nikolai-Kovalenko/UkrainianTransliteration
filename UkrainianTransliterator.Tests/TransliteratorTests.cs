using FluentAssertions;

namespace UkrainianTransliterator.Tests;

public class TransliteratorTests
{
    private readonly UkrainianToLatinTransliterator _transliterator;

    public TransliteratorTests()
    {
        _transliterator = new UkrainianToLatinTransliterator();
    }

    [Theory]
    [InlineData("Îëåêñ³é", "Oleksii")]
    [InlineData("Éîñèï³âêà", "Yosypivka")]
    [InlineData("¥àëà´àí", "Galagan")]
    [InlineData("Æèòîìèð", "Zhytomyr")]
    [InlineData("Êè¿â", "Kyiv")]
    [InlineData("Ìèêîëà¿â", "Mykolaiv")]
    [InlineData("Îëåêñàíäð", "Oleksandr")]
    [InlineData("Ùåðáóõè", "Shcherbukhy")]
    [InlineData("Þð³é", "Yurii")]
    [InlineData("ßãîòèí", "Yahotyn")]
    [InlineData("Çãîðàíè", "Zghorany")]
    [InlineData("Ðîçãîí", "Rozghon")]
    [InlineData("çã", "zgh")]
    public void Transliterate_OnlyLetters(string input, string expected)
    {
        var result = _transliterator.GetTransliteration(input);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("Ïðèâ³ò, ñâ³ò! ßê ñïðàâè?", "Pryvit, svit! Yak spravy?")]
    [InlineData("1234", "1234")]
    [InlineData(" ", " ")]
    [InlineData("Ïðèâ³ò!123", "Pryvit!123")]
    public void Transliterate_VariousInputs(string input, string expected)
    {
        var result = _transliterator.GetTransliteration(input);
        result.Should().Be(expected);
    }

    [Fact]
    public void Transliterate_ExceptionFîrNullInput()
    {
        // Act
        var action = () => _transliterator.GetTransliteration(null);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("Input cannot be null or empty (Parameter 'input')");
    }

    [Fact]
    public void Transliterate_ExceptionFîrEmptyInput()
    {
        // Act
        var action = () => _transliterator.GetTransliteration(string.Empty);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("Input cannot be null or empty (Parameter 'input')");
    }
}