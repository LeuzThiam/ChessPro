using ChessPro.Domain;
using System.Xml.Serialization;
using Xunit;

namespace ChessPro.Domain.Tests;

public class EchiquierTests
{
    [Fact]
    public void PositionDeDepart_ShouldPlacerLeRoiBlancEnE1()
    {
        var echiquier = Echiquier.PositionDeDepart();
        Assert.Equal(new Piece(TypePiece.Roi, Couleur.Blanc), echiquier[Case.Convertir("e1")]);
    }

    [Fact]
    public void PositionDeDepart_ShouldLaisserLeCentreVide()
    {
        var echiquier = Echiquier.PositionDeDepart();
        Assert.Null(echiquier[Case.Convertir("e4")]);
    }

    [Theory]
    [InlineData("a1", TypePiece.Tour, Couleur.Blanc)]
    [InlineData("h1", TypePiece.Tour, Couleur.Blanc)]
    [InlineData("a8", TypePiece.Tour, Couleur.Noir)]
    [InlineData("h8", TypePiece.Tour, Couleur.Noir)]
    [InlineData("d1", TypePiece.Reine, Couleur.Blanc)]
    [InlineData("d8", TypePiece.Reine, Couleur.Noir)]

    public void PositionDeDepart_ShouldPlacerLesPiecesAttendues(string notation, TypePiece type, Couleur couleur)
    {
        var echiquier = Echiquier.PositionDeDepart();
        Assert.Equal(new Piece(type, couleur), echiquier[Case.Convertir(notation)]);
    }
    
}