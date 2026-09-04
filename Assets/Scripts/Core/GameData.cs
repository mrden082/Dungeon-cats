using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }

    // Игровые данные, которые сохраняются между сессиями

    [Header("Characters")]
    [SerializeField] private CharacterData[] characters;

    public CharacterData[] Characters => characters;

    [Header("Quests")]
    [SerializeField] private QuestData[] quests;

    public QuestData[] Quests => quests;

    // Игровые данные, которые относятся к конкретному игроку

    public PlayerData PlayerData { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        PlayerData = new PlayerData();

        Debug.Log("[GameData] GameData создан.");
        Debug.Log("[GameData] PlayerData создан.");
    }
}