﻿#region Using Namespaces...

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Entity.Validation;
using GenericRepository;
using DataModel;

#endregion

namespace UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...

        private DBForTestingEntities _context = null;
        private GenericRepository<AMS_Event_Latest> _AMS_Event_LatestRepository;
        private GenericRepository<AMS_Event> _AMS_EventRepository;
        
        #endregion

        public UnitOfWork()
        {
            _context = new DBForTestingEntities();
        }

        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for Project repository.
        /// </summary>
        public GenericRepository<AMS_Event_Latest> AMS_Event_LatestRepository
        {
            get
            {
                if (this._AMS_Event_LatestRepository == null)
                    this._AMS_Event_LatestRepository = new GenericRepository<AMS_Event_Latest>(_context);
                return _AMS_Event_LatestRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<AMS_Event> AMS_EventRepository
        {
            get
            {
                if (this._AMS_EventRepository == null)
                    this._AMS_EventRepository = new GenericRepository<AMS_Event>(_context);
                return _AMS_EventRepository;
            }
        }

        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, 
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false; 
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}