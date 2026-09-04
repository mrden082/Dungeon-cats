using UnityEngine;

public class QuestTest : MonoBehaviour
{
    [Header("Quests")]
    public QuestData[] testQuests;

    [Header("UI")]
    public QuestCardUI questCardPrefab;
    public Transform questContainer;

    private void Start()
    {
        Debug.Log("Количество квестов: " + testQuests.Length);

        foreach (QuestData quest in testQuests)
        {
            Debug.Log("Создаём квест: " + quest.id);

            QuestCardUI card = Instantiate(questCardPrefab, questContainer);

            card.gameObject.name = "QuestCard_" + quest.id;

            card.SetQuest(quest);

            Debug.Log("Карточка создана: " + card.gameObject.name);
        }
    }
}