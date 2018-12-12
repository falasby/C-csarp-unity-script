using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

using UnityEngine.SocialPlatforms;
public class Game : MonoBehaviour
{ // движение персонажа
    public Rigidbody2D rb2d;
    public float playerSpeed;

    public int directionInput;
    public GameObject ButtonNext;
    public bool facingRight = true;
    public AudioClip MyAudio;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;
    public GameObject spawn7;
    public GameObject spawn8;
    public GameObject spawn9;
    public GameObject spawn10;
    public int clickrec = 0;
    public Vector3 spawnValues;
    public float gold = 0;
    public UnityEngine.UI.Text Gold;
    public UnityEngine.UI.Text Almaz;
    public UnityEngine.UI.Text ClickerText;
    public UnityEngine.UI.Text one;
            public UnityEngine.UI.Text two;
    public int click = 1000000;
    public int Damage = 1;
    public float almazi = 0;
    // public Animator anim;
    public int lvl = 0;
    public int Up = 0;
    public int Uptimer = 0;
    private const string achiv1 = "CgkI3ION-q4ZEAIQAQ";
    private const string achiv2 = "CgkI3ION-q4ZEAIQAg";
    private const string achiv3 = "CgkI3ION-q4ZEAIQAw";
    private const string achiv4 = "CgkI3ION-q4ZEAIQBA";
    private const string achiv5 = "CgkI3ION-q4ZEAIQBQ";
    private const string achiv6 = "CgkI3ION-q4ZEAIQBg";
    private const string leaderboard = "CgkI3ION-q4ZEAIQBw";

    public GameObject Pyka;
    public GameObject Hogu;
    public int Tik;
    public int EnterMine;

    private const string BlockMoney = "ca-app-pub-8883264459930838/1845769109";
    private const string banner = "ca-app-pub-8883264459930838/9369035905";
    private InterstitialAd ad;



