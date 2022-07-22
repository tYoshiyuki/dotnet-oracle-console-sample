# dotnet-oracle-console-sample
ODP.NET で Oracle にデータアクセスするサンプル

## Feature
- .NET Framework
- .NET Core
- .NET6
- ODP.NET

## Project
- DotNetOracleConsoleSample
    - ODP.NET + .NET Framework + EntityFramework のサンプル
- DotNetOracleConsoleSample.Core
    - ODP.NET + .NET Core + EntityFrameworkCore のサンプル
- DotNetOracleConsoleSample.Core.Benchmark
    - DotNetOracleConsoleSample.Core のベンチマーク用
- DotNetOracleConsoleSample.DotNet
    - ODP.NET + .NET6 + EntityFrameworkCore のサンプル
- DotNetOracleConsoleSample.DotNet.Benchmark
    - DotNetOracleConsoleSample.DotNet.Benchmark のベンチマーク用

## Benchmark Result
### DotNetOracleConsoleSample.Core.Benchmark
|     Method |     Mean |   Error |  StdDev |
|----------- |---------:|--------:|--------:|
|   SqlQuery | 295.1 ms | 5.76 ms | 9.78 ms |
| FromSqlRaw | 249.3 ms | 4.54 ms | 3.79 ms |

### DotNetOracleConsoleSample.DotNet.Benchmark
|     Method |     Mean |   Error |  StdDev |
|----------- |---------:|--------:|--------:|
|   SqlQuery | 226.0 ms | 4.51 ms | 8.36 ms |
| FromSqlRaw | 156.5 ms | 3.07 ms | 4.69 ms |
