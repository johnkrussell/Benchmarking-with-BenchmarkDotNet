namespace Benchmarks;
using BenchmarkDotNet.Attributes;
using System.Security.Cryptography;

[MemoryDiagnoser]
public class RandomVsRandomNumberGeneratorBenchmarks
{
    private Random rnd = new(42);
    private byte[] buffer = new byte[16];

    [Benchmark(Baseline = true)]
    public int RandomNext() => rnd.Next();

    [Benchmark]
    public byte[] RNGCrypto() { RandomNumberGenerator.Fill(buffer); return buffer; }
}
