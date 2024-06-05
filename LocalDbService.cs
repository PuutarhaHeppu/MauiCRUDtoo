using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiCRUDtoo
{
    public class LocalDbService
    {
        private const string DB_Name = "myDatabase";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(".", DB_Name));
            _connection.CreateTableAsync<Person>();
        }

        public async Task<List<Person>> GetPersons()
        {
            return await _connection.Table<Person>().ToListAsync();
        }

        public async Task<Person> GetById(int id)
        {
            return await _connection.Table<Person>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Person Person)
        {
            await _connection.InsertAsync(Person);
        }

        public async Task Update(Person Person)
        {
            await _connection.UpdateAsync(Person);
        }

        public async Task Delete(Person Person)
        {
            await _connection.DeleteAsync(Person);
        }
    }
}
