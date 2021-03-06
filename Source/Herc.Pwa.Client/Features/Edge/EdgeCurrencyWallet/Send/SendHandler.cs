﻿namespace Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Herc.Pwa.Client.Features.Base;
  using Herc.Pwa.Client.Features.Edge.Dtos;
  using MediatR;
  using Microsoft.JSInterop;

  public class SendHandler : BaseHandler<SendAction, EdgeCurrencyWalletsState>
  {
    public SendHandler(IStore aStore, IMediator aMediator) : base(aStore)
    {
      Mediator = aMediator;
    }

    private IMediator Mediator { get; }

    public override async Task<EdgeCurrencyWalletsState> Handle(SendAction aSendAction, CancellationToken aCancellationToken)
    {
      SendDto sendDto = MapSendActionToSendDto(aSendAction);

      Console.WriteLine("Call the jsinterop to send via Edge");
      string transactionId = await JSRuntime.Current.InvokeAsync<string>(EdgeInteropMethodNames.EdgeCurrencyWalletInterop_Send, sendDto);
      Console.WriteLine($"SendTransactionId:{transactionId}");

      return await Task.FromResult(EdgeCurrencyWalletsState);
    }

    private SendDto MapSendActionToSendDto(SendAction aSendAction)
    {
      return new SendDto
      {
        NativeAmount = aSendAction.NativeAmount,
        CurrencyCode = aSendAction.CurrencyCode,
        DestinationAddress = aSendAction.DestinationAddress,
        EdgeCurrencyWalletId = aSendAction.EdgeCurrencyWalletId,
        Fee = aSendAction.Fee.ToString()
      };
    }
  }
}
