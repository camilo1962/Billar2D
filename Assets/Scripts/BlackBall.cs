using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackBall : Ball
{
    public GameObject gameOver;
    public Button newGame;
    public Button mainMenu;
    public Button exit;
    public Text winner;

    public override void OnHole()
    {
        if (GameMaster.instance.solidCanHitBlack && GameMaster.instance.solid)
        {
            Destroy(gameObject);
            ShowGameOverPanel("Lisas");
        }

        else if (GameMaster.instance.stripesCanHitBlack && GameMaster.instance.stripe)
        {
            Destroy(gameObject);        
            ShowGameOverPanel("Ralladas");
        }

        else
        {
            Destroy(gameObject);
            if (GameMaster.instance.stripe)
                ShowGameOverPanel(" Lisas!");
            else if (GameMaster.instance.solid)
                ShowGameOverPanel(" Ralladas!");
            else
                ShowGameOverPanel(" NADIE!");
        }
    }

    private void ShowGameOverPanel(string win)
    {
        GameMaster.instance.paused = true;
        Time.timeScale = 0f;
        winner.text =  "¡Ganan " + win;
        newGame.onClick.AddListener(() => SceneManager.LoadScene("Billar"));
        mainMenu.onClick.AddListener(() => SceneManager.LoadScene("Menu"));
        exit.onClick.AddListener(() => Application.Quit());
        gameOver.SetActive(true);
    }
}
