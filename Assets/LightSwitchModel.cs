using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class LightSwitchModel
{
    [RealtimeProperty(1, true, true)] private bool _isOn; // this boolean will be kept the same for everyone ni the room
        //means property id, then reliabye (way of sending data), then interpolate (transitions)
}
