namespace ChessPro.Domain;

/// <summary>
/// Un coup : case de départ, case d'arrivée, catégorie (MoveFlag), et pièce de promotion si besoin.
/// Immutable. Ne connaît rien de l'échiquier : c'est au générateur de coups de produire des Move
/// valides, pas au Move de se valider lui-même.
/// </summary>
public readonly record struct Move(Square From, Square To, MoveFlag Flag = MoveFlag.Quiet, PieceType? Promotion = null)
{
    public bool IsCapture => Flag is MoveFlag.Capture or MoveFlag.EnPassant or MoveFlag.PromotionCapture;

    public bool IsCastle => Flag is MoveFlag.CastleKingSide or MoveFlag.CastleQueenSide;

    public bool IsPromotion => Flag is MoveFlag.Promotion or MoveFlag.PromotionCapture;

    public override string ToString() =>
        IsPromotion ? $"{From}{To}={Promotion}" : $"{From}{To}";
}
