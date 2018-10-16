using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	public float slowness = 10f;
	public Image panelImage;
	public GameObject panelRestart,GAMEMANAGER,panelShop;
	public Image[] heart;

	public void endGame(){
		StartCoroutine (restartLevel ());
	}
	IEnumerator restartLevel(){
		Time.timeScale = 1f / slowness;
		Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

		yield return new WaitForSeconds (2f/slowness);
		Time.timeScale = 1f;
		Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
		panelRestart.SetActive (true);
		panelImage.CrossFadeAlpha (1.0f, 2f, false);
		yield return new WaitForSeconds (1f);
		GAMEMANAGER.SetActive (false);
	}
	public void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
	public void Quit(){
		//PlayerPrefs.DeleteAll ();
		Application.Quit ();
	}

	public void minusLife(int lives){
		if(lives >=0 && lives <=3)
			heart [lives].CrossFadeAlpha (0f, 1f, true);
	}
	public void addLife(int lives){
		if(lives < 3)
			heart [lives].CrossFadeAlpha (1f, 1f, false);
	}
}
