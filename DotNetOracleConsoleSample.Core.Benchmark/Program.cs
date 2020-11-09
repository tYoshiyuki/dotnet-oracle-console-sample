using System;
using BenchmarkDotNet.Running;

namespace DotNetOracleConsoleSample.Core.Benchmark
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
