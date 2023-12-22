using Bookinist.DAL.Entityes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.DAL.Entityes
{
	public class Book : NamedEntity
	{
		public virtual Category Category { get; set; }
	}
}
