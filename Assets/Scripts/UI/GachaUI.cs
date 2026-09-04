using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GachaUI : MonoBehaviour
{
    [SerializeField] private GachaSystem gachaSystem;

    [SerializeField] private GameObject resultPanel;
    [SerializeField] private Image characterImage;
    [SerializeField] private TMP_Text characterName;
    [SerializeField] private TMP_Text rarityText;

    public class Rarity
    {
        public const string Common = "Common";
        public const string Rare = "Rare";
        public const string Epic = "Epic";
        public const string Legendary = "Legendary";
    }

    public void Roll()
    {
        CharacterData character = gachaSystem.Roll();

        characterImage.sprite = character.portrait;
        characterName.text = character.characterName;
        rarityText.text = character.rarity.Name;
        rarityText.color = character.rarity.Color;

        resultPanel.SetActive(true);
    }

    public void CloseResult()
    {
        resultPanel.SetActive(false);
    }
}