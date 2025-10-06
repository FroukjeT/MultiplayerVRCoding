using Normal.Realtime;
using UnityEngine;

public class PlayerHatSync : RealtimeComponent<PlayerAppearanceModel>
{
    public GameObject[] hatObjects;

    protected override void OnRealtimeModelReplaced(PlayerAppearanceModel prev, PlayerAppearanceModel current)
    {
        if (prev != null)
            prev.hatIdDidChange -= OnHatChanged;

        if (current != null)
        {
            ApplayHat(current.hatId);
            current.hatIdDidChange += OnHatChanged;
        }
    }

    public void SetHat(int id)
    {
        if (!realtimeView.isOwnedLocallyInHierarchy)
            realtimeView.RequestOwnership();
        model.hatId = id;
    }

    private void OnHatChanged(PlayerAppearanceModel model, int value)
    {
        ApplayHat(value);
    }

    private void ApplayHat(int id) { 
        for (int i = 0; i< hatObjects.Length; i++)
            hatObjects[i].SetActive(i == id);   
    }
}
