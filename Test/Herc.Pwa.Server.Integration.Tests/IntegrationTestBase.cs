﻿namespace Herc.Pwa.Server.Integration.Tests
{
  using System.Threading.Tasks;

  public class IntegrationTestBase
  {
    public async Task Setup() => await SliceFixture.ResetCheckpoint();
  }
}
