using UnityEngine;

public class HatButton : MonoBehaviour
{
    public int hatId;

    public void OnClick()
    {
        if (LocalPlayerReference.myHatSync != null) 
            LocalPlayerReference.myHatSync.SetHat(hatId);
    }
}
