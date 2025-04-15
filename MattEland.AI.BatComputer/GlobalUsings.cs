global using System.Collections.Immutable;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Localization;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using MattEland.AI.BatComputer.Models;
global using MattEland.AI.BatComputer.Presentation;
global using MattEland.AI.BatComputer.DataContracts;
global using MattEland.AI.BatComputer.DataContracts.Serialization;
global using MattEland.AI.BatComputer.Services.Caching;
global using MattEland.AI.BatComputer.Services.Endpoints;
global using ApplicationExecutionState = Windows.ApplicationModel.Activation.ApplicationExecutionState;

[assembly: Uno.Extensions.Reactive.Config.BindableGenerationTool(3)]