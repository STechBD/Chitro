using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Chitro
{
	/// <summary>
	/// Load the main window of the application.
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			// Show the main window of the application
			Window window = new Model.MainWindow();
			window.Show();
		}
	}
}
