using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PrisonerHatRiddle;

namespace PrisonerHatRiddleTest
{
    [TestFixture]
    public class PrisonerTest
    {
        /*
         * Can you solve the prisoner hat riddle? - Alex Gendler 
         * 
         * http://ed.ted.com/lessons/can-you-solve-the-prisoner-hat-riddle-alex-gendler#digdeeper
        */

        private Prisoners prisoners;

        [OneTimeSetUp]
        public void SetupTest()
        {
            prisoners = new Prisoners();
        }

        [OneTimeTearDown]
        public void TearDownTest()
        {
            prisoners = null;
        }

        [TestCase("W W B B W W W W W B", "B W B B W W W W W B")]
        [TestCase("B W B B W W B W W B", "W W B B W W B W W B")]
        [TestCase("W W B B W W B B W W", "W W B B W W B B W W")]
        public void AcceptanceTests(string hats, string expected)
        {
            Assert.AreEqual(expected, prisoners.GetAllResponses(hats));
        }
        
        [TestCase("W W B", "B W B")]
        [TestCase("W W W", "W W W")]
        [TestCase("W B W", "B B W")]
        [TestCase("W B B", "W B B")]
        public void GetAllResponsesTest(string hats, string expected)
        {
            Assert.AreEqual(expected, prisoners.GetAllResponses(hats));
        }
    }
}
