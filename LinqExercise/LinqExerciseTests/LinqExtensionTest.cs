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
        private IEnumerable<string> _enumerable;

        [Test]
        public void MyWhere_NullEnumerableAndGetResult_ThrowArgumentNullException()
        {
           _enumerable = null;

            Assert.Throws<ArgumentNullException>(() => _enumerable.MyWhere(x => true).ToList());
        }

        [Test]
        public void MyWhere_EmptyEnumerable_ReturnEmptyEnumerable()
        {
            _enumerable = new List<string>();

            var result = _enumerable.MyWhere(x => true);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void MyWhere_AlwaysTruePredicate_ReturnFullEnumerable()
        {
            _enumerable = new[] {"Galo", "Sears", "Israel", "Shop", "Your", "Way"};

            var result = _enumerable.MyWhere(x => true);

            Assert.That(result, Is.EquivalentTo(_enumerable));
        }

        [Test]
        public void MyWhere_AlwaysFalsePredicate_ReturnEmptyEnumerable()
        {
            _enumerable = new [] { "Galo", "Sears", "Israel", "Shop", "Your", "Way" };

            var result = _enumerable.MyWhere(x => false);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void MyWhere_SomeItemsSatisfyThePredicate_ReturnOnlyItemsThatSatisfyThePredicate()
        {
            _enumerable = new []{ "galo", "sears", "israel", "shop", "your", "way" };
            Func<string, bool> predicate = x => x.Contains('s');
            var result = _enumerable.MyWhere(predicate);

            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.AreEqual(3, result.Count());
            Assert.That(result, Is.EquivalentTo(_enumerable.Where(predicate)));
        }

        [Test]
        public void MyWhere_NullPredicate_ThrowArgumentNullException()
        {
            _enumerable = new[] {"galo", "sears", "israel", "shop", "your", "way"};

            Assert.Throws<ArgumentNullException>(() => _enumerable.MyWhere(null).ToList());
        }
    }
}
