using ChessPro.Domain;
using Xunit;

namespace ChessPro.Domain.Tests;

public class GenerateurCoupsTests
{
    [Fact]
    public void CoupsCavalier_DepuisE4_SurEchiquierVide_ShouldRetourner8Coups()
    {
        var echiquier = new Echiquier();
        echiquier[Case.Convertir("e4")] = new Piece(TypePiece.Cavalier, Couleur.Blanc);

        var coups = GenerateurCoups.CoupsCavalier(echiquier, Case.Convertir("e4"));

        Assert.Equal(8, coups.Count());
    }

    [Fact]
    public void CoupsCavalier_DepuisB1_SurEchiquierVide_ShouldRetourner3Coups()
    {
        var echiquier = new Echiquier();
        echiquier[Case.Convertir("b1")] = new Piece(TypePiece.Cavalier, Couleur.Blanc);

        var coups = GenerateurCoups.CoupsCavalier(echiquier, Case.Convertir("b1"));

        Assert.Equal(3, coups.Count());
    }

    [Fact]
    public void CoupsCavalier_DepuisA1_SurEchiquierVide_ShouldRetournerSeulementLesCoupsSurLEchiquier()
    {
        var echiquier = new Echiquier();
        echiquier[Case.Convertir("a1")] = new Piece(TypePiece.Cavalier, Couleur.Blanc);

        var coups = GenerateurCoups.CoupsCavalier(echiquier, Case.Convertir("a1"));

        Assert.Equal(2, coups.Count());
    }

    [Fact]
    public void CoupsCavalier_ShouldPasAutoriserDeCapturerUnePieceDeMemeCouleur()
    {
        var echiquier = new Echiquier();
        echiquier[Case.Convertir("b1")] = new Piece(TypePiece.Cavalier, Couleur.Blanc);
        echiquier[Case.Convertir("d2")] = new Piece(TypePiece.Pion, Couleur.Blanc);

        var coups = GenerateurCoups.CoupsCavalier(echiquier, Case.Convertir("b1"));

        Assert.DoesNotContain(coups, coup => coup.Arrivee == Case.Convertir("d2"));
    }

    [Fact]
    public void CoupsCavalier_ShouldAutoriserDeCapturerUnePieceAdverse()
    {
        var echiquier = new Echiquier();
        echiquier[Case.Convertir("b1")] = new Piece(TypePiece.Cavalier, Couleur.Blanc);
        echiquier[Case.Convertir("d2")] = new Piece(TypePiece.Pion, Couleur.Noir);

        var coups = GenerateurCoups.CoupsCavalier(echiquier, Case.Convertir("b1"));
        var coupVersD2 = coups.Single(coup => coup.Arrivee == Case.Convertir("d2"));

        Assert.Equal(TypeCoup.Capture, coupVersD2.Type);
    }
}