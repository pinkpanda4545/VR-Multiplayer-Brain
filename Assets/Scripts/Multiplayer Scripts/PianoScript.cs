using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables; 
using System.Collections;
using System.Collections.Generic;

public class PianoScript : MonoBehaviour
{
    public XRBaseInteractable keyLow;
    public XRBaseInteractable keyMid;
    public XRBaseInteractable keyHigh;
    public AudioSource winSound; 
    public AudioSource backgroundMusic; 
    public OverallWinScript overallWin; 

    private List<int> orderClicked = new List<int>();
    private bool hasWon = false;
    private float sinkHeight = 0.525f;
    private int granularity = 100; 

    public void CustomPointClick(int index)
    { 
        if (!hasWon)
        {
            orderClicked.Add(index);
            this.gameObject.transform.GetChild(index).GetComponent<AudioSource>().Play();

            int len = orderClicked.Count;
            if (len >= 6)
            {
                if (orderClicked[len-6] == 1 && orderClicked[len-5] == 2 
                    && orderClicked[len-4] == 0 && orderClicked[len-3] == 1
                    && orderClicked[len-2] == 0  && orderClicked[len-1] == 2)
                {
                    hasWon = true;
                    StartCoroutine(YouWin());
                    StartCoroutine(Glizzy()); 
                }
            }
        }
    }

    IEnumerator YouWin()
    {
        print("you win the piano puzzle");
        var x = this.gameObject.transform.position.x;
        var y = this.gameObject.transform.position.y;
        var z = this.gameObject.transform.position.z;
        var change = sinkHeight / granularity;

        for (int i = 0; i < granularity; i++)
        {
            this.gameObject.transform.position = new Vector3(x, y - (i * change), z);
            yield return new WaitForSeconds(0.01f);
        }

        backgroundMusic.Stop();
        overallWin.PianoWin(); 
    }

    IEnumerator Glizzy()
    {
        yield return new WaitForSeconds(0.2f);

        winSound.Play();
    }
}
