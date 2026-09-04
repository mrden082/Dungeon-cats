using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheatingGold : MonoBehaviour
{
    public int gold = 0;
    public TMP_Text goldScore;


    public void AddGold()
    {
        gold += 100000000; 

        goldScore.text = gold.ToString();
    }
}
