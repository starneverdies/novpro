using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VariationDatabase", menuName="Databse/VariationDatabase")]
public class VariationDatabase : ScriptableObject
{
	public List<Group> groups = new List<Group>();
	public Group GetGroupByName(string name)
	{
		return groups.Find(group => group.name == name);
	}
	public Group GetRandomGroup()
	{
		if(groups.Count == 0) return null;
		int randomIndex = Random.Range(0, groups.Count);
		return groups[randomIndex];
	}
}

[System.Serializable]
public class Group
{
	public string name;
	public string oppoName;
	
	public Group(string name, string oppoName)
	{
		this.name = name;
		this.oppoName = oppoName;
	}
}

