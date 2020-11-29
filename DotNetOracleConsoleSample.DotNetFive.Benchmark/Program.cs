using System;
using BenchmarkDotNet.Running;

namespace DotNetOracleConsoleSample.DotNetFive.Benchmark
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
