namespace Benchmarks;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class StringComparisonBenchmarks
{
    private string a = "SitecoreRocks";
    private string b = "sitecorerocks";

    [Benchmark(Baseline = true)]
    public bool OperatorEq() => a == b;

    [Benchmark]
    public bool EqualsMethod() => a.Equals(b);

    [Benchmark]
    public bool OrdinalIgnoreCase() => string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
}
