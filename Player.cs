using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Player : NetworkBehaviour  // MonoBehaviour
 {


public GameObject[] spawnPoints;


	public UnityEngine.UI.Button Teleport1;
	public UnityEngine.UI.Button Mass;
	public UnityEngine.UI.Button FireBoll1;
	public UnityEngine.UI.Button FireBigBoll;
	public GameObject FireBigBoll1;
	public UnityEngine.UI.Button SpeedButton;
	public GameObject SpeedButtonSpawn;


    public int SpeeDShop = 0;
	public int fireBigBollShop = 0;

	public GameObject GemeOvers;

	public float MoveSpeed;

	public float Heals =100;
	public Slider sliderHP;
	public Image HPme;
	public Text HpText;
public int Money;
public Text MoneyText;




public GameObject teleportMoney;
public GameObject FireBollMoney;


public GameObject canvesPlayer;
public GameObject CameraKill;
public GameObject CameraDeal;


public int Counte;
public Text CounteText;
public int Dead;
public Text DeaDText;

public Image AUEKD;
public Text AUETEXT;
public GameObject AUEOBOD;
public Image TeleportKDimage;
public Text teleportTEXT;
public GameObject TeleportOBOD;
public Image FireKDImage;
public Text FireTEXT;
public GameObject FireOBOD;
public Image FireKDImageBig;
public Text FireTEXTBig;
public GameObject FireOBODBig;
public Image SpeedKDImage;
public Text SpeedTEXT;
public GameObject SpeedOBOD;

public Text fsdfsdf;// номер скила


	private Rigidbody Player123;

	public GameObject Bullet;
	public GameObject BulletBig;

	public GameObject startPos;
		public GameObject startPosBigFire;

	private float gravityForce;

	private Vector3 moveVector;

	public Joystick joystick;

	public Vector3 target;

	private Ray ray;

	private RaycastHit hit;


public int fingerId;


	private CharacterController ch_controller;

	public float timeuUpdate;
	public int TimeuupdateINT;

	public Animator anim;

	public int Skill;
	public float TeleportKD;
	public float TeleportSkill = 7f;
	public float TeleportDistans;

	public static float FireKD;
	public float FireSkill = 7f;

	public float FireBigKD;
	public float FireBigSkill = 7f;

	public float dist = 20f;
	public float MassKD;
	public float MassSkill = 7f;
	public float MassDistans;

	public float SpeedKd;
	public float SpeedSkill = 7f;
public float timerSpeed;
public bool timerBoolspeed;


	public GameObject MassEffect;

	public GameObject TeleportEffect;
		public GameObject lawaEffect;
		
	

	public List<GameObject> currentHitObject = new List<GameObject>();

	public Vector3 center;

	public float radiys;

	public float currectenDistans = 1f;


public float PlaceX;
public float PlaceZ;

private void awake(){
	
}

	private void Start()
	{
		FireSkill  =  PlayerPrefs.GetFloat ("FireSkill");
	FireBigSkill = PlayerPrefs.GetFloat("FireBigSkill");
		fireBigBollShop = PlayerPrefs.GetInt("fireBigBollShop");
		SpeedSkill	=  PlayerPrefs.GetFloat("SpeedSkill");
         SpeeDShop =  PlayerPrefs.GetInt("SpeeDShop");
	TeleportSkill = PlayerPrefs.GetFloat("TeleportSkill");
	TeleportDistans = PlayerPrefs.GetFloat("TeleportDistans");
	Dead = PlayerPrefs.GetInt("dead");
   Counte = PlayerPrefs.GetInt ("Kill");
   Money = PlayerPrefs.GetInt ("Money");
   
    // PlaceX = UnityEngine.Random.Range(-94,45);
	//  PlaceZ = UnityEngine.Random.Range(105,-30);
   //this.transform.position = new Vector3(PlaceX,1,PlaceZ);
	//	GemeOvers.SetActive(false);
		this.Player123 = base.GetComponent<Rigidbody>();
		this.anim = base.GetComponent<Animator>();
		this.Skill = 0;
	}

public void FireBoll()
	{
		
			this.Skill = 1;
		this.anim.SetInteger("state", 0);
	}
	public void FireBIG()
	{
		
			this.Skill = 4;
		this.anim.SetInteger("state", 0);
	}

	public void Speedfast()
	{
		
			this.Skill = 5;
this.timeuUpdate = 5;
		this.anim.SetInteger("state", 0);
	}

	public void Teleport()
	{
		
		this.Skill = 2;
			this.anim.SetInteger("state", 0);
	}

	public void AUE()
	{
		this.Skill = 3;
		this.timeuUpdate = 5;
		this.anim.SetInteger("state", 3);
			this.Mass.interactable = false;
	}

	private void SpeedBool(){
		if(timerBoolspeed == false){
			MoveSpeed = MoveSpeed - 30;
			timerBoolspeed = true;
			timerSpeed =0;
		}
	}

	private void FixedUpdate()
	{
		this.ch_controller = base.GetComponent<CharacterController>();
		this.FindDirection();
	}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	private void Update()
	{
		PlayerPrefs.SetFloat("FireBigSkill",FireBigSkill);
PlayerPrefs.SetInt("fireBigBollShop",fireBigBollShop);
	PlayerPrefs.SetFloat("SpeedSkill",SpeedSkill);
PlayerPrefs.SetInt("SpeeDShop",SpeeDShop);
		PlayerPrefs.SetFloat("TeleportSkill",TeleportSkill);
	 PlayerPrefs.SetFloat("TeleportDistans",TeleportDistans);
		 PlayerPrefs.SetFloat ("FireSkill",FireSkill);
      PlayerPrefs.SetInt ("Money",Money);
	//PlayerPrefs.GetInt("Money");
	MoneyText.text = Money.ToString();
	CounteText.text = Counte.ToString();
	DeaDText.text = Dead.ToString();
	PlayerPrefs.SetInt ("Kill",Counte);
//покупки
if(fireBigBollShop == 1){
		FireBigBoll1.SetActive(true);
	}
	else{
		FireBigBoll1.SetActive(false);
	}
	if(SpeeDShop == 1){
		SpeedButtonSpawn.SetActive(true);
	}
	else{
		SpeedButtonSpawn.SetActive(false);
	}




//таймер скорости
if( timerSpeed > 0){
	timerSpeed -=Time.deltaTime;
	timerBoolspeed = true;}
if(timerSpeed <0){
	timerBoolspeed = false;
SpeedBool();
	
}
 

 
 
if(Skill == 1){
	FireOBOD.SetActive(true);
}
else
{
	FireOBOD.SetActive(false);
}
if(Skill == 2){
	TeleportOBOD.SetActive(true);
}
else
{
	TeleportOBOD.SetActive(false);
}if(Skill == 3){
	AUEOBOD.SetActive(true);
}
else
{
	AUEOBOD.SetActive(false);
}if(Skill == 4){
	FireOBODBig.SetActive(true);
}
else
{
	FireOBODBig.SetActive(false);
}
if(Skill == 5){
	SpeedOBOD.SetActive(true);
}
else
{
	SpeedOBOD.SetActive(false);
}





		fsdfsdf.text = Skill.ToString();
		TimeuupdateINT = Mathf.RoundToInt(timeuUpdate);

		//skill BAr
		AUEKD.fillAmount = MassKD / 4;
		AUETEXT.text = MassKD.ToString ("0");
		if(MassKD <=0){
        AUETEXT.text = "";
		}
		TeleportKDimage.fillAmount = TeleportKD / TeleportSkill;
		teleportTEXT.text = TeleportKD.ToString ("0");
		if(TeleportKD <=0){
        teleportTEXT.text = "";
		}
		FireKDImage.fillAmount = FireKD / FireSkill;
		FireTEXT.text = FireKD.ToString ("0");
		if(FireKD <=0){
        FireTEXT.text = "";
		}
		
FireKDImageBig.fillAmount = FireBigKD / FireBigSkill;
		FireTEXTBig.text = FireBigKD.ToString ("0");
		if(FireBigKD <=0){
        FireTEXTBig.text = "";}

		SpeedKDImage.fillAmount = SpeedKd / SpeedSkill;
		SpeedTEXT.text = SpeedKd.ToString ("0");
		if(SpeedKd <=0){
        SpeedTEXT.text = "";}
       


		if(Heals<=0){
		
			CameraDeal.SetActive(false);
             CameraKill.SetActive(true);
			 canvesPlayer.SetActive(false);
			 this.transform.position = new Vector3(100,100,100);
			Dead +=1;
			PlayerPrefs.SetInt("deal",Dead);
			DeaDText.text = Dead.ToString();
			//GemeOvers.SetActive(true);
			GetComponent<BoxCollider>().enabled = false;
			
			gameObject.SetActive(false);
			
			
		

		}
		if(Heals<100 & Heals <= 0){
		Heals +=  Time.deltaTime / 2;}

//жизни бар
		HPme.fillAmount = Heals/100;
		HpText.text = "" + Heals.ToString();
	//text = time.ToString("00");
	//	sliderHP.value = Heals;
	
		if (this.MassKD > 0f || Skill == 3)
		{
			this.Mass.interactable = false;
		}
		else
		{
			this.Mass.interactable = true;
		}
		if (Player.FireKD > 0f )
		{
			this.FireBoll1.interactable = false;
		}
		else
		{
		this.FireBoll1.interactable = true;
		}
		if (FireBigKD > 0f )
		{
			this.FireBigBoll.interactable = false;
		}
		else
		{
		this.FireBigBoll.interactable = true;
		}
		if (this.TeleportKD > 0f )
		{
			this.Teleport1.interactable = false;
		}
		else
		{
			this.Teleport1.interactable = true;
		}
		if (SpeedKd > 0f )
		{
			this.SpeedButton.interactable = false;
		}
		else
		{
		this.SpeedButton.interactable = true;
		}



		this.gameGravity();
		this.gun();
		if ((this.timeuUpdate < 4 & this.Skill == 1) || (this.timeuUpdate < 4 & this.Skill == 2) || (this.Skill == 3 & this.timeuUpdate < 3) || this.Skill == 0||this.timeuUpdate < 4 & this.Skill == 4|| Skill ==5)
		{
Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);
	Vector3 vector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * this.MoveSpeed;
			vector = Vector3.ClampMagnitude(vector, this.MoveSpeed);
        if (moveVector != Vector3.zero)
        {
			
            transform.rotation = Quaternion.LookRotation(moveVector);
            transform.Translate(moveVector * MoveSpeed * Time.deltaTime, Space.World);
			this.anim.SetInteger("state", 1);
        }   
			else if (vector.x != 0f || vector.z != 0f)
			{
				this.anim.SetInteger("state", 1);
			}
			else
			{
				this.anim.SetInteger("state", 0);
			}
			if (vector != Vector3.zero)
			{
				this.Player123.MovePosition(base.transform.position + vector * Time.deltaTime);
				this.Player123.MoveRotation(Quaternion.LookRotation(vector));
			}
		}
		this.moveVector.y = this.gravityForce;
	
	}

	private void gameGravity()
	{
		if (!this.ch_controller.isGrounded)
		{
			this.gravityForce -= 20f * Time.deltaTime;
		}
		else
		{
			this.gravityForce = -1f;
		}
	}

	private void FindDirection()
	{
		
		if (this.MassKD > 0f)
		{
			this.MassKD -= Time.deltaTime;
		}
		if (Player.FireKD > 0f)
		{
			Player.FireKD -= Time.deltaTime;
		}
		if (FireBigKD > 0f)
		{
			FireBigKD -= Time.deltaTime;
		}
		if (this.TeleportKD > 0f)
		{
			this.TeleportKD -= Time.deltaTime;
		}
		if (this.SpeedKd > 0f)
		{
			this.SpeedKd-= Time.deltaTime;
		}
		if (this.timeuUpdate > 0)
		{
			this.timeuUpdate -= Time.deltaTime;

		//	timeuUpdate -= Time.deltaTime ; 

		}
		
	if (!EventSystem.current.IsPointerOverGameObject()){
		if(joystick.Horizontal != 0 & joystick.Vertical != 0){
	if (Input.GetMouseButton(0) & this.Skill == 1  &!EventSystem.current.IsPointerOverGameObject()|| Input.GetMouseButton(0) & this.Skill == 2 & this.timeuUpdate ==0|| Input.GetMouseButton(0) & this.Skill == 3 & this.timeuUpdate ==0||Input.GetMouseButton(0) & this.Skill == 4  &!EventSystem.current.IsPointerOverGameObject()||Input.GetMouseButton(0) & Skill==5)
	//	if (Input.touchCount==2 & this.Skill == 1 || Input.touchCount>1 & this.Skill == 2 & this.timeuUpdate ==0|| Input.touchCount>1 & this.Skill == 3 & this.timeuUpdate ==0||Input.touchCount>1 & Skill ==0 & this.timeuUpdate ==0)
		{
			if (this.Skill == 1|| Skill == 4)
			{
				this.anim.SetInteger("state", 2);
			}
			if (this.Skill == 2)
			{
				this.anim.SetInteger("state", 0);
			}
			
			//		this.ray = Camera.main.ScreenPointToRay(Input.touches[1].position);
		
	
		
			this.ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(this.ray, out this.hit, 100f))
			{
				this.target = this.hit.point;
			}
			Vector3 vector = this.target - base.transform.position;
			vector = new Vector3(vector.x, 0f, vector.z);
			if (vector != Vector3.zero)
			{
				base.transform.forward = vector;
			}
			this.timeuUpdate = 5;
			this.TimeuupdateINT = 5;
		
		}
		}
		if(joystick.Horizontal == 0 & joystick.Vertical == 0 ){
			
			if (Input.GetMouseButton(0) & this.Skill == 1  || Input.GetMouseButton(0) & this.Skill == 2 & this.timeuUpdate ==0|| Input.GetMouseButton(0) & this.Skill == 3 & this.timeuUpdate ==0||Input.GetMouseButton(0) & this.Skill == 4 ||Input.GetMouseButton(0) & Skill ==5 )
		{
			if (this.Skill == 1|| Skill ==4)
			{
				this.anim.SetInteger("state", 2);
			}
			if (this.Skill == 2)
			{
				this.anim.SetInteger("state", 0);
			}
			
			//	this.ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
		
	
		
			this.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	
			if (Physics.Raycast(this.ray, out this.hit, 100f))
			{
				this.target = this.hit.point;
			}
			Vector3 vector = this.target - base.transform.position;
			vector = new Vector3(vector.x, 0f, vector.z);
			if (vector != Vector3.zero)
			{
				base.transform.forward = vector;
			}
			this.timeuUpdate = 5;
			this.TimeuupdateINT = 5;
		
		}
		}
		}}


	private void gun()
	{

		if (this.TimeuupdateINT == 5 & this.Skill == 5 & SpeedKd <= 0f)
		{
Debug.Log("скорость");

			SpeedKd = this.SpeedSkill;
			timerSpeed = 5;
			MoveSpeed = MoveSpeed + 30;
			Skill = 0;
			

		}
//бигфаербол
		if (this.TimeuupdateINT == 4 & this.Skill == 4 & FireBigKD <= 0f)
		{
			
			Vector3 position = this.startPosBigFire.transform.position;
			Quaternion rotation = this.startPosBigFire.transform.rotation;
			GameObject bull = UnityEngine.Object.Instantiate<GameObject>(BulletBig, position, rotation);
			Rigidbody component = bull.GetComponent<Rigidbody>();
			component.AddForce(bull.transform.forward * 20f, ForceMode.Impulse);
		    
			//UnityEngine.Object.Destroy(gameObject, 10f);
			this.TimeuupdateINT = 4;
			FireBigKD = this.FireBigSkill;
			this.Skill = 0;
			this.timeuUpdate = 0;
		}


//фаерболт
		if (this.TimeuupdateINT == 4 & this.Skill == 1 & Player.FireKD <= 0f)
		{
			Debug.Log("bax");
			Vector3 position = this.startPos.transform.position;
			Quaternion rotation = this.startPos.transform.rotation;
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Bullet, position, rotation);
			Rigidbody component = gameObject.GetComponent<Rigidbody>();
			gameObject.GetComponent<Bullet>().name123 = this.gameObject;
			component.AddForce(gameObject.transform.forward * 50f, ForceMode.Impulse);
			UnityEngine.Object.Destroy(gameObject, 2f);
        

			this.TimeuupdateINT = 4;
			Player.FireKD = this.FireSkill;
			this.Skill = 0;
			this.timeuUpdate = 0;
		}
