﻿using System;
using Microsoft.AspNetCore.Blazor.Components;

namespace HercPwa2.Client.Components.Iconic
{
  public class IconicBase : BaseComponent
  {
    
    [Parameter] protected string FillColor { get; set; } = "purple";

    [Parameter] protected int Size { get; set; } = 16;
  }
}
