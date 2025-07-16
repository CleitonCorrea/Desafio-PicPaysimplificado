using Microsoft.EntityFrameworkCore.Storage;
using PicPaySimplificado.Infra;
using PicPaySimplificado.Model;

namespace PicPaySimplificado.Repository.Transferencia
{
    public interface ITransferenciaRepository
    {
       Task AddTransaction(TransferenciaEntity entity);

        Task CommitAsyc();

        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
