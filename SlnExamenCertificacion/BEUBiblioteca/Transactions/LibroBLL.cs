using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUBiblioteca.Transactions
{
    public class LibroBLL
    {
            public static void Create(Libro a)
            {
                using (BibliotecaEntities db = new BibliotecaEntities())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            db.Libro.Add(a);
                            db.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }

            public static Libro Get(int? id)
            {
            BibliotecaEntities db = new BibliotecaEntities();
                return db.Libro.Find(id);
            }

            public static void Update(Libro Libro)
            {
            using (BibliotecaEntities db = new BibliotecaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Libro.Attach(Libro);
                        db.Entry(Libro).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            }

            public static void Delete(int? id)
            {
            using (BibliotecaEntities db = new BibliotecaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Libro Libro = db.Libro.Find(id);
                        db.Entry(Libro).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            }

            public static List<Libro> List()
            {
                BibliotecaEntities db = new BibliotecaEntities();
                return db.Libro.ToList();
            }

        }
    }
