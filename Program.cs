using System.Collections.Immutable;
using System.Reflection;
using System.Text.Json;
using ProblemSolving.Abstractions;
using ProblemSolving.Framework;

public class Program
{
    public static void Main(string[] args)
    {
        ImmutableDictionary<int, Type> problemMapping = Assembly.GetAssembly(typeof(Program))
            .GetTypes()
            .Where(t => typeof(IProblem).IsAssignableFrom(t))
            .Where(t => t.GetCustomAttribute<ProblemIdAttribute>() != null)
            .ToImmutableDictionary(t => t.GetCustomAttribute<ProblemIdAttribute>()!.Id);

        string jsonString = File.ReadAllText("runconfig.json");
        var runConfig = JsonSerializer.Deserialize<RunConfig>(jsonString);

        bool problemExists = problemMapping.TryGetValue(runConfig.ProblemId, out Type problem);
        if(!problemExists)
        {
            throw new Exception($"Problem with id {runConfig.ProblemId} does not exist");
        }
        var problemInstance = (IProblem)Activator.CreateInstance(problem, runConfig.Arguments);
        problemInstance.Execute();
        problemInstance.DisplayResult();
    }
}
