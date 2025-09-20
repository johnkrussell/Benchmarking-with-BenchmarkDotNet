namespace Benchmarks;
using BenchmarkDotNet.Attributes;
using System.Text.RegularExpressions;

[MemoryDiagnoser]
public partial class RegexGeneratorBenchmarks
{
    private string input = "https://example.com/path";

    [GeneratedRegex("https://(.*)")]
    private static partial Regex UrlRegex();

    private Regex dynamicRegex = new("https://(.*)");

    [Benchmark(Baseline = true)]
    public bool DynamicRegex() => dynamicRegex.IsMatch(input);

    [Benchmark]
    public bool SourceGenRegex() => UrlRegex().IsMatch(input);
}
