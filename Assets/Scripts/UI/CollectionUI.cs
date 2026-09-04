using UnityEngine;

public class CollectionUI : MonoBehaviour
{
    [SerializeField] private CharacterCardUI characterCardPrefab;
    [SerializeField] private Transform container;

    private void OnEnable()
    {
        Debug.Log(
            "[CollectionUI] Открытие коллекции. " +
            "Получаем свежие данные."
        );

        RefreshCollection();
    }

    public void RefreshCollection()
    {
        Debug.Log("[CollectionUI] Обновление коллекции.");

        ClearCards();

        CharacterData[] characters =
            CollectionSystem.Instance.GetAllCharacters();

        foreach (CharacterData character in characters)
        {
            if (character == null)
                continue;

            bool unlocked =
                CollectionSystem.Instance.IsUnlocked(character.id);

            Debug.Log(
                $"[CollectionUI] {character.characterName} " +
                $"({character.id}) → unlocked: {unlocked}"
            );

            CharacterCardUI card =
    Instantiate(characterCardPrefab, container);

            Debug.Log(
                $"[CollectionUI] Создана карточка: {character.characterName}, " +
                $"позиция: {card.transform.localPosition}, " +
                $"родитель: {card.transform.parent.name}"
            );

            card.Setup(character, unlocked);
        }

        Debug.Log("[CollectionUI] Коллекция обновлена.");
    }

    private void ClearCards()
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }
    }
}