using PicPaySimplificado.Model.Requests;
using PicPaySimplificado.Model.Response;
using PicPaySimplificado.Repository.Carteira;

namespace PicPaySimplificado.Services.Carteiras
{
    public class CarteirasService : ICarteiraService
    {
        public readonly ICarteiraRepository _carteiraRepository;

        public CarteirasService(ICarteiraRepository carteiraRepository)
        {
            _carteiraRepository = carteiraRepository;
        }

        

        public async Task<Result<bool>> ExecuteAsync(CarteiraRequest request)
        {
           var walletExists = await _carteiraRepository.GetByCpfCnpj(request.CpfCnpj, request.Email);

            if (walletExists != null)
            {
                return Result<bool>.Failure("Já existe uma carteira cadastrada com o CPF ou CNPJ informado.");
            }
            var wallet = new Model.CarteiraEntity(request.NomeCompleto, request.CpfCnpj, request.Email, request.Senha, request.TipoUsuario, request.SaldoConta);
            
            await _carteiraRepository.AddAsync(wallet);
            await _carteiraRepository.CommitAssync();

            return Result<bool>.Success(true);


        }
    
}
