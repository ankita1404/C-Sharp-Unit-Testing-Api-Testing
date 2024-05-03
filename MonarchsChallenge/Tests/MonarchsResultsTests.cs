using NUnit.Framework;

namespace MonarchsChallenge.Tests
{
    
    public class MonarchsResultsTests
    {


        [Test , Category("TEST 1: Verify total monarch count")]
        public void TestCase1()
        {
           int result = MonarchsResults.CountMonarchs(GetMonarchList());

            Assert.That(result, Is.EqualTo(5));


        }

        [Test, Category("TEST 2: Verify longest ruling monarch")]
        public void Test_MonarchWithLongestRulingPeriod()
        {
            var LongestRulingMonrach = MonarchsResults.LongestRulingMonarch(GetMonarchList());
           
            Assert.That(LongestRulingMonrach.RulingLength, Is.EqualTo(1018));
        }

        [Test, Category("TEST 3: Verify longest ruling house")]
        public void Test_MonarchWithLongestRulingHouse()
        {
           
            MonarchHouse Rulinghouse= MonarchsResults.LongestRulingHouse(GetMonarchList());
            int time = Rulinghouse.RulingTime;
            var house = Rulinghouse.HouseName;

            Assert.Multiple(() =>
            {
                Assert.That(Rulinghouse.RulingTime, Is.EqualTo(1297));
                Assert.That(Rulinghouse.HouseName, Is.EqualTo("House of Normandy"));
            });


        }

        [Test , Category("Maximum occurence Monarch name")]
        public void Test_MonarchCommonNames()
        {
            var CommonName =MonarchsResults.MostCommonMonarchName(GetMonarchList());

            Assert.That(CommonName, Is.EqualTo("William"));


        }

        [Test, Category("Verify when monrach year column has only start year with dash '-' (still ruling/present)")]
        public void Test_MonrachStillRuling()
        {
            
            Monarch[] Monarch_SpecificData = Array.FindAll<Monarch>(GetMonarchList(), x => x.Years.EndsWith('-') || x.Years.Equals("899"));
                   
            var LongestRulingMonrach = MonarchsResults.LongestRulingMonarch(Monarch_SpecificData);
            Assert.That(LongestRulingMonrach.RulingLength, Is.EqualTo(37));

        }

        [Test, Category("Verify when monrach year column has only start year, no end year, no dash '-'")]
        public void Test_MonarchRuleForOneYear()
        {
            Monarch[] 
            Monarch_ServeOnly_oneYear = Array.FindAll<Monarch>(GetMonarchList(), x => !x.Years.Contains('-'));

            var MonarchData = MonarchsResults.LongestRulingMonarch(Monarch_ServeOnly_oneYear);

            Assert.That(MonarchData.RulingLength, Is.EqualTo(1));

        }

       


        //Test Data
        private Monarch[] GetMonarchList()
        {
            Monarch[] listOfMonarch = new Monarch[5];
            Monarch monarch1 = new Monarch();
            monarch1.Name = "Edward the Martyr   ";
            monarch1.Country = "United Kingdom";
            monarch1.House = "House of Normandy";
            monarch1.Years = "1485-1509";
            


            listOfMonarch[0] = monarch1;

            Monarch monarch2 = new Monarch();
            monarch2.Name = "Edmund";
            monarch2.Country = "United Kingdom";
            monarch2.House = "House of Normandy";
            monarch2.Years = "1987-";

            listOfMonarch[1] =  monarch2;

            Monarch monarch3 = new Monarch();
            monarch3.Name = "Henry VI";
            monarch3.Country = "Norway";
            monarch3.House = "House of Lancaster";
            monarch3.Years = "899";

            listOfMonarch[2]  = monarch3;

            Monarch monarch4 = new Monarch();
            monarch4.Name = "William III";
            monarch4.Country = "United Kingdom";
            monarch4.House = "House of Normandy";
            monarch4.Years = "900-1918";

            listOfMonarch[3] = monarch4;

            Monarch monarch5 = new Monarch();
            monarch5.Name = "William III";
            monarch5.Country = "United Kingdom";
            monarch5.House = "House of Normandy";
            monarch5.Years = "1700-1918";

            listOfMonarch[4] = monarch5;

            return listOfMonarch;

        }

       


    }
}
