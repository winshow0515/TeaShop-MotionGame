using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Scene2_Controller : MonoBehaviour
{
    public List<string> selectedIngredients = new List<string>();
    //public Animator shakeCupAnimator; // 引用 shake 杯的 Animator Controller

    public void AddIngredient(string ingredient)
    {
        selectedIngredients.Add(ingredient);
        // 播放加料動畫
        Debug.Log("Added ingredient: " + ingredient);
        GetComponent<Animator>().SetTrigger($"{ingredient}");//播放對應的動畫
    }

    public void NextScene()
    {
        // 將選擇的配料傳遞到場景三
        PlayerPrefs.SetString("ingredients", string.Join(",", selectedIngredients.ToArray()));
        SceneManager.LoadScene("Scene3_shake");
    }
    public void QuitGame()
    {
        Debug.Log("Quit called");
        Application.Quit();
    }
}