using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DynamicFOV : MonoBehaviour
{
    Ray raycast;
    RaycastHit hit;
    public bool isHit;
    public float hitDistance;
    [Range(0,10)]
    public float focusSpeed;

    public PostProcessVolume volume;
    DepthOfField depthOfField;

    public float maxFocusDistance;

    private void Start() 
    {
        volume.profile.TryGetSettings(out depthOfField); 
    }
    // Update is called once per frame
    void Update()
    {
        raycast = new Ray(transform.position, transform.forward * maxFocusDistance);

        isHit = false;

        if (Physics.Raycast(raycast, out hit, maxFocusDistance))
        {
            isHit = true;
            hitDistance = Vector3.Distance(transform.position, hit.point);
        }
        else
        {
            if(hitDistance < maxFocusDistance)
            {
                hitDistance++;
            }
        }

        SetFocus();
    }

    void SetFocus()
    {
        depthOfField.focusDistance.value = Mathf.Lerp(depthOfField.focusDistance.value, hitDistance, Time.deltaTime * focusSpeed);
    }

    private void OnDrawGizmos() 
    {
        if (isHit)
        {
            Gizmos.DrawWireSphere(hit.point, 0.1f);

            Debug.DrawRay(transform.position, transform.forward * Vector3.Distance(transform.position, hit.point));
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * maxFocusDistance);
        }
    }
}
