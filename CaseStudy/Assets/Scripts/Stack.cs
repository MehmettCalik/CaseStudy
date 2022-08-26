using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stack : MonoBehaviour
{

    public Rigidbody rb;
    public Transform LastGemTra;
    public List<GameObject> SelectedGems = new List<GameObject>();
    public GameObject Ring;
    public float GemsDistance;
    public float Speed;
   // public float DownTime;
    public float GemCount;

    void Start()
    {
        DOTween.Init();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {


       // rb.velocity += new Vector3(rb.velocity.x,rb.velocity.y,rb.velocity.z+1.5f);
          transform.position += Vector3.forward * Speed * Time.deltaTime;


        if (transform.position.x < -2.2f)
        {
            transform.position = new Vector3(-2.2f, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 2.2f)
        {
            transform.position = new Vector3(2.2f, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gem")
        {

            if (other.gameObject.name=="CubeGem")
            {
                if (!LastGemTra)
                {
                   GameObject CubeGem = Instantiate(Resources.Load<GameObject>("CubeGem_Flat"), Ring.transform.position, Quaternion.identity);
                    LastGemTra = CubeGem.transform;

                }else
                {
                    //GameObject CubeGem = Instantiate(Resources.Load<GameObject>("CubeGem_Flat"),LastGemTra.transform.DOLocalMove(.position,.5f), Quaternion.identity);
                    //LastGemTra = CubeGem.transform;

                }

            }
            GemCount++;
            other.transform.parent = transform;
            SelectedGems.Add(other.gameObject);
            other.gameObject.tag = "Untagged";

            




            if (!LastGemTra)
            {
             //  Instantiate(Resources.Load<GameObject>("SwordHitRed"), new Vector3(col.transform.position.x, col.transform.position.y + .5f, col.transform.position.z), Quaternion.identity);

                other.gameObject.AddComponent<StackObject>().nodePos = Ring.transform;
                LastGemTra = other.transform;
            }
            else
            {
                other.gameObject.AddComponent<StackObject>().nodePos = LastGemTra;
                LastGemTra = other.transform;
                other.gameObject.GetComponent<StackObject>().posY = GemsDistance;
            }

            //for (int i = SelectedGems.Count; i > 0; i--)
            //{
            //    Vector3 scale = new Vector3(1.5f, 1.5f, 1.5f);
            //    scale *= 1.5f;
            //    SelectedGems[i].transform.DOScale(scale, 0.3f).OnComplete(() => SelectedGems[i].transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.3f));
            //    tekrar bakılacak
            //}

        }

        if (other.gameObject.name=="Obstacle")
        {
            StartCoroutine(Obstacle());
           
        }
    }

    IEnumerator Obstacle()
    {
        transform.DOMoveZ(transform.position.z - 7f, 1f);
        yield return new WaitForSeconds(0.2f);
       
        if (SelectedGems.Count>1)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject LastGem = SelectedGems[SelectedGems.Count - 1];
                LastGem.transform.SetParent(null);
                Destroy(LastGem.GetComponent<StackObject>());
                //LastGem.GetComponent<Rigidbody>().AddForce(Vector3.forward*10);
                LastGem.GetComponent<Rigidbody>().velocity = new Vector3(0f, Random.Range(1, 2), Random.Range(0, 20));
                SelectedGems.RemoveAt(SelectedGems.Count - 1);
                LastGem.gameObject.tag = "Gem";

            }
        }
        else
        {
        }
       
    }


    //public void Stacking(GameObject other, int index)
    //{
    //    other.transform.parent = transform;
    //    Vector3 newpos = SelectedGems[index].transform.localPosition;
    //    newpos.y += GemsDistance;
    //    other.transform.localPosition = newpos;
    //}

    //private void OnMouseDown()
    //{
    //    Down();
    //}
    //private void OnMouseUp()
    //{
    //    Up();
    //} 
    //public void Down()
    //{
    //    for (int i = 0; i < SelectedGems.Length; i++)
    //    {
    //        Vector3 pos = SelectedGems[i].transform.localPosition;
    //        pos.x = SelectedGems[i - 1].transform.localPosition.x;
    //        SelectedGems[i].transform.DOLocalMove(pos, DownTime);
    //    }   
    //}
    //public void Up()
    //{
    //    for (int i = 0; i < SelectedGems.Length; i++)
    //    {
    //        Vector3 pos = SelectedGems[i].transform.localPosition;
    //        pos.x = SelectedGems[0].transform.localPosition.x;
    //        SelectedGems[i].transform.DOLocalMove(pos, 0.75f);
    //    }
    //}



}
