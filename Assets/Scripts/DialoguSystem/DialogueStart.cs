using UnityEngine;

public class DialogueStart : MonoBehaviour
{
    [SerializeField] string[] lines;
    [SerializeField] bool isPerson;
    [SerializeField] bool dialogueFinished = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!dialogueFinished)
        {
            if (isPerson)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    DialogueManager.main.StartDialogue(lines);
                }
            }
            else
            {
                DialogueManager.main.StartDialogue(lines);
            }
        }
    }
}
