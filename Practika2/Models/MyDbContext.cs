using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika2.Models
{
	public class MyDbContext : DbContext
	{
		public MyDbContext() : base ("ConnectionString")
		{ }
		public DbSet<Person> People { get; set; }
	}
}
