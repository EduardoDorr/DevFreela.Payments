using Microsoft.AspNetCore.Mvc;

using MediatR;

using DevFreela.Payments.Application.Commands;

namespace DevFreela.Payments.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePaymentCommand paymentInfo)
    {
        var result = await _mediator.Send(paymentInfo);

        if (!result)
            return BadRequest();

        return NoContent();
    }
}