using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GemControll : MonoBehaviour
{
    public Transform nodePos;
    public float posY;
    public GameObject[] SelectedGems;
    void Start()
    {
        DOTween.Init();
        
    }

    void Update()
    {
        SelectedGems = GameObject.FindGameObjectsWithTag("Selected");
        Sequence sequence = DOTween.Sequence();

        for (int i = 0; i < SelectedGems.Length; i++)
        {

            //SelectedGems[i].transform.position = new Vector3(Mathf.Lerp(transform.position.x, nodePos.position.x, Time.deltaTime * 30), nodePos.position.y - posY, nodePos.position.z);
            // sequence.Append(Gem[i].transform.DOMoveY(Gem[i].transform.position.y + .3f, 1)).Join(transform.DORotate(new Vector3(720, 0, 0), 1f))
            //.OnComplete(() => Gem[i].transform.DOMoveY(Gem[i].transform.position.y - .3f, 1f));


        }

    }
}
