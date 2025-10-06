using Normal.Realtime;
using UnityEngine;

public class NetworkedSlidingDoor : RealtimeComponent<DoorModel>
{
    [SerializeField] private SlidingDoor door;

    protected override void OnRealtimeModelReplaced(DoorModel prev, DoorModel current)
    {
        if (prev != null) prev.isOpenDidChange -= OnDoorChanged;

        if (current != null)
        {
            // Initialize local door state from the model (late joiners get correct state)
            Apply(current.isOpen);
            current.isOpenDidChange += OnDoorChanged;
        }
    }

    public void OpenDoor()
    {
        if (!realtimeView.isOwnedLocallyInHierarchy)
            realtimeView.RequestOwnership();
        model.isOpen = true;
    }

    public void CloseDoor()
    {
        if (!realtimeView.isOwnedLocallyInHierarchy)
            realtimeView.RequestOwnership();
        model.isOpen = false;
    }

    private void OnDoorChanged(DoorModel model, bool value) => Apply(value);

    private void Apply(bool value)
    {
        if (door != null) door.isOpen = value;
    }
}
