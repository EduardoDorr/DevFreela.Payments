using MediatR;

namespace DevFreela.Payments.Application.Notifications;

public sealed record PaymentApprovedNotification(int ProjectId) : INotification;