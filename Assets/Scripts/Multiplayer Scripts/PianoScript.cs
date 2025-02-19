using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables; 
using System.Collections.Generic;

public class PianoScript : MonoBehaviour
{
    public XRBaseInteractable keyLow;
    public XRBaseInteractable keyMid;
    public XRBaseInteractable keyHigh;

    private List<int> orderClicked = new List<int>();

    void Start()
    {
        // Add event listeners to handle clicks
        keyLow.selectEntered.AddListener((args) => CustomPointClick(0));
        keyMid.selectEntered.AddListener((args) => CustomPointClick(1));
        keyHigh.selectEntered.AddListener((args) => CustomPointClick(2));
    }

    public void CustomPointClick(int index)
    {
        print("clicked"); 
        orderClicked.Add(index);
        print("Clicked Order: " + string.Join(", ", orderClicked));
        // Check order for code logic
    }
}
