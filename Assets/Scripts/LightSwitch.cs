using UnityEngine;

public class LightSwitch : Interactable {

    public Light m_Light; // im using m_Light name since 'light' is already a variable used by unity
    public bool isOn;
    float countDown = 0.01f;

    private void Start() {
        UpdateLight();
    }

    void UpdateLight() {
        m_Light.enabled = isOn;
    }

    public override string GetDescription() {
        if(interactionType == InteractionType.Click)
        {
            if (isOn) return "Press [E] to turn <color=red>off</color> the light.";
            return "Press [E] to turn <color=green>on</color> the light.";
        }
        else
        {
            if (isOn) return "Hold [E] to turn <color=red>off</color> the light."; 
            return "Hold [E] to turn <color=green>on</color> the light.";
        }
    }

    public override void Interact() {
        isOn = !isOn;

        UpdateLight();
    }
}
