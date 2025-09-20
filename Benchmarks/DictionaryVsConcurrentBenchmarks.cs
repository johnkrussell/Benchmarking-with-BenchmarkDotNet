namespace Benchmarks;

using System.Collections.Concurrent;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class DictionaryVsConcurrentBenchmarks
{
    private Dictionary<int, int> _dict = null!;
    private ConcurrentDictionary<int, int> _cdict = null!;
    private int _nextKey;

    private const int Capacity = 4_096;
    private const int ExistingKey = 123456;

    [IterationSetup]
    public void IterationSetup()
    {
        _dict = new Dictionary<int, int>(Capacity);
        _cdict = new ConcurrentDictionary<int, int>(concurrencyLevel: Environment.ProcessorCount, capacity: Capacity);

        _dict[ExistingKey] = 42;
        _cdict[ExistingKey] = 42;

        _nextKey = 0;
    }

    [Benchmark(Baseline = true)]
    public int DictLookup() => _dict[ExistingKey];

    [Benchmark]
    public int ConcurrentLookup() => _cdict[ExistingKey];

    [Benchmark]
    public void DictInsert() => _dict[_nextKey++] = 1;

    [Benchmark]
    public void ConcurrentTryAdd() => _cdict.TryAdd(_nextKey++, 1);
}