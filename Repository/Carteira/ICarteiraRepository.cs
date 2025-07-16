using PicPaySimplificado.Model;

namespace PicPaySimplificado.Repository.Carteira
{
    public interface ICarteiraRepository
    {
        Task AddAsync(CarteiraEntity carteira);
        Task UpdateAsync(CarteiraEntity carteira);

        Task<CarteiraEntity> GetByCpfCnpj( string cpfCnpj, string email);

        Task<CarteiraEntity> GetById(int id);

        Task CommitAssync();
       
    }
}
