using ChessPro.Domain;
using Xunit;

namespace ChessPro.Domain.Tests;

public class CoupTests
{
    [Theory]
    [InlineData(TypeCoup.Capture, true)]
    [InlineData(TypeCoup.PriseEnPassant, true)]
    [InlineData(TypeCoup.PromotionCapture, true)]
    [InlineData(TypeCoup.Normal, false)]
    [InlineData(TypeCoup.PousseeDouble, false)]
    [InlineData(TypeCoup.PetitRoque, false)]
    public void EstCapture_ShouldReflectType(TypeCoup type, bool attendu)
    {
        var coup = new Coup(Case.Convertir("e4"), Case.Convertir("e5"), type);

        Assert.Equal(attendu, coup.EstCapture);
    }

    [Fact]
    public void EstPromotion_ShouldBeTrue_SeulementPourLesTypesDePromotion()
    {
        var promotion = new Coup(Case.Convertir("e7"), Case.Convertir("e8"), TypeCoup.Promotion, TypePiece.Reine);
        var normal = new Coup(Case.Convertir("e2"), Case.Convertir("e4"));

        Assert.True(promotion.EstPromotion);
        Assert.False(normal.EstPromotion);
    }

    [Fact]
    public void DeuxCoups_AvecMemesValeurs_ShouldBeEqual()
    {
        var a = new Coup(Case.Convertir("e2"), Case.Convertir("e4"), TypeCoup.PousseeDouble);
        var b = new Coup(Case.Convertir("e2"), Case.Convertir("e4"), TypeCoup.PousseeDouble);

        Assert.Equal(a, b);
    }
}
