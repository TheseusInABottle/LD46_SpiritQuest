using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
	[SerializeField] private CombatController enemysSet;
	[SerializeField] private VariableInt level;
	[SerializeField] private VariableInt stage;

	public Button[] btns;
	public AudioSource buttonsound;

	private void Start()
	{
		switch (stage.number)
		{
			case 0:
				btns[1].interactable = false;
				btns[2].interactable = false;
				btns[3].interactable = false;
				btns[4].interactable = false;
				btns[5].interactable = false;
				btns[6].interactable = false;
				btns[7].interactable = false;
				btns[8].interactable = false;
				btns[9].interactable = false;
				btns[10].interactable = false;
				btns[11].interactable = false;
				break;

			case 1:
				btns[0].interactable = false;
				btns[3].interactable = false;
				btns[4].interactable = false;
				btns[5].interactable = false;
				btns[6].interactable = false;
				btns[7].interactable = false;
				btns[8].interactable = false;
				btns[9].interactable = false;
				btns[10].interactable = false;
				btns[11].interactable = false;
				break;

			case 2:
				btns[0].interactable = false;
				btns[1].interactable = false;
				btns[2].interactable = false;
				btns[4].interactable = false;
				btns[5].interactable = false;
				btns[6].interactable = false;
				btns[7].interactable = false;
				btns[8].interactable = false;
				btns[9].interactable = false;
				btns[10].interactable = false;
				btns[11].interactable = false;
				break;

			case 3:
				btns[0].interactable = false;
				btns[1].interactable = false;
				btns[2].interactable = false;
				btns[4].interactable = false;
				btns[5].interactable = false;
				btns[6].interactable = false;
				btns[7].interactable = false;
				btns[8].interactable = false;
				btns[9].interactable = false;
				btns[10].interactable = false;
				btns[11].interactable = false;
				break;

			case 4:
				btns[0].interactable = false;
				btns[1].interactable = false;
				btns[2].interactable = false;
				btns[3].interactable = false;
				btns[6].interactable = false;
				btns[7].interactable = false;
				btns[8].interactable = false;
				btns[9].interactable = false;
				btns[10].interactable = false;
				btns[11].interactable = false;
				break;

			case 5:
				btns[0].interactable = false;
				btns[1].interactable = false;
				btns[2].interactable = false;
				btns[3].interactable = false;
				btns[4].interactable = false;
				btns[5].interactable = false;
				btns[8].interactable = false;
				btns[9].interactable = false;
				btns[10].interactable = false;
				btns[11].interactable = false;
				break;

			case 6:
				btns[0].interactable = false;
				btns[1].interactable = false;
				btns[2].interactable = false;
				btns[3].interactable = false;
				btns[4].interactable = false;
				btns[5].interactable = false;
				btns[6].interactable = false;
				btns[9].interactable = false;
				btns[10].interactable = false;
				btns[11].interactable = false;
				break;

			case 7:
				btns[0].interactable = false;
				btns[1].interactable = false;
				btns[2].interactable = false;
				btns[3].interactable = false;
				btns[4].interactable = false;
				btns[5].interactable = false;
				btns[6].interactable = false;
				btns[7].interactable = false;
				btns[8].interactable = false;
				btns[10].interactable = false;
				btns[11].interactable = false;
				break;

			case 8:
				btns[0].interactable = false;
				btns[1].interactable = false;
				btns[2].interactable = false;
				btns[3].interactable = false;
				btns[4].interactable = false;
				btns[5].interactable = false;
				btns[6].interactable = false;
				btns[7].interactable = false;
				btns[8].interactable = false;
				btns[11].interactable = false;
				break;

			case 9:
				btns[0].interactable = false;
				btns[1].interactable = false;
				btns[2].interactable = false;
				btns[3].interactable = false;
				btns[4].interactable = false;
				btns[5].interactable = false;
				btns[6].interactable = false;
				btns[7].interactable = false;
				btns[8].interactable = false;
				btns[9].interactable = false;
				btns[11].interactable = false;
				break;

			case 10:
				btns[0].interactable = false;
				btns[1].interactable = false;
				btns[2].interactable = false;
				btns[3].interactable = false;
				btns[4].interactable = false;
				btns[5].interactable = false;
				btns[6].interactable = false;
				btns[7].interactable = false;
				btns[8].interactable = false;
				btns[9].interactable = false;
				btns[10].interactable = false;
				break;

			case 11:
				btns[0].interactable = false;
				btns[1].interactable = false;
				btns[2].interactable = false;
				btns[3].interactable = false;
				btns[4].interactable = false;
				btns[5].interactable = false;
				btns[6].interactable = false;
				btns[7].interactable = false;
				btns[8].interactable = false;
				btns[9].interactable = false;
				btns[10].interactable = false;
				break;
		}
	}

	public void ABtn()
	{
		btns[0].interactable = false;
		level.number = 0;
		PullPush.level = level;
		stage.number = 1;
		PullPush.memory = stage;
		buttonsound.Play();
		SceneManager.LoadScene(2);
	}

	public void BBtn()
	{
		btns[1].interactable = false;
		btns[2].interactable = false;
		level.number = 1;
		PullPush.level = level;
		stage.number = 2;
		PullPush.memory = stage;
		buttonsound.Play();
		SceneManager.LoadScene(2);
	}

	public void CBtn()
	{
		btns[2].interactable = false;
		btns[1].interactable = false;
		level.number = 2;
		PullPush.level = level;
		stage.number = 3;
		PullPush.memory = stage;
		buttonsound.Play();
		SceneManager.LoadScene(2);
	}

	public void DBtn()
	{
		btns[3].interactable = false;
		level.number = 3;
		PullPush.level = level;
		stage.number = 4;
		PullPush.memory = stage;
		buttonsound.Play();
		SceneManager.LoadScene(2);
	}

	public void EBtn()
	{
		btns[4].interactable = false;
		btns[5].interactable = false;
		level.number = 4;
		PullPush.level = level;
		stage.number = 5;
		PullPush.memory = stage;
		buttonsound.Play();
		SceneManager.LoadScene(2);
	}

	public void FBtn()
	{
		btns[5].interactable = false;
		btns[4].interactable = false;
		level.number = 5;
		PullPush.level = level;
		stage.number = 6;
		PullPush.memory = stage;
		buttonsound.Play();
		SceneManager.LoadScene(2);
	}

	public void GBtn()
	{
		btns[6].interactable = false;
		btns[7].interactable = false;
		btns[8].interactable = false;
		level.number = 6;
		PullPush.level = level;
		stage.number = 7;
		PullPush.memory = stage;
		buttonsound.Play();
		SceneManager.LoadScene(2);
	}

	public void HBtn()
	{
		btns[7].interactable = false;
		btns[6].interactable = false;
		btns[8].interactable = false;
		level.number = 7;
		PullPush.level = level;
		stage.number = 8;
		PullPush.memory = stage;
		buttonsound.Play();
		SceneManager.LoadScene(2);
	}

	public void IBtn()
	{
		btns[8].interactable = false;
		btns[7].interactable = false;
		btns[6].interactable = false;
		level.number = 8;
		PullPush.level = level;
		stage.number = 9;
		PullPush.memory = stage;
		buttonsound.Play();
		SceneManager.LoadScene(2);
	}

	public void JBtn()
	{
		btns[9].interactable = false;
		btns[10].interactable = false;
		level.number = 9;
		PullPush.level = level;
		stage.number = 10;
		PullPush.memory = stage;
		buttonsound.Play();
		SceneManager.LoadScene(2);
	}

	public void KBtn()
	{
		btns[10].interactable = false;
		btns[9].interactable = false;
		level.number = 10;
		PullPush.level = level;
		stage.number = 11;
		buttonsound.Play();
		PullPush.memory = stage;
		SceneManager.LoadScene(2);
	}

	public void LBtn()
	{
		btns[11].interactable = false;
		level.number = 11;
		PullPush.level = level;
		PullPush.memory = stage;
		buttonsound.Play();
		SceneManager.LoadScene(2);
	}
}
