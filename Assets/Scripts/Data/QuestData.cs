using UnityEngine;

[CreateAssetMenu(fileName = "QuestData", menuName = "Game/Quest")]
public class QuestData : ScriptableObject
{
    public string id;
    public string description;
    public Sprite icon;

    public int rewardExp;
    public int rewardCoins;
}