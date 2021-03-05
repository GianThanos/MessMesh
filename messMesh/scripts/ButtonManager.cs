using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(2);
	}

	public void ExitApp()
    {
		Application.Quit();
	}

	public void ToGame(string sceneName)
	{
		SceneManager.LoadScene(1);
	}

	public void ToStart(string sceneName)
	{
		SceneManager.LoadScene(0);
	}
}
