using System;

namespace DotNetDesignPatternDemos.SOLID.InterfaceSegregationPrinciple
{
	public class Document
	{
	}

	public interface IMachine
	{
		void Print(Document d);
		void Scan(Document d);
		void Fax(Document d);
	}

	// ok if you need a multifunction machine
	public class MultiFunctionPrinter : IMachine
	{
		public void Print(Document d)
		{
			//
		}

		public void Scan(Document d)
		{
			//
		}

		public void Fax(Document d)
		{
			//
		}
	}

	public class OldFashionPrinter : IMachine
	{
		public void Print(Document d)
		{
			// yep
		}

		public void Scan(Document d)
		{
			throw new NotImplementedException();
		}

		public void Fax(Document d)
		{
			throw new NotImplementedException();
		}
	}

	public interface IPrinter
	{
		void Print(Document d);
	}

	public interface IScanner
	{
		void Scan(Document d);
	}

	public class Printer : IPrinter
	{
		public void Print(Document d)
		{

		}
	}

	public class Photocopier : IPrinter, IScanner
	{
		public void Print(Document d)
		{
			throw new NotImplementedException();
		}

		public void Scan(Document d)
		{
			throw new NotImplementedException();
		}
	}

	public interface IMultipFunctionDevice : IScanner, IPrinter //...
	{

	}

	public class MultiFunctionMachine : IMultipFunctionDevice
	{
		// compose this out of several modules
		private IPrinter printer;
		private IScanner scanner;

		public MultiFunctionMachine(IPrinter printer, IScanner scanner)
		{
			if (printer == null)
			{
				throw new ArgumentNullException(paramName: "Printer");
			}
			if (scanner == null)
			{
				throw new ArgumentNullException(paramName: "Scanner");
			}
			this.printer = printer;
			this.scanner = scanner;
		}

		public void Print(Document d)
		{
			printer.Print(d);
		}

		public void Scan(Document d)
		{
			scanner.Scan(d);
		}
	}
}
