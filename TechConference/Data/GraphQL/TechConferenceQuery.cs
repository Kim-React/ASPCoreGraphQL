using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using TechConference.Repository;

namespace TechConference.Data.GraphQL
{
    public class TechConferenceQuery:ObjectGraphType
    {
        public TechConferenceQuery(SessionRepository sessionRepository)
        {
            Field<ListGraphType<SessionType>>(
                "sessions",
                resolve: context => sessionRepository.GetSessions()
                );
        }
    } 
}
