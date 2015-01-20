using System;
using System.Collections.Generic;
using System.Linq;
using LinqExercise;
using NUnit.Framework;

namespace LinqExerciseTests
{
    [TestFixture]
    public class LinqExtensionTest
    {
        
        [Test]
        public void MyWhere_WhenNullEnumerableAndGetResult_ThrowArgumentNullException()
        {
           IEnumerable<object> enumerable = null;

            Assert.Throws<ArgumentNullException>(() => enumerable.MyWhere(x => true).ToList());
        }

        [Test]
        public void MyWhere_WhenEmptyEnumerable_ReturnEmptyEnumerable()
        {
            var enumerable = new List<string>();

            var result = enumerable.MyWhere(x => true);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void MyWhere_WhenPredicateAlwaysTrue_ReturnFullEnumerable()
        {
            var enumerable = new[] {"Galo", "Sears", "Israel", "Shop", "Your", "Way"};

            var result = enumerable.MyWhere(x => true);

            Assert.That(result, Is.EquivalentTo(enumerable));
        }


        [Test]
        public void MyWhere_WhenPredicateAlwaysFalse_ReturnEmptyEnumerable()
        {
            var enumerable = new [] { "Galo", "Sears", "Israel", "Shop", "Your", "Way" };

            var result = enumerable.MyWhere(x => false);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void MyWhere_WhenSomeItemsSatisfyThePredicate_ReturnOnlyItemsThatSatisfyThePredicate()
        {
            var enumerable = new []{ "galo", "sears", "israel", "shop", "your", "way" };
            var expected = new[] { "sears", "israel", "shop" };
            Func<string, bool> predicate = x => x.Contains('s');
            
            var result = enumerable.MyWhere(predicate);

            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void MyWhere_NullPredicate_ThrowArgumentNullException()
        {
            var enumerable = new[] {"galo", "sears", "israel", "shop", "your", "way"};

            Assert.Throws<ArgumentNullException>(() => enumerable.MyWhere(null).ToList());
        }
    }
}
