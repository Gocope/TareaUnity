using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptSalida : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
       {
            FindAnyObjectByType<GameManager>().End(true);
       }
    }
}
