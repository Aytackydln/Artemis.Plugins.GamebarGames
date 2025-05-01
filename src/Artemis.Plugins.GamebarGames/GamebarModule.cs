using System;
using System.Collections.Generic;
using System.Linq;
using Artemis.Core.Modules;
using Artemis.Plugins.GamebarGames.DataModels;
using JetBrains.Annotations;

namespace Artemis.Plugins.GamebarGames;

[PublicAPI]
public class GamebarModule : Module<GamebarInfo>
{
    private readonly GamebarGamesList _gamebarGamesList = new();

    public GamebarModule()
    {
        _gamebarGamesList.GameListChanged += GamebarGamesListOnGameListChanged;
    }

    private void GamebarGamesListOnGameListChanged(object? sender, EventArgs e)
    {
        UpdateGameExeList();
    }

    private void UpdateGameExeList()
    {
        DataModel.GameExeList = _gamebarGamesList.GetGameExes()
            .Select(exePath => exePath[..^4])
            .ToArray();
    }

    public override void Enable()
    {
        _gamebarGamesList.StartWatching();
        UpdateGameExeList();
    }

    public override void Disable()
    {
        _gamebarGamesList.StopWatching();
    }

    public override void Update(double deltaTime)
    {
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        
        if (disposing)
        {
            _gamebarGamesList.Dispose();
        }
    }

    public override List<IModuleActivationRequirement>? ActivationRequirements => null;
}