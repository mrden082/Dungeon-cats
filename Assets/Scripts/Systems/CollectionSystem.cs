using UnityEngine;

public class CollectionSystem : MonoBehaviour
{
    // Создаем синглтон для доступа к системе коллекции из других скриптов
    public static CollectionSystem Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Debug.Log("[CollectionSystem] CollectionSystem создан.");
    }

    // Получает всех персонажей, существующих в игре
    public CharacterData[] GetAllCharacters()
    {
        CharacterData[] characters = GameData.Instance.Characters;

        Debug.Log(
            $"[CollectionSystem] Получено персонажей из GameData: {characters.Length}"
        );

        foreach (CharacterData character in characters)
        {
            Debug.Log(
                $"[CollectionSystem] Персонаж: {character.characterName} ({character.id})"
            );
        }

        return characters;
    }

    // Проверяет, открыт ли конкретный персонаж у игрока
    public bool IsUnlocked(string characterId)
    {
        bool unlocked = GameData.Instance.PlayerData
            .UnlockedCharacters
            .Contains(characterId);

        Debug.Log(
            $"[CollectionSystem] Проверка {characterId}: {unlocked}"
        );

        return unlocked;
    }
}