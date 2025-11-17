namespace ProblemSolving.Framework;

[AttributeUsage(AttributeTargets.Class)]
public class ProblemIdAttribute : Attribute
{
    public int Id { get; }

    public ProblemIdAttribute(int id)
    {
        Id = id;
    }
}

