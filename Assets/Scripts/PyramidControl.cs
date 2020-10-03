using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class PyramidControl : MonoBehaviour
{
	public static int slotsOccupied;

	[SerializeField]
	private Transform[] rings;

	// [SerializeField]
	// private GameObject winSign;

	// [SerializeField]
	// private GameObject wrongSign;
	public Text textScore;
    public GameObject Stand;
    public GameObject StandBase;
    public float PosDifOrigin;
    public float PosDistance;
	private int[] indexs;
	private Vector3[] locations;

	// Envio de datos
	private button_manage button_manage;
	public GameObject ScorePanel;
	private int cont = 0;

	void Awake()
    {
        button_manage = GameObject.FindObjectOfType<button_manage>();
    }

    // Start is called before the first frame update
    private void Start()
    {
		Drag.PuzzleDone += CheckResults;
		// slotsOccupied = 0;
		// winSign.SetActive(true);
		// wrongSign.SetActive(true);
		textScore.text = "0";
		// Inicializacion de arrays de indices y posiciones
		indexs = new int[rings.Length];
		locations = new Vector3[rings.Length];
		float Origin = StandBase.transform.position.y - PosDifOrigin;
		for (int i = 0; i < rings.Length; i++)
		{
			indexs[i] = 0;
			locations[i] = new Vector3(Stand.transform.position.x, Origin + ((i + 1) * PosDistance), 0f);
		}
    }

	public void CheckResults()
	{
		// Debug.Log (rings[0].position.y);
		if (rings[0].position.y == 1.7f &&
			rings[1].position.y == 0.15f &&
			rings[2].position.y == -1.5f &&
			rings[3].position.y == -3.15f)
		{
			// winSign.SetActive(true);
			Invoke("ReloadGame", 2f);
		}
		else
		{
			// wrongSign.SetActive(true);
			Invoke("ReloadGame", 1f);
		}
	}

	private void ReloadGame()
	{
		Drag.PuzzleDone -= CheckResults;
		SceneManager.LoadScene("SampleScene");
	}

    // Update is called once per frame
    void Update()
    {
		for (int i = 0; i < rings.Length; i++)
		{
			// Debug.Log(rings[i].position + rings[i].name + " -- " + locations[i]);
			if (rings[i].position == locations[i])
			{
				indexs[i] = 1;
			}
			else indexs[i] = 0;
		}
		int sum = indexs.Sum();
		textScore.text = sum.ToString();
		// Envio de puntaje
		button_manage.GetScore(sum.ToString());
		// Fin del juego
		if (sum == rings.Length && cont == 0 && Input.GetMouseButtonUp (0))
		{
			button_manage.GetRecommendation();
			ScorePanel.gameObject.SetActive(true);
			cont = 1;
			Debug.Log("Envío-" + cont);
		}
    }
}
