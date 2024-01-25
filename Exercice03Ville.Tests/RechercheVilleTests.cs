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
    }
}
