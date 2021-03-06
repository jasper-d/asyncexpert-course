﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace Dotnetos.AsyncExpert.Homework.Module01.Benchmark
{
    [DisassemblyDiagnoser(exportCombinedDisassemblyReport: true, maxDepth: 2, printInstructionAddresses: true, exportHtml: true)]
    [MemoryDiagnoser]
    [ShortRunJob]
    public class FibonacciCalc
    {
        // HOMEWORK:
        // ✔ 1. Write implementations for RecursiveWithMemoization and Iterative solutions
        // ✔ 2. Add memory profiler to the benchmark
        // ✔ 3. Run with release configuration and compare results 
        // ✔ 4. Open disassembler report and compare machine code
        // 
        // You can use the discussion panel to compare your results with other students

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public ulong Recursive(ulong n)
        {
            if (n == 0) return 0;
            if (n == 1 || n == 2) return 1;
            return Recursive(n - 2) + Recursive(n - 1);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public ulong TailRecursive(ulong n) => 
            Fibonacci.Fs.Fibonacci.fib(n);

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Data))]
        public ulong Iterative(ulong n)
        {
            return Compute(n);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static ulong Compute(ulong n)
        {
            if (n == 0) return 0;
            ulong head = 1;
            ulong tail = 1;
            for (ulong i = 2; i < n; i++)
            {
                ulong carry = head;
                head = tail;
                tail += carry;
            }
            return tail;
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public ulong TailRecursiveMemoized(ulong n) =>
            Fibonacci.Fs.Fibonacci.memoized.Invoke(n);

        public IEnumerable<ulong> Data()
        {
            yield return 15;
            yield return 35;
        }
    }
}
