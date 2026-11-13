namespace ChessPro.Domain;

/// <summary>
/// Catégorie d'un coup. Une seule autorité pour "quel genre de coup est-ce",
/// plutôt que plusieurs booléens indépendants (EstPromotion/EstEnPassant/EstPetitRoque/...)
/// qui peuvent se contredire.
/// </summary>
public enum MoveFlag
{
    Quiet,
    Capture,
    DoublePawnPush,
    EnPassant,
    CastleKingSide,
    CastleQueenSide,
    Promotion,
    PromotionCapture
}
