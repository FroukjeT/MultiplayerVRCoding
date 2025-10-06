using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class PlayerAppearanceModel
{
    [RealtimeProperty(1, true, true)] private int _hatId;
}
