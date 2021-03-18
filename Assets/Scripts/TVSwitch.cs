using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVSwitch : Interactable
{
    public UnityEngine.Video.VideoPlayer videoPlayer;
    public bool isOn;

    private void Start() {
        UpdateLight();
    }

    void UpdateLight() {
        if(isOn)    videoPlayer.Play();
        else videoPlayer.Stop();
    }

    public override string GetDescription() {
        if(interactionType == InteractionType.Click)
        {
            if (isOn) return "Press [E] to turn <color=red>off</color> the tv.";
            return "Press [E] to turn <color=green>on</color> the tv.";
        }
        else
        {
            if (isOn) return "Hold [E] to turn <color=red>off</color> the tv."; 
            return "Hold [E] to turn <color=green>on</color> the tv.";
        }
    }

    public override void Interact() {
        isOn = !isOn;

        UpdateLight();
    }
}
