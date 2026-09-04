using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCardUI : MonoBehaviour
{
    [SerializeField] private Image characterImage;
    [SerializeField] private TMP_Text characterName;
    [SerializeField] private GameObject lockedOverlay;

    public void Setup(CharacterData character, bool unlocked)
    {
        characterImage.sprite = character.icon;

        if (unlocked)
        {
            characterName.text = character.characterName;
            lockedOverlay.SetActive(false);
        }
        else
        {
            characterName.text = "???";
            lockedOverlay.SetActive(true);
        }
    }
}