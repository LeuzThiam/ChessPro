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
}
