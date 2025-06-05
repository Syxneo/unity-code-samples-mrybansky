using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LeaderboardAnim : MonoBehaviour
{
    [SerializeField] List<CanvasGroup> secondPlace = new List<CanvasGroup>();
    [SerializeField] List<CanvasGroup> firstPlace = new List<CanvasGroup>();
    [SerializeField] List<CanvasGroup> thirdPlace = new List<CanvasGroup>();

    [SerializeField] CanvasGroup title;

    [SerializeField] GameObject contentCells;

    float time = 0.35f;
    float cooldown = 0.125f;


    public void ClickArrow()
    {
        HideLeaderboardPlaces();
        FadeWeeklyPlanetSequentiallyDeactivate();
        Invoke("OpenLeaderboardScreen", time);
    }
    
    public void OpenLeaderboardScreen()
    {
        ShowLeaderboardPlaces();
        StartCoroutine(FadeWeeklyPlanetSequentiallyActivate());
    }

    private IEnumerator FadeWeeklyPlanetSequentiallyActivate()
    {
        CanvasGroup[] canvasGroups = contentCells.GetComponentsInChildren<CanvasGroup>();
        foreach (CanvasGroup canvasGroup in canvasGroups)
        {
            canvasGroup.DOFade(1f, time);
            yield return new WaitForSeconds(cooldown);
        }
    }

    void FadeWeeklyPlanetSequentiallyDeactivate()
    {
        CanvasGroup[] canvasGroups = contentCells.GetComponentsInChildren<CanvasGroup>();
        foreach (CanvasGroup canvasGroup in canvasGroups)
        {
            canvasGroup.DOFade(0, time);
        }
    }

    void ShowLeaderboardPlaces()
    {
        title.DOFade(1, time);
        foreach (CanvasGroup canvasGroup in secondPlace)
        {
            canvasGroup.DOFade(1f, time);
        }
        foreach (CanvasGroup canvasGroup in firstPlace)
        {
            canvasGroup.DOFade(1f, time);
        }
        foreach (CanvasGroup canvasGroup in thirdPlace)
        {
            canvasGroup.DOFade(1f, time);
        }
    }
    void HideLeaderboardPlaces()
    {
        title.DOFade(0, time);
        foreach (CanvasGroup canvasGroup in secondPlace)
        {
            canvasGroup.DOFade(0, time);
        }
        foreach (CanvasGroup canvasGroup in firstPlace)
        {
            canvasGroup.DOFade(0, time);
        }
        foreach (CanvasGroup canvasGroup in thirdPlace)
        {
            canvasGroup.DOFade(0, time);
        }
    }
