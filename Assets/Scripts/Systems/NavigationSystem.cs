using UnityEngine;

public class NavigationSystem : MonoBehaviour
{
    public enum NavigationState
    {
        Store,
        Heroes,
        Team,
        Dungeons,
        Quests
    }

    [Header("Content")]
    [SerializeField] private GameObject storeContent;
    [SerializeField] private GameObject heroesContent;
    [SerializeField] private GameObject teamContent;
    [SerializeField] private GameObject dungeonsContent;
    [SerializeField] private GameObject questsContent;

    [Header("Default Content")]
    [SerializeField] private NavigationState defaultState = NavigationState.Team;

    private NavigationState currentState;

    private void Start()
    {
        NavigateTo(defaultState);
    }

    public void NavigateTo(NavigationState state)
    {
        DisableAllContent();

        switch (state)
        {
            case NavigationState.Store:
                storeContent.SetActive(true);
                break;

            case NavigationState.Heroes:
                heroesContent.SetActive(true);
                break;

            case NavigationState.Team:
                teamContent.SetActive(true);
                break;

            case NavigationState.Dungeons:
                dungeonsContent.SetActive(true);
                break;

            case NavigationState.Quests:
                questsContent.SetActive(true);
                break;
        }

        currentState = state;

        Debug.Log($"[NavigationSystem] Открыт раздел: {state}");
    }

    private void DisableAllContent()
    {
        storeContent.SetActive(false);
        heroesContent.SetActive(false);
        teamContent.SetActive(false);
        dungeonsContent.SetActive(false);
        questsContent.SetActive(false);
    }

    // Методы для Button -> On Click()

    public void OpenStore()
    {
        NavigateTo(NavigationState.Store);
    }

    public void OpenHeroes()
    {
        NavigateTo(NavigationState.Heroes);
    }

    public void OpenTeam()
    {
        NavigateTo(NavigationState.Team);
    }

    public void OpenDungeons()
    {
        NavigateTo(NavigationState.Dungeons);
    }

    public void OpenQuests()
    {
        NavigateTo(NavigationState.Quests);
    }
}