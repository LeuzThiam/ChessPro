namespace ChessPro.Domain;

public enum Couleur
{
    Blanc,
    Noir
}

public static class CouleurExtensions
{
    public static Couleur Opposee(this Couleur couleur) =>
        couleur == Couleur.Blanc ? Couleur.Noir : Couleur.Blanc;
}
