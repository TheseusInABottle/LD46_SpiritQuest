using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CombatController : MonoBehaviour
{

	private enum battleState { playerTurn, enemyTurn, playerDefeat, enemyDefeat, talking, gameend }
	private battleState battle;
	[SerializeField] private UniversalInformation Foes;
	[SerializeField] private UniversalInformation playerCharacters;
	[SerializeField] private VariableInt enemyLevel;
	[SerializeField] private VariableInt playerSelection;
	[SerializeField] private VariableFloat attackTime;
	private float timeBetweenTurns;
	public int postFightPress;
	public AudioSource buttonSound;
	public AudioSource[] moveSounds;

	[Header("Enemy Variables")]
	public CharacterSO enemyInfo;
	public Text enemyName;
	public Slider enemyHealth;
	public Image enemySprite;

	[Header("Player Variables")]
	public Text playerName;
	public Slider playerHealth;
	public Image playerSprite;

	[Header("Player UI")]
	public CharacterSO playerInfo;
	public Button attack;
	public Button defend;
	public Button boost;
	public Button meditate;
	public Button closeButton;
	public Button afterFightButton;
	public Button playerDeathButton;
	public Button demonkidBeaten;
	public Text preFightText;

	private void Awake()
	{
		playerInfo = PullPush.player;
		playerSelection = PullPush.playerCharacter;

		afterFightButton.interactable = false;
		playerDeathButton.interactable = false;
		demonkidBeaten.interactable = false;
		battle = battleState.talking;
		timeBetweenTurns = attackTime.floatingPoint;
		SelectedFoe(enemyLevel.number);
		PlayerCharacter(playerSelection.number);

	}

	// Start is called before the first frame update
	void Start()
	{
		enemyName.text = enemyInfo.identityName;
		enemyHealth.maxValue = enemyInfo.maxHP;
		enemyHealth.value = enemyInfo.maxHP;
		enemySprite.sprite = enemyInfo.spriteGraphic;
		enemyInfo.boost = enemyInfo.startBoost;
		enemyInfo.attack = enemyInfo.startAttack;
		enemyInfo.defence = enemyInfo.startDefence;


		playerName.text = playerInfo.identityName;
		playerHealth.maxValue = playerInfo.maxHP;
		playerHealth.value = playerInfo.maxHP;
		playerSprite.sprite = playerInfo.spriteGraphic;
		playerInfo.boost = playerInfo.startBoost;
		playerInfo.attack = playerInfo.startAttack;
		playerInfo.defence = playerInfo.startDefence;
	}

	// Update is called once per frame
	void Update()
	{
		switch (battle)
		{
			case battleState.playerTurn:
				PlayerTurn();
				break;

			case battleState.enemyTurn:
				EnemyTurn();
				break;

			case battleState.playerDefeat:
				PlayerDeath();
				break;

			case battleState.enemyDefeat:
				EnemyDeath();
				break;
			case battleState.talking:
				PreFightTalking();
				break;

			case battleState.gameend:

				break;
		}
	}

	private void EnemyTurn()
	{
		if (enemyHealth.value <= 0)
		{
			afterFightButton.interactable = true;
			battle = battleState.enemyDefeat;
		}
		else
		{
			attack.interactable = false;
			defend.interactable = false;
			boost.interactable = false;
			meditate.interactable = false;

			int r;
			r = enemyInfo.favoredMoves[Random.Range(0, 10)];
			switch (r)
			{
				case 0:
					if(timeBetweenTurns < 0)
					{
						playerHealth.value -= ((enemyInfo.attack * enemyInfo.boost) - playerInfo.defence);
						enemyInfo.defence = enemyInfo.startDefence;
						enemyInfo.boost = 1;
						preFightText.text = enemyInfo.identityName + ": ATTACKS!";
						moveSounds[0].Play();
						battle = battleState.playerTurn;
					}
					else
					{
						timeBetweenTurns -= Time.deltaTime;
					}
					break;

				case 1:
					if(timeBetweenTurns < 0)
					{
						enemyInfo.defence = enemyInfo.startDefence;
						enemyInfo.boost += 1;
						preFightText.text = enemyInfo.identityName + ": BOOST IN POWER!";
						enemyInfo.boost = 1;
						moveSounds[2].Play();

						battle = battleState.playerTurn;
					}
					else
					{
						timeBetweenTurns -= Time.deltaTime;
					}
					break;

				case 2:
					if (timeBetweenTurns < 0)
					{
						enemyInfo.defence = enemyInfo.startDefence;
						enemyInfo.defence += (enemyInfo.defence * enemyInfo.boost);
						enemyInfo.boost = 1;
						preFightText.text = enemyInfo.identityName + ": DEFENDS ITSELF!";
						moveSounds[1].Play();

						battle = battleState.playerTurn;
					}
					else
					{
						timeBetweenTurns -= Time.deltaTime;
					}
					break;

				case 3:
					if (timeBetweenTurns < 0)
					{
						enemyHealth.value *= 1.25f;
						preFightText.text = enemyInfo.identityName + ": CALMS ITS MIND TO RESTORE HEALTH";
						moveSounds[3].Play();

						battle = battleState.playerTurn;
					}
					else
					{
						timeBetweenTurns -= Time.deltaTime;
					}
					break;
			}
		}
	}

	private void PlayerTurn()
	{
		if (playerHealth.value <= 0)
		{
			battle = battleState.playerDefeat;
		}
		else
		{
			attack.interactable = true;
			defend.interactable = true;
			boost.interactable = true;
			meditate.interactable = true;
		}
	}

	private void PlayerDeath()
	{
		attack.interactable = false;
		defend.interactable = false;
		boost.interactable = false;
		meditate.interactable = false;
		playerDeathButton.interactable = true;
	}

	public void RestartDeath(int presses)
	{
		switch (presses)
		{
			case 0:
				preFightText.text = playerInfo.identityName + " HAS FALLEN AND WITH THEM THE FATE OF THIS WORLD IS SEALED.";
				break;
			case 1:
				preFightText.text = "SOON ALL WILL FADE TO BLACK, BUT YOU MAY TRY AGAIN TO SAVE THIS WORLD.";
				break;
			case 3:
				preFightText.text = "CLICK ONCE MORE TO WIND BACK TIME TO THE BEGINNING OF YOUR JOURNEY.";
				break;
			case 4:
				SceneManager.LoadScene(0);
				break;

		}
		postFightPress++;
	}

	private void EnemyDeath()
	{
		attack.interactable = false;
		defend.interactable = false;
		boost.interactable = false;
		meditate.interactable = false;
	}

	public void PostFightButton()
	{
		AdanceText(postFightPress);

	}

	public void PlayerDeathPresses()
	{
		RestartDeath(postFightPress);

	}

	private void AdanceText(int press)
	{
		switch (postFightPress)
		{
			case 0:
				preFightText.text = enemyInfo.postFightText;
				break;
			case 1:
				preFightText.text = enemyInfo.identityName + " DROPPED A " + enemyInfo.dropped + "!";
				break;
			case 3:
				preFightText.text = playerInfo.identityName + " GAINED A BOOST TO " + enemyInfo.statboosted + "!";
				switch (enemyInfo.statboosted)
				{
					case ("ATTACK"):
						playerInfo.startAttack += 5;
						PullPush.player = playerInfo;
						break;
					case ("DEFENCE"):
						playerInfo.startDefence += 5;
						PullPush.player = playerInfo;
						break;
					case ("HP"):
						playerInfo.maxHP += 25;
						PullPush.player = playerInfo;
						break;
				}
				break;
			case 4:
				if(enemyInfo.identityName == "<Color=#3E31A2>DEMON</Color> PRINCE")
				{
					attack.interactable = false;
					defend.interactable = false;
					boost.interactable = false;
					meditate.interactable = false;
					preFightText.text = "CONGRADUALTIONS THE WORLD IS SAVED PRESS THE X TO RETURN TO TITLE SCREEN";
					demonkidBeaten.interactable = true;
					afterFightButton.interactable = false;
				} else
				{
					SceneManager.LoadScene(1);
				}
				break;
		}
		postFightPress++;
	}

	private void PreFightTalking()
	{
		attack.interactable = false;
		defend.interactable = false;
		boost.interactable = false;
		meditate.interactable = false;
		preFightText.text = enemyInfo.prefightText;
	}

	public void CloseTextStartBattle()
	{
		preFightText.text = "";
		closeButton.interactable = false;
		battle = battleState.playerTurn;

	}

	public void AttackButton()
	{
		timeBetweenTurns = attackTime.floatingPoint;
		preFightText.text = playerInfo.identityName + ": STRIKES " + enemyInfo.identityName +"!";
		enemyHealth.value -= ((playerInfo.attack * playerInfo.boost) - enemyInfo.defence);
		playerInfo.boost = 1;
		playerInfo.defence = playerInfo.startDefence;
		moveSounds[0].Play();
		battle = battleState.enemyTurn;
	}

	public void DefendButton()
	{
		timeBetweenTurns = attackTime.floatingPoint;
		preFightText.text = playerInfo.identityName + ": DEFENDS FROM " + enemyInfo.identityName + "!";
		playerInfo.defence = playerInfo.startDefence;
		playerInfo.defence += (playerInfo.defence * playerInfo.boost);
		playerInfo.boost = 1;
		moveSounds[1].Play();
		battle = battleState.enemyTurn;
	}

	public void BoostButton()
	{
		timeBetweenTurns = attackTime.floatingPoint;
		preFightText.text = playerInfo.identityName + ": BOOST IN POWER!";
		playerInfo.defence = playerInfo.startDefence;
		if (playerInfo.boost <= playerInfo.startBoost + 4)
		{
			playerInfo.boost += 1;
		}
		moveSounds[2].Play();
		battle = battleState.enemyTurn;
	}

	public void MeditateButton()
	{
		timeBetweenTurns = attackTime.floatingPoint;
		preFightText.text = playerInfo.identityName + ": CALMS THERE MIND AND HEALS " + enemyInfo.identityName + ".";
		playerHealth.value *= 1.25f;
		moveSounds[3].Play();
		battle = battleState.enemyTurn;
	}

	public void SelectedFoe(int level)
	{
		switch (level)
		{
			case 0: enemyInfo = Foes.entitys[0];  break;
			case 1: enemyInfo = Foes.entitys[1]; break;
			case 2: enemyInfo = Foes.entitys[2]; break;
			case 3: enemyInfo = Foes.entitys[3]; break;
			case 4: enemyInfo = Foes.entitys[4]; break;
			case 5: enemyInfo = Foes.entitys[5]; break;
			case 6: enemyInfo = Foes.entitys[6]; break;
			case 7: enemyInfo = Foes.entitys[7]; break;
			case 8: enemyInfo = Foes.entitys[8]; break;
			case 9: enemyInfo = Foes.entitys[9]; break;
			case 10: enemyInfo = Foes.entitys[10]; break;
			case 11: enemyInfo = Foes.entitys[11]; break;
		}
	}

	public void PlayerCharacter(int choice)
	{
		switch (choice)
		{
			case 0: playerInfo = playerCharacters.entitys[0]; break;
			case 1: playerInfo = playerCharacters.entitys[1]; break;
			case 2: playerInfo = playerCharacters.entitys[2]; break;
		}
	}

	public void ReturnToTitle()
	{
		SceneManager.LoadScene(0);
	}

}
