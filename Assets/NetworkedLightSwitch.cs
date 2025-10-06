using UnityEngine;
using Normal.Realtime; 

//this script is the bridge between unity and Nomcore

public class NetworkedLightSwitch : RealtimeComponent<LightSwitchModel> //networked data object called lightswitchmodel, shared boolean isOn
{
    public Light targetLight; //reference to unity light component in scene

    //run this method when our component is connected to a lightSwitchModel:
    protected override void OnRealtimeModelReplaced(LightSwitchModel previousModel, LightSwitchModel currentModel)
    {
        if (previousModel != null)
        {
            //unregister from events, unsucsvribe from old models change event(cleanup)
            previousModel.isOnDidChange -= OnLightChanged;
        }

        if (currentModel != null) //then: if we have a new model)
        {
            //if this mode is brand new in the rooom (so first client), instantialise the network value from whatever ht elight currently is (so make sure it starts with on)
            if(currentModel.isFreshModel)
                currentModel.isOn = targetLight != null && targetLight.enabled; 

            Apply(currentModel.isOn);
            //register for events so we'll know if the value changes later
            currentModel.isOnDidChange += OnLightChanged;
        }
    }

    public void ToggleLight()
    {
        if(!realtimeView.isOwnedLocallyInHierarchy) //only the person who owns the object can change it
            realtimeView.RequestOwnership(); //request ownership if we don't have it

        model.isOn = !model.isOn; //toggle the boolean value, it flips the boolean from true to false
    }

    //when isOn changes: Normcore will call this method (either you or another user)
    private void OnLightChanged(LightSwitchModel model, bool isOn) //this method is called when the boolean changes
    {
        Apply(isOn); //apply the change to the light
    }

    //this is the only place wehre we touch the unity light in our sene, no tewroking, just set enabled to match the shared boolean
    // every client runs thsi when the value changes, so everyone will see the same result
    private void Apply(bool isOn) //apply the change to the light
    {
        if (targetLight != null) //if we have a reference to a light component
            targetLight.enabled = isOn; //set the light's enabled property to the value of isOn
    }
}
