using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterText : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI textUI;

    [Header("Typing Settings")]
    public float typingSpeed = 0.05f;      // 每个字间隔
    public float paragraphDelay = 1.0f;    // 每段之间的停顿

    [TextArea(3, 5)]
    public string[] paragraphs;

    void Start()
    {
        textUI.text = "";
        StartCoroutine(TypeParagraphs());
        
    }

    IEnumerator TypeParagraphs()
    {
        for (int i = 0; i < paragraphs.Length; i++)
        {
            yield return StartCoroutine(TypeSingleParagraph(paragraphs[i]));

            if (i < paragraphs.Length - 1)
                yield return new WaitForSeconds(paragraphDelay);

            textUI.text += "\n\n"; // 段落间空行
        }
        yield return new WaitForSeconds(2f);

        timer.instance.ChangeEvent();
    }

    IEnumerator TypeSingleParagraph(string paragraph)
    {
        foreach (char c in paragraph)
        {
            textUI.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
