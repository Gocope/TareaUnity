using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody2D rb;
    public float horizontalInput = 0f;
    public float verticalInput = 0f;
    public Vector2 startPos;
    private bool normSize;
    public float normalSize = 0.5f;
    public float smallSize = 0.25f;
    public AudioSource audioSource;
    public AudioClip bip;
    private float tIni = 0f;
    private float tFin = -10f;
    public int tChangeSize = 2;
    public int tLastChangeSize = 5;
    private Animator animator;

    void Start()
    {
        transform.localScale = new Vector3(normalSize, normalSize, 1);
        startPos = transform.position;
        normSize = true;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & normSize & (Time.time > tFin + tLastChangeSize))
        {
            normSize = !normSize;
            audioSource.clip = bip;
            audioSource.Play();
            tIni = Time.time;
            transform.localScale = new Vector3(smallSize, smallSize, 1);
        }
        else {
            if (!normSize & Time.time > tIni + tChangeSize) {
                transform.localScale = new Vector3(normalSize, normalSize, 1);
                tFin = Time.time;
                normSize = true;
            }
        }
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        rb.linearVelocity = new Vector2(horizontalInput * speed, verticalInput * speed);
        animator.SetBool("running", ((horizontalInput != 0.0f) | (verticalInput != 0.0f)));
     }

    public void Reset()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = startPos;
    }
}
