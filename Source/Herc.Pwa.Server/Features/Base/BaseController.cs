﻿namespace Herc.Pwa.Server.Features.Base
{
  using Herc.Pwa.Shared.Features.Base;
  using MediatR;
  using Microsoft.AspNetCore.Mvc;
  using System.Threading.Tasks;

  public class BaseController<TRequest, TResponse> : Controller
    where TRequest : IRequest<TResponse>
    where TResponse : BaseResponse
  {
    public BaseController(IMediator aMediator)
    {
      Mediator = aMediator;
    }

    protected IMediator Mediator { get; }

    protected virtual async Task<IActionResult> Send(TRequest aRequest)
    {
      TResponse response = await Mediator.Send(aRequest);

      return Ok(response);
    }
  }
}
