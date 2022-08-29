using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("Gem")]
    public GameObject TotalGem_UI;
    public int TotalGemInt;
    public Text TotalGemText;
    public Text GemText;
    [Header("Win")]
    public GameObject winPanel;
    [Header("Lose")]
    public GameObject LosePanel;
    [Header("LevelStart")]
    public GameObject LevelStartButton;
    [Header("Level")]
   // public GameObject[] Level;
    //public int LevelCount=1;
    //public int levelOk;
    public Text levelText;
    [Header("Final")]
    public GameObject FinalButton;
    private void Awake()
    {
        instance = this;
        DOTween.Init();
    }
    private void Start()
    {
        //TotalGemText.text = (PlayerPrefs.GetInt("Money") + TotalGemInt).ToString();
        TotalGemText.text = PlayerPrefs.GetInt("Money") + "";

        if (PlayerPrefs.GetInt("Level") == 0)
        {
            PlayerPrefs.SetInt("Level", 1);
        }

        if (PlayerPrefs.GetInt("Level") < Application.levelCount)
        {
            if (Application.loadedLevel != PlayerPrefs.GetInt("Level"))
            {
                Application.LoadLevel(PlayerPrefs.GetInt("Level"));
            }
        }


        levelText.text = PlayerPrefs.GetInt("Level") + "";

    }


    public void NextLevel()
    {
        StartCoroutine(NextPlatform());

       
               
    }
    private void LateUpdate()
    {
        TotalGemText.text = PlayerPrefs.GetInt("Money")+"";

    }

    public void Retry()
    {
        Application.LoadLevel(Application.loadedLevel);

    }

    public void IsStart()
    {
        PlayerController.instance.isStart = true;
        LevelStartButton.SetActive(false);
    }
    
    
    IEnumerator NextPlatform()
    {
        TotalGemText.text = (PlayerPrefs.GetInt("Money") + TotalGemInt).ToString();
        TotalGemInt += PlayerController.instance.GemCount;
        //TotalGemText.text = TotalGemInt.ToString();
        PlayerPrefs.SetInt(("Money"), TotalGemInt);
        //PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money"));
        TotalGem_UI.transform.DOScale(1.2f, 1).OnComplete(() => TotalGem_UI.transform.DOScale(1, 1f));
        FinalButton.GetComponent<Button>().enabled = false;
        yield return new WaitForSeconds(2f);
        FinalButton.SetActive(false);
        // PlayerPrefs.SetInt(("Money"),PlayerPrefs.GetInt("Money"));
 
         PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        if (PlayerPrefs.GetInt("Level") >= Application.levelCount)
        {
            Application.LoadLevel(Random.Range(1, Application.levelCount));
        }
        else
        {
            Application.LoadLevel(PlayerPrefs.GetInt("Level"));
        }









        //LevelCount++;
        //GameObject Level1, Level2, Level3;
        //if (Level[0])
        //{
        //    Destroy( Level1 = Instantiate(Resources.Load<GameObject>("Level1"), new Vector3(-24f, 20f, -70f), Quaternion.identity),levelOk=1);

        //}
        //if (Level[1])
        //{
        //    Destroy(Level2 = Instantiate(Resources.Load<GameObject>("Level2"), new Vector3(-24f, 20f, -70f), Quaternion.identity), levelOk = 1);
        //}
        //if (Level[2])
        //{
        //    Destroy(Level3 = Instantiate(Resources.Load<GameObject>("Level3"), new Vector3(-24f, 20f, -70f), Quaternion.identity), levelOk = 1);
        //}
        //if (LevelCount<=3)
        //{
        //    switch (LevelCount)
        //    {
        //        case 1:
        //            Level[0];
        //            break;

        //        case 2:
        //            Level[1];
        //            break;

        //        case 3:
        //            Level[2];
        //            break;
        //        default:
        //            Level[Random.Range(1, 3)];
        //            break;
        //    }
        //}

        //GameObject Level2=Instantiate(Resources.Load<GameObject>("Level2"), new Vector3(-24f, 20f, -70f), Quaternion.identity);
        //GameObject Level3=Instantiate(Resources.Load<GameObject>("Level3"), new Vector3(-24f, 20f, -70f), Quaternion.identity);
        //if (LevelCount <= 3)
        //{
        //    switch (Level)
        //    {
        //        case 1:
        //            Level[0].SetActive(true);
        //            break;
        //        case 2:
        //            Level[0].SetActive(false);
        //            Level[1].SetActive(true);

        //            break;
        //        case 3:
        //            Level[1].SetActive(false);
        //            Level[2].SetActive(true);

        //            break;
        //        default:
        //            Level[Random.Range(1, 3)].SetActive(true);
        //            break;
        //    }
        //}


    }
}