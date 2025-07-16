using Microsoft.EntityFrameworkCore.Storage;
using PicPaySimplificado.Infra;
using PicPaySimplificado.Model;

namespace PicPaySimplificado.Repository.Transferencia
{
    public class TransferenciaRepository : ITransferenciaRepository
    {
        private readonly ApplicationDbContext _context;

        public TransferenciaRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddTransaction(TransferenciaEntity entity)
        {
            await _context.transfers.AddAsync(entity);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
          return await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsyc()
        {
            await _context.SaveChangesAsync();
        }
    }
}
