namespace Benchmarks;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class StringInterpolationBenchmarks
{
    private int a=1, b=2, c=3;

    [Benchmark(Baseline = true)]
    public string Interpolation() => $"{a}-{b}-{c}";

    [Benchmark]
    public string Format() => string.Format("{0}-{1}-{2}", a,b,c);
}
