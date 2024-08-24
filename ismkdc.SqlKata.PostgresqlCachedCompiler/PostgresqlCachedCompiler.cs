using SqlKata;
using SqlKata.Compilers;

namespace ismkdc.SqlKata.PostgresqlCachedCompiler;

public class PostgresqlCachedCompiler : PostgresCompiler
{
    private static readonly Dictionary<ulong, SqlResult> Cache = new();

    protected override SqlResult CompileRaw(Query query)
    {
        var hash = CalculateHash(Environment.StackTrace);

        if (Cache.TryGetValue(hash, out var cached)) return cached;

        var compiled = base.CompileRaw(query);

        Cache[hash] = compiled;

        return compiled;
    }

    private static ulong CalculateHash(string data)
    {
        var hashedValue = 3074457345618258791ul;

        foreach (var t in data)
        {
            hashedValue += t;
            hashedValue *= 3074457345618258799ul;
        }

        return hashedValue;
    }
}