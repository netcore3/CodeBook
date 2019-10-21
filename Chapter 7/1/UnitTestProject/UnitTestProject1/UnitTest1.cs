using Microsoft.VisualStudio.TestTools.UnitTesting;

using ConsoleApp;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethodisPair()
		{
			bool res = Program.isPair(2);
			Assert.IsTrue(res);

		}
		[TestMethod]
		public void TestMethodisPair2()
		{
			bool res = Program.isPair(3);
			Assert.IsFalse(res);

		}
	}
}
