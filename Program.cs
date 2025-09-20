using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;

public class Program
{
    public static void Main(string[] args)
    {
        var config = ManualConfig.Create(DefaultConfig.Instance).WithOrderer(new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest));

        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
    }
}