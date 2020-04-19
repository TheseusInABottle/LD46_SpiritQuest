using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName =("ScriptableObject/Entity"))]
public class CharacterSO : ScriptableObject
{

	public string identityName;
	public int maxHP;
	public int startAttack;
	public int attack;
	public int startDefence;
	public int defence;
	public int boost;
	public int startBoost;
	public Sprite spriteGraphic;
	public string prefightText;
	public string postFightText;
	public string dropped;
	public string statboosted;
	public int[] favoredMoves;
}
