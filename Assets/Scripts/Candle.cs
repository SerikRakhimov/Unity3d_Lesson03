using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Candle : MonoBehaviour
{
   [SerializeField]
   private Light pointLight;

   private bool isLight;

   void Start()
   {
      isLight = false;
      // отключаем свет от свечи
      pointLight.gameObject.SetActive(false);
   }

   public void ChangeLight()
   {
      // меняем true на false и наоборот 
      isLight = !isLight;
      // попеременно включаем/выключаем свет в зависимости от значения переменной isLight
      pointLight.gameObject.SetActive(isLight);
   }


}
