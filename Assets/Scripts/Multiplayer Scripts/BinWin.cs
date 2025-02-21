using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinWin : MonoBehaviour
{
    public AudioSource winSound;
    public Material BlackMaterial;
    private int winCount = 0;
    public OverallWinScript overallWin; 

    public void BinCompleted(int binNum)
    {
        winCount++;

        if (winCount == 6)
        {
            //you win puzzle 1!
            print("you win the numbers puzzle");
            winSound.Play();
            for (int i = 0; i < 6; i++)
            {
                this.gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().material = BlackMaterial;
            }
            overallWin.NumbersWin();
        }
    }
}
