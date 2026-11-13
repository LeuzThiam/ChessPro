namespace ChessPro.Domain;

/// <summary>
/// Un coup : case de départ, case d'arrivée, catégorie (TypeCoup), et pièce de promotion si besoin.
/// Immutable. Ne connaît rien de l'échiquier : c'est au générateur de coups de produire des Coup
/// valides, pas au Coup de se valider lui-même.
/// </summary>
public readonly record struct Coup(Case Depart, Case Arrivee, TypeCoup Type = TypeCoup.Normal, TypePiece? PiecePromotion = null)
{
    public bool EstCapture => Type is TypeCoup.Capture or TypeCoup.PriseEnPassant or TypeCoup.PromotionCapture;

    public bool EstRoque => Type is TypeCoup.PetitRoque or TypeCoup.GrandRoque;

    public bool EstPromotion => Type is TypeCoup.Promotion or TypeCoup.PromotionCapture;

    public override string ToString() =>
        EstPromotion ? $"{Depart}{Arrivee}={PiecePromotion}" : $"{Depart}{Arrivee}";
}
