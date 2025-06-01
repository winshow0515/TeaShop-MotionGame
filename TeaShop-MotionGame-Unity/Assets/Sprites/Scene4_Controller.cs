using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq; // 引入 LINQ 以使用 Sort()

public class Scene4_Controller : MonoBehaviour
{
    public Image drinkImage;
    public TMPro.TextMeshProUGUI drinkName;

    public Dictionary<string, DrinkData> drinkRecipes = new Dictionary<string, DrinkData>()
        {
            {"冰塊", new DrinkData { Name = "一氧化二氫", ImageName = "a" }},
            {"多多", new DrinkData { Name = "米血", ImageName = "f" }},
            {"牛奶", new DrinkData { Name = "優格", ImageName = "b" }},
            {"糖", new DrinkData { Name = "臺南人", ImageName = "c" }},
            {"紅茶", new DrinkData { Name = "蝦餅", ImageName = "e" }},
            {"綠茶", new DrinkData { Name = "壞蛋特調", ImageName = "d" }},
            {"冰塊,多多", new DrinkData { Name = "皮蛋瘦肉粥", ImageName = "c" }},
            {"冰塊,牛奶", new DrinkData { Name = "黃雲翔", ImageName = "g" }},
            {"冰塊,糖", new DrinkData { Name = "冰糖", ImageName = "a" }},
            {"冰塊,紅茶", new DrinkData { Name = "鹹豆花", ImageName = "b" }},
            {"冰塊,綠茶", new DrinkData { Name = "譚語萱", ImageName = "IceGreenTea" }},
            {"多多,牛奶", new DrinkData { Name = "苡銨特調87號", ImageName = "g" }},
            {"多多,糖", new DrinkData { Name = "炒麵", ImageName = "c" }},
            {"多多,紅茶", new DrinkData { Name = "瑪格莉特披薩", ImageName = "f" }},
            {"多多,綠茶", new DrinkData { Name = "多多慮", ImageName = "e" }},
            {"牛奶,糖", new DrinkData { Name = "超甜牛奶", ImageName = "d" }},
            {"牛奶,紅茶", new DrinkData { Name = "ㄋㄟㄋㄟ好喝到咩噗茶", ImageName = "f" }},
            {"牛奶,綠茶", new DrinkData { Name = "炒飯", ImageName = "e" }},
            {"糖,紅茶", new DrinkData { Name = "嘎逼", ImageName = "b" }},
            {"糖,綠茶", new DrinkData { Name = "黃金魚蛋", ImageName = "a" }},
            {"紅茶,綠茶", new DrinkData { Name = "松露野菇燉飯", ImageName = "d" }},
            {"冰塊,多多,牛奶", new DrinkData { Name = "大腸麵線", ImageName = "c" }},
            {"冰塊,多多,糖", new DrinkData { Name = "滑蛋牛肉", ImageName = "f" }},
            {"冰塊,多多,紅茶", new DrinkData { Name = "凱撒沙拉", ImageName = "b" }},
            {"冰塊,多多,綠茶", new DrinkData { Name = "炸雞", ImageName = "a" }},
            {"冰塊,牛奶,糖", new DrinkData { Name = "烏龍麵", ImageName = "g" }},
            {"冰塊,牛奶,紅茶", new DrinkData { Name = "鴨肉麵", ImageName = "b" }},
            {"冰塊,牛奶,綠茶", new DrinkData { Name = "酸辣湯", ImageName = "a" }},
            {"冰塊,糖,紅茶", new DrinkData { Name = "雞蛋豆腐", ImageName = "e" }},
            {"冰塊,糖,綠茶", new DrinkData { Name = "蚵仔煎", ImageName = "d" }},
            {"冰塊,紅茶,綠茶", new DrinkData { Name = "麥香魚漢堡", ImageName = "g" }},
            {"多多,牛奶,糖", new DrinkData { Name = "饅頭夾蛋", ImageName = "d" }},
            {"多多,牛奶,紅茶", new DrinkData { Name = "滑鼠", ImageName = "g" }},
            {"多多,牛奶,綠茶", new DrinkData { Name = "煎餃", ImageName = "f" }},
            {"多多,糖,紅茶", new DrinkData { Name = "薯條", ImageName = "b" }},
            {"多多,糖,綠茶", new DrinkData { Name = "玉米水餃", ImageName = "a" }},
            {"多多,紅茶,綠茶", new DrinkData { Name = "麻辣鴨血", ImageName = "c" }},
            {"牛奶,糖,紅茶", new DrinkData { Name = "丼飯", ImageName = "d" }},
            {"牛奶,糖,綠茶", new DrinkData { Name = "章魚燒", ImageName = "c" }},
            {"牛奶,紅茶,綠茶", new DrinkData { Name = "牛肉麵", ImageName = "e" }},
            {"糖,紅茶,綠茶", new DrinkData { Name = "玉米濃湯", ImageName = "a" }},
            {"冰塊,多多,牛奶,糖", new DrinkData { Name = "大阪燒", ImageName = "f" }},
            {"冰塊,多多,牛奶,紅茶", new DrinkData { Name = "咖哩飯", ImageName = "c" }},
            {"冰塊,多多,牛奶,綠茶", new DrinkData { Name = "鍋燒意麵", ImageName = "g" }},
            {"冰塊,多多,糖,紅茶", new DrinkData { Name = "吳珏庭", ImageName = "e" }},
            {"冰塊,多多,糖,綠茶", new DrinkData { Name = "炒高麗菜", ImageName = "d" }},
            {"冰塊,多多,紅茶,綠茶", new DrinkData { Name = "陳玟秀", ImageName = "f" }},
            {"冰塊,牛奶,糖,紅茶", new DrinkData { Name = "夜市牛排", ImageName = "e" }},
            {"冰塊,牛奶,糖,綠茶", new DrinkData { Name = "雞排", ImageName = "c" }},
            {"冰塊,牛奶,紅茶,綠茶", new DrinkData { Name = "金沙雞肉義大利麵", ImageName = "d" }},
            {"冰塊,糖,紅茶,綠茶", new DrinkData { Name = "臭豆腐", ImageName = "b" }},
            {"多多,牛奶,糖,紅茶", new DrinkData { Name = "燒餅", ImageName = "a" }},
            {"多多,牛奶,糖,綠茶", new DrinkData { Name = "蛋捲", ImageName = "a" }},
            {"多多,牛奶,紅茶,綠茶", new DrinkData { Name = "油條", ImageName = "b" }},
            {"多多,糖,紅茶,綠茶", new DrinkData { Name = "麻醬麵", ImageName = "c" }},
            {"牛奶,糖,紅茶,綠茶", new DrinkData { Name = "洋芋片", ImageName = "g" }},
            {"冰塊,多多,牛奶,糖,紅茶", new DrinkData { Name = "小籠湯包", ImageName = "f" }},
            {"冰塊,多多,牛奶,糖,綠茶", new DrinkData { Name = "排骨酥麵", ImageName = "e" }},
            {"冰塊,多多,牛奶,紅茶,綠茶", new DrinkData { Name = "海底撈火鍋", ImageName = "g" }},
            {"冰塊,多多,糖,紅茶,綠茶", new DrinkData { Name = "銀絲卷", ImageName = "a" }},
            {"冰塊,牛奶,糖,紅茶,綠茶", new DrinkData { Name = "三杯雞", ImageName = "d" }},
            {"多多,牛奶,糖,紅茶,綠茶", new DrinkData { Name = "奶皇包", ImageName = "c" }},
            {"冰塊,多多,牛奶,糖,紅茶,綠茶", new DrinkData { Name = "狠人", ImageName = "d" }}
        };

