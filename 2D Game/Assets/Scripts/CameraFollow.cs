using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public CharacterMove Player;

	public bool isFollowing;


	// Camera position offset
	public float xOffset;
	public float yOffset;

	// Use this for initialization
	void Start () {
		Player = FindObjectOfType<CharacterMove>();

		isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(isFollowing){
			transform.position = new Vector3(Player.transform.position.x + xOffset, Player.transform.position.y + yOffset, transform.position.z);
		}
	}
}