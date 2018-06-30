using System.IO;
using Xunit;

namespace StigsPdfTools.Tests
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
		{
			if (File.Exists("Test1.pdf")) File.Delete("Test1.pdf");
			Program.CreateMergedPdf("Test1.pdf", "TestData");
			Assert.True(File.Exists("Test1.pdf"));
		}
	}
}