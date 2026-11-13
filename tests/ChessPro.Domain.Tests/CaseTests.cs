using ChessPro.Domain;
using Xunit;

namespace ChessPro.Domain.Tests;

public class CaseTests
{
    [Theory]
    [InlineData("a1", 0, 0)]
    [InlineData("h8", 7, 7)]
    [InlineData("e4", 4, 3)]
    public void Convertir_ShouldReturnExpectedColonneAndRangee(string algebrique, int colonneAttendue, int rangeeAttendue)
    {
        var uneCase = Case.Convertir(algebrique);

        Assert.Equal(colonneAttendue, uneCase.Colonne);
        Assert.Equal(rangeeAttendue, uneCase.Rangee);
    }

    [Theory]
    [InlineData("a1")]
    [InlineData("h8")]
    [InlineData("e4")]
    public void ToString_ShouldRoundTrip_ThroughConvertir(string algebrique)
    {
        var uneCase = Case.Convertir(algebrique);

        Assert.Equal(algebrique, uneCase.ToString());
    }

    [Theory]
    [InlineData("")]
    [InlineData("i1")]
    [InlineData("a9")]
    [InlineData("a0")]
    [InlineData("zz")]
    public void EssayerConvertir_ShouldReturnFalse_PourNotationInvalide(string algebrique)
    {
        bool resultat = Case.EssayerConvertir(algebrique, out _);

        Assert.False(resultat);
    }

    [Fact]
    public void Constructeur_ShouldThrow_QuandHorsLimites()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Case(8, 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Case(0, -1));
    }

    [Fact]
    public void DeuxCases_AvecMemeColonneEtRangee_ShouldBeEqual()
    {
        var a = new Case(4, 3);
        var b = Case.Convertir("e4");

        Assert.Equal(a, b);
        Assert.True(a == b);
    }
}
