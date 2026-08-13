using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    float speed = 2f;
    float sprintModifier = 2f;

    private SpriteRenderer spriteRenderer;
    private Color itemColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent <SpriteRenderer>();
        itemColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement handle.
        float step = Input.GetKey(KeyCode.LeftShift) ? speed * Time.deltaTime * sprintModifier : speed * Time.deltaTime; // Runs with Shift pressed.

        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.up * step);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * step);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.down * step);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * step);
        if (Input.GetKeyDown(KeyCode.Q))
            transform.Rotate(new Vector3(0, 0, 10));
        if (Input.GetKeyDown(KeyCode.E))
            transform.Rotate(new Vector3(0, 0, -10));

        //Color handle.
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
