namespace ChessPro.Domain;

/// <summary>
/// Une pièce est une donnée pure (type + couleur), sans position ni mutation interne.
/// La position est toujours portée par le plateau (Board), pas par la pièce elle-même :
/// ça évite d'avoir deux sources de vérité pour "où est cette pièce".
/// </summary>
public readonly record struct Piece(PieceType Type, Color Color)
{
    public override string ToString() => $"{Color} {Type}";
}
