using Exercice03Ville.Core;

namespace Exercice03Ville.Tests
{
    [TestClass]
    public class RechercheVilleTests
    {
        [TestMethod]
        public void Search_TextLessThanTwoCharacters_ThrowsNotFoundException()
        {
            var rechercheVille = new RechercheVille();
            var searchWord = "a";
            rechercheVille.Rechercher(searchWord);
        }
    }
}
