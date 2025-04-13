using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager main;

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private float textSpeed;

    public string[] lines;
    private int index;
    
    void Awake()
    {
        main = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (textComponent.text == lines[index])
            {
                NextLine();
            } else {
                StopAllCoroutines();
                textComponent.text = lines[index];
                dialoguePanel.SetActive(false);
            }
        }
    }

    public void StartDialogue(string[] dialogueLines)
    {
        dialoguePanel.SetActive(true);
        textComponent.text = string.Empty;
        index = 0;
        lines = dialogueLines;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }

    }
}