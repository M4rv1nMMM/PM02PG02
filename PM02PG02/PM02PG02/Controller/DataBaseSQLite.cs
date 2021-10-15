using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PM02PG02.Models;
using SQLite;

namespace PM02PG02.Controller
{
    public class DataBaseSQLite
    {
        readonly SQLiteAsyncConnection db;

        //Constructor de la clase DataBaseSQLite
        public DataBaseSQLite(String pathdb)
        {
            //Crear una conexion a la base de datos
            db = new SQLiteAsyncConnection(pathdb);

            //Creacion de la tabla personas dentro de SQLite
            db.CreateTableAsync<Personas>().Wait();
        }

        // Operaciones CRUD con SQLite
        // READ List Way 

        public Task<List<Personas>> ObtenerListaPersonas()
        {
            return db.Table<Personas>().ToListAsync();
        }

        // READ one by one
        public Task<Personas> ObtenerPersona(int pcodigo)
        {
            return db.Table<Personas>()
                .Where(i => i.codigo == pcodigo)
                .FirstOrDefaultAsync();
        }

        // CREAR persona
        public Task<int> GrabarPersona(Personas persona)
        {
            if(persona.codigo != 0)
            {
                return db.UpdateAsync(persona);
            }    
            else
            {
                return db.InsertAsync(persona);
            }    
        }

        // DELETE
        public Task<int> EliminarPersona(Personas persona)
        {
            return db.DeleteAsync(persona);
        }
    }
}
