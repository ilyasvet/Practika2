using Practika2.Infrastructure.Commands;
using Practika2.Models;
using Practika2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Practika2.ViewModels
{
	internal class MainViewModel : ViewModelBase
	{
		#region Основные поля (Титл, прогресс-бар, статус-бар)
		private string _Title;
		public string Title
		{
			get => _Title;
			set => Set(ref _Title, value);
		}
		private string _ProgressString;
		public string ProgressString
		{
			get => _ProgressString;
			set => Set(ref _ProgressString, value);
		}
		private int _ProgressValue;
		public int ProgressValue
		{
			get => _ProgressValue;
			set => Set(ref _ProgressValue, value);
		}
		#endregion
		#region конструктор
		public MainViewModel()
		{
			#region Назначение основы (Титл, прогресс-бар, статус-бар)
			Title = "База данных";
			ProgressString = "Готово";
			ProgressValue = 0;
			AnimateProgressBar();
			Context = new MyDbContext();
			#endregion

			Persons = Context.People.ToList();


			CreatePage = new Views.Pages.CreatePage();
			#region Команды
			RestartCommand = new LambdaCommand(OnRestartCommandExecuted, CanRestatrCommandExecute);
			CreateNewPersonCommand = new LambdaCommand(OnCreateNewPersonExecuted, CanCreateNewPersonExecute);
			DeletePersonCommand = new LambdaCommand(OnDeletePersonCommandExecuted, CanDeletePersonCommandExecute);
			ShowWindowCommand = new LambdaCommand(OnShowWindowCommandExecuted, CanShowWindowCommandExecute);
			#endregion

		}
		#endregion
		#region Анимация прогресс-бара
		async private void AnimateProgressBar()
		{
			await Task.Run(() =>
			{
				while (true)
				{
					if (ProgressValue == 0)
					{
						while (ProgressValue < 100)
						{
							ProgressValue++;
							Task.Delay(50).Wait();
						}
					}
					if (ProgressValue == 100)
					{
						while (ProgressValue != 0)
						{
							ProgressValue--;
							Task.Delay(50).Wait();
						}
					}
				}
			});
		}
		#endregion
		#region Дата контекст
		public MyDbContext Context { get; set; }
		#endregion
		#region Список людей
		private List<Person> _Persons;
		public List<Person> Persons
		{
			get => _Persons;
			set
			{
				_Persons = value;
				OnPropertyChanged();
			}
		}
		#endregion
		#region Страница добавки
		private Page _CurrentPage { get; set; }
		public Page CurrentPage
		{
			get => _CurrentPage;
			set
			{
				_CurrentPage = value;
				OnPropertyChanged();

			}

		}
		private Page CreatePage;
		#endregion
		#region Команда - добавления человека
		public ICommand CreateNewPersonCommand { get; }
		public bool CanCreateNewPersonExecute(object p) => true;
		public void OnCreateNewPersonExecuted(object p)
		{

			CurrentPage = CreatePage;
		}
		#endregion
		#region Команда - обновить
		public ICommand RestartCommand { get; }
		public bool CanRestatrCommandExecute(object p) => true;
		public void OnRestartCommandExecuted(object p)
		{
			Persons = Context.People.ToList();
		}
		#endregion
		#region Команда - удалить
		public ICommand DeletePersonCommand { get; }
		public bool CanDeletePersonCommandExecute(object p) => true;
		public void OnDeletePersonCommandExecuted(object p)
		{
			Context.People.Remove(SelectedPerson);
			Context.SaveChanges();
			Persons = Context.People.ToList();
		}
		private Person _SelectedPerson;
		public Person SelectedPerson
		{
			get => _SelectedPerson;
			set => Set(ref _SelectedPerson, value);
		}
		#endregion
		#region Команда - показать окно другое
		public ICommand ShowWindowCommand { get; }
		public bool CanShowWindowCommandExecute(object p) => true;
		public void OnShowWindowCommandExecuted(object p)
		{
			var win = new AnotherWindow();
			win.Show();
			win.DataContext = new AnotherviewModel()
			{
				Persons2 = Persons,	
			};
		}
		#endregion
		

	}
}
