using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    float speed = 2f;
    float sprintModifier = 2f;
    private SpriteRenderer spriteRenderer;
    private Color itemColor;

    void Start()
    {
        spriteRenderer = GetComponent <SpriteRenderer>();
        itemColor = Color.white;
    }

    void Update()
    {
        HandleMovement();
        HandleColor();
    }

    private void HandleMovement()
    {
        float step = Input.GetKey(KeyCode.LeftShift) ? speed * Time.deltaTime * sprintModifier : speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.up * step);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * step);
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.down * step);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * step);

        if (Input.GetKeyDown(KeyCode.Q))
            transform.Rotate(new Vector3(0, 0, 10));
        if (Input.GetKeyDown(KeyCode.E))
            transform.Rotate(new Vector3(0, 0, -10));
    }

    private void HandleColor()
    {
        if (Input.GetKeyDown(KeyCode.O)) // Hides when O is pressed.
            spriteRenderer.color = Color.clear;
        if (Input.GetKeyUp(KeyCode.O)) // Stops hidding when key is up.
            spriteRenderer.color = itemColor;
        if (Input.GetKeyUp(KeyCode.R)) // Assigns a random color.
        {
            itemColor = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
            spriteRenderer.color = itemColor;
        }
    }
}
