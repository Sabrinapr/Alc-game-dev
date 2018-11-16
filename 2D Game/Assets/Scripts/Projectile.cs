using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float Speed;
	public float TimeOut;
	public GameObject PC;
	public GameObject EnemyDeath;
	public GameObject ProjectileParticle;
	public int PointsForKill;

	// Use this for initialization
	void Start () {
		PC = GameObject.Find("PC");
		EnemyDeath = Resources.Load("Prefabs/DeathPS") as GameObject;
		ProjectileParticle = Resources.Load("Prefabs/RespawnPS") as GameObject;
		if(PC.transform.localScale.x < 0)
			Speed = -Speed;	
			//Destroys projectile after x seconds
			Destroy(gameObject,TimeOut);	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Enemy"){
			Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			ScoreManager.AddPoints (PointsForKill);
		}
		Destroy (gameObject);
	}
		void OnCollisionEnter2D(Collision2D other)
	{
		Instantiate(ProjectileParticle, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}