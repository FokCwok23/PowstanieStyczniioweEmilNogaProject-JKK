using UnityEngine;

public class DialogueStart : MonoBehaviour
{
    [SerializeField] string[] lines;
    [SerializeField] bool isPerson;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPerson) {
            if (Input.GetKeyDown(KeyCode.Space){
                DialogueManager.main.StartDialogue(lines);
            }
        } else {
            DialogueManager.main.StartDialogue(lines);
        }
    }
}
