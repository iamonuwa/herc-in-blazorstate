﻿namespace Herc.Pwa.Client.Features.Edge.Components.Wallet
{
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using Microsoft.AspNetCore.Blazor.Components;

  public class WalletModel : BaseComponent
  {
    [Parameter]
    protected EdgeCurrencyWallet EdgeCurrencyWallet { get; set; }
  }
} 