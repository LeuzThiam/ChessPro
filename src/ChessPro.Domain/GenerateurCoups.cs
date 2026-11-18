namespace ChessPro.Domain;

public static class GenerateurCoups
{
    private static readonly (int Colonne, int Rangee)[] DeplacementsCavalier =
    {
        (1, 2), (2, 1), (2, -1), (1, -2),
        (-1, -2), (-2, -1), (-2, 1), (-1, 2)
    };

    public static IEnumerable<Coup> CoupsCavalier(Echiquier echiquier, Case depart)
    {
        foreach (var (deltaColonne, deltaRangee) in DeplacementsCavalier)
        {
            int colonne = depart.Colonne + deltaColonne;
            int rangee = depart.Rangee + deltaRangee;

            if (!Case.EssayerCreer(colonne, rangee, out var arrivee))
                continue;
            var pieceSurArrivee = echiquier[arrivee];
            var pieceQuiBouge = echiquier[depart];

            if (pieceSurArrivee is not null && pieceSurArrivee.Value.Couleur == pieceQuiBouge?.Couleur)
                continue;
            yield return new Coup(depart, arrivee, pieceSurArrivee is null ? TypeCoup.Normal : TypeCoup.Capture);
        }
    }
}