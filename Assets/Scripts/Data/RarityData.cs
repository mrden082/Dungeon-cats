using UnityEngine;

[CreateAssetMenu(fileName = "Rarity", menuName = "Dungeons Cats/Rarity")]
public class RarityData : ScriptableObject
{
    [Range(1, 4)]
    public int rarity;

    public string Name
    {
        get
        {
            return rarity switch
            {
                1 => "Common",
                2 => "Rare",
                3 => "Epic",
                4 => "Legendary",
                _ => "Unknown"
            };
        }
    }

    public float DropRate
    {
        get
        {
            return rarity switch
            {
                1 => 0.7f,
                2 => 0.2f,
                3 => 0.09f,
                4 => 0.01f,
                _ => 0f
            };
        }
    }

    public Color Color
    {
        get
        {
            return rarity switch
            {
                1 => Color.white,
                2 => Color.blue,
                3 => new Color(0.6f, 0.2f, 1f),
                4 => new Color(1f, 0.75f, 0f),
                _ => Color.white
            };
        }
    }
}