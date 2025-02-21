using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverallWinScript : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public GameObject centerWall;
    public GameObject fireworks; 

    private bool pianoWin = false;
    private bool numbersWin = false;
    private bool overallWin = false; 

    public void PianoWin()
    {
        if (!overallWin)
        {
            print("piano win"); 
            pianoWin = true;
            if (numbersWin)
            {
                overallWin = true;
                MakeFireworks(); 
            }
        }
    }

    public void NumbersWin()
    {
        if (!overallWin)
        {
            print("numbers win");
            numbersWin = true;
            if (pianoWin)
            {
                overallWin = true;
                MakeFireworks();
            }
        }
    }

    public void MakeFireworks()
    {
        print("make fireworks");
        backgroundMusic.enabled = true;
        centerWall.SetActive(false);
        fireworks.SetActive(true);
    }
}
