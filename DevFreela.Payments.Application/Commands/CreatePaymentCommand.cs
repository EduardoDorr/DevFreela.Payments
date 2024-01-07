using MediatR;

namespace DevFreela.Payments.Application.Commands;

public record CreatePaymentCommand(int ProjectId, string CreditCardNumber, string Cvv, string ExpiresAt, string FullName, decimal Amount) : IRequest<bool>;