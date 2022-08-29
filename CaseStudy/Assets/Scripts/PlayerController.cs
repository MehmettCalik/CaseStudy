using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.NiceVibrations;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public List<GameObject> SelectedGems = new List<GameObject>();
    public GameObject LastGemTra;
    public GameObject Ring;
    public Rigidbody rb;
    public int GemCount;
    public float GemsDistance=.35f;
    public float Speed;
    public bool isStart;
    public bool isStack;
    public Camera Camera;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Camera = Camera.main;
        DOTween.Init();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isStart)
        {
            rb.velocity = new Vector3(0, 0, 0);

        }
        if (isStart)
        {
            rb.velocity = new Vector3(0, 0, 5);

            if (transform.position.x < -2f)
            {
                transform.position = new Vector3(-2f, transform.position.y, transform.position.z);
            }

            if (transform.position.x > 3f)
            {
                transform.position = new Vector3(3f, transform.position.y, transform.position.z);
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Gem")
        {
            MMVibrationManager.Haptic(HapticTypes.LightImpact);
            Destroy(Instantiate(Resources.Load<GameObject>("Partical"), other.transform.localPosition, Quaternion.Euler(-90, 0, 0)), 0.2f);
            isStack = true;
            float ParticalTime=0.1f;
            Vector3 particalPos = new Vector3(Ring.transform.position.x, Ring.transform.position.y + (GemsDistance * SelectedGems.Count), Ring.transform.position.z);

            if (other.gameObject.name == "CubeGem" || other.gameObject.name == "CubeGem(Clone)")
            {
                GameObject CubeGem;
                if (SelectedGems.Count < 1)
                {
                    GemCount++;
                    Destroy(other.gameObject);
                    CubeGem = Instantiate(Resources.Load<GameObject>("CubeGem_Flat"));
                    Destroy(Instantiate(Resources.Load<GameObject>("Partical"), particalPos, Quaternion.Euler(-90, 0, 0)), ParticalTime);
                    SelectedGems.Add(CubeGem.gameObject);
                    LastGemTra = SelectedGems[SelectedGems.Count - 1];
                    CubeGem.GetComponent<StackObject>().nodePos = Ring.transform;
                    CubeGem.GetComponent<StackObject>().posY = 0;


                }
                else
                {
                    GemCount++;
                    LastGemTra = SelectedGems[SelectedGems.Count - 1];
                    Destroy(other.gameObject);
                    CubeGem = Instantiate(Resources.Load<GameObject>("CubeGem_Flat"));
                    Destroy(Instantiate(Resources.Load<GameObject>("Partical"), particalPos, Quaternion.Euler(-90, 0, 0)), ParticalTime);
                    SelectedGems.Add(CubeGem.gameObject);
                    CubeGem.GetComponent<StackObject>().nodePos = LastGemTra.transform;
                    CubeGem.GetComponent<StackObject>().posY = GemsDistance;
                }
            }
            if (other.gameObject.name == "Diamond" || other.gameObject.name == "Diamond(Clone)")
            {
                GameObject CubeGem;

                if (SelectedGems.Count < 1)
                {
                    GemCount++;
                    Destroy(other.gameObject);
                    CubeGem = Instantiate(Resources.Load<GameObject>("Diamond_Flat"));
                    Destroy(Instantiate(Resources.Load<GameObject>("Partical"), particalPos, Quaternion.Euler(-90, 0, 0)), ParticalTime);
                    SelectedGems.Add(CubeGem.gameObject);
                    LastGemTra = SelectedGems[SelectedGems.Count - 1];
                    CubeGem.GetComponent<StackObject>().nodePos = Ring.transform;
                    CubeGem.GetComponent<StackObject>().posY = 0;
                }
                else
                {
                    GemCount++;
                    LastGemTra = SelectedGems[SelectedGems.Count - 1];
                    Destroy(other.gameObject);
                    CubeGem = Instantiate(Resources.Load<GameObject>("Diamond_Flat"));
                    Destroy(Instantiate(Resources.Load<GameObject>("Partical"), particalPos, Quaternion.Euler(-90, 0, 0)), ParticalTime);
                    SelectedGems.Add(CubeGem.gameObject);
                    CubeGem.GetComponent<StackObject>().nodePos = LastGemTra.transform;
                    CubeGem.GetComponent<StackObject>().posY = GemsDistance;
                }
            }
            if (other.gameObject.name == "HeartGem" || other.gameObject.name == "HeartGem(Clone)")
            {
                GameObject CubeGem;

                if (SelectedGems.Count < 1)
                {
                    GemCount++;
                    Destroy(other.gameObject);
                    CubeGem = Instantiate(Resources.Load<GameObject>("HeartGem_Flat"));
                    Destroy(Instantiate(Resources.Load<GameObject>("Partical"), particalPos, Quaternion.Euler(-90, 0, 0)), ParticalTime);
                    SelectedGems.Add(CubeGem.gameObject);
                    LastGemTra = SelectedGems[SelectedGems.Count - 1];
                    CubeGem.GetComponent<StackObject>().nodePos = Ring.transform;
                    CubeGem.GetComponent<StackObject>().posY = 0;
                }
                else
                {
                    GemCount++;
                    LastGemTra = SelectedGems[SelectedGems.Count - 1];
                    Destroy(other.gameObject);
                    CubeGem = Instantiate(Resources.Load<GameObject>("HeartGem_Flat"));
                    Destroy(Instantiate(Resources.Load<GameObject>("Partical"), particalPos, Quaternion.Euler(-90, 0, 0)), ParticalTime);
                    SelectedGems.Add(CubeGem.gameObject);
                    CubeGem.GetComponent<StackObject>().nodePos = LastGemTra.transform;
                    CubeGem.GetComponent<StackObject>().posY = GemsDistance;
                }
            }
            if (other.gameObject.name == "SphereGem" || other.gameObject.name == "SphereGem(Clone)")
            {
                GameObject CubeGem;

                if (SelectedGems.Count < 1)
                {
                    GemCount++;
                    Destroy(other.gameObject);
                    CubeGem = Instantiate(Resources.Load<GameObject>("SphereGem_Flat"));
                    Destroy(Instantiate(Resources.Load<GameObject>("Partical"), particalPos, Quaternion.Euler(-90, 0, 0)), ParticalTime);
                    SelectedGems.Add(CubeGem.gameObject);
                    LastGemTra = SelectedGems[SelectedGems.Count - 1];
                    CubeGem.GetComponent<StackObject>().nodePos = Ring.transform;
                    CubeGem.GetComponent<StackObject>().posY = 0;
                }
                else
                {
                    GemCount++;
                    LastGemTra = SelectedGems[SelectedGems.Count - 1];
                    Destroy(other.gameObject);
                    CubeGem = Instantiate(Resources.Load<GameObject>("SphereGem_Flat"));
                    Destroy(Instantiate(Resources.Load<GameObject>("Partical"), particalPos, Quaternion.Euler(-90, 0, 0)), ParticalTime);
                    SelectedGems.Add(CubeGem.gameObject);
                    CubeGem.GetComponent<StackObject>().nodePos = LastGemTra.transform;
                    CubeGem.GetComponent<StackObject>().posY = GemsDistance;
                }
               
            }
            StartCoroutine(Swing());



        }
        else
        {
            isStack = false;
        }
        if (other.gameObject.tag == "Obstacle")
        {
            StartCoroutine(Obstacle());
            Camera.DOShakePosition(0.25f, 1f);
        }

        if (other.gameObject.tag=="Stop")
        {
            isStart = false;
            UIManager.instance.GemText.text = GemCount.ToString();
            UIManager.instance.winPanel.SetActive(true);

        }
        
    }

    

    IEnumerator Obstacle()
    {
        MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
        transform.DOMoveZ(transform.position.z - 10f, 1f);
        Vector3 thrownGem = new Vector3(Ring.transform.position.x, Ring.transform.position.y + (GemsDistance * SelectedGems.Count), Ring.transform.position.z + 2);
        if (SelectedGems.Count > 1)
        {
            for (int i = 0; i < Random.Range(1,5); i++)
            {

                yield return new WaitForSeconds(.1f);
                if (SelectedGems[SelectedGems.Count - 1].name == "CubeGem_Flat(Clone)")
                {
                    GemCount--;
                    GameObject InstantiateGem = Instantiate(Resources.Load<GameObject>("CubeGem"), thrownGem , Quaternion.identity);
                    InstantiateGem.GetComponent<Rigidbody>().AddForce(InstantiateGem.transform.forward *10* Random.Range(35, 60), ForceMode.Force);
                    InstantiateGem.GetComponent<Rigidbody>().AddForce(Vector3.left * Random.Range(35, 60) * 10, ForceMode.Force);
                    InstantiateGem.GetComponent<Rigidbody>().AddForce(Vector3.right * Random.Range(35, 60) * 10, ForceMode.Force);
                }
                if (SelectedGems[SelectedGems.Count - 1].name == "Diamond_Flat(Clone)")
                {
                    GemCount--;
                    GameObject InstantiateGem = Instantiate(Resources.Load<GameObject>("Diamond"), thrownGem , Quaternion.identity);
                    InstantiateGem.GetComponent<Rigidbody>().AddForce(InstantiateGem.transform.forward*10 * Random.Range(30, 55), ForceMode.Force);
                    InstantiateGem.GetComponent<Rigidbody>().AddForce(Vector3.left * Random.Range(30, 55) * 15, ForceMode.Force);
                    InstantiateGem.GetComponent<Rigidbody>().AddForce(Vector3.right * Random.Range(30, 50) * 15, ForceMode.Force);
                }
                if (SelectedGems[SelectedGems.Count - 1].name == "HeartGem_Flat(Clone)")
                {
                    GemCount--;
                    GameObject InstantiateGem = Instantiate(Resources.Load<GameObject>("HeartGem"), thrownGem , Quaternion.identity);
                    InstantiateGem.GetComponent<Rigidbody>().AddForce(InstantiateGem.transform.forward *10* Random.Range(25, 45), ForceMode.Force);
                    InstantiateGem.GetComponent<Rigidbody>().AddForce(Vector3.left * Random.Range(25, 45) * 18, ForceMode.Force);
                    InstantiateGem.GetComponent<Rigidbody>().AddForce(Vector3.right * Random.Range(25, 45) * 18, ForceMode.Force);
                }
                if (SelectedGems[SelectedGems.Count - 1].name == "SphereGem_Flat(Clone)")
                {
                    GemCount--;
                    GameObject InstantiateGem = Instantiate(Resources.Load<GameObject>("SphereGem"), thrownGem , Quaternion.identity);
                    InstantiateGem.GetComponent<Rigidbody>().AddForce(InstantiateGem.transform.forward*10 * Random.Range(40, 55), ForceMode.Force);
                    InstantiateGem.GetComponent<Rigidbody>().AddForce(Vector3.left * Random.Range(40, 50) * 5, ForceMode.Force);
                    InstantiateGem.GetComponent<Rigidbody>().AddForce(Vector3.right * Random.Range(40, 50) * 5, ForceMode.Force);
                }
                Destroy(SelectedGems[SelectedGems.Count - 1]);
                SelectedGems.RemoveAt(SelectedGems.Count - 1);

            }
        }

    }
    IEnumerator Swing()
    {
        foreach (var item in SelectedGems)
        {
            item.transform.DOScale(1.5f, .2f).OnComplete(() => item.transform.DOScale(1f, .2f));
            yield return new WaitForSeconds(.1f);
        }
    }
}