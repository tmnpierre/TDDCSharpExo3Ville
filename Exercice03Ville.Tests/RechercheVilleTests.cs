using Exercice03Ville.Core;

namespace Exercice03Ville.Tests
{
    [TestClass]
    public class RechercheVilleTests
    {
        private RechercheVille rechercheVille;

        [TestInitialize]
        public void Setup()
        {
            rechercheVille = new RechercheVille();
            rechercheVille.AjouterVilles(new List<string> { "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver",
                                                            "Amsterdam", "Vienne", "Sydney", "New York", "Londres", "Bangkok",
                                                            "Hong Kong", "Dubai", "Rome", "Istanbul" });
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void Search_TextLessThanTwoCharacters_ThrowsNotFoundException()
        {
            rechercheVille.Rechercher("a");
        }

        [TestMethod]
        public void Search_TextTwoOrMoreCharacters_ReturnsMatchingCities()
        {
            var resultats = rechercheVille.Rechercher("Va");
            CollectionAssert.AreEqual(new List<string> { "Valence", "Vancouver" }, resultats);
        }

        [TestMethod]
        public void Search_CaseInsensitiveSearch_ReturnsMatchingCities()
        {
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
            var resultats = rechercheVille.Rechercher("ape");
            CollectionAssert.AreEqual(new List<string> { "Budapest" }, resultats);
        }

        [TestMethod]
        public void Search_Asterisk_ReturnsAllCities()
        {
            var toutesLesVilles = new List<string> { "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver", "Amsterdam", "Vienne", "Sydney", "New York", "Londres", "Bangkok", "Hong Kong", "Dubai", "Rome", "Istanbul" };
            var resultats = rechercheVille.Rechercher("*");
            CollectionAssert.AreEquivalent(toutesLesVilles, resultats);
        }
    }
}
