namespace DevFreela.Payments.Domain.Interfaces;

public interface IMessageBusService
{
    void Publish(string queue, byte[] message);
}