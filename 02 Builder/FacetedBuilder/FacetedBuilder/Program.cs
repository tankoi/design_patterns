using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacetedBuilder
{
	public class Person
	{
		// address
		public string StreetAddress, PostCode, City;

		// employment
		public string CompanyName, Position;
		public int AnnualIncome;

		public override string ToString()
		{
			return string.Format("StreetAddress: {0}, PostCode: {1}, City: {2}, Company: {3}, Position: {4}, AnnualIncome: {5}"
				, StreetAddress
				, Position
				, City
				, CompanyName
				, Position
				, AnnualIncome
			);
		}
	}

	public class  PersonBuilder // facade
	{
		// reference!
		protected Person person = new Person();

		public PersonJobBuilder Works { get { return new PersonJobBuilder(person); } }
		public PersonAddressBuilder Lives {	get	{ return new PersonAddressBuilder(person); } }

		public static implicit operator Person(PersonBuilder pb)
		{
			return pb.person;
		}
	}

	public class PersonAddressBuilder : PersonBuilder
	{
		public PersonAddressBuilder(Person person)
		{
			this.person = person;
		}

		public PersonAddressBuilder At(string streetAddress)
		{
			person.StreetAddress = streetAddress;

			return this;
		}

		public PersonAddressBuilder WithPostCode(string postCode)
		{
			person.PostCode = postCode;

			return this;
		}

		public PersonAddressBuilder In(string city)
		{
			person.City = city;

			return this;
		}
	}

	public class PersonJobBuilder : PersonBuilder
	{
		public PersonJobBuilder(Person person)
		{
			this.person = person;
		}

		public PersonJobBuilder At(string companyName)
		{
			person.CompanyName = companyName;

			return this;
		}

		public PersonJobBuilder AsA(string position)
		{
			person.Position = position;

			return this;
		}

		public PersonJobBuilder Earning(int amount) 
		{
			person.AnnualIncome = amount;

			return this;
		}
	}

	public class Demo
	{
		static void Main(string[] args)
		{
			var pb = new PersonBuilder();
			Person person = pb
				.Lives
					.At("123 London Road")
					.In("London")
					.WithPostCode("SW12AC")
				.Works
					.At("Fabrikam")
					.AsA("Engineer")
					.Earning(123000);

			Console.WriteLine(person);
		}
	}
}
