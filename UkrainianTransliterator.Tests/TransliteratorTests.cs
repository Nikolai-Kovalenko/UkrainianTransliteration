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
    [InlineData("������", "Oleksii")]
    [InlineData("��������", "Yosypivka")]
    [InlineData("������", "Galagan")]
    [InlineData("�������", "Zhytomyr")]
    [InlineData("���", "Kyiv")]
    [InlineData("�������", "Mykolaiv")]
    [InlineData("���������", "Oleksandr")]
    [InlineData("�������", "Shcherbukhy")]
    [InlineData("���", "Yurii")]
    [InlineData("������", "Yahotyn")]
    [InlineData("�������", "Zghorany")]
    [InlineData("������", "Rozghon")]
    [InlineData("��", "zgh")]
    public void Transliterate_OnlyLetters(string input, string expected)
    {
        var result = _transliterator.GetTransliteration(input);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("�����, ���! �� ������?", "Pryvit, svit! Yak spravy?")]
    [InlineData("1234", "1234")]
    [InlineData(" ", " ")]
    [InlineData("�����!123", "Pryvit!123")]
    public void Transliterate_VariousInputs(string input, string expected)
    {
        var result = _transliterator.GetTransliteration(input);
        result.Should().Be(expected);
    }

    [Fact]
    public void Transliterate_ExceptionF�rNullInput()
    {
        // Act
        var action = () => _transliterator.GetTransliteration(null);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("Input cannot be null or empty (Parameter 'input')");
    }

    [Fact]
    public void Transliterate_ExceptionF�rEmptyInput()
    {
        // Act
        var action = () => _transliterator.GetTransliteration(string.Empty);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("Input cannot be null or empty (Parameter 'input')");
    }
}