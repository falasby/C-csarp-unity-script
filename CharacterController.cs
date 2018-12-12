using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CnControls;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;
public class CharacterController : MonoBehaviour {

    public Sprite SlidingOnAWallSprite;
    public Animator anim;
    public float SpawnX, SpawnY;
    public GameObject mybutton;
    public GameObject jostick;


    public AudioClip JumpAudio;
    public AudioClip killAudio;
    public string LevelName;
    public bool restert;
    public AudioClip gameover;

    private const string GameOverAD = "ca-app-pub-8883264459930838/3323590703";
    private const string banner = "ca-app-pub-8883264459930838/1846857508";
    private InterstitialAd ad;

  Vector3 position;
  
    void Start()
    {
       // Advertisement.Initialize("1316773", false);
        anim = GetComponent<Animator>();
        //Создание объекта для проверки, если игрок мели или трогательная стены
        groundState = new GroundState(transform.gameObject);
        SpawnX = transform.position.x;
        SpawnY = transform.position.y;
        BannerView bannerV = new BannerView(banner, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
      //  AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("3230ACE00CE1BB97").Build();
        bannerV.LoadAd(request);

    }

    void Update()
    {


        position = new Vector3(CnInputManager.GetAxis("Horizontal"), 0f, 0f);
        Debug.Log(position);
        Debug.Log(input.x);
        anim.SetInteger("State", 0);
        //движение персонажа на клаве
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            input.x = -1;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            input.x = 1;
        else if (!Input.GetKeyUp(KeyCode.RightArrow) && Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) && !Input.GetKeyUp(KeyCode.LeftArrow))
            input.x = 0;
        if (Input.GetKeyDown(KeyCode.Space))
            input.y = 1;
      //  transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, (position.x == 0) ? transform.localEulerAngles.y : (position.x + 1) * 90, transform.localEulerAngles.z);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            anim.SetInteger("State", 1);

        //если идти в другом направлении
        if (position.x > 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
      else if (position.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("State", 2);
        }
    }
   

    public void RightButton()
    {
        position.x = 1;
    }
    public void LeftButton()
    {
        position.x = -1;
    }

    public void JumpButton()
    {
        input.y = 1;
    }

    public void StopMoving()
    {

        input.y = 0;
        position.x = 0;
    }





    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "SAW1" || col.gameObject.name == "Mace01" || col.gameObject.name == "SawClean" || col.gameObject.name == "kill" || col.gameObject.tag == "killzona")
        {

       
           
            Application.LoadLevel(Application.loadedLevelName);
       
            anim.SetInteger("State", 4);
            GetComponent<TrailRenderer>().enabled = false;
          //  Application.LoadLevel("Application.loadedlevel");
           // transform.position = new Vector3(SpawnX, SpawnY, transform.position.z);
            GetComponent<AudioSource>().clip = killAudio;
            GetComponent<AudioSource>().Play();


        }
        else
            GetComponent<TrailRenderer>().enabled = true;


        if (col.gameObject.name == "endlvl")
        {

            Destroy(this);
            mybutton.gameObject.SetActive(true);
            jostick.gameObject.SetActive(false);
            ad = new InterstitialAd(GameOverAD);
           AdRequest request = new AdRequest.Builder().Build();
         //   AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("3230ACE00CE1BB97").Build();
            ad.LoadAd(request);
            ad.OnAdLoaded += OnAdLoaded;
        }
    }
    public void OnAdLoaded(object sender, System.EventArgs args)
    {
        ad.Show();
    }
    public class GroundState
    {
        private GameObject player;
        private float width;
        private float height;
        private float length;

        //GroundState constructor.  Sets offsets for raycasting.
        public GroundState(GameObject playerRef)
        {
            player = playerRef;
            width = player.GetComponent<Collider2D>().bounds.extents.x + 0.1f;
            height = player.GetComponent<Collider2D>().bounds.extents.y + 0.2f;
            length = 0.05f;
        }

        // Возвращает ли или нет игрок прикасается стены.
        public bool isWall()
        {
            bool left = Physics2D.Raycast(new Vector2(player.transform.position.x - width, player.transform.position.y), -Vector2.right, length);
            bool right = Physics2D.Raycast(new Vector2(player.transform.position.x + width, player.transform.position.y), Vector2.right, length);


            if (left || right)
                return true;

            else
                return false;






        }


        //Возвращает ли или нет игрок касаясь земли.
        public bool isGround()
        {
            bool bottom1 = Physics2D.Raycast(new Vector2(player.transform.position.x, player.transform.position.y - height), -Vector2.up, length);
            bool bottom2 = Physics2D.Raycast(new Vector2(player.transform.position.x + (width - 0.2f), player.transform.position.y - height), -Vector2.up, length);
            bool bottom3 = Physics2D.Raycast(new Vector2(player.transform.position.x - (width - 0.2f), player.transform.position.y - height), -Vector2.up, length);
            if (bottom1 || bottom2 || bottom3)
                return true;
            else
                return false;

        }

        //возвращает ли или нет игрок прикасается к стене или землю.
        public bool isTouching()
        {

            if (isGround() || isWall())
                return true;
            else
                return false;


        }

        //Возвращает направление стены.
        public int wallDirection()
        {
            bool left = Physics2D.Raycast(new Vector2(player.transform.position.x - width, player.transform.position.y), -Vector2.right, length);
            bool right = Physics2D.Raycast(new Vector2(player.transform.position.x + width, player.transform.position.y), Vector2.right, length);

            if (left)
                return -1;
            else if (right)
                return 1;
            else
                return 0;




        }
       
    }
  
    
    //Вы можете настроить эти значения в инспекторе до совершенства. Я предпочитаю их частными.
    public float speed = 10f;
    public float accel = 6f;
    public float airAccel = 1.5f;
    public float jump = 10f;  

    private GroundState groundState;



    private Vector2 input;



    void FixedUpdate()
    {

        GetComponent<Rigidbody2D>().AddForce(new Vector2(((position.x * speed) - GetComponent<Rigidbody2D>().velocity.x) * (groundState.isGround() ? accel : airAccel), 0)); //Переместить игрока.
        GetComponent<Rigidbody2D>().velocity = new Vector2((position.x == 0 && groundState.isGround()) ? 0 : GetComponent<Rigidbody2D>().velocity.x, (input.y == 1 && groundState.isTouching()) ? jump : GetComponent<Rigidbody2D>().velocity.y); //Stop player if input.x is 0 (and grounded) and jump if input.y is 1

        if (groundState.isWall() && !groundState.isGround() && input.y == 1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-groundState.wallDirection() * speed * 0.75f, GetComponent<Rigidbody2D>().velocity.y); //// Останов игрок, если input.x равен 0 (и заземлен) и переход, если input.y 1
            GetComponent<AudioSource>().clip = JumpAudio;
            GetComponent<AudioSource>().Play();
        }

        if (input.y >0)
        {
            GetComponent<AudioSource>().clip = JumpAudio;
        }

        if (input.y > 0 && groundState.isGround())
        {
            GetComponent<AudioSource>().Play();
        }
  

        if (groundState.isWall() && !groundState.isGround() && input.y == 1)
            transform.Rotate(new Vector3(0, 180, 0));
           GetComponent<SpriteRenderer>().flipX = false;
        

        if (groundState.isWall())
       GetComponent<SpriteRenderer>().flipX = true;


       input.y = 0;

    //    input.x = 0;



    }
   

}
