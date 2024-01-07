using MediatR;

using DevFreela.Payments.Application.Notifications;

namespace DevFreela.Payments.Application.Commands.Handlers;

public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, bool>
{
    private readonly IMediator _mediator;

    public CreatePaymentCommandHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<bool> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        // Publish a notification that the payment has been approved
        await _mediator.Publish(new PaymentApprovedNotification(request.ProjectId), cancellationToken);

        return true;
    }
}