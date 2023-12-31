﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bookinist.DAL.Context;
using Bookinist.DAL.Entityes.Base;
using Bookinist.Interfaces;

namespace Bookinist.DAL
{
	internal class DbRepository<T> : IRepository<T> where T : Entity, new()
	{
		private readonly BookinistDB _db;
		private readonly DbSet<T> _set;

		public bool AutoSaveChanges { get; set; } = true;

		public DbRepository(BookinistDB db)
		{
			_db = db;
		}

		public virtual IQueryable<T> Items => _set;

		public T Get(int id)
		{
			return Items.SingleOrDefault(item => item.Id == id);
		}

		public async Task<T> GetAsync(int id, CancellationToken cancel = default)
		{
			return await Items.SingleOrDefaultAsync(item => item.Id == id, cancel).ConfigureAwait(false);
		}

		public T Add(T item)
		{
			if (item == null) throw new ArgumentNullException(nameof(item));
			_db.Entry(item).State = EntityState.Added;
			if (AutoSaveChanges)
				_db.SaveChanges();

			return item;
		}

		public async Task<T> AddAsync(T item, CancellationToken cancel = default)
		{
			if (item == null) throw new ArgumentNullException(nameof(item));
			_db.Entry(item).State = EntityState.Added;
			if (AutoSaveChanges)
				await _db.SaveChangesAsync().ConfigureAwait(false);

			return item;
		}
		public void Update(T item)
		{
			if (item == null) throw new ArgumentNullException(nameof(item));
			_db.Entry(item).State = EntityState.Modified;
			if (AutoSaveChanges)
				_db.SaveChanges();
		}

		public async Task UpdateAsync(T item, CancellationToken cancel = default)
		{
			if (item == null) throw new ArgumentNullException(nameof(item));
			_db.Entry(item).State = EntityState.Modified;
			if (AutoSaveChanges)
				await _db.SaveChangesAsync();
		}


		public void Remove(int id)
		{
			_db.Remove(new T { Id = id });

			if(AutoSaveChanges) 
				_db.SaveChanges();
		}

		public async Task RemoveAsync(int id, CancellationToken cancel = default)
		{
			_db.Remove(new T { Id = id });

			if (AutoSaveChanges)
				await _db.SaveChangesAsync();
		}

	}
}
