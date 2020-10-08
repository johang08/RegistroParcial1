using RegistroParcial1_JohanLuis.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroParcial1_JohanLuis.BLL
{
    public class ArticulosBLL
    {
        public static bool Guardar(Articulos articulos)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Persona.Add(articulos) != null)
                {
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }
        public static bool Modificar(Articulos articulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                articulos = contexto.Articulos.Find(articulos.ArticulosID);
                foreach (var item in articulos.Existencia)
                {
                    if (!articulos.Existencia.Exists(d => d.Id == item.Id))
                        contexto.Entry(item).State = EntityState.Deleted;
                }
                contexto.Entry(articulos).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Articulos articulos = contexto.Articulos.Find(id);
                contexto.Entry(articulos).State = EntityState.Deleted;
                paso = (contexto.SaveChanges() > 0);

            }
            catch (Exception)
            {
                throw;
            }
            contexto.Dispose();
            return paso;

        }


    }
}

public static Articulos Buscar(int id)
{
    Contexto = new Contexto();
    Articulos articulos = new Articulos();
    try
    {
        articulos = Contexto.Articulos.Find(id);
        articulos.Existencia.Count();
    }
    catch (Exception)
    { throw; }
    finally
    { Contexto.Dispose(); }
    return articulos;
}

public static List<Articulos> GetList(Expression<Func<Articulos, bool>> articulos)
{
    List<Articulos> Lista = new List<Articulos>();
    Contexto contexto = new Contexto();
    try
    {
        Lista = Contexto.Persona.Where(articulos).ToList();
    }
    catch (Exception)
    {
        throw;
    }
    finally
    {
        Contexto.Dispose();
    }
    return Lista;
}