    [System.Serializable]
    public struct DrinkData
    {
        public string Name;
        public string ImageName;
    }

    void Start()
    {
        string ingredients = PlayerPrefs.GetString("ingredients", "");
        Debug.Log("Selected Ingredients (raw): " + ingredients);

        // 將配料字串分割成陣列
        string[] ingredientArray = ingredients.Split(',');

        // 對配料陣列進行排序
        System.Array.Sort(ingredientArray);

        // 將排序後的配料陣列重新組合成字串，用作字典的 Key
        string sortedIngredients = string.Join(",", ingredientArray);
        Debug.Log("Sorted Ingredients: " + sortedIngredients);

        // 根據排序後的配料判斷飲料名稱和圖片
        if (drinkRecipes.ContainsKey(sortedIngredients))
        {
            drinkName.text = drinkRecipes[sortedIngredients].Name;
            Sprite drinkSprite = Resources.Load<Sprite>("Drinks/" + drinkRecipes[sortedIngredients].ImageName);
            if (drinkSprite != null)
            {
                drinkImage.sprite = drinkSprite;
            }
            else
            {
                Debug.LogError("找不到圖片: Drinks/" + drinkRecipes[sortedIngredients].ImageName);
                drinkName.text = "神秘飲料";
            }
        }
        else
        {
            drinkName.text = "特調飲料";
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("Scene2_Ingredients");
    }
        
    public void QuitGame()
    {
        Debug.Log("Quit called");
        Application.Quit();
    }
}