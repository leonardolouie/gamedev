using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loader : MonoBehaviour {

	private void Start(){
		Application.targetFrameRate = 60;
	}
	public void loadLevel(){
		SceneManager.LoadScene (1);
	}
	public void quit(){
		Application.Quit ();
	}
}
