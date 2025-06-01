using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene1_Controller : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(960, 540, false); // 寬, 高, 是否全螢幕
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scene2_Ingredients");
    }
    public void QuitGame()
    {
        Debug.Log("Quit called");
        Application.Quit();
    }
}
