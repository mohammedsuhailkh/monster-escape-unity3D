using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayGameOverSound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
            StartCoroutine(loadGameOver());
        }
    }



 public IEnumerator loadGameOver()
    {
        yield return new WaitForSeconds(2f);
       
           SceneManager.LoadScene(2);
        
    }



    
}
