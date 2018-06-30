// Copyright 2018 Stig Schmidt Nielsson. This file is distributed under the MIT license - see LICENSE.txt file in root dir or https://opensource.org/licenses/MIT. 

using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace StigsPdfMerge {
	public class Program {
		private static int Main(string[] args) {
			if (args.Length != 2) return Usage();
			CreateMergedPdf(args[0], args[1]);
			Console.ReadLine();
			return 0;
		}
		private static int Usage(string msg = null) {
			if(msg != null) Console.Error.WriteLine(msg);
			Console.Error.WriteLine("Usage: StgsPdfMerge.exe <OUTPUTFILE> <DIRECTORY_WITH_PDF_FILES>\n");
			Console.ReadLine();
			return -1;
		}

		public static void CreateMergedPdf(string outputFile, string sourceDir) {
			using (var stream = new FileStream(outputFile, FileMode.Create)) {
				var pdfDoc = new Document(PageSize.A4);
				var pdf = new PdfCopy(pdfDoc, stream);
				pdfDoc.Open();
				string[] files = Directory.GetFiles(sourceDir, "*.pdf");
				Console.WriteLine($"Merging {files.Length} into {outputFile}.");
				foreach (var file in files) {
					Console.WriteLine("Adding " + file);
					pdf.AddDocument(new PdfReader(file));
				}
				pdfDoc.Close();
				Console.WriteLine($"{outputFile} created.");
			}
		}
	}
}