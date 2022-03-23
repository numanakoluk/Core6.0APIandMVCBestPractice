using Core.UnitOfWorks;

namespace Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOFWork
    {
        private readonly AppDbContext _context;

        //Ctor Desc
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
