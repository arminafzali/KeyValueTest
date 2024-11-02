using Present2;

namespace DictTest
{
    public class UnitTest1
    {

        [Fact]
        public void Test1()
        {
            var keyPair = new KeyPair();
            keyPair.AddToDict("a", 2, "b");
            keyPair.AddToDict("a", 4, "c");
            keyPair.AddToDict("a", 25, "d");
            keyPair.AddToDict("a", 26, "e");
            keyPair.AddToDict("a", 27, "f");
            keyPair.AddToDict("b", 6, "g");
            Assert.Null(keyPair.GetByTimeStamp("a", 1));
            Assert.Equal("b", keyPair.GetByTimeStamp("a", 2));
            Assert.Equal("b", keyPair.GetByTimeStamp("a", 3));
            Assert.Equal("c", keyPair.GetByTimeStamp("a", 4));
            Assert.Equal("c", keyPair.GetByTimeStamp("a", 5));
            Assert.Equal("c", keyPair.GetByTimeStamp("a", 24));
            Assert.Equal("e", keyPair.GetByTimeStamp("a", 26));
            Assert.Equal("d", keyPair.GetByTimeStamp("a", 25));
            Assert.Equal("f", keyPair.GetByTimeStamp("a", 27));
            Assert.Equal("f", keyPair.GetByTimeStamp("a", 28));
            Assert.Equal("f", keyPair.GetByTimeStamp("a", 44));
            Assert.Equal("g", keyPair.GetByTimeStamp("b", 6));
            Assert.Null(keyPair.GetByTimeStamp("c", 6));
        }
    }
}