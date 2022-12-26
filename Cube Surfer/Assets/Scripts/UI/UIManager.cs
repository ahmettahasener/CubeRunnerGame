using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    public Image backgroundImage;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        FinishGame();
    }

    public void FinishGame()
    {
        if (playerController.gameFinish)
        backgroundImage.gameObject.SetActive(true);
    }
}
