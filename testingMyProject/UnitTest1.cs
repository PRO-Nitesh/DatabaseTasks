using System.Security.Cryptography.X509Certificates;

namespace testingMyProject.test
{
    public class UnitTest1
    {
        //[Fact]
        [Theory]
            [InlineData(2,6,12)]
            [InlineData(7,1,7)]
            [InlineData(8,2,16)]
            public void multiply(int a, int b, int result)
        {
            Assert.Equal(result, mul(a, b));
        }
          int mul (int a, int b)
            {
                return a * b;
            }

        
    }
}