﻿using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist
{
	internal class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			var app = new App();
			app.InitializeComponent();
			app.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] arg) => Host
			.CreateDefaultBuilder(arg)
			.ConfigureServices(App.ConfigureServices);
	}
}
