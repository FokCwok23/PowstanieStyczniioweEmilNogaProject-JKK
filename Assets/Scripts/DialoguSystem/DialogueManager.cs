using UnityEngine;
using TMPro;
using System.Collections;
using System.Runtime.CompilerServices;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager main;

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private float textSpeed;
    [SerializeField] private GameObject player;
    private PlayerMovement playerMovement;

    public string[] lines;
    private int index;
    
    void Awake()
    {
        main = this;
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { 
            
        }
        if (Input.GetKeyDown(KeyCode.Space) && dialoguePanel.activeInHierarchy)
        {
            if (index < lines.Length)
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
            else
            {
                playerMovement.enabled = true;
                dialoguePanel.SetActive(false);
            }
        }
    }

    public void StartDialogue(string[] dialogueLines)
    {
        playerMovement.enabled = false;
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
        else
            {
            playerMovement.enabled = true;
            dialoguePanel.SetActive(false);
            }
    }
}