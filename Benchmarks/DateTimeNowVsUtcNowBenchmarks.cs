namespace Benchmarks;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class DateTimeNowVsUtcNowBenchmarks
{
    [Benchmark(Baseline = true)]
    public DateTime Now() => DateTime.Now;

    [Benchmark]
    public DateTime UtcNow() => DateTime.UtcNow;
}