    public Vector2 speed = new Vector2(20, 50);
    // 2 - направление движения 
    private Vector2 movement;
    // кирки
    public GameObject[] Weapon;
    public GameObject[] Button;
    public int noomermine;
    // шахты
    public GameObject[] Buttonmine;
    public GameObject[] mine;
    public int spawnMine;
    // Х2 рубины
    public GameObject[] RubinX2;
    public int rubin = 0;
    // Спавн мобов
    public GameObject[] ButtonSpawnMOb;
    public GameObject[] Mob;
    public int SpawnMob = 0;
    //х2 маин
    public GameObject[] RubinMine;
    public int rubinx2mine = 0;
    // Скорость добычи
    public GameObject[] SpeedButton;
    public float TimeCek = 5;
    // скорость мобов
    public GameObject[] Speedmob;
    public float speedmob = 0.01f;
    private int save = 0;
    private void Awake()
    {

        
         save = PlayerPrefs.GetInt("save");
        if (save == 0)
        {
            PlayerPrefs.SetInt("up", Up);
            PlayerPrefs.SetInt("click", click);
            PlayerPrefs.SetInt("damage", Damage);
            PlayerPrefs.SetFloat("almazi", almazi);
            PlayerPrefs.SetInt("nomer", noomermine);
            PlayerPrefs.SetFloat("gold", gold);
            PlayerPrefs.SetInt("spawnMine", spawnMine);
            PlayerPrefs.SetInt("rubinx2", rubin);
            PlayerPrefs.SetInt("spawnMob", SpawnMob);
            PlayerPrefs.SetInt("rubinx2mine", rubinx2mine);
            PlayerPrefs.SetFloat("timer", TimeCek);
            PlayerPrefs.SetFloat("speedmob", speedmob);



        }
    }
    void Start()
    {



        //  PlayGamesPlatform.Activate();


        BannerView bannerV = new BannerView(banner, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        bannerV.LoadAd(request);


        ButtonNext.GetComponent<Button>().interactable = false;
        rb2d = GetComponent<Rigidbody2D>();
        save = 1;
        if (save == 1)
        {
            PlayerPrefs.SetInt("save", save);
            Up = PlayerPrefs.GetInt("up");
            click = PlayerPrefs.GetInt("click");
            Damage = PlayerPrefs.GetInt("damage");
           almazi = PlayerPrefs.GetFloat("almazi");

            noomermine = PlayerPrefs.GetInt("nomer");
            gold = PlayerPrefs.GetFloat("gold");
            spawnMine = PlayerPrefs.GetInt("spawnMine");
            rubin = PlayerPrefs.GetInt("rubinx2");
            SpawnMob = PlayerPrefs.GetInt("spawnMob");
            rubinx2mine = PlayerPrefs.GetInt("rubinx2mine");
            TimeCek = PlayerPrefs.GetFloat("timer");
            speedmob = PlayerPrefs.GetFloat("speedmob");



        }

        Pyka.GetComponent<Animator>();
    }
    private void Update()
    {

        if(Up == 1)
        {
            GetComponent<Animator>().SetInteger("State", 2);
            Pyka.gameObject.active = false;
        }
        if (EnterMine == 1) {
            if (Up == 1)
            {
                clickrec++;
                if (clickrec == 1500)
                {
                    clickrec = 0;
                    ad = new InterstitialAd(BlockMoney);
                    AdRequest request = new AdRequest.Builder().Build();
                    //   AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("3230ACE00CE1BB97").Build();
                    ad.LoadAd(request);
                    ad.OnAdLoaded += OnAdLoaded;

                }




                GetComponent<Animator>().SetInteger("State", 2);

                Uptimer++;
                if (Uptimer >= 3)
                {

                    if (rubin == 0)
                    {
                        SpawnWaves();
                        Uptimer = 0;
                    }
                    else if (rubin == 1)
                    {
                        SpawnWaves();
                        SpawnWaves();
                        Uptimer = 0;
                    }
                    else if (rubin == 2)
                    {
                        SpawnWaves();
                        SpawnWaves();
                        SpawnWaves();
                        Uptimer = 0;
                    }
                    else if (rubin == 3)
                    {
                        SpawnWaves();
                        SpawnWaves();
                        SpawnWaves();
                        SpawnWaves();
                        Uptimer = 0;
                    }
                }
            }
        }

      if(click <= 990000)
        {
          
            GetTheAchiv(achiv2);
        }
        if (click <= 900000)
        {
            GetTheAchiv(achiv3);
        }
        if (click <= 750000)
        {
            GetTheAchiv(achiv4);
        }
        if (click <= 500000)
        {
            GetTheAchiv(achiv5);
        }
        if (click <= 0)
        {
            GetTheAchiv(achiv6);
        }

       

        if (gold >= 1000000000)
        {
            gold = gold - 1000000000;
            almazi = almazi + 1;
        }
         if (almazi >= 10)
        {
            ButtonNext.GetComponent<Button>().interactable = true;
           
        }
        PlayerPrefs.SetInt("click", click);
        PlayerPrefs.SetInt("up", Up);
        PlayerPrefs.SetInt("damage", Damage);
        PlayerPrefs.SetFloat("almazi", almazi);
        PlayerPrefs.SetInt("save", save);
        PlayerPrefs.SetInt("nomer", noomermine);
        PlayerPrefs.SetFloat("gold", gold);
        PlayerPrefs.SetInt("spawnMine", spawnMine);
        PlayerPrefs.SetInt("rubinx2", rubin);
        PlayerPrefs.SetInt("spawnMob", SpawnMob);
        PlayerPrefs.SetInt("rubinx2mine", rubinx2mine);
        PlayerPrefs.SetFloat("timer", TimeCek);
        PlayerPrefs.SetFloat("speedmob", speedmob);

        if ((directionInput > 0) && (facingRight))
        {
            Flip();
        }

        if ((directionInput < 0) && (!facingRight))
        {
            Flip();
        }
        



        if (speedmob >= 0.01f)
        {
            Speedmob[0].SetActive(true);
        }
        if (speedmob >= 0.02f)
        {
            Speedmob[1].SetActive(true);
            Speedmob[0].SetActive(false);
        }
        if (speedmob >= 0.03f)
        {
            Speedmob[2].SetActive(true);
            Speedmob[1].SetActive(false);
        }
        if (speedmob >= 0.04f)
        {
            Speedmob[3].SetActive(true);
            Speedmob[2].SetActive(false);
        }
        if (speedmob >= 0.05f)
        {
            Speedmob[4].SetActive(true);
            Speedmob[3].SetActive(false);
        }
        if (speedmob >= 0.06f)
        {
            Speedmob[5].SetActive(true);
            Speedmob[4].SetActive(false);
        }
        if (speedmob >= 0.07f)
        {
            Speedmob[6].SetActive(true);
            Speedmob[5].SetActive(false);
        }
        if (speedmob >= 0.08f)
        {
            Speedmob[7].SetActive(true);
            Speedmob[6].SetActive(false);
        }
        if (speedmob >= 0.09f)
        {
            
            Speedmob[7].SetActive(false);
        }

        if (TimeCek == 5)
        {
            SpeedButton[0].SetActive(true);
        }
        if (TimeCek <= 4)
        {
            SpeedButton[1].SetActive(true);
            SpeedButton[0].SetActive(false);
        }
        if (TimeCek <= 3)
        {
            SpeedButton[2].SetActive(true);
            SpeedButton[1].SetActive(false);
        }
        if (TimeCek <= 2)
        {
            SpeedButton[3].SetActive(true);
            SpeedButton[2].SetActive(false);
        }
        if (TimeCek <= 1)
        {
            TimeCek = 0.96f;
            SpeedButton[3].SetActive(false);
        }

        if (rubinx2mine == 0)
        {
            RubinMine[0].SetActive(true);


        }
        if (rubinx2mine == 1)
        {
            RubinMine[0].SetActive(false);
            RubinMine[1].SetActive(true);
        }
        if (rubinx2mine == 2)
        {
            RubinMine[1].SetActive(false);
            RubinMine[2].SetActive(true);
        }
        if (rubinx2mine == 3)
        {
            RubinMine[2].SetActive(false);

        }


        if (SpawnMob >= 0)
        {
            ButtonSpawnMOb[0].SetActive(true);

        }
        if (SpawnMob >= 1)
        {
            Mob[0].SetActive(true);
            ButtonSpawnMOb[0].SetActive(false);
            ButtonSpawnMOb[1].SetActive(true);
         
        }
        if (SpawnMob >= 2)
        {
            Mob[1].SetActive(true);
            ButtonSpawnMOb[1].SetActive(false);
            ButtonSpawnMOb[2].SetActive(true);


        }
        if (SpawnMob >= 3)
        {
            Mob[2].SetActive(true);
            ButtonSpawnMOb[2].SetActive(false);
            ButtonSpawnMOb[3].SetActive(true);

        }
        if (SpawnMob >= 4)
        {
            Mob[3].SetActive(true);
            ButtonSpawnMOb[3].SetActive(false);
            ButtonSpawnMOb[4].SetActive(true);

        }
        if (SpawnMob >= 5)
        {
            Mob[4].SetActive(true);
            ButtonSpawnMOb[4].SetActive(false);
            ButtonSpawnMOb[5].SetActive(true);

        }
        if (SpawnMob >= 6)
        {
            Mob[5].SetActive(true);
            ButtonSpawnMOb[5].SetActive(false);
            ButtonSpawnMOb[6].SetActive(true);

        }
        if (SpawnMob >= 7)
        {
            Mob[6].SetActive(true);
            ButtonSpawnMOb[6].SetActive(false);
            ButtonSpawnMOb[7].SetActive(true);

        }
        if (SpawnMob >= 8)
        {
            Mob[7].SetActive(true);
            ButtonSpawnMOb[7].SetActive(false);
        

        }



        if (rubin == 0)
        {
            RubinX2[0].SetActive(true);


        }
        if (rubin == 1)
        {
            RubinX2[0].SetActive(false);
            RubinX2[1].SetActive(true);
        }
        if (rubin == 2)
        {
            RubinX2[1].SetActive(false);
            RubinX2[2].SetActive(true);

        }
        if (rubin == 3)
        {
            RubinX2[2].SetActive(false);
           

        }
       
        if (noomermine == 0)
        {
            Button[0].SetActive(true);
            Weapon[0].SetActive(true);
        }
        if (noomermine == 1)
        {
            Button[0].SetActive(false);
            Button[1].SetActive(true);
            Weapon[0].SetActive(false);
            Weapon[1].SetActive(true);
        }
        if (noomermine == 2)
        {
            Button[1].SetActive(false);
            Button[2].SetActive(true);
            Weapon[1].SetActive(false);
            Weapon[2].SetActive(true);
        }
        if (noomermine == 3)
        {
            Button[2].SetActive(false);
            Button[3].SetActive(true);
            Weapon[2].SetActive(false);
            Weapon[3].SetActive(true);
        }
        if (noomermine == 4)
        {
            Button[3].SetActive(false);
            Button[4].SetActive(true);
            Weapon[3].SetActive(false);
            Weapon[4].SetActive(true);
        }
        if (noomermine == 5)
        {
            Button[4].SetActive(false);
            Button[5].SetActive(true);
            Weapon[4].SetActive(false);
            Weapon[5].SetActive(true);
        }
        if (noomermine == 6)
        {
            Button[5].SetActive(false);
            Button[6].SetActive(true);
            Weapon[5].SetActive(false);
            Weapon[6].SetActive(true);
        }
        if (noomermine == 7)
        {
            Button[6].SetActive(false);
            Button[7].SetActive(true);
            Weapon[6].SetActive(false);
            Weapon[7].SetActive(true);
        }
        if (noomermine == 8)
        {
            Button[7].SetActive(false);
            Button[8].SetActive(true);
            Weapon[7].SetActive(false);
            Weapon[8].SetActive(true);
        }
        if (noomermine >= 9)
        {
            Button[8].SetActive(false);
          //  Button[9].SetActive(true);
            Weapon[8].SetActive(false);
            Weapon[9].SetActive(true);
        }
        if (noomermine >= 10)
        {

            Button[9].SetActive(false);
            Weapon[10].SetActive(true);
        }


        if (spawnMine >= 0)
        {
            Buttonmine[0].SetActive(true);
           
        }
        if (spawnMine >= 1)
        {
            Buttonmine[0].SetActive(false);
            Buttonmine[1].SetActive(true);
            mine[0].SetActive(true);

        }
        if (spawnMine >= 2)
        {
            Buttonmine[1].SetActive(false);
            Buttonmine[2].SetActive(true);
            mine[1].SetActive(true);

        }
        if (spawnMine >= 3)
        {
            Buttonmine[2].SetActive(false);
            Buttonmine[3].SetActive(true);
            mine[2].SetActive(true);

        }
        if (spawnMine >= 4)
        {
            Buttonmine[3].SetActive(false);
            Buttonmine[4].SetActive(true);
            mine[3].SetActive(true);

        }
        if (spawnMine >= 5)
        {
            Buttonmine[4].SetActive(false);
            Buttonmine[5].SetActive(true);
            mine[4].SetActive(true);

        }
        if (spawnMine >= 6)
        {
            Buttonmine[5].SetActive(false);
            Buttonmine[6].SetActive(true);
            mine[5].SetActive(true);

        }
        if (spawnMine >= 7)
        {
            Buttonmine[6].SetActive(false);
         //   Buttonmine[7].SetActive(true);
            mine[6].SetActive(true);

        }

        Almaz.text = System.String.Format("{0:0,0}", almazi);
        Gold.text = System.String.Format("{0:0,0}", gold);
        ClickerText.text = System.String.Format("{0:0,0}", click);
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical"); // 4 - движение в каждом направлении 
        movement = new Vector2(speed.x * directionInput, speed.y * inputY);
    }
  
    private void FixedUpdate()
    {
       
        GetComponent<Rigidbody2D>().velocity = movement;
    }
    public void Move(int InputAxis)
    {

        directionInput = InputAxis;
        if(InputAxis == 1 || InputAxis == -1)
        {
       
        }
        else
        {
            GetComponent<Animator>().SetInteger("State", 0);
        }

    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void Speedup()
    {
        speedmob = speedmob + 0.011f;
    }
    public void SpeedMine()
    {
        TimeCek = TimeCek - 1.01f;
    }

    public void SpawnMOBMOB()
    {
        SpawnMob = SpawnMob + 1;
    }

    public void rubininX2()
    {
        rubin = rubin + 1;
    }
    public void rubininX2mine2()
    {
        rubinx2mine = rubinx2mine + 1;
    }
    public void clicknomer()
    {
        noomermine = noomermine + 1;
    }
    public void spawnMinII()
    {
        spawnMine = spawnMine + 1;
    }
    public void onClick()
    {
        if (EnterMine == 1)
        {
            if (Up == 0)
            { 
                clickrec++;
            if (clickrec == 500)
            {
                clickrec = 0;
                ad = new InterstitialAd(BlockMoney);
                AdRequest request = new AdRequest.Builder().Build();
                //   AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("3230ACE00CE1BB97").Build();
                ad.LoadAd(request);
                ad.OnAdLoaded += OnAdLoaded;

            }

            GetComponent<AudioSource>().Play();


            Tik = 1;
            if (Tik == 1)
            {
                GetComponent<Animator>().Play("удар");
                Tik++;
            }
            if (Tik >= 5)
            {
                Pyka.GetComponent<Animator>().SetInteger("State", 0);
            }



            if (rubin == 0)
                SpawnWaves();
            else if (rubin == 1)
            {
                SpawnWaves();
                SpawnWaves();
            }
            else if (rubin == 2)
            {
                SpawnWaves();
                SpawnWaves();
                SpawnWaves();
            }
            else if (rubin == 3)
            {
                SpawnWaves();
                SpawnWaves();
                SpawnWaves();
                SpawnWaves();
            }

            // SpawnWaves();
            //     anim.SetInteger("State", 1);
        }
        }
    }
    public void OnAdLoaded(object sender, System.EventArgs args)
    {
        ad.Show();
    }
    public void Damege1()
    {
        if (EnterMine == 1)
        {

            click = click - Damage;
           


        }
    }

        public void Spawn2()
    {
        lvl = lvl + 1;
        // SpawnWaves();
        //     anim.SetInteger("State", 1);
    }
    public void X2rubin()
    {
      
        // SpawnWaves();
        //     anim.SetInteger("State", 1);
    }

    void SpawnWaves()
    {
        if (noomermine == 0)
        {
            Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, Random.Range(90.0f, -90.0f));
            Instantiate(spawn1, spawnPosition, spawnRotation);
        }else if (noomermine == 1)
        {
            Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, Random.Range(90.0f, -90.0f));
            Instantiate(spawn2, spawnPosition, spawnRotation);
        }
        else if (noomermine == 2)
        {
            Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, Random.Range(90.0f, -90.0f));
            Instantiate(spawn3, spawnPosition, spawnRotation);
        }
        else if (noomermine == 3)
        {
            Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, Random.Range(90.0f, -90.0f));
            Instantiate(spawn4, spawnPosition, spawnRotation);
        }
        else if (noomermine == 4)
        {
            Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, Random.Range(90.0f, -90.0f));
            Instantiate(spawn5, spawnPosition, spawnRotation);
        }
        else if (noomermine == 5)
        {
            Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, Random.Range(90.0f, -90.0f));
            Instantiate(spawn6, spawnPosition, spawnRotation);
        }
        else if (noomermine == 6)
        {
            Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, Random.Range(90.0f, -90.0f));
            Instantiate(spawn7, spawnPosition, spawnRotation);
        }
        else if (noomermine == 7)
        {
            Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, Random.Range(90.0f, -90.0f));
            Instantiate(spawn8, spawnPosition, spawnRotation);
        }
        else if (noomermine == 8)
        {
            Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, Random.Range(90.0f, -90.0f));
            Instantiate(spawn9, spawnPosition, spawnRotation);
        }
        else if (noomermine >= 9)
        {
            Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, Random.Range(90.0f, -90.0f));
            Instantiate(spawn10, spawnPosition, spawnRotation);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
      
      

            if (col.gameObject.tag == "coin")
            {
                if (noomermine == 0)
                {
                    gold = gold + 1;
                } else if (noomermine == 1)
                {
                    gold = gold + 10;
                }
                else if (noomermine == 2)
                {
                    gold = gold + 40;
                }
                else if (noomermine == 3)
                {
                    gold = gold + 140;
                }
            else if (noomermine == 4)
            {
                gold = gold + 1000;
            }
            else if (noomermine == 5)
            {
                gold = gold + 5000;
            }
            else if (noomermine == 6)
            {
                gold = gold + 30000;
            }
            else if (noomermine == 7)
            {
                gold = gold + 150000;
            }
            else if (noomermine == 8)
            {
                gold = gold + 300000;
            }
            else if (noomermine == 9)
            {
                gold = gold + 1000000;
            }
            else if (noomermine == 10)
            {
                gold = gold + 2000000;
            }




            Destroy(col.gameObject);

            

        }

    }
    public void UPweapon()
    {
 Up = Up + 1;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "mine")
        {
            EnterMine = 1;
          
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "mine")
        {
            EnterMine = 1;
           
        }

    }
    public void Exit()
    {
        Application.Quit();
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "mine")
        {
            EnterMine = 0;
           
        }

    }
   public void ClickDostigenia()
    {

       Social.ShowLeaderboardUI();
    }
    public void ClickAthiv()
    {
      
        Social.ShowAchievementsUI();

    }
    private void GetTheAchiv(string id)
    {
        Social.ReportProgress(id, 100.0f, (bool success) => {
          
        });
    }
    public void Athiv()
    {
        Social.localUser.Authenticate((bool success) => {
            if (success) one.text = "Вы вошли в Google play";
            else one.text = "Войти в   Google play";
        });


    }
    public void menu()
    {
        Application.LoadLevel(0);
    }
   
}