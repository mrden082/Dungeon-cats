using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestCardUI : MonoBehaviour
{
    [Header("UI")]
    public Image characterImage;
    public TMP_Text descriptionText;
    public TMP_Text rewardText;

    public void SetQuest(QuestData quest)
    {
        characterImage.sprite = quest.icon;
        descriptionText.text = quest.description;

        rewardText.text =
            "EXP: " + quest.rewardExp +
            " | Coins: " + quest.rewardCoins;
    }
}