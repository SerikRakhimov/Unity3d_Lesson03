using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Interactionmanager : MonoBehaviour
{
    [SerializeField]
    private RigidbodyFirstPersonController playerController;

    [SerializeField]
    private Image handImage;

    [SerializeField]
    private float interactDistance;

    [SerializeField]
    private GameObject paperPanel;

    [SerializeField]
    private LayerMask layermask;

    private void Start()
    {
        // отключаем руку и бумагу
        handImage.gameObject.SetActive(false);
        paperPanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit raycastHit;
        if(Physics.Raycast(ray, out raycastHit, interactDistance, layermask))
        {

            // если рука не отображается
            if(!handImage.gameObject.activeSelf)
            {
                // включаем картинку
                handImage.gameObject.SetActive(true);
            }
            // если нажата "E"
            if(Input.GetKeyDown(KeyCode.E)){
                // если в поле обзора записка
                if (raycastHit.transform.tag == "Paper")
                {
                    // включить изображение записки
                    paperPanel.gameObject.SetActive(true);
                    //отключить игрока
                    playerController.enabled = false;
                }
                // если в поле обзора свеча
                if (raycastHit.transform.tag == "Candle")
                {
                    // получить объект свечу
                    Candle candle = raycastHit.transform.GetComponent<Candle>();
                    if (candle!=null)
                    {
                        // зажечь/потушить свечу
                        candle.ChangeLight();
                    }
                }
            }
            // если нажата "Esc"
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                // отключить изображение записки
                paperPanel.gameObject.SetActive(false);
                //отключить игрока
                playerController.enabled = true;
            }
        }
        else
        {
            // выключаем картинку с рукой
            handImage.gameObject.SetActive(false);
        }
    }
}
