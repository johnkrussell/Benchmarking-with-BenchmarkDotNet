namespace Benchmarks;

using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class ArraySortBenchmarks
{
    private int[] arr = new int[1000];

    [GlobalSetup]
    public void Setup()
    {
        var r = new Random(42);
        for (int i = 0; i < arr.Length; i++) arr[i] = r.Next();
    }

    [Benchmark(Baseline = true)]
    public void ArraySort() => Array.Sort(arr);

    [Benchmark]
    public void LinqOrderBy() => arr.OrderBy(x => x).ToArray();
}