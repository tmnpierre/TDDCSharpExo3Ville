namespace Exercice03Ville.Core
{
    public class RechercheVille
    {
        private List<String> _villes = new List<String>();

        public void AjouterVilles(List<String> villes)
        {
            _villes.AddRange(villes);
        }

        public List<String> Rechercher(String mot)
        {
            if (mot == "*")
            {
                return new List<String>(_villes);
            }

            if (mot.Length < 2)
            {
                throw new NotFoundException("La recherche doit contenir au moins 2 caractères.");
            }

            return _villes.FindAll(ville => ville.IndexOf(mot, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
