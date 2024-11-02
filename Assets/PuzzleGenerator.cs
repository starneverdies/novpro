using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleGenerator : MonoBehaviour
{
    public GameObject horizontalLayoutGroup;
    public GameObject verticalLayoutGroup;
    public Button generationText;
	
	public VariationDatabase variationDatabse;
    private int rows;
    private int columns;
    private int row;
    private int column;
	private string name = null;
	private string oppoName = null;
 //   private double remainingTime=0;

    public List<GameObject> verticalLayoutGroups = new List<GameObject>();
    void Start()
    {
		rows = Random.Range(10, 15);
		columns = Random.Range(10, 14);
		row = Random.Range(0, rows);
		column = Random.Range(0, columns);
		
		/*Group randomVariationdata = variationDatabse.GetRandomGroup();
		if(randomVariationdata != null)
		{
			this.name = randomVariationdata.name;
			this.oppoName = randomVariationdata.oppoName;
		}*/
		
		int formatDeciding = Random.Range(0, 3);
		name = GetRandomAlphabetsNumbersSpecialChar(formatDeciding).ToString();
		oppoName = GetRandomAlphabetsNumbersSpecialChar(formatDeciding).ToString();
		if(oppoName == name)
		{
			oppoName = GetRandomAlphabetsNumbersSpecialChar(formatDeciding).ToString();
		}
		
		Generate(rows, columns);
    }

    public void Generate(int a, int b)
    {
        for (int i = 0; i < a; i++)
        {
            GameObject verticalLayot = Instantiate(verticalLayoutGroup, horizontalLayoutGroup.transform);
            for (int j = 0; j < b; j++)
            {
                GameObject mytext = Instantiate(generationText.gameObject, verticalLayot.transform);
				if(row == i && column == j)
				{
					mytext.GetComponentInChildren<TMP_Text>().text = name;					
				}else
				{
					mytext.GetComponentInChildren<TMP_Text>().text = oppoName;											
				}
                mytext.GetComponent<IntegerHolder>().holding =int.Parse(i.ToString()+j.ToString());
                mytext.GetComponent<IntegerHolder>().errored =int.Parse(row.ToString()+column.ToString());
                mytext.GetComponent<IntegerHolder>().AddingListener();
            }
			verticalLayoutGroups.Add(verticalLayot);
        }
    }
	
	public static char GetRandomAlphabetsNumbersSpecialChar(int index)
	{
		const string alphas = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
		const string nums = "123456789";
		const string specials = "!@#$%^&*()-_=+[]{};:'\",.<>?/|\\`~";
		if(index == 0)
		{
			int randomIndex = Random.Range(0, alphas.Length);
			return alphas[randomIndex];
		}else if(index == 1)
		{
			int randomIndex = Random.Range(0, nums.Length);
			return nums[randomIndex];
			
		}else
		{
			int randomIndex = Random.Range(0, specials.Length);
			return specials[randomIndex];			
		}
	}
	
	public void RestartLevel()
	{
		foreach(GameObject obj in verticalLayoutGroups)
		{
			Destroy(obj);
		}
		Start();
	}
	
	public void RestartLevel(int index)
	{
		int currentWins = PlayerPrefs.GetInt("Wins", 0);
		currentWins += index;
		PlayerPrefs.SetInt("Wins", currentWins);
		PlayerPrefs.Save();
		
		foreach(GameObject obj in verticalLayoutGroups)
		{
			Destroy(obj);
		}
		Start();
	}
}
