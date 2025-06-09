using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
  public void RestartButton()
    {
        SceneManager.LoadScene("Prototype4");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
