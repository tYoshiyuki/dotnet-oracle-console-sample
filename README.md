# dotnet-oracle-console-sample
ODP.NET で Oracle にデータアクセスするサンプル

## Feature
- .NET Framework
- .NET Core
- .NET5
- ODP.NET

## Project
- DotNetOracleConsoleSample
    - ODP.NET + .NET Framework + EntityFramework のサンプル
- DotNetOracleConsoleSample.Core
    - ODP.NET + .NET Core + EntityFrameworkCore のサンプル
- DotNetOracleConsoleSample.Core.Benchmark
    - DotNetOracleConsoleSample.Core のベンチマーク用
- DotNetOracleConsoleSample.DotNetFive
    - ODP.NET + .NET5 + EntityFrameworkCore のサンプル
- DotNetOracleConsoleSample.DotNetFive.Benchmark
    - DotNetOracleConsoleSample.DotNetFive.Benchmark のベンチマーク用

## Benchmark Result
### DotNetOracleConsoleSample.Core.Benchmark
|     Method |       Mean |    Error |   StdDev |
|----------- |-----------:|---------:|---------:|
|   SqlQuery | 1,098.5 ms | 20.67 ms | 31.56 ms |
| FromSqlRaw |   775.6 ms | 15.36 ms | 28.08 ms |

### DotNetOracleConsoleSample.DotNetFive.Benchmark
|     Method |       Mean |    Error |   StdDev |
|----------- |-----------:|---------:|---------:|
|   SqlQuery | 1,129.0 ms | 21.05 ms | 22.52 ms |
| FromSqlRaw |   789.2 ms | 15.67 ms | 31.30 ms |
