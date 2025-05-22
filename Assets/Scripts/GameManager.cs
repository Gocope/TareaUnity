using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player, bloqueSalida;
    public int tiempoNivel = 99;
    private int tiempoRestante = 0;
    public TextMeshProUGUI textoTemporizador;
    private float tiempoAnterior = 0;

    //public static GameManager Instance { get; private set; }

    private int numLevel; // Número de nivel



    private void Awake()
    {
        numLevel = 1;
    }
    void Start()
    {
        tiempoRestante = tiempoNivel;
    }
    void Update()
    {
        if (tiempoRestante > 0 & Time.time >= tiempoAnterior + 1)
        {
            tiempoRestante--;
            textoTemporizador.text = tiempoRestante.ToString();
            tiempoAnterior = Time.time;
        } else
        {
            if (tiempoRestante <= 0)
            {
                End(false);
            }
        }
    }

    public void Reset()
    {
        player.GetComponent<MoverPlayer>().Reset();
        tiempoRestante = tiempoNivel;
    }

    public void LoadNextLevel()
    {
        if (!SceneManager.GetActiveScene().Equals("Game_Level3")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);// Cargamos la siguiente escena
            numLevel++;
        }
        else
        {
            End(true);
        }
    }
    public void LoadSameLevel()
    {
        SceneManager.LoadScene("Game_Level" + numLevel);
    }
    public void End(bool winner)
    {
         if (winner)
        {
            SceneManager.LoadScene("EndGameWin");
        }
        else
        {
            SceneManager.LoadScene("EndGameLose");
        }
        player.GetComponent<MoverPlayer>().Reset();
    }
}
