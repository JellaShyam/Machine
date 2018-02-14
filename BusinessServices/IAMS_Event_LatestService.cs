using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IAMS_Event_LatestService
    {
        AMS_Event_LatestEntity GetAMSEventLatestEntityById(int AMSEventLatestEntityId);
        //AMS_Event_LatestEntity GetAMS_Event_LatestEntityBySiteId(string SiteId);
        IEnumerable<AMS_Event_LatestEntity> GetAllAMSEventLatestEntity();
        IEnumerable<AMS_Event_LatestEntity> GetManyAMSEventLatestEntities(List<string> Keys);
        IEnumerable<AMS_Event_LatestEntity> GetSortedAMSEventLatestEntities(string SortColumn, string SortDirection, int take, int skip);
        int AMS_Event_Latest(AMS_Event_LatestEntity AMSEventLatestEntity);
        bool UpdateAMS_Event_Latest(int projectId, AMS_Event_LatestEntity AMSEventLatestEntity);
        bool DeleteAMS_Event_Latest(int AMSEventLatestEntityId);
    }
}
