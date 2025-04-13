using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Prallax : MonoBehaviour
{
    private float startPos, length;
    [SerializeField] GameObject cam;
    [SerializeField] float parallaxEffect;

    private void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        float movement = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
        if (movement > startPos + length) {
            startPos += length;
        } else if (movement < startPos - length) {
            startPos -= length;
        }
    }
}
