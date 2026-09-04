using UnityEngine;

public class QuestsUI : MonoBehaviour
{
    [SerializeField] private QuestCardUI questCardPrefab;
    [SerializeField] private Transform container;

    private void OnEnable()
    {
        Debug.Log(
            "[QuestsUI] Открытие квестов. " +
            "Получаем свежие данные."
        );

        RefreshQuests();
    }

    public void RefreshQuests()
    {
        Debug.Log("[QuestsUI] Обновление квестов.");

        ClearQuests();

        QuestData[] quests =
            QuestSystem.Instance.GetAllQuests();

        foreach (QuestData quest in quests)
        {
            if (quest == null)
                continue;

            bool completed =
                QuestSystem.Instance.IsQuestCompleted(quest.id);

            Debug.Log(
                $"[QuestsUI] {quest.description} " +
                $"({quest.id}) → completed: {completed}"
            );

            QuestCardUI card =
    Instantiate(questCardPrefab, container);

            Debug.Log(
                $"[QuestsUI] Создан квест: {quest.description}, " +
                $"позиция: {card.transform.localPosition}, " +
                $"родитель: {card.transform.parent.name}"
            );

            card.SetQuest(quest);
        }

        Debug.Log("[QuestsUI] Квесты обновлены.");
    }

    private void ClearQuests()
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }
    }
}