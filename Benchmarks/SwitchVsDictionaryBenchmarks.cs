namespace Benchmarks;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class SwitchVsDictionaryBenchmarks
{
    private Dictionary<int,string> dict = new();

    [GlobalSetup]
    public void Setup()
    {
        for (int i = 0; i < 10; i++) dict[i] = i.ToString();
    }

    [Benchmark(Baseline = true)]
    public string SwitchCase()
    {
        int i = 5;
        return i switch
        {
            0 => "0",
            1 => "1",
            2 => "2",
            3 => "3",
            4 => "4",
            5 => "5",
            _ => "x"
        };
    }

    [Benchmark]
    public string DictionaryLookup()
    {
        int i = 5;
        return dict[i];
    }
}
