using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public void GameScene(int Level)
    {
        SceneManager.LoadScene("Game_Level1");
    }
}
