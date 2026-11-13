namespace ChessPro.Domain;

/// <summary>
/// Une case de l'échiquier : File (colonne, 0 = a .. 7 = h) et Rank (rangée, 0 = rang 1 .. 7 = rang 8).
/// Value Object : deux Square avec les mêmes File/Rank sont égaux et interchangeables.
/// </summary>
public readonly record struct Square
{
    public int File { get; }
    public int Rank { get; }

    public Square(int file, int rank)
    {
        if (file < 0 || file > 7)
            throw new ArgumentOutOfRangeException(nameof(file), file, "File doit être entre 0 et 7.");
        if (rank < 0 || rank > 7)
            throw new ArgumentOutOfRangeException(nameof(rank), rank, "Rank doit être entre 0 et 7.");

        File = file;
        Rank = rank;
    }

    public static bool IsValid(int file, int rank) =>
        file is >= 0 and <= 7 && rank is >= 0 and <= 7;

    public static bool TryCreate(int file, int rank, out Square square)
    {
        if (!IsValid(file, rank))
        {
            square = default;
            return false;
        }

        square = new Square(file, rank);
        return true;
    }

    /// <summary>Notation algébrique, ex. "e4".</summary>
    public static Square Parse(string algebraic)
    {
        if (!TryParse(algebraic, out var square))
            throw new FormatException($"Notation algébrique invalide : \"{algebraic}\".");

        return square;
    }

    public static bool TryParse(string? algebraic, out Square square)
    {
        square = default;

        if (algebraic is not { Length: 2 })
            return false;

        int file = algebraic[0] - 'a';
        int rank = algebraic[1] - '1';

        return TryCreate(file, rank, out square);
    }

    public override string ToString() => $"{(char)('a' + File)}{Rank + 1}";
}
