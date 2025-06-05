using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class AnimateTxt : MonoBehaviour
{
    [SerializeField]private TMP_Text thisObjectText;
    string text;

    // Start is called before the first frame update
    void Start()
    {
        this.thisObjectText = GetComponent<TMP_Text>();
        text = thisObjectText.text;
        WriteDeathText();
    }

    void WriteDeathText()
    {
        thisObjectText.text = "";
        DOTween.To(() => thisObjectText.text.Length, x => thisObjectText.text = text.Substring(0, x), text.Length, text.Length / 12.5f)
            .SetEase(Ease.Linear);
    }
}
