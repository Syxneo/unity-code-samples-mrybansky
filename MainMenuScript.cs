using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject avatarButton;
    [SerializeField] GameObject avatarArrows;
    [SerializeField] GameObject leaderboardButton;
    [SerializeField] GameObject leaderboardArrows;
    [SerializeField] GameObject placeholderAvatarLeaderboard;
    [SerializeField] GameObject advertButton;
    [SerializeField] RectTransform placeholderAdvert;
    [SerializeField] GameObject questButton;
    [SerializeField] RectTransform placeholderQuestButton;
    [SerializeField] GameObject inventoryButton;
    [SerializeField] RectTransform placeholderInventoryButton;

    [SerializeField] GameObject hitboxCharacterSelection;
    [SerializeField] GameObject hitboxPlanetSelection;

    Vector2 startingPositionAvatarLeaderboard;
    Vector2 startingPositionAdvert;
    Vector2 startingPositionQuest;
    Vector2 startingPositionInventory;

    private void Start()
    {
        startingPositionAvatarLeaderboard = leaderboardButton.GetComponent<RectTransform>().anchoredPosition;
        startingPositionAdvert = advertButton.GetComponent<RectTransform>().anchoredPosition;
        startingPositionQuest = questButton.GetComponent<RectTransform>().anchoredPosition;
        startingPositionInventory = inventoryButton.GetComponent<RectTransform>().anchoredPosition;
    }

    float time = 0.6f;

    public void CloseEverythingInMainMenu()
    {
        CloseAvatarButton();
        CloseLeaderboardButton();
        CloseAdvertButton();
        CloseQuestButton();
    }

    public void OpenAvatarButton()
    {
        CloseHitbox();
        CloseLeaderboardButton();
        OpenInventoryButton();
        avatarButton.transform.DOMoveX(placeholderAvatarLeaderboard.transform.position.x, time);
        avatarButton.SetActive(true);
        avatarButton.GetComponent<CanvasGroup>().DOFade(1, time);
        avatarArrows.SetActive(true);
        avatarArrows.GetComponent<CanvasGroup>().DOFade(1, time);
    }
    public void CloseAvatarButton()
    {
        CloseInventoryButton();
        avatarButton.GetComponent<RectTransform>().DOAnchorPosX(startingPositionAvatarLeaderboard.x, time);
        avatarButton.GetComponent<CanvasGroup>().DOFade(0, time).OnComplete(() => avatarButton.SetActive(false)).OnComplete(() => OpenHitbox());
        avatarArrows.GetComponent<CanvasGroup>().DOFade(0, time).OnComplete(() => avatarArrows.SetActive(false));
    }
    public void OpenLeaderboardButton()
    {
        CloseHitbox();
        CloseAvatarButton();
        leaderboardButton.transform.DOMoveX(placeholderAvatarLeaderboard.transform.position.x, time);
        leaderboardButton.SetActive(true);
        leaderboardButton.GetComponent<CanvasGroup>().DOFade(1, time);
        leaderboardArrows.SetActive(true);
        leaderboardArrows.GetComponent<CanvasGroup>().DOFade(1, time);
    }
    public void CloseLeaderboardButton()
    {
        leaderboardButton.GetComponent<RectTransform>().DOAnchorPosX(startingPositionAvatarLeaderboard.x, time);
        leaderboardButton.GetComponent<CanvasGroup>().DOFade(0, time).OnComplete(() => leaderboardButton.SetActive(false)).OnComplete(() => OpenHitbox());
        leaderboardArrows.GetComponent<CanvasGroup>().DOFade(0, time).OnComplete(() => leaderboardArrows.SetActive(false));
    }

    private void CloseHitbox()
    {
        hitboxCharacterSelection.SetActive(false);
        hitboxPlanetSelection.SetActive(false);
    }

    private void OpenHitbox()
    {
        hitboxCharacterSelection.SetActive(true);
        hitboxPlanetSelection.SetActive(true);
    }

    public void OpenAdvertButton()
    {
        advertButton.SetActive(true);
        advertButton.GetComponent<CanvasGroup>().DOFade(1, time);
        advertButton.GetComponent<RectTransform>().DOAnchorPosX(placeholderAdvert.transform.position.x, time);
    }

    public void CloseAdvertButton()
    {
        advertButton.GetComponent<RectTransform>().DOAnchorPosX(startingPositionAdvert.x, time);
        advertButton.GetComponent<CanvasGroup>().DOFade(0, 0.1f).OnComplete(()=>advertButton.SetActive(false));
    }

    public void OpenQuestButton()
    {
        questButton.SetActive(true);
        questButton.GetComponent<CanvasGroup>().DOFade(1, time);
        questButton.GetComponent<RectTransform>().DOAnchorPosX(placeholderQuestButton.transform.position.x, time);
    }

    public void CloseQuestButton()
    {
        questButton.GetComponent<RectTransform>().DOAnchorPosX(startingPositionQuest.x, time);
        questButton.GetComponent<CanvasGroup>().DOFade(0, 0.1f).OnComplete(() => questButton.SetActive(false));
    }

    public void OpenInventoryButton()
    {
        inventoryButton.SetActive(true);
        inventoryButton.GetComponent<CanvasGroup>().DOFade(1, time);
        inventoryButton.GetComponent<RectTransform>().DOAnchorPosX(placeholderInventoryButton.anchoredPosition.x, time);
    }

    public void CloseInventoryButton()
    {
        inventoryButton.GetComponent<RectTransform>().DOAnchorPosX(startingPositionInventory.x, time);
        inventoryButton.GetComponent<CanvasGroup>().DOFade(0, 0.1f).OnComplete(() => inventoryButton.SetActive(false));
    }
}
