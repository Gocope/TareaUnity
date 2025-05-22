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
