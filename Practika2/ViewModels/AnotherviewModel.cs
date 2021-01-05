using Practika2.Infrastructure.Commands;
using Practika2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Practika2.ViewModels
{
	internal class AnotherviewModel : ViewModelBase
	{
		public AnotherviewModel()
		{
			FindPersonCommand = new LambdaCommand(OnFindPersonCommandExecuted, CanFindPersonCommandExecute);
		}
		#region Список людейщ
		private List<Person> _Persons2;
		public List<Person> Persons2
		{
			get => _Persons2;
			set
			{
				_Persons2 = value;
				OnPropertyChanged();
			}
		}
		#endregion
		#region Текст ID и команда
		private string _TextID;
		public string TextID
		{
			get => _TextID;
			set => Set(ref _TextID, value);
		}
		public ICommand FindPersonCommand { get; }
		public bool CanFindPersonCommandExecute(object p) => !string.IsNullOrWhiteSpace(TextID);
		public void OnFindPersonCommandExecuted(object p)
		{
			if (int.TryParse(TextID, out int _value))
			{
				var person = Persons2.Find(s => s.ID == _value);
				if (person == null)
				{
					MessageBox.Show("Не найден");
					return;
				}
				MessageBox.Show(person.ToString());
			}
			else
			{
				MessageBox.Show("Данные некорректны");
			}
		}
		#endregion
	}
}
