using System.Text.Json.Serialization;

namespace MonarchsChallenge;

public class Monarch
{
    private const string Space = " ";
    private const string Dash = "-";

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("nm")]
    public string Name { get; set; }

    public string FirstName => Name.Split(Space, StringSplitOptions.RemoveEmptyEntries).First();

    [JsonPropertyName("cty")] 
    public string Country { get; set; }

    [JsonPropertyName("hse")]
    public string House { get; set; }

    [JsonPropertyName("yrs")] 
    public string Years { get; set; }
    
    public int RulingLength
    {
        get
        {
            if (Years.Contains(Dash) is false)
            {
                return 1;
            }
            
            var splitYears = Years.Split(Dash, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            if (splitYears.Length < 2)
            {
                return DateTime.Now.Year - splitYears.First();
            }

            return splitYears.Last() - splitYears.First();
        }
    }

    public static implicit operator Monarch(int v)
    {
        throw new NotImplementedException();
    }
}