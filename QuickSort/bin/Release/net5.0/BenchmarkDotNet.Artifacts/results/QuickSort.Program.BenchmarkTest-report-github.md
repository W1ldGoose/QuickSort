``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19041.1348 (2004/May2020Update/20H1)
Intel Core i5-7400 CPU 3.00GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK=5.0.402
  [Host]     : .NET 5.0.11 (5.0.1121.47308), X64 RyuJIT
  Job-QPZBCL : .NET 5.0.11 (5.0.1121.47308), X64 RyuJIT

RunStrategy=Throughput  

```
|       Method |        N |       Mean |      Error |    StdDev | Rank |     Gen 0 |    Allocated |
|------------- |--------- |-----------:|-----------:|----------:|-----:|----------:|-------------:|
| ParallelTest |  1000000 |   8.054 ms |  0.1533 ms | 0.1640 ms |    1 |  218.7500 |    682,730 B |
|   SerialTest |  1000000 |  25.023 ms |  0.3228 ms | 0.3020 ms |    2 |         - |            - |
| ParallelTest | 10000000 | 215.917 ms |  3.2099 ms | 2.6804 ms |    3 | 6666.6667 | 21,333,677 B |
|   SerialTest | 10000000 | 769.202 ms | 10.4976 ms | 9.3058 ms |    4 |         - |            - |
