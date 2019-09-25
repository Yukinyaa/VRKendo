using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class SaberScript : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean action;
    public Transform saberBlade;


    Vector3 originalScale;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = saberBlade.localScale;
    }

    float scale = 0;
    float desiredScale;
    // Update is called once per frame
    void Update()
    {
        //if (action.GetState(handType))
            desiredScale = 1;
        //else desiredScale = 0;
        scale = scale * 0.8f + desiredScale * 0.2f;
        saberBlade.localScale = originalScale * scale;
    }
    
}
