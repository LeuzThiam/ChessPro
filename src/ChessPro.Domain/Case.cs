namespace ChessPro.Domain;

/// <summary>
/// Une case de l'échiquier : Colonne (0 = a .. 7 = h) et Rangee (0 = rang 1 .. 7 = rang 8).
/// Value Object : deux Case avec les mêmes Colonne/Rangee sont égales et interchangeables.
/// </summary>
public readonly record struct Case
{
    public int Colonne { get; }
    public int Rangee { get; }

    public Case(int colonne, int rangee)
    {
        if (colonne < 0 || colonne > 7)
            throw new ArgumentOutOfRangeException(nameof(colonne), colonne, "Colonne doit être entre 0 et 7.");
        if (rangee < 0 || rangee > 7)
            throw new ArgumentOutOfRangeException(nameof(rangee), rangee, "Rangee doit être entre 0 et 7.");

        Colonne = colonne;
        Rangee = rangee;
    }

    public static bool EstValide(int colonne, int rangee) =>
        colonne is >= 0 and <= 7 && rangee is >= 0 and <= 7;

    public static bool EssayerCreer(int colonne, int rangee, out Case uneCase)
    {
        if (!EstValide(colonne, rangee))
        {
            uneCase = default;
            return false;
        }

        uneCase = new Case(colonne, rangee);
        return true;
    }

    /// <summary>Notation algébrique, ex. "e4".</summary>
    public static Case Convertir(string algebrique)
    {
        if (!EssayerConvertir(algebrique, out var uneCase))
            throw new FormatException($"Notation algébrique invalide : \"{algebrique}\".");

        return uneCase;
    }

    public static bool EssayerConvertir(string? algebrique, out Case uneCase)
    {
        uneCase = default;

        if (algebrique is not { Length: 2 })
            return false;

        int colonne = algebrique[0] - 'a';
        int rangee = algebrique[1] - '1';

        return EssayerCreer(colonne, rangee, out uneCase);
    }

    public override string ToString() => $"{(char)('a' + Colonne)}{Rangee + 1}";
}
