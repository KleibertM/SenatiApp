using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Joss.Model;
using System.Threading.Tasks;

namespace Joss.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath) 
        { 
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Alumno>().Wait();
        }

        public Task<int> SaveAlumnoASync(Alumno alum)
        {
            if (alum.IdAlum != 0)
            {
                return db.UpdateAsync(alum);
            } else
            {
                return db.InsertAsync(alum);
            }
        }

        public Task<int> DeleteAlumnoAsync(Alumno alum)
        {
            return db.DeleteAsync(alum);
        }

        public Task<List<Alumno>> GetAlumnosAsync()
        {
            return db.Table<Alumno>().ToListAsync();
        }

        public Task<Alumno> GetAlumnoById(int idAlum)
        {
            return db.Table<Alumno>().Where(a => a.IdAlum == idAlum).FirstOrDefaultAsync();
        }
    }
}
