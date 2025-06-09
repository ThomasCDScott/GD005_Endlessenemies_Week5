using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuControl : MonoBehaviour
{
  

    public void changeScene()
    {
     
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
