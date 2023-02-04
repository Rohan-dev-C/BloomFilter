namespace BloomFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BloomFilter<string> bloomFilter = new BloomFilter<string>(5000);

            bloomFilter.Insert("red", 3);
            bloomFilter.Insert("orange", 3);
            bloomFilter.Insert("yellow", 3);
            bloomFilter.Insert("green", 3);
            bloomFilter.Insert("blue", 3);
            bloomFilter.Insert("purple", 3);

            var temp = bloomFilter.ProbablyContains("pink");
            var temp2 = bloomFilter.ProbablyContains("yellow");
        }
    }
}