using Artemis.Core.Modules;
using JetBrains.Annotations;

namespace Artemis.Plugins.GamebarGames.DataModels;

[PublicAPI]
public class GamebarInfo : DataModel
{
    [DataModelProperty(Name = "Game .exe list")]
    public string[] GameExeList { get; set; } = [];
}