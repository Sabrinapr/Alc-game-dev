﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static int Score;
	
	Text ScoeText;

	//use this for initialization
	void Start () {
		ScoreText = GetComponent<Text>();

		Score = 0;
	}

	// Update is called once per frame
	void Update () {
		if (Score < 0)
			Score = 0;
		ScoreText.text = " " + Score;
	}