using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOW = UnitOfWork;
using BusinessEntities;
using System.Transactions;
using GenericRepository;
using DataModel;

namespace BusinessServices
{
    public class AMS_Event_LatestService:IAMS_Event_LatestService
    {
        private readonly UOW.UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
         public AMS_Event_LatestService()
        {
            _unitOfWork = new UOW.UnitOfWork();
        }
         /// <summary>
         /// Fetches AMS_Event_LatestEntity details by id
         /// </summary>
         /// <param name="AMSEventLatestEntityId"></param>
         /// <returns></returns>
        public AMS_Event_LatestEntity GetAMSEventLatestEntityById(int AMSEventLatestEntityId)
        {
            var _AMS_Event_LatestEntity = _unitOfWork.AMS_Event_LatestRepository.GetByID(AMSEventLatestEntityId);
            if (_AMS_Event_LatestEntity != null)
            {
                var projectModel = Mapper.Map<AMS_Event_LatestEntity>(_AMS_Event_LatestEntity);
                return projectModel;
            }
            return null;
        }
        /// <summary>
        /// Fetches all the GetAllAMSEventLatestEntities.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AMS_Event_LatestEntity> GetAllAMSEventLatestEntity()
        {
            var _AMS_Event_LatestEntity = _unitOfWork.AMS_Event_LatestRepository.GetAll().ToList();
            if (_AMS_Event_LatestEntity.Any())
            {
                var productsModel = Mapper.Map<List<AMS_Event_LatestEntity>>(_AMS_Event_LatestEntity);
                return productsModel;
            }
            return null;
        }
        /// <summary>
        /// Creates a AMS_Event_LatestEntity
        /// </summary>
        /// <param name="AMSEventLatestEntity"></param>
        /// <returns>_AMSEventLatest.Id</returns>
        public int AMS_Event_Latest(AMS_Event_LatestEntity AMSEventLatestEntity)
        {
            using (var scope = new TransactionScope())
            {
                var _AMSEventLatest = new AMS_Event_Latest
                {
                    SiteId = AMSEventLatestEntity.SiteId
                };
                _unitOfWork.AMS_Event_LatestRepository.Insert(_AMSEventLatest);
                _unitOfWork.Save();
                scope.Complete();
                return _AMSEventLatest.Id;
            }
        }
        /// <summary>
        /// Updates a AMSEventLatestEntity
        /// </summary>
        /// <param name="AMSEventLatestEntityId"></param>
        /// <param name="AMSEventLatestEntity"></param>
        /// <returns>success</returns>
        public bool UpdateAMS_Event_Latest(int AMSEventLatestEntityId, AMS_Event_LatestEntity AMSEventLatestEntity)
        {
            var success = false;
            if (AMSEventLatestEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var _AMSEventLatestEntity = _unitOfWork.AMS_Event_LatestRepository.GetByID(AMSEventLatestEntityId);
                    if (_AMSEventLatestEntity != null)
                    {
                        _AMSEventLatestEntity.SiteId = AMSEventLatestEntity.SiteId;
                        _unitOfWork.AMS_Event_LatestRepository.Update(_AMSEventLatestEntity);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
        /// <summary>
        /// Deletes a particular AMSEventLatestEntity
        /// </summary>
        /// <param name="AMSEventLatestEntityId"></param>
        /// <returns>success</returns>
        public bool DeleteAMS_Event_Latest(int AMSEventLatestEntityId)
        {
            var success = false;
            if (AMSEventLatestEntityId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var Project = _unitOfWork.AMS_Event_LatestRepository.GetByID(AMSEventLatestEntityId);
                    if (Project != null)
                    {
                        _unitOfWork.AMS_Event_LatestRepository.Delete(Project);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
        /// <summary>
        /// Fetches all the AMSEventLatestEntities.
        /// </summary>
        /// <param name="Keys"></param>(List Of Site Ids)
        /// <returns></returns>
        public IEnumerable<AMS_Event_LatestEntity> GetManyAMSEventLatestEntities(List<string> Keys)
        {
            var _AMS_Event_LatestEntity = _unitOfWork.AMS_Event_LatestRepository.GetMany(x => Keys.Contains(x.SiteId)).ToList();
            if (_AMS_Event_LatestEntity.Any())
            {
                var _latestSiteEvents = Mapper.Map<List<AMS_Event_LatestEntity>>(_AMS_Event_LatestEntity);
                return _latestSiteEvents;
            }
            return null;
        }
        /// <summary>
        /// Fetches all the AMSEventLatestEntities based on input Filters.
        /// </summary>
        /// <param name="SortColumn"></param>
        /// <param name="SortDirection"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        public IEnumerable<AMS_Event_LatestEntity> GetSortedAMSEventLatestEntities(string SortColumn, string SortDirection, int take, int skip)
        {
            var _AMS_Event_LatestEntity = _unitOfWork.AMS_Event_LatestRepository.GetSrtedData(SortColumn, SortDirection, take, skip);
            if (_AMS_Event_LatestEntity.Any())
            {
                var _latestSiteEvents = Mapper.Map<List<AMS_Event_LatestEntity>>(_AMS_Event_LatestEntity);
                return _latestSiteEvents;
            }
            return null;
        }
    }
}
