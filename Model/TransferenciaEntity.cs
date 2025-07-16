using System.Security.Cryptography.X509Certificates;

namespace PicPaySimplificado.Model
{
    public class TransferenciaEntity
    {
        public Guid IdTransaction { get; set; }
        public int SenderId { get; set; }
        public CarteiraEntity Sender { get; set; }
        public int ReceiverId { get; set; }
        public CarteiraEntity Receiver { get; set; }
        public decimal Valor { get; set; } 

        public TransferenciaEntity(Guid idTransaction, int senderId, CarteiraEntity sender, int receiverId, CarteiraEntity receiver, decimal valor)
        {
            IdTransaction = idTransaction;
            SenderId = senderId;
            Sender = sender;
            ReceiverId = receiverId;
            Receiver = receiver;
            Valor = valor;
        }

        private TransferenciaEntity()
        {
            // EF Core requires a parameterless constructor for entity instantiation
        }

    }

}

