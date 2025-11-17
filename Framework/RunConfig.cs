using System.Text.Json.Serialization;

namespace ProblemSolving.Framework;


[JsonConverter(typeof(RunConfigConverter))]
public class RunConfig
{
    public RunConfig()
    {
        Arguments = Array.Empty<object>();
    }
    public int ProblemId { get; set; }
    public object[] Arguments { get; set; }
}
