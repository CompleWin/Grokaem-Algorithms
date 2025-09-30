using Grokaem_Algo;

namespace AlgorithmTests;

public class BinarySeatchTests
{
    [Theory]
    [InlineData(new[] {1, 2, 3, 4, 5}, 5, 4)]
    [InlineData(new[] {1, 2, 3, 4, 5}, 1, 0)]
    [InlineData(new[] {1, 3, 5, 7, 9}, 3, 1)]
    public void BinarySearch_IntListInput_ShouldReturnIndex(int[] collection, int target, int? expectedResult)
    {
        int? exactResult = Algorithm.BinarySearch<int>(collection.ToList(), target);
        Assert.Equal(exactResult, expectedResult);
    }
    
    [Theory]
    [InlineData(new[] {1.2f, 2.3f, 3.1f, 4.4f, 5.5f}, 3.1f, 2)]
    [InlineData(new[] {1.2f, 2.3f, 3.1f, 4.4f, 5.5f}, 1.2f, 0)]
    [InlineData(new[] {1.2f, 2.3f, 3.1f, 4.4f, 5.5f}, 5.5f, 4)]
    public void BinarySearch_FloatListInput_ShouldReturnIndex(float[] collection, float target, int? expectedResult)
    {
        int? exactResult = Algorithm.BinarySearch<float>(collection.ToList(), target);
        Assert.Equal(exactResult, expectedResult);
    }
    
    [Theory]
    [InlineData(new[] {1.2, 2.3, 3.1, 4.4, 5.5}, 3.1, 2)]
    [InlineData(new[] {1.2, 2.3, 3.1, 4.4, 5.5}, 1.2, 0)]
    [InlineData(new[] {1.2, 2.3, 3.1, 4.4, 5.5}, 5.5, 4)]
    public void BinarySearch_DoubleListInput_ShouldReturnIndex(double[] collection, double target, int? expectedResult)
    {
        int? exactResult = Algorithm.BinarySearch<double>(collection.ToList(), target);
        Assert.Equal(exactResult, expectedResult);
    }
    
    [Theory]
    [InlineData(new[] {1, 2, 3, 4, 5}, 10, null)]
    [InlineData(new[] {1, 2, 3, 4, 5}, -1, null)]
    [InlineData(new[] {1, 2, 3, 4, 5}, 100000, null)]
    public void BinarySearch_IntListInput_ShouldReturnNull(int[] collection, int target, int? expectedResult)
    {
        int? exactResult = Algorithm.BinarySearch<int>(collection.ToList(), target);
        Assert.Equal(exactResult, expectedResult);
    }
    
    
}