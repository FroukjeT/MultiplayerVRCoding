using UnityEngine;
using Normal.Realtime;

public class LocalPlayerReference : MonoBehaviour
{
    public static PlayerHatSync myHatSync;
    void Start()
    {
        var view = GetComponent<RealtimeView>();
        if (view.isOwnedLocallyInHierarchy)
        {
            myHatSync = GetComponent<PlayerHatSync>();
        }
    }
}
