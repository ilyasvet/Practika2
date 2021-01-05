using Practika2.Infrastructure.Commands;
using Practika2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Practika2.ViewModels
{
	internal class CreateViewModel : ViewModelBase
	{
		#region Поля добавления человека и команда 
		private string _Name;
		public string Name
		{
			get => _Name;
			set => Set(ref _Name, value);
		}
		private string _SurName;
		public string SurName
		{
			get => _SurName;
			set => Set(ref _SurName, value);
		}
		private string _Age;
		public string Age
		{
			get => _Age;
			set => Set(ref _Age, value);
		}
		public bool CanCreateNewPersonEndExecute(object p) => !string.IsNullOrWhiteSpace(Age)
			&& !string.IsNullOrWhiteSpace(Name)
			&& !string.IsNullOrWhiteSpace(SurName);
		public void OnCreateNewPersonEndExecuted(object p)
		{
			var person = new Person()
			{
				Name = Name,
				SurName = SurName,
				Age = int.Parse(Age),
			};
			Context.People.Add(person);
			Context.SaveChanges();
		}
		public ICommand CreateNewPersonEndCommand { get; }
		#endregion
		#region Конструктор
		public CreateViewModel()
		{
			CreateNewPersonEndCommand = new LambdaCommand(OnCreateNewPersonEndExecuted, CanCreateNewPersonEndExecute);
			
			Context = new MyDbContext();
		}
		public MyDbContext Context { get; set; }
		#endregion
		
	}
}
