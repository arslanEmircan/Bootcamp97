using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class AmazonInitialize : MonoBehaviour
{
    public TextMeshProUGUI ResultText;
    AudioSource audioSource;
    AudioClip myClip;
    float downloadP=0.01f;
    float _m1SongTime;
    private string AccessKeyID = "AKIA33OCMEVT7CH25KI4";
    private string SecretAccessKey = "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";
    private static string bucketName = "myawsbucketforrunnergame";
    private static string keyName = "the-night.mp3";
    public string url = "https://myawsbucketforrunnergame.s3.amazonaws.com/the-night.mp3";

    IEnumerator GetAudioClip()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG))
        {
            DownloadHandlerAudioClip dHA = new DownloadHandlerAudioClip(string.Empty, AudioType.WAV);
            dHA.streamAudio = true;
            www.downloadHandler = dHA;
            www.SendWebRequest();
            while (www.downloadProgress < downloadP)
            {
                Debug.Log(www.downloadProgress  + "bytes : " + www.downloadedBytes);
                yield return new WaitForSeconds(.1f);

            }
            if (www.isNetworkError)
            {
                Debug.Log("error");
            }
            else
            {
                audioSource.clip = dHA.audioClip;
                _m1SongTime = audioSource.clip.length + Time.time;
                audioSource.Play();
              
            }
        }
    }
    

    IEnumerator AudioPlayer()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG))
        {
            DownloadHandlerAudioClip dHA = new DownloadHandlerAudioClip(string.Empty, AudioType.WAV);
            dHA.streamAudio = true;
            www.downloadHandler = dHA;
            www.SendWebRequest();
            while(!www.isDone)
            {
                while (www.downloadProgress < downloadP)
                {
                        Debug.Log(www.downloadProgress);
                        yield return www;

                }
                    if (www.isNetworkError)
                    {
                        Debug.Log("error");
                    }
                    else
                    {
                            Debug.Log("daha tamamlanmadi");
                            audioSource.clip = dHA.audioClip;
                            _m1SongTime = audioSource.clip.length + Time.time;
                            downloadP += 0.01f;
                    }
            }
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(AudioPlayer());

       
    }
    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        
    }
   
}