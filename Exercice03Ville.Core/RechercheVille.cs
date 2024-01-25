namespace Exercice03Ville.Core
{
    public class RechercheVille
    {
        private List<String> _villes;

        public List<String> Rechercher(String mot)
        {
            if (mot.Length < 2)
            {
                throw new NotFoundException("La recherche doit contenir au moins 2 caractères.");
            }

            throw new NotImplementedException();
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
