﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.ViewModels
{
	static class ViewModelRegistrator
	{
		public static IServiceCollection AddViewModel(this IServiceCollection services) => services
			.AddSingleton<MainWindowViewModel>();
	}
}
