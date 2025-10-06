using UnityEngine;
using UnityEngine.Events;

public class DistanceCheck : MonoBehaviour
{
    [Header("References")]
    public Rigidbody trackedRigidbody;
    public Transform target;

    [Header("Settings")]
    public float openDistance = 0.1f;

    [Header("Events")]
    public UnityEvent onOpen;
    public UnityEvent onUnopen;

    private bool isOpen = false;

    void Update()
    {
        float distance = Vector3.Distance(trackedRigidbody.position, target.position);

        // check if within threshold
        if (!isOpen && distance <= openDistance)
        {
            isOpen = true;
            onOpen.Invoke();
        }
        else if (isOpen && distance > openDistance)
        {
            isOpen = false;
            onUnopen.Invoke();
        }
    }


}
