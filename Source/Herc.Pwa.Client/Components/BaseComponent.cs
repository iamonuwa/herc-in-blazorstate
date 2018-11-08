﻿namespace Herc.Pwa.Client.Components
{
  using System;
  using System.Collections.Concurrent;
  using BlazorState.Behaviors.ReduxDevTools;
  using Herc.Pwa.Client.Features.Application;
  using Herc.Pwa.Client.Features.Counter;
  using Herc.Pwa.Client.Features.Edge;
  using Herc.Pwa.Client.Features.Edge.EdgeAccount;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using Herc.Pwa.Client.Features.Idology;
  using Herc.Pwa.Client.Features.WeatherForecast;
  using Herc.Pwa.Client.Shared;
  using Microsoft.AspNetCore.Blazor.Components;

  /// <summary>
  /// Makes access to the State a little easier and by inheriting from
  /// BlazorStateDevToolsComponent it allows for ReduxDevTools operation.
  /// </summary>
  /// <remarks>
  /// In production one would NOT be required to use these base components
  /// But would be required to properly implement the required interfaces.
  /// one could conditionally inherit from BlazorComponent for production build.
  /// </remarks>
  public class BaseComponent : BlazorStateDevToolsComponent
  {
    static ConcurrentDictionary<string, int> s_InstanceCounts = new ConcurrentDictionary<string, int>();
    public BaseComponent()
    {
      string name = GetType().Name;
      int count = s_InstanceCounts.AddOrUpdate(name, 1, (aKey, aValue) => aValue + 1);

      Id = $"{name}-{count}";
    }


    ~BaseComponent()
    {
      string name = GetType().Name;
      Console.WriteLine($"Destroying a {name}");
      s_InstanceCounts[name]--;
    }

    public string Id { get; }

    public string TestId { get; set; }

    [Inject]
    public ColorPalette ColorPalette { get; set; }

    public Guid Guid { get; } = Guid.NewGuid();
    public ApplicationState ApplicationState => Store.GetState<ApplicationState>();
    public CounterState CounterState => Store.GetState<CounterState>();
    public WeatherForecastsState WeatherForecastsState => Store.GetState<WeatherForecastsState>();
    public EdgeState EdgeState => Store.GetState<EdgeState>();
    public EdgeAccountState EdgeAccountState => Store.GetState<EdgeAccountState>();
    public EdgeCurrencyWalletsState EdgeCurrencyWalletsState => Store.GetState<EdgeCurrencyWalletsState>();
    public IdologyState IdologyState => Store.GetState<IdologyState>();

  }
}