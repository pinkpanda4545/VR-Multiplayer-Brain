using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class BinLid : MonoBehaviour
{
    public int binNumber;
    public BinWin binWinScript; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NumberBall")
        {
            if (other.gameObject.name.Split("_")[2] == binNumber.ToString())
            {
                binWinScript.BinCompleted(binNumber);
                other.gameObject.GetComponent<XRGrabInteractable>().enabled = false; 
            }

            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NumberBall" && other.gameObject.name.Split("_")[2] != binNumber.ToString())
        {
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
