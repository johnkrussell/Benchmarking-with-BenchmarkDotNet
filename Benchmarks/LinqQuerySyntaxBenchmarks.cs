namespace Benchmarks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

public class LinqQuerySyntaxBenchmarks
{
    private int[] data = Enumerable.Range(0,1000).ToArray();

    [Benchmark(Baseline = true)]
    public int MethodSyntax() => data.Where(x => x > 500).Select(x => x*2).Sum();

    [Benchmark]
    public int QuerySyntax() => (from x in data where x > 500 select x*2).Sum();
}
