using NUnit.Framework;
using System;
using System.Linq;

namespace Collections.Tests
{
    public class ColectionTests
    {

        [Test]
        public void Test_Colection_EmptyConstructor()
        {
            var nums = new Collection<int>();
            Assert.AreEqual(0, nums.Count);
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            var nums = new Collection<int>(5);
            Assert.That(nums.ToString(), Is.EqualTo("[5]"));
        }
        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var nums = new Collection<int>(5, 6);
            Assert.That(nums.ToString(), Is.EqualTo("[5, 6]"));
        }
        [Test]
        public void Test_Collection_Add()
        {
            var nums = new Collection<int>();
            nums.Add(1);
            Assert.That(nums.ToString(), Is.EqualTo("[1]"));
        }

        [Test]
        public void Test_Collection_AddRange()
        {
            var nums = new Collection<int>(1, 2, 3);
            nums.AddRange(new[] { 4, 5, 6 });
            Assert.That(nums.ToString(), Is.EqualTo("[1, 2, 3, 4, 5, 6]"));
        }
        [Test]
        public void Test_Collection_GetByIndex()
        {
            var nums = new Collection<int>(8, 1, 3);

            Assert.That(nums[0], Is.EqualTo(8));
        }
        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            var strings = new Collection<string>("test8", "test6", "test7", "test4");
            Assert.That(() => strings[4], Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void Test_Collection_SetByIndex()
        {
            var strings = new Collection<string>("test8", "test6", "test7", "test4");
            strings.Add("test3");
            Assert.That(() => strings[4], Is.EqualTo(("test3")));
        }

        [Test]
        public void Test_Collection_InsertAtStart()
        {
            var strings = new Collection<string>("a", "b", "c", "d");
            strings.InsertAt(0, "1");
            Assert.That(() => strings[0], Is.EqualTo(("1")));
        }
        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            var strings = new Collection<string>("a", "b", "c", "d");
            strings.InsertAt(4, "1");
            Assert.That(() => strings[4], Is.EqualTo(("1")));
        }
        [Test]
        public void Test_Collection_InsertAtMiddle()
        {
            var strings = new Collection<string>("a", "b", "c", "d");
            strings.InsertAt(2, "1");
            Assert.That(() => strings[2], Is.EqualTo(("1")));
        }

        public void Test_Collection_InsertAtWithGrow() { }

        [Test]
        public void Test_Collection_RemoveAtStart()
        {
            var strings = new Collection<string>("a", "b", "c", "d");
            strings.RemoveAt(0);
            Assert.That(() => strings[0], Is.EqualTo(("b")));
        }

        [Test]
        public void Test_Collection_RemoveAtMiddle()
        {
            var strings = new Collection<string>("a", "b", "c", "d", "e");
            int capacity = strings.Length;
            int middle = capacity / 2 + 1;
            strings.RemoveAt(middle);
            Assert.That(() => strings[2], Is.EqualTo(("d")));
        }


        [Test]
        public void Test_Collection_ToStringEmpty()
        {
            var strings = new Collection<string>("a", "b", "c", "d", "e");
            strings.Clear();
            Assert.That(() => strings.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_ToStringNestedCollections()
        {
            var names = new Collection<string>("Teddy", "Ivan");
            var nums = new Collection<int>(20, 30);
            var dates = new Collection<DateTime>();

            var nested = new Collection<object>(names, nums, dates);
            string nestedToString = nested.ToString();

            Assert.That(() => nestedToString, Is.EqualTo("[[Teddy, Ivan], [20, 30], []]"));

        }
        [Test]
        [Timeout(1000)]
        public void Test_Collection_1MillionItems()
        {
            const int itemsCount = 1000000;
            var nums = new Collection<int>();
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());
            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);
            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);
            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);
        }

        [Test]
        public void Test_Collection_AddWithGrow()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;

        }
        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            var strings = new Collection<string>("a", "b", "c", "d", "e");
            int count = strings.Count;
            int capacity = strings.Capacity;
            Assert.That(() => count == capacity);
                //Assert.WHAT?
        }
        [Test]
        public void Test_Collection_RemoveAtEnd()
        {
            var strings = new Collection<string>("a", "b", "c", "d");
            int end = strings.Count - 1;
            strings.RemoveAt(end);
            int newEnd = strings.Count - 1;
            Assert.That(() => strings[newEnd], Is.EqualTo(("c")));
        }
        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {
            var strings = new Collection<string>("a", "b", "c", "d");
            strings.InsertAt(56, "1");
            Assert.That(() => strings[10], Throws.InstanceOf<ArgumentOutOfRangeException>());
            //Assert.WHAT?

        }
        [Test]
        public void Test_Collection_SetByInvalidIndex()
        {
            var strings = new Collection<string>("1", "2", "3", "4");
            strings.InsertAt(56,"5");
            Assert.That(() => strings[56], Is.EqualTo(("[]")));
            //Assert.WHAT?
        }
        public void Test_Collection_AddRangeWithGrow() { }
        public void Test_Collection_ExchangeMiddle() { }
        public void Test_Collection_ExchangeFirstLast() { }
        public void Test_Collection_ExchangeInvalidIndexes() { }
        public void Test_Collection_ToStringSingle() { }
        public void Test_Collection_ToStringMultiple() { }
        public void Test_Collection_RemoveAtInvalidIndex() { }
        public void Test_Collection_RemoveAll() { }
        public void Test_Collection_Clear() { }
    }
}