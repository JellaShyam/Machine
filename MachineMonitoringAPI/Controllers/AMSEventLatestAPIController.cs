using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessServices;
using BusinessEntities;
using GenericRepository;
using UnitOfWork;

namespace MachineMonitoringAPI.Controllers
{
    public class AMSEventLatestAPIController : ApiController
    {
        private readonly IAMS_Event_LatestService _AMS_Event_LatestServiceServices;

         #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public AMSEventLatestAPIController()
        {
            _AMS_Event_LatestServiceServices = new AMS_Event_LatestService();
        }
        #endregion
        /// <summary>
        /// Fetching all AMS_Event_Latest
        /// </summary>
        public HttpResponseMessage Get()
        {
            var AMS_Event_Latest = _AMS_Event_LatestServiceServices.GetAllAMSEventLatestEntity();
            if (AMS_Event_Latest != null)
            {
                var AMS_Event_LatestEntities = AMS_Event_Latest as List<AMS_Event_LatestEntity> ?? AMS_Event_Latest.ToList();
                if (AMS_Event_LatestEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, AMS_Event_LatestEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
        }
        /// <summary>
        /// Fetching all AMS_Event_Latest by Id
        /// </summary>
        public HttpResponseMessage Get(int id)
        {
            var product = _AMS_Event_LatestServiceServices.GetAMSEventLatestEntityById(id);
            if (product != null)
                return Request.CreateResponse(HttpStatusCode.OK, product);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }
        /// <summary>
        /// Fetching all Sorted AMS_Event_Latest by Skipping and Take functionality
        /// </summary>
        [Route("api/AMSEventLatestAPI/GetSortedData")]
        public HttpResponseMessage GetSortedData()
        {
            string SortColumn = "EventDateTime";
            string SortDirection = "desc";
            int skip = 0;
            int take = 10;
            var AMS_Event_Latest = _AMS_Event_LatestServiceServices.GetSortedAMSEventLatestEntities(SortColumn, SortDirection, take, skip);
            if (AMS_Event_Latest != null)
            {
                var AMS_Event_LatestEntities = AMS_Event_Latest as List<AMS_Event_LatestEntity> ?? AMS_Event_Latest.ToList();
                if (AMS_Event_LatestEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, AMS_Event_LatestEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
        }
        /// <summary>
        /// Fetching Multiple AMS_Event_Latest by giving List of Sites
        /// </summary>
        [Route("api/AMSEventLatestAPI/GetByMultipleSiteId")]
        public HttpResponseMessage GetByMultipleSiteId()
        {
            List<string> Keys = new List<string> { "BS-0000001", "BS-0000002" };
            var AMS_Event_Latests = _AMS_Event_LatestServiceServices.GetManyAMSEventLatestEntities(Keys);
            if (AMS_Event_Latests != null)
                return Request.CreateResponse(HttpStatusCode.OK, AMS_Event_Latests);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }
        /// <summary>
        /// Inserting AMS_Event_Latest
        /// </summary>
        public int Post([FromBody] AMS_Event_LatestEntity _AMS_Event_LatestEntity)
        {
            return _AMS_Event_LatestServiceServices.AMS_Event_Latest(_AMS_Event_LatestEntity);
        }
        /// <summary>
        /// Update AMS_Event_Latest
        /// </summary>
        public bool Put(int id, [FromBody]AMS_Event_LatestEntity _AMS_Event_LatestEntity)
        {
            if (id  > 0)           
                return _AMS_Event_LatestServiceServices.UpdateAMS_Event_Latest(id, _AMS_Event_LatestEntity);            
            return false;
        }
        /// <summary>
        /// Delete AMS_Event_Latest
        /// </summary>
        public bool Delete(int id)
        {
            if (id > 0)
                return _AMS_Event_LatestServiceServices.DeleteAMS_Event_Latest(id);
            return false;
        }
    }
}
