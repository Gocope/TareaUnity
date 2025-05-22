using UnityEngine;

public class ScriptGrid : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
       {
            FindAnyObjectByType<GameManager>().End(false);
       }
    }
}
