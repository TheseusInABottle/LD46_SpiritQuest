using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
	public VariableInt playerSelection;
	public UniversalInformation playerCharacter;
	public AudioSource buttonSFX;

	public void Sage()
	{
		buttonSFX.Play();
		playerSelection.number = 0;
		PullPush.playerCharacter = playerSelection;
		PullPush.player = playerCharacter.entitys[0];
		PullPush.player.startAttack = 10;
		PullPush.player.startDefence = 5;
		PullPush.player.startBoost = 1;
		SceneManager.LoadScene(1);
	}

	public void Hero()
	{
		buttonSFX.Play();
		playerSelection.number = 1;
		PullPush.playerCharacter = playerSelection;
		PullPush.player = playerCharacter.entitys[1];
		PullPush.player.startAttack = 10;
		PullPush.player.startDefence = 5;
		PullPush.player.startBoost = 1;
		SceneManager.LoadScene(1);
	}

	public void Lady()
	{
		buttonSFX.Play();
		playerSelection.number = 2;
		PullPush.playerCharacter = playerSelection;
		PullPush.player = playerCharacter.entitys[2];
		PullPush.player.startAttack = 10;
		PullPush.player.startDefence = 5;
		PullPush.player.startBoost = 1;
		SceneManager.LoadScene(1);
	}

	public void ButtonSound()
	{

	}
}
