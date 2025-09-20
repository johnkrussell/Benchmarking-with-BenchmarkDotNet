namespace Benchmarks;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class SpanVsSubstringBenchmarks
{
    private string s = "abcdefghijklmnopqrstuvwxyz";

    [Benchmark(Baseline = true)]
    public string Substring() => s.Substring(5,10);

    [Benchmark]
    public ReadOnlySpan<char> Slice() => s.AsSpan(5,10);
}
