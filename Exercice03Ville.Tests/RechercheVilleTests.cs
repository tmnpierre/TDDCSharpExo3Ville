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

            rechercheVille.AjouterVilles(new List<string> { "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver", 
                                                            "Amsterdam", "Vienne", "Sydney", "New York", "Londres", "Bangkok", 
                                                            "Hong Kong", "Dubai", "Rome", "Istanbul" });

            var resultats = rechercheVille.Rechercher("Va");

            CollectionAssert.AreEqual(new List<string> { "Valence", "Vancouver" }, resultats);
        }
        [TestMethod]
        public void Search_CaseInsensitiveSearch_ReturnsMatchingCities()
        {
            var rechercheVille = new RechercheVille();

            rechercheVille.AjouterVilles(new List<string> { "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver",
                                                            "Amsterdam", "Vienne", "Sydney", "New York", "Londres", "Bangkok",
                                                            "Hong Kong", "Dubai", "Rome", "Istanbul" });

            var resultatsMinuscules = rechercheVille.Rechercher("va");
            var resultatsMajuscules = rechercheVille.Rechercher("VA");
            var resultatsMixtes = rechercheVille.Rechercher("Va");

            var villesAttendues = new List<string> { "Valence", "Vancouver" };
            CollectionAssert.AreEqual(villesAttendues, resultatsMinuscules);
            CollectionAssert.AreEqual(villesAttendues, resultatsMajuscules);
            CollectionAssert.AreEqual(villesAttendues, resultatsMixtes);
        }

        [TestMethod]
        public void Search_PartialCitySearch_ReturnsMatchingCities()
        {
            var rechercheVille = new RechercheVille();

            rechercheVille.AjouterVilles(new List<string> { "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver",
                                                            "Amsterdam", "Vienne", "Sydney", "New York", "Londres", "Bangkok",
                                                            "Hong Kong", "Dubai", "Rome", "Istanbul" });

            var resultats = rechercheVille.Rechercher("ape");

            CollectionAssert.AreEqual(new List<string> { "Budapest" }, resultats);
        }

        [TestMethod]
        public void Search_Asterisk_ReturnsAllCities()
        {
            var rechercheVille = new RechercheVille();
            var toutesLesVilles = new List<string> { "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver", "Amsterdam", "Vienne", "Sydney", "New York", "Londres", "Bangkok", "Hong Kong", "Dubai", "Rome", "Istanbul" };
            rechercheVille.AjouterVilles(toutesLesVilles);

            var resultats = rechercheVille.Rechercher("*");

            CollectionAssert.AreEquivalent(toutesLesVilles, resultats);
        }

    }
}
