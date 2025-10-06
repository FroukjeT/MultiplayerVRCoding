using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    [Header("Settings")]
    public float openLimit = 1f;
    public float speed = 2f;
    bool isOpen = false;

    void Update()
    {

        Vector3 localPos = transform.localPosition;

        if (isOpen)
        {
            if (localPos.z <= openLimit)
            {
                localPos.z += speed * Time.deltaTime;
                localPos.z = Mathf.Clamp(localPos.z, 0f, openLimit);

            }

        }
        else
        {
            if (localPos.z > 0)
            {
                localPos.z -= speed * Time.deltaTime;
                localPos.z = Mathf.Clamp(localPos.z, 0f, openLimit);
            }

        }
        transform.localPosition = localPos;

    }

    public void SetOpen()
    {
        isOpen = true;
    }

    public void SetClosed()
    {
        isOpen = false;
    }

}
