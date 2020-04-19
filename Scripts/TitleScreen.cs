using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
	public VariableInt level;
	public VariableInt memeory;

	public AudioSource buttonClick;
	public AudioMixer music;
	public AudioMixer sfx;
	public bool optionsMenuVisable;
	public bool instructionsVisable;
	public GameObject optionsPanel;
	public GameObject instructionsPanel;

	public void StartGame()
	{
		level.number = 0;
		memeory.number = 0;
		buttonClick.Play();

		//PullPush.level = level;
		//PullPush.memory = memeory;
		SceneManager.LoadScene(3);
	}

	public void OptionsMenu()
	{
		buttonClick.Play();
		optionsMenuVisable = !optionsMenuVisable;

		if (optionsMenuVisable == true)
		{
			optionsPanel.gameObject.SetActive(true);
		} else
		{
			optionsPanel.gameObject.SetActive(false);
		}
	}

	public void InstructionsMenu()
	{
		buttonClick.Play();

		instructionsVisable = !instructionsVisable;

		if (instructionsVisable == true)
		{
			instructionsPanel.gameObject.SetActive(true);
		}
		else
		{
			instructionsPanel.gameObject.SetActive(false);
		}
	}

	public void SetVolumeMusic(float mVolume)
	{
		music.SetFloat("MusicVolume", mVolume);
	}

	public void SetVolumeSFX(float sfxVolume)
	{
		sfx.SetFloat("SFXVolume", sfxVolume);
	}

	public void sfxTestButton()
	{
		buttonClick.Play();
	}
}
