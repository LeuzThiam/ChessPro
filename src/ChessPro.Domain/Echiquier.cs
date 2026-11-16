namespace ChessPro.Domain;

public sealed class Echiquier
{
    private readonly Piece?[] _cases = new Piece?[64];

    public Piece? this[Case uneCase]
    {
        get => _cases[Indice(uneCase)];
        set => _cases[Indice(uneCase)] = value;
    }

    private static int Indice(Case uneCase) => uneCase.Rangee * 8 + uneCase.Colonne;

    private static readonly TypePiece[] RangeeInitiale =
{
    TypePiece.Tour, TypePiece.Cavalier, TypePiece.Fou, TypePiece.Reine,
    TypePiece.Roi, TypePiece.Fou, TypePiece.Cavalier, TypePiece.Tour
};

    public static Echiquier PositionDeDepart()
    {
        var echiquier = new Echiquier();

        for (int colonne = 0; colonne < 8; colonne++)
        {
            echiquier[new Case(colonne, 0)] = new Piece(RangeeInitiale[colonne], Couleur.Blanc);
            echiquier[new Case(colonne, 1)] = new Piece(TypePiece.Pion, Couleur.Blanc);

            echiquier[new Case(colonne, 6)] = new Piece(TypePiece.Pion, Couleur.Noir);
            echiquier[new Case(colonne, 7)] = new Piece(RangeeInitiale[colonne], Couleur.Noir);
        }

        return echiquier;
    }
}
