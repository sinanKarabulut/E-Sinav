using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esinav.Domain.Shared.ValueObject;
using Esinav.Domain.Shared.DbContext;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Transactions;

namespace Esinav.Domain.Shared.Repository
{
    public class RepositoryForCRUD<T> : IRepositoryForCRUD<T> where T : class
    {
        private readonly IDbContextForCRUD _context;
        private IDbSet<T> _entities;

        public RepositoryForCRUD(IDbContextForCRUD context)
        {
            this._context = context;
        }

        public T GetById(object id)
        {
            return this._entities.Find(id);
        }

        public T GetById(object[] id)
        {
            return this.Entities.Find(id);
        }

        public IQueryable<T> Table
        {
            get { return this.Entities; }
        }
        public OperationResult Insert(T entity)
        {
            OperationResult result = new OperationResult(false);

            try
            {

                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Add(entity);

                int effectedRows = this._context.SaveChanges();

                if (effectedRows >= 1)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "{0} Özellik: {1} => Hata: {2}"
                            , entity.GetType().Name
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.Errors.Add(ex.Message);

            }
            return result;
        }

        public OperationResult Insert(IList<T> entityList)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entityList == null)
                {
                    throw new ArgumentNullException("entityList");
                }

                foreach (T entity in entityList)
                {
                    this.Entities.Add(entity);
                }

                int effectedRows = this._context.SaveChanges();

                if (effectedRows >= entityList.Count)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "Özellik: {0} => Hata: {1}"
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.Errors.Add(ex.Message);

            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<OperationResult> InsertAsync(T entity)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Add(entity);

                int effectedRows = await this._context.SaveChangesAsync();

                if (effectedRows >= 1)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }

            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "{0} Özellik: {1} => Hata: {2}"
                            , entity.GetType().Name
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                        );
                    }
                }
            }

            return result;
        }

        public async Task<OperationResult> InsertAsync(IList<T> entityList)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entityList == null)
                {
                    throw new ArgumentNullException("entityList");
                }

                foreach (T entity in entityList)
                {
                    this.Entities.Add(entity);
                }

                int effectedRows = await this._context.SaveChangesAsync();

                if (effectedRows >= entityList.Count)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }

            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "Özellik: {0} => Hata: {1}"
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                        );
                    }
                }
            }

            return result;
        }

        public OperationResult Update(T entity)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                int effectedRows = this._context.SaveChanges();

                if (effectedRows >= 1)
                {
                    result.Succeeded = true;

                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    string entityName = validationErrors.Entry.Entity.GetType().Name;
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "Obje: {0} {1}Özellik: {2} => Hata: {3}"
                            , entityName
                            , System.Environment.NewLine
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.Errors.Add(ex.Message);

            }
            return result;
        }

        public OperationResult Update(IList<T> entityList)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entityList == null)
                {
                    throw new ArgumentNullException("entityList");
                }

                int effectedRows = this._context.SaveChanges();

                if (effectedRows >= entityList.Count)
                {
                    result.Succeeded = true;

                    //this._context.Database.Connection.Close();

                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "Özellik: {0} => Hata: {1}"
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.Errors.Add(ex.Message);

            }
            return result;
        }

        public async Task<OperationResult> UpdateAsync(T entity)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                int effectedRows = await this._context.SaveChangesAsync();

                if (effectedRows >= 1)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "{0} Özellik: {1} => Hata: {2}"
                            , entity.GetType().Name
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.Errors.Add(ex.Message);

            }
            return result;
        }

        public async Task<OperationResult> UpdateAsync(IList<T> entityList)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entityList == null)
                {
                    throw new ArgumentNullException("entityList");
                }

                int effectedRows = await this._context.SaveChangesAsync();

                if (effectedRows >= entityList.Count)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "Özellik: {0} => Hata: {1}"
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                        );
                    }
                }
            }
            return result;
        }

        public OperationResult Delete(T entity)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Remove(entity);

                int effectedRows = this._context.SaveChanges();

                if (effectedRows >= 1)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "{0} Özellik: {1} => Hata: {2}"
                            , entity.GetType().Name
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                        );
                    }
                }
            }
            return result;
        }

        public OperationResult Delete(IList<T> entityList)
        {
            OperationResult result = new OperationResult(false);

            if (entityList == null)
            {
                throw new ArgumentNullException("entityList");
            }

            foreach (T entity in entityList)
            {
                this.Entities.Remove(entity);
            }

            int effectedRows = this._context.SaveChanges();

            if (effectedRows >= entityList.Count())
            {
                result.Succeeded = true;
            }
            else
            {
                result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
            }
            return result;
        }

        public async Task<OperationResult> DeleteAsync(T entity)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Remove(entity);

                int effectedRows = await this._context.SaveChangesAsync();

                if (effectedRows >= 1)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "{0} Özellik: {1} => Hata: {2}"
                            , entity.GetType().Name
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.Errors.Add(ex.Message);

            }
            return result;
        }

        public async Task<OperationResult> DeleteAsync(IList<T> entityList)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entityList == null)
                {
                    throw new ArgumentNullException("entityList");
                }

                foreach (T entity in entityList)
                {
                    this.Entities.Remove(entity);
                }

                int effectedRows = await this._context.SaveChangesAsync();

                if (effectedRows >= entityList.Count)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "Özellik: {0} => Hata: {1}"
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.Errors.Add(ex.Message);

            }
            return result;
        }

        public IEnumerable<T_Target> ToList<T_Target>(IQueryable<T_Target> query)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                IEnumerable<T_Target> toReturn = query.ToList();
                scope.Complete();
                return toReturn;
            }
        }

        public T_Target ToSingle<T_Target>(IQueryable<T_Target> query)
        {
            var trace = query.ToString();

            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                T_Target toReturn = query.SingleOrDefault();
                scope.Complete();
                return toReturn;
            }
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (this._entities == null)
                {
                    this._entities = _context.Set<T>();
                }

                return this._entities;
            }
        }
    }
}
