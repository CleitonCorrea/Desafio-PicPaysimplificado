using PicPaySimplificado.Model.Requests;
using PicPaySimplificado.Model.Response;

namespace PicPaySimplificado.Services.Carteiras
{
    public interface ICarteiraService
    {
        Task<Result<bool>> ExecuteAsync(CarteiraRequest request);
    }
}
