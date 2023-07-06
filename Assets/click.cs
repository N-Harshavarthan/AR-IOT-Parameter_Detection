using System.Collections; 
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Vuforia;

public class click : MonoBehaviour
{

  InputField Temp;
  InputField Hum;
  public VirtualButtonBehaviour Vb_on ;

  void start()
  {
    Temp = GameObject.Find("InputFieldTemp").GetComponent<InputField>();
    Hum = GameObject.Find("InputFieldHum").GetComponent<InputField>();

    Vb_on.RegisterOnButtonPressed(OnButtonPressed_on);
  }
 
  public void OnButtonPressed_on(VirtualButtonBehaviour Vb_on)
  {
    GetData_tem();
    GetData_hum();
    Debug.Log("Click");
  }

  void GetData_tem() => StartCoroutine(GetData_Coroutine1());
  void GetData_hum() => StartCoroutine(GetData_Coroutine());

  IEnumerator GetData_Coroutine1()
  {
    Debug.Log("Getting Data");
    Temp.text = "Loading ...";
    string uri = "http://blynk-cloud.com/76wDnYyJ1sOdpPKkIMa5XfjpPfnj-4Ak/get/v0";
    using(UnityWebRequest request = UnityWebRequest.Get(uri))
    {
      yield return request.SendWebRequest();
      if (request.isNetworkError || request.isHttpError)
        Temp.text = request.error;
      else
      {
        Temp.text = request.downloadHandler.text;
        Temp.text = Temp.text.Substring(2,2);
      }
    }

  }

  IEnumerator GetData_Coroutine()
  {
    Debug.Log("Getting Data");
    Hum.text = "Loading ...";
    string uri = "http://blynk-cloud.com/ --- /get/v1";
    using(UnityWebRequest request = UnityWebRequest.Get(uri))
    {
      yield return request.SendWebRequest();
      if (request.isNetworkError || request.isHttpError)
        Hum.text = request.error;
      else
      {
        Hum.text = request.downloadHandler.text;
        Hum.text = Hum.text.Substring(2,2);
       
      }
    }

  }
}