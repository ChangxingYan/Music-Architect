using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Instantiator : MonoBehaviour
{
    public GameObject MNPrefab;
   public float maxRange;
    public int numberOfPrefab = 7;
    public float radius = 40f;
    GameObject[] musicNotes;
    public int clickCounter = 0;
    public List<int> IdCounter;
    public string Bar;
    public LineRenderer lineRend;
  //  public ParticleAndSound pnsd;
    public MusicNoteSound DoReMi;
    public Button generate;
    public Text textArchi;
    [SerializeField]
    public Text clickLeft;
    private ColorBlock color;
    public bool LoadPrefab;
    public Transform ripple;
    public RectTransform rectTransform;
    public Button clear;
    public Text clearText;


    Vector3[] positionArray;
    [SerializeField]public GameObject[] textPositions;

    public static Instantiator instantiator;

    private void Awake()
    {
        if (instantiator == null)
        { //Singleton
            instantiator = this;
        }
        else if (instantiator != this)
        {
            Destroy(gameObject);
        }
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Bar = "";

        //lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = numberOfPrefab;
     //   pnsd = GetComponent<ParticleAndSound>();
        IdCounter = new List<int>();
        musicNotes = new GameObject[numberOfPrefab];
        generate.enabled = false;
        LoadPrefab = true;
        positionArray = new Vector3[numberOfPrefab];
        
    }

    // called third
    void Start()
    {
    }

    // called when the game is terminated
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void LoadP()
    {

        for (int counter = 0; counter < numberOfPrefab; counter++)
        {
            float angle = counter * Mathf.PI * 2 / numberOfPrefab;
            Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;

            musicNotes[counter] = Instantiate(MNPrefab, pos, Quaternion.identity);

        }
    }

    [Obsolete]
    void Update()
    {
        
        if (LoadPrefab)
        {
            LoadP();
            AddPosIntoList(musicNotes);
            LoadPrefab = false;
        }



    /*    if (generate.enabled == true)
        {

            RaycastHit hitClick;
            Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(raycast, out hitClick))
            { 
            if(hitClick.transform.gameObject == FindObjectOfType<ProgressBar>())
                {

                }
            
            }
        }*/

       if (Input.GetMouseButtonDown(0))
        {
     
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if(Bar.Length < numberOfPrefab) { 
                for (int a = 0; a < numberOfPrefab; a++)

                    if (hit.transform.gameObject == musicNotes[a])  // click on one star with particular id "a"
                        {
                          Vector3 starPos = hit.transform.gameObject.transform.position;
                        lineRend.SetPosition(clickCounter, starPos);    //add the position to linerender new point 

                            ripple.position = starPos;

                            ripple.GetComponent<ParticleSystem>().Play();

                            
                        IdCounter.Add(a);   //add id to a list
                        clickCounter++;     //how many times of click left
                        
                            DoReMi.PlayParticleAndAudio(a);

                            Bar = String.Join("", new List<int>(IdCounter).ConvertAll(i => i.ToString()).ToArray());    //convert the list of ids into a string


                            clickLeft.text = "Click count: " + clickCounter.ToString() + " / 7.";       //show on screen top left
                    }
                }

            }
        }

        
         /*if(Input.GetMouseButton(0))

         {
             RaycastHit hit;
              Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

              if (Physics.Raycast(ray, out hit))
              {
                     if(Bar.Length < numberOfPrefab) 
                     { 

                         latestPosition = Input.mousePosition;

                         lineRend.SetPosition(clickCounter, latestPosition);


                         
       
                     }


               }

         }*/




         
        if (generate != null) 
        { 
            if(generate.enabled == false && clickCounter == 7)
            {
                generate.enabled = true;
                GameObject Yellow = generate.gameObject.transform.Find("Yellow").gameObject;
                GameObject YellowDark = generate.gameObject.transform.Find("YellowDark").gameObject;
                Yellow.SetActive(true);
                Yellow.SetActive(true);
                YellowDark.SetActive(false);
                
        //    color.normalColor = new Color32(255, 100, 100, 0); ;
        //    Architecture.colors = color;
            textArchi.color = Color.white;

            }
        }

        if (clear.enabled == true && clickCounter == 7)
        {
            clear.enabled = false;

            clearText.color =new Vector4(65, 65, 65, 1);


        }
    }

    void AddPosIntoList(GameObject[] tempObj)
    {
        //List<Vector3> positionList = new List<Vector3>();
        for (int i = 0; i < numberOfPrefab; i++)
        {

            /* positionList.Add(tempObj[i].transform.position);
             positionArray = positionList.ToArray();*/

            Vector3 temPos = Camera.main.WorldToScreenPoint(tempObj[i].transform.position);


            Vector2 correctPoint = new Vector2(temPos.x / Screen.width * rectTransform.sizeDelta.x, temPos.y / Screen.height * rectTransform.sizeDelta.y);
            RectTransform tempVector = textPositions[i].GetComponent<RectTransform>();


            tempVector.anchoredPosition = correctPoint;


            Debug.Log(Screen.width / rectTransform.localScale.x);
        }
    }
    

}
