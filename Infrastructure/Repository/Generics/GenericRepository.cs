using Domain.Interfaces.Generics;
using Entities.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generics
{
    public class GenericRepository<T> : IGeneric<T>, IDisposable where T : class
    {

        // To detect redundant calls
        private bool _disposed = false;

        // Instantiate a SafeHandle instance.
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        private readonly DbContextOptions<ContextBase> _optionBuilder;

        public GenericRepository()
        {
            _optionBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task Add(T objeto)
        {
            using var data = new ContextBase(_optionBuilder);
            await data.Set<T>().AddAsync(objeto);
            await data.SaveChangesAsync();
        }

        public async Task Delete(T objeto)
        {
            using var data = new ContextBase(_optionBuilder);
            data.Set<T>().Remove(objeto);
            await data.SaveChangesAsync();
        }

        public async Task<T> GetEntityById(int id)
        {
            using var data = new ContextBase(_optionBuilder);
            return await data.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> List()
        {
            using var data = new ContextBase(_optionBuilder);
            return await data.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task Update(T objeto)
        {
            using var data = new ContextBase(_optionBuilder);
            data.Set<T>().Update(objeto);
            await data.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _safeHandle?.Dispose();
            }

            _disposed = true;
        }
    }
}
