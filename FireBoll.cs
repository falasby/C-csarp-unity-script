using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBoll : MonoBehaviour {
public float speed;
public float stoppingDistance;
public GameObject startPos;

public float retreatDistance;

public float AttackFire;

public GameObject Bulletbot;

	public Slider sliderHPEnemy;

public int Counte;
public Transform Vrag;


public GameObject[] enemy;//
public GameObject closets;//
public string nearest;//

Animator anim;

public float waitTime;
public float startWaitTime;
public Transform[] moveSpots;
private int randomSpot;
public Transform target;

public float Heals;
public GameObject effectKill;


public int Skill;
//телепорт
public float TeleportKD ;
public float TeleportSkill = 7;
public float TeleportDistans;

//фаерболт
public float FireKD ;
public float FireSkill = 7;
//ауескил
public float TimerMass;
public float TimerMassKD;
public float MassKD ;
public float MassSkill = 7;
public float MassDistans;
public bool MassStart;


//эффекты
public GameObject MassEffect;
public GameObject TeleportEffect;
public GameObject lawaEffect;

public List<GameObject> currentHitObject = new List<GameObject>();//
public Vector3 center;
public float radiys;
public float currectenDistans =1;
public float PlaceX;
public float PlaceZ;
public GameObject[] spawnPoints;
	// Use this for initialization
	void Start () {

		
		// PlaceX = UnityEngine.Random.Range(-94,45);
	//  PlaceZ = UnityEngine.Random.Range(105,-30);
  // this.transform.position = new Vector3(PlaceX,1,PlaceZ);
	anim = GetComponent<Animator>();
	 enemy = GameObject.FindGameObjectsWithTag("Player");
		FireKD = 0;
		waitTime = startWaitTime;
		randomSpot = Random.Range(0,moveSpots.Length);
	}

	
	

		
	

	// Update is called once per frame
	GameObject FindClosestEnemy(){
float distance = Mathf.Infinity;
Vector3 position = transform.position;

foreach(GameObject go in enemy){
	if(go != null){
	Vector3 diff = go.transform.position - position;
	
	float curDistance = diff.sqrMagnitude;
	if(go!=this.gameObject && curDistance<distance ){
	Vector3	enemytransform = go.transform.position;
		closets = go;
		distance = curDistance;
	}
	}

}
  return closets;
	}
	

	void Update () {
 
		
		if(Heals<=0){
			  
	Destroy(gameObject);
		}
			if(Heals<100){
		Heals +=  Time.deltaTime / 2;}
sliderHPEnemy.value = Heals/100;
sliderHPEnemy.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
	//	sliderHPEnemy.value = Heals / 100;
    nearest=FindClosestEnemy().name;  //таргет и имя обьекта
   Vector3 bot = closets.transform.position ;

		if(FireKD>0){
			FireKD -=Time.deltaTime;
		}
		if(TeleportKD>0){
           TeleportKD -= Time.deltaTime;
        }
		if(MassKD>0){
           MassKD -= Time.deltaTime;
        }
		if(TimerMass>0){
		//	TimerMass -=Time.deltaTime;
		}
		if(MassStart == true){
			TimerMass -= Time.deltaTime;
		}
//масс скилл.............
if ( MassKD <= 0 & Vector3.Distance(transform.position,bot)<=MassDistans){
anim.SetInteger("state", 3);
MassStart = true;
}
  if ( MassKD <= 0 & TimerMass <= 0){
GameObject MassEffectDel =  Instantiate(MassEffect,transform);
      Destroy(MassEffectDel,1.5f);
        currentHitObject.Clear();
RaycastHit[] hits = Physics.SphereCastAll(transform.position,MassDistans,this.transform.position);
Heals = Heals -1;
foreach(RaycastHit hit in hits){
    currentHitObject.Add(hit.transform.gameObject);
     Vector3 bot1 = (hit.transform.position - transform.position).normalized;
 if (hit.rigidbody & hit.transform != transform & Vector3.Distance(transform.position,hit.transform.position)<=MassDistans)
          hit.rigidbody.AddForce(bot1* 25f, ForceMode.Impulse);
		  
 // hit.rigidbody.AddForce(h * 20f);
  // hit.AddForce(ray.direction * 5);
   // currectenDistans = hit.distance;
}
 MassKD = MassSkill;
          Skill = 1;
		  TimerMass = 1.1f;
		  Debug.Log("массс");
		  MassStart = false;
}


		if(Vector3.Distance(transform.position,bot)<=stoppingDistance & FireKD <=0 ||Vector3.Distance(transform.position,bot)<=TeleportDistans & TeleportKD <=0 || MassStart == true){
 AttackFire -= Time.deltaTime;
 	
//движение к цели и поворот!

		if(Vector3.Distance(transform.position,bot)>stoppingDistance){
			 // anim.SetInteger("state", 2);
		//	transform.position = Vector3.MoveTowards(transform.position,player1.position,speed * Time.deltaTime);
			Vector3 Rotation = bot - Vrag.position;
			 Vrag.rotation = Quaternion.Slerp(Vrag.rotation,Quaternion.LookRotation(Rotation),speed);
			 }
		
			else if (Vector3.Distance(transform.position,bot)<stoppingDistance && Vector3.Distance(transform.position,bot)>retreatDistance & FireKD<=0)
			{	  anim.SetInteger("state", 2);
				Vector3 Rotation = bot - Vrag.position;
			 Vrag.rotation = Quaternion.Slerp(Vrag.rotation,Quaternion.LookRotation(Rotation),speed);
				transform.position = this.transform.position;}
	
	 	if (FireKD<= 0 & AttackFire <4.5){
			 anim.SetInteger("state", 2);
		Vector3 SpawnPoint = startPos.transform.position;
        //создание угол поворота для старта снаряда
        Quaternion SpawnRoot = startPos.transform.rotation; 
        // создать снаряд
        GameObject pula_for_faer = Instantiate(Bulletbot,SpawnPoint,SpawnRoot);
//получение компонента у пули
pula_for_faer.GetComponent<Bullet>().name123 = this.gameObject;
        Rigidbody Run = pula_for_faer.GetComponent<Rigidbody>();
        //придаем скорость снаряду
        Run.AddForce(pula_for_faer.transform.forward * 50,ForceMode.Impulse);
        //удаление пули через 100 сек
        Destroy(pula_for_faer,4);
		// this.transform.parent = Bulletbot.transform; 
    
	
		
		

		FireKD = FireSkill;
	//	Debug.Log(this.transform.parent);
		AttackFire = 5;
		// pula_for_faer.transform.parent = this.transform; 
		// pula_for_faer.transform.SetParent (this.transform, true);
	//pula_for_faer.transform.parent = this.transform;
	//pula_for_faer.GetComponent<Bullet>.
	//	 Debug.Log ("«Родитель игрока:" + pula_for_faer.transform.parent.name);
		}


//телепорт

		if( TeleportKD <=0 & FireKD >=0){
        if( Vector3.Distance(transform.position,bot)<=TeleportDistans ){
			
transform.position = bot*1.2f;

    TeleportKD = TeleportSkill;
	 GameObject TeleportDel =  Instantiate(TeleportEffect,transform);
      Destroy(TeleportDel,1);
       }   
	}
			else {
FireKD -=Time.deltaTime;
			}
	
		}
		else
		//движение по точкам спавна!
		{	
			 anim.SetInteger("state", 1);
			transform.position = Vector3.MoveTowards(transform.position,moveSpots[randomSpot].position,speed * Time.deltaTime);
		Vector3 Rotation = moveSpots[randomSpot].position - Vrag.position;
			 Vrag.rotation = Quaternion.Slerp(Vrag.rotation,Quaternion.LookRotation(Rotation),speed*Time.deltaTime);
if(Vector3.Distance(transform.position,moveSpots[randomSpot].position)<0.2f){
if(waitTime<= 0){
	randomSpot = Random.Range(0,moveSpots.Length);
waitTime = startWaitTime;
}else
{
	waitTime -= Time.deltaTime;
}
}
			
		}}
		void OnTriggerStay(Collider other) { 
			                
         if(other.tag == "Lawa") {   
			
		

	Heals = Heals - 1 * Time.deltaTime;  
	 lawaEffect.SetActive(true);
}

	
}
 void OnTriggerExit(Collider other){
    
lawaEffect.SetActive(false);


 }
void OnTriggerEnter(Collider other) { 
			if(other.tag == "Bullet") {   
	Heals = Heals - 7;          

}
if(other.tag =="Lawa"){
	
	randomSpot = 13;
}           
}



		}
	

