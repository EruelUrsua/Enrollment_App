using Enrollment.Datamodel;
using Enrollment.DataModel;
using Entprog.DataModel.Repository;

namespace Enrollment.App.Models.Repositories
{
    public class SubjectRepo : GenericRepo<Subject>, ISubjectRepo
    {
        public SubjectRepo(AppDbContext context) : base(context)
        {

        }
    }
}
