using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Dungeons Cats/Character")]
public class CharacterData : ScriptableObject
{
    public string id;
    public string characterName;
    public Sprite icon;
    public Sprite portrait;

    // Редкость персонажа и её характеристики
    public RarityData rarity;
}