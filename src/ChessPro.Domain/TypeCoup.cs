namespace ChessPro.Domain;

/// <summary>
/// Catégorie d'un coup. Une seule autorité pour "quel genre de coup est-ce",
/// plutôt que plusieurs booléens indépendants (EstPromotion/EstEnPassant/EstPetitRoque/...)
/// qui peuvent se contredire.
/// </summary>
public enum TypeCoup
{
    Normal,
    Capture,
    PousseeDouble,
    PriseEnPassant,
    PetitRoque,
    GrandRoque,
    Promotion,
    PromotionCapture
}
