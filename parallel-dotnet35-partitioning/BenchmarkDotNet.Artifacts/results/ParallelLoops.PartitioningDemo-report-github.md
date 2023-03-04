``` ini

BenchmarkDotNet=v0.13.5, OS=ubuntu 22.04
AMD Ryzen 5 2400G with Radeon Vega Graphics, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.113
  [Host]     : .NET 6.0.13 (6.0.1322.60201), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.13 (6.0.1322.60201), X64 RyuJIT AVX2


```
|                 Method |       Mean |     Error |    StdDev |
|----------------------- |-----------:|----------:|----------:|
|        SquareEachValue | 3,152.7 μs | 106.97 μs | 313.71 μs |
| SquareEachValueChunked |   747.7 μs |  14.80 μs |  26.30 μs |
