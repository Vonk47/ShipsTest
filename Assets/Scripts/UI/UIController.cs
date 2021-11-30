using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] Button startAgainButton;
   
    void Start()
    {
        startAgainButton.onClick.AddListener(StartAgain);
    }

    public void SetActiveGameOver()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
   private void StartAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
