using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
using static MovementPlayer;

public class HealthSystem : MonoBehaviour
{
    //public Text timeText;

    [SerializeField] AudioSource audioSourceDeath;
    [SerializeField] AudioSource audioSourceEat;
    [SerializeField] AudioSource audioSourceScream;
    public float maxHealth = 30f;
    [SerializeField] GameObject healthGO;
    private Slider healthUI;

    [SerializeField] private CanvasGroup deathScreen;
    [SerializeField] private CanvasGroup buttonDeath;
    [SerializeField] private CanvasGroup humanScream;

    public TMP_Text deathText;
    public string textToDeathAnimate;

    private Vector3 startPos;

    MovementPlayer player;
    Animator animator;
    [SerializeField] Animator animatorHuman;
    [SerializeField] Animator animatorHuman1;
    bool isDead = false;
    // Use this for initialization
    void Start()
    {
        healthUI = healthGO.GetComponent<Slider>();
        player = GetComponent<MovementPlayer>();
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
        maxHealth -= Time.deltaTime;
        healthUI.value = maxHealth;
        }

        if (maxHealth <= 0)
        {
            OnPlayerDeath();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
           
            OnPlayerDeath();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Food")
        {
            audioSourceEat.Play();
            maxHealth = 30;
            Destroy(collision.gameObject);         
        }
        if (collision.gameObject.tag == "NextLevel")
        {
            SceneLoader.LoadScene();
        }
        if (collision.gameObject.tag == "Damage")
        {
            OnPlayerDeath();
        }
        if (collision.gameObject.tag == "Human")
        {
            animatorHuman.Play("Bited");
            animatorHuman1.Play("Bited");
            humanScream.DOFade(1, 0.5f);
            audioSourceScream.Play();
            humanScream.DOFade(0, 0.5f).SetDelay(1);

        }

    }
    void OnPlayerDeath()
    {
        isDead = true;
        DOTween.Sequence()
            .AppendCallback(() => player.PlayDead())
            .AppendInterval(1.3f)
            .Append(deathScreen.DOFade(1, 1))
            .OnComplete(() => WriteDeathText());
        audioSourceDeath.Play();

            
    }

    void WriteDeathText()
    {
        deathText.text = "";
        DOTween.To(() => deathText.text.Length, x => deathText.text = textToDeathAnimate.Substring(0, x), textToDeathAnimate.Length, 1.5f)
            .SetEase(Ease.Linear)
            .OnComplete(() => ButtonFade());
    }

    void ButtonFade()
    {
        buttonDeath.DOFade(1, 1);
    }

    public void ResetScreen()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
