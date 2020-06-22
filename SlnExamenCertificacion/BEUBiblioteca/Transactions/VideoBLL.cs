using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUBiblioteca.Transactions
{
    public class VideoBLL
    {
        public static void Create(Video a)
        {
            using (BibliotecaEntities db = new BibliotecaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Video.Add(a);
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

        public static Video Get(int? id)
        {
            BibliotecaEntities db = new BibliotecaEntities();
            return db.Video.Find(id);
        }

        public static void Update(Video Video)
        {
            using (BibliotecaEntities db = new BibliotecaEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Video.Attach(Video);
                        db.Entry(Video).State = System.Data.Entity.EntityState.Modified;
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
                        Video Video = db.Video.Find(id);
                        db.Entry(Video).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Video> List()
        {
            BibliotecaEntities db = new BibliotecaEntities();
            return db.Video.ToList();
        }
       
    }
}

