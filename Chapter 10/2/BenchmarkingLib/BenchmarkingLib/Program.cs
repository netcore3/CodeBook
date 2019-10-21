using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BenchmarkDotNet.Attributes;

using BenchmarkDotNet.Running;
using LibToBenchmark;

namespace BenchmarkingLib
{
	[MemoryDiagnoser]
	[DisassemblyDiagnoser(printAsm: true, printSource: true, printIL: true)]
	public class Program
	{
		static List<HistoricalValue> HisticalPrices;

		static Program()
		{
			HistoricalPriceReader reader = new HistoricalPriceReader();
			HisticalPrices = reader.GetHistoricalQuotes("MSFT").ToList();
		}
		static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<Program>();
			Console.ReadKey();
		}

		[Benchmark]
		//public static void CalculateWithLinq()
		public void CalculateWithLinq()
		{
			var linqres = SimpleMovingAverage.CalculateSMALinq(HisticalPrices, 14);
			Debug.WriteLine(linqres.Count);
		}

		[Benchmark]
		public void CalculateWithNonLinq()
		{
			var res = SimpleMovingAverage.CalculateSMA(HisticalPrices, 14);
			Debug.WriteLine(res.Count);
		}
	}
}