using System.Linq;
using UnityEngine;

public class GachaSystem : MonoBehaviour
{
    public CharacterData Roll()
    {
        CharacterData[] characters = GameData.Instance.Characters;

        Debug.Log($"[GachaSystem] Получено персонажей из GameData: {characters.Length}");

        

        if (characters == null || characters.Length == 0)
        {
            Debug.LogError("[GachaSystem] В GameData нет персонажей.");
            return null;
        }

        // Получаем все существующие редкости
        // непосредственно из CharacterData
        RarityData[] rarities = characters
            .Where(character => character != null && character.rarity != null)
            .Select(character => character.rarity)
            .Distinct()
            .OrderBy(rarity => rarity.rarity)
            .ToArray();

        if (rarities.Length == 0)
        {
            Debug.LogError("[GachaSystem] У персонажей не указана редкость.");
            return null;
        }

        // Определяем редкость
        float randomValue = Random.value;
        float cumulativeRate = 0f;

        RarityData selectedRarity = null;

        foreach (RarityData rarity in rarities)
        {
            cumulativeRate += rarity.DropRate;

            if (randomValue < cumulativeRate)
            {
                selectedRarity = rarity;
                break;
            }
        }

        if (selectedRarity == null)
        {
            Debug.LogError(
                "[GachaSystem] Не удалось определить редкость."
            );

            return null;
        }

        // Получаем персонажей выбранной редкости
        CharacterData[] availableCharacters = characters
            .Where(character =>
                character != null &&
                character.rarity == selectedRarity)
            .ToArray();

        if (availableCharacters.Length == 0)
        {
            Debug.LogError(
                $"[GachaSystem] Нет персонажей редкости " +
                $"{selectedRarity.Name}."
            );

            return null;
        }

        // Выбираем случайного персонажа
        CharacterData character =
            availableCharacters[
                Random.Range(0, availableCharacters.Length)
            ];

        Debug.Log(
            $"[GachaSystem] Выпал персонаж: {character.id} " +
            $"({selectedRarity.Name})"
        );

        // Записываем полученного персонажа игроку
        GameData.Instance.PlayerData.UnlockedCharacters.Add(character.id);

        Debug.Log(
    $"[GachaSystem] Добавлен в коллекцию: {character.id}. " +
    $"Всего открыто: {GameData.Instance.PlayerData.UnlockedCharacters.Count}"
        );

        return character;
    }
}