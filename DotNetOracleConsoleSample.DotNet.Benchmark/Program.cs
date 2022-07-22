using System;
using BenchmarkDotNet.Running;

namespace DotNetOracleConsoleSample.DotNet.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Target>();
            Console.ReadKey();
        }
    }
}
