using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Infra;
using PicPaySimplificado.Model;

namespace PicPaySimplificado.Repository.Carteira
{
    public class CarteiraRepository : ICarteiraRepository
    {
        private readonly ApplicationDbContext _context;

        public CarteiraRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddAsync(CarteiraEntity carteira)
        {
           await  _context.Wallets.AddAsync(carteira);
        }

        public async Task CommitAssync()
        {
           await _context.SaveChangesAsync();
        }

        public async Task<CarteiraEntity> GetByCpfCnpj(string cpfCnpj, string email)
        {
            return await _context.Wallets
                .FirstOrDefaultAsync(w => w.CpfCnpj.Equals(cpfCnpj) || w.Email.Equals(email));
        }

        public async Task<CarteiraEntity> GetById(int id)
        {
            return await _context.Wallets
                .FindAsync(id);
        }

        public async Task UpdateAsync(CarteiraEntity carteira)
        {
            _context.Update(carteira);
        }
    }
}
