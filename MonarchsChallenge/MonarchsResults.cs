namespace MonarchsChallenge;

internal static class MonarchsResults
{
    public static int CountMonarchs(this Monarch[] monarchs) => 
        monarchs.Length;

    public static Monarch? LongestRulingMonarch(this Monarch[] monarchs) => 
        monarchs.MaxBy(x => x.RulingLength);

    public static MonarchHouse? LongestRulingHouse(this Monarch[] monarchs) =>
        monarchs
            .GroupBy(x => x.House)
            .Select(x => new MonarchHouse(x.Key, x.Sum(y => y.RulingLength)))
            .MaxBy(x => x.RulingTime);


    public static string? MostCommonMonarchName(this Monarch[] monarchs) =>
        monarchs.GroupBy(m => m.FirstName)
            .MaxBy(g => g.Count())?
            .Key;
}

internal class MonarchHouse
{
    public MonarchHouse(string houseName, int rulingTime)
    {
        HouseName = houseName;
        RulingTime = rulingTime;
    }

    public string HouseName { get; }
    public int RulingTime { get; }
}