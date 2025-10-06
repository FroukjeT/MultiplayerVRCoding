using System.Security.Cryptography;
using UnityEngine;

public class RigController : MonoBehaviour
{
    //head and target
    public Transform headIKTarget;
    public Transform kyleRig;
    public Transform headBone;

    //vr camera
    public Transform vrCamera;

    //left controller and target
    public Transform leftIKTarget;
    public Transform leftController;

    //right controller and target
    public Transform rightIKTarget;
    public Transform rightController;

    //basically you just make publics, asign things to it later, make sure they follow each other
    void LateUpdate()
    {
        // rotate body to match camera yaw only
        // //so you create reference for the Vr headset, then adjust roation of kylerig to match rotation of VR headset
        // by using quaternion.euler, you convert values in xyz values fimilar to inspector
        // then finally you set rotation to (0, headset, 0) so it only rotates on y axis
        kyleRig.rotation = Quaternion.Euler(0f, vrCamera.eulerAngles.y, 0f);

        // head follows camera - move the whole kylerig to align the head with the Vr players head
        kyleRig.position += (headIKTarget.position - headBone.position);

        //arms folow controllers
        leftIKTarget.SetPositionAndRotation(leftController.position, leftController.rotation);
        rightIKTarget.SetPositionAndRotation(rightController.position, rightController.rotation);   
    }
}
