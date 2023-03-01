using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GPSLocation : MonoBehaviour
{
    public Text GPSStatus;
    public Text latitudeValue;
    public Text longitudeValue;
    public Text altitudeValue;
    public Text horizontalAccuracyValue;
    public Text timestampValue;
    
    void Start() {
        StartCoroutine(GPSLoc());
    }

    IEnumerator GPSLoc() {
        // Проверяем дал ли пользователь разрешение на использование сервиса геолокации
        if (!Input.location.isEnabledByUser)
            yield break;

        // Включаем сервис перед выполнением запроса позиции 
        Input.location.Start();

        // Ожидаем пока сервис не инициализируется
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Сервис не отвечает более 20 сек
        if (maxWait < 1) {
            GPSStatus.text = "Time out";
            yield break;
        }

        // Соединение не удалось
        if (Input.location.status == LocationServiceStatus.Failed) {
            GPSStatus.text = "Unable to determine device location";
            yield break;
        } else {
            GPSStatus.text = "Running";
            InvokeRepeating("UpdateGPSData", 0.5f, 1f);
        }

    }// конец метода GPSLoc

    private void UpdateGPSData() {
        
        if (Input.location.status == LocationServiceStatus.Running) {
            // 
            GPSStatus.text = "Running";
            latitudeValue.text = Input.location.lastData.latitude.ToString();
            longitudeValue.text = Input.location.lastData.longitude.ToString();
            altitudeValue.text = Input.location.lastData.altitude.ToString();
            horizontalAccuracyValue.text = Input.location.lastData.horizontalAccuracy.ToString();
            timestampValue.text = Input.location.lastData.timestamp.ToString();
        } else {
            // Сервис остановлен

        }

    }// конец метода UpdateGPSData

}
