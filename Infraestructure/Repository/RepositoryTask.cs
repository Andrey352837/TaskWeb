using Infraestructure.Models;
using Infraestructure.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;


namespace Infraestructure.Repository
{
    public class RepositoryTask : IRepositoryTask
    {        

        public IEnumerable<TaskDB> GetTasks()
        {
            IEnumerable<TaskDB> lista = null;
            try
            {

                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener todos las tasks incluyendo el autor
                    lista = ctx.TaskDB.ToList<TaskDB>();


                }
                return lista;
            }

            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public IEnumerable<TaskDB> GetTasksForComplete(int pOption)
        {
            int option = 0;
            if (pOption ==1){
                option = 1;
            }
            IEnumerable<TaskDB> oTask = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener libros por Autor
                    oTask = ctx.TaskDB.
                        Where(l => l.completeTask.Equals(option)).ToList<TaskDB>();

                }
                return oTask;
            }

            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        } 

        public TaskDB GetTaskForId(int id)
        {
            TaskDB oTaskDB = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener libro por ID incluyendo el autor y todas sus categorías
                    oTaskDB = ctx.TaskDB.Find(id);

                }
                return oTaskDB;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public TaskDB Save(TaskDB pTask)
        {
            int retorno = 0;
            TaskDB oTaskDB = null;

            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oTaskDB = GetTaskForId((int)pTask.id);
               

                if (oTaskDB == null)
                {

                    //Insertar
                    //Logica para agregar las categorias al libro
                    
                       
                    
                    //Insertar Libro
                    ctx.TaskDB.Add(pTask);
                    //SaveChanges
                    //guarda todos los cambios realizados en el contexto de la base de datos.
                    retorno = ctx.SaveChanges();
                    //retorna número de filas afectadas
                }
                else
                {
                    //Registradas: 1,2,3
                    //Actualizar: 1,3,4

                    //Actualizar Libro
                    ctx.TaskDB.Add(pTask);
                    ctx.Entry(pTask).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();

                    //Logica para actualizar Categorias
                   
                }
            }

            if (retorno >= 0)
                oTaskDB = GetTaskForId((int)pTask.id);

            return oTaskDB;
       
    }
    }
}
