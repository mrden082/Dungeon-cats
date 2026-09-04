using System.Collections.Generic;

public class PlayerData
{
    // Валюта игрока
    public int Coins;
    public int Diamonds;

    // Персонажи, которых игрок уже получил
    public HashSet<string> UnlockedCharacters { get; } = new HashSet<string>();

    // Квесты, которые игрок уже выполнил
    public HashSet<string> CompletedQuests { get; } = new HashSet<string>();

    // Предметы которые игрок уже получил
    public HashSet<string> UnlockedItems { get; } = new HashSet<string>();
}