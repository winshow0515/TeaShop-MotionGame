using UnityEngine;
using System.IO.Ports;
using TMPro;
using UnityEngine.UI;
using System.Linq.Expressions;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShakeDetector : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM3", 9600);

    public TextMeshProUGUI shakeMessage;
    public RectTransform progressFill;
    public float shakeThreshold = 0.2f;
    public float progressStep = 5f;
    public float maxProgressWidth = 500f; // 進度條最長寬度（px）
    public int requiredShakes = 100;

    private Vector3 lastAccel = Vector3.zero;
    private int shakeCount = 0;
    private bool animationPlayed = false;

    IEnumerator SetInitialTransform()
    {
        // 等一幀，讓 Animator 播完進場預設值再設定我們自己的值
        yield return null;

        transform.position = new Vector3(0f, -1f, 0f);
        transform.rotation = Quaternion.identity;
        transform.localScale = new Vector3(2f, 2f, 1f);
    }
    void Start()
    {
        StartCoroutine(SetInitialTransform());
        if (!serialPort.IsOpen)
        {
            serialPort.Open();
            serialPort.ReadTimeout = 50;
        }

        shakeMessage.text = "搖晃傳感器吧";
        progressFill.sizeDelta = new Vector2(0, progressFill.sizeDelta.y);
    }

    void Update()
    {
        if (serialPort.IsOpen && !animationPlayed)
        {
            try
            {
                string data = serialPort.ReadLine(); // "0.12,-0.03,0.98"
                string[] values = data.Split(',');

                if (values.Length >= 3)
                {
                    float ax = float.Parse(values[0]);
                    float ay = float.Parse(values[1]);
                    float az = float.Parse(values[2]);

                    Vector3 accel = new Vector3(ax, ay, az).normalized;
                    float delta = Vector3.Distance(accel, lastAccel);

                    if (delta > shakeThreshold)
                    {
                        shakeCount++;
                        Debug.Log($"偵測到晃動第 {shakeCount} 次");

                        // 更新進度條寬度
                        float width = Mathf.Clamp(shakeCount * progressStep, 0f, maxProgressWidth);
                        progressFill.sizeDelta = new Vector2(width, progressFill.sizeDelta.y);
                    }

                    lastAccel = accel;

                    if (shakeCount >= requiredShakes && !animationPlayed)
                    {
                        animationPlayed = true;
                        shakeMessage.text = "搖晃完成！";
                        TriggerShakeAnimation();
                    }
                }
            }
            catch (System.Exception) { }
        }
    }

    IEnumerator WaitAndGoNextScene()
    {
        yield return new WaitForSeconds(2f); // 3 秒動畫 + 1 秒 Idle
        Debug.Log("進入下個場景");
        SceneManager.LoadScene("Scene4_Result");
    }

    void TriggerShakeAnimation()
    {
        // 在這裡撥放雪克杯動畫（例如觸發 Animator）
        Debug.Log(">>> 觸發動畫 <<<");
        // 例如：
        GetComponent<Animator>().SetTrigger("ShakeCup");
        StartCoroutine(WaitAndGoNextScene());
    }
    public void QuitGame()
    {
        Debug.Log("Quit called");
        Application.Quit();
    }
}
