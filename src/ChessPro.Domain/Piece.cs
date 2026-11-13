namespace ChessPro.Domain;

/// <summary>
/// Une pièce est une donnée pure (type + couleur), sans position ni mutation interne.
/// La position est toujours portée par le plateau (Echiquier), pas par la pièce elle-même :
/// ça évite d'avoir deux sources de vérité pour "où est cette pièce".
/// </summary>
public readonly record struct Piece(TypePiece Type, Couleur Couleur)
{
    public override string ToString() => $"{Couleur} {Type}";
}
