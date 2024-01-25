using Exercice03Ville.Core;

namespace Exercice03Ville.Tests
{
    [TestClass]
    public class RechercheVilleTests
    {
        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void Search_TextLessThanTwoCharacters_ThrowsNotFoundException()
        {
            var rechercheVille = new RechercheVille();

            rechercheVille.Rechercher("a");
        }

        [TestMethod]
        public void Search_TextTwoOrMoreCharacters_ReturnsMatchingCities()
        {
            var rechercheVille = new RechercheVille();

            rechercheVille.AjouterVilles(new List<string> { "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver", "Amsterdam", "Vienne", "Sydney", "New York", "Londres", "Bangkok", "Hong Kong", "Dubai", "Rome", "Istanbul" });

            var resultats = rechercheVille.Rechercher("Va");

            CollectionAssert.AreEqual(new List<string> { "Valence", "Vancouver" }, resultats);
        }

    }
}