//телепорт		
		if (this.TimeuupdateINT == 4 & this.Skill == 2 & this.TeleportKD <= 0f)
		{
			this.TeleportKD = this.TeleportSkill;
			if (Vector3.Distance(base.transform.position, this.target) >= this.TeleportDistans)
			{
				base.transform.position += base.transform.forward * this.TeleportDistans;
				GameObject obj = UnityEngine.Object.Instantiate<GameObject>(TeleportEffect, this.transform);
				UnityEngine.Object.Destroy(obj, 1f);
				this.Skill = 0;
				this.timeuUpdate = 0;
			}
			else
			{
				GameObject obj = UnityEngine.Object.Instantiate<GameObject>(TeleportEffect, this.transform);
				UnityEngine.Object.Destroy(obj, 1f);
				base.transform.position = this.hit.point;
				this.Skill = 0;
				this.timeuUpdate = 0;
			}
		}
//массскилл		
		if (this.Skill == 3 & this.MassKD <= 0f & this.TimeuupdateINT == 5)
		{
			this.anim.SetInteger("state", 3);
		}
		if (this.Skill == 3 & this.MassKD <= 0f & this.TimeuupdateINT == 3)
		{
GameObject MassEffectDel =  Instantiate(MassEffect,transform);
      Destroy(MassEffectDel,1.5f);
        currentHitObject.Clear();
RaycastHit[] hits = Physics.SphereCastAll(transform.position,MassDistans,transform.position);
Heals = Heals -1;
foreach(RaycastHit hit in hits){
    currentHitObject.Add(hit.transform.gameObject);
     Vector3 bot1 = (hit.transform.position - transform.position).normalized;
 if (hit.rigidbody & hit.transform != transform & Vector3.Distance(transform.position,hit.transform.position)<=MassDistans){
	    
          hit.rigidbody.AddForce(bot1* 25f, ForceMode.Impulse);
		  
		  }
/* 
			GameObject obj2 = UnityEngine.Object.Instantiate<GameObject>(this.MassEffect, base.transform);
			UnityEngine.Object.Destroy(obj2, 1.5f);
			this.currentHitObject.Clear();
			RaycastHit[] array = Physics.SphereCastAll(base.transform.position, this.MassDistans, base.transform.position);
			RaycastHit[] array2 = array;
			Heals = Heals -8;
			for (int i = 0; i < array2.Length; i++)
			{
				RaycastHit raycastHit = array2[i];
				this.currentHitObject.Add(raycastHit.transform.gameObject);
				Vector3 normalized = (raycastHit.transform.position - this.transform.position).normalized;
				if (raycastHit.rigidbody & raycastHit.transform != this.transform)
				{
					raycastHit.rigidbody.AddForce(normalized * 30f, ForceMode.Impulse);
				}*/
				this.Skill = 0;
				this.MassKD = this.MassSkill;
				
				this.timeuUpdate = 0;
				
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Debug.DrawLine(base.transform.position, base.transform.position * this.currectenDistans);
		Gizmos.DrawWireSphere(base.transform.position, this.MassDistans);
	}

	


		void OnTriggerStay(Collider other) { 

						    
         if(other.tag == "Lawa") {  
			 
	Heals = Heals - 4 * Time.deltaTime;  
	 lawaEffect.SetActive(true);
}

	
}
 void OnTriggerExit(Collider other){
    if(other.tag == "Lawa"){
lawaEffect.SetActive(false);
MoveSpeed =  MoveSpeed - 15;
	}
 }



void OnTriggerEnter(Collider other) { 
	 if(other.tag == "Lawa"){
	lawaEffect.SetActive(true);
		MoveSpeed = MoveSpeed + 15; }	                   
}           

 public void GameoVer(){
	// Application.LoadLevel(0);
	  SceneManager.LoadScene(2);
	 
 }


	
}
