using Practika2.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika2.Infrastructure.Commands
{
	internal class LambdaCommand : Command
	{
		private readonly Action<object> _Execute;
		private readonly Func<object, bool> _CanExecute;
		public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecuted = null)
		{
			_Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
			_CanExecute = CanExecuted;
		}
		public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;


		public override void Execute(object parameter) => _Execute(parameter);

	}
}
