namespace MonarchsChallenge;

internal static class Program
{
    static async Task Main()
    {
        var customHttpClient = new CustomClient();

        
        var collector = new MonarchsCollector(customHttpClient);
        var monarchs = await collector.GetMonarchs();

        
        //Answer to question 1
        var monarchsAmount = monarchs.CountMonarchs();
        Console.WriteLine($"There are {monarchsAmount} monarchs in the list");

        //Answer to question 2
        var longestRulingMonarch = monarchs.LongestRulingMonarch();
        Console.WriteLine(
            $"With the result of {longestRulingMonarch.RulingLength} years, the longest ruling monarch is {longestRulingMonarch.Name} of {longestRulingMonarch.House}");
        
        //Answer to question 3
        var longestRulingHouse = monarchs.LongestRulingHouse();
        Console.WriteLine(
            $"With the result of  {longestRulingHouse.RulingTime} years, the longest ruling house is {longestRulingHouse!.HouseName}.");

        //Answer to question 4
        var mostCommonName = monarchs.MostCommonMonarchName();
            Console.WriteLine($"The most common name is {mostCommonName}");
    }
}