using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika2.Models
{
	public class Person
	{
		private int _ID;
		public int ID
		{
			get => _ID;
			set => _ID = value;
		}

		private string _Name;
		public string Name
		{
			get => _Name;
			set => _Name = value;
		}
		private int _Age;
		public int Age
		{
			get => _Age;
			set => _Age = value;
		}
		private string _SurName;
		public string SurName
		{
			get => _SurName;
			set => _SurName = value;
		}
		public Person() { }
		public override string ToString()
		{
			return $"{Name} {SurName} {Age}";
		}
	}
}
