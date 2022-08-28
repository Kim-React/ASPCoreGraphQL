using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechConference.Api.Data.Entities;
using TechConference.Data;

namespace TechConference.Repository
{
    public class SessionRepository
    {
        public TechConferenceDbContext _dbContext;
        public SessionRepository(TechConferenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Session> GetSessions()
        {
            return _dbContext.Sessions;
        }

        public Session AddSession(Session session)
        {
            _dbContext.Sessions.Add(session);
            _dbContext.SaveChanges();
            return session;
        }

    }
}
