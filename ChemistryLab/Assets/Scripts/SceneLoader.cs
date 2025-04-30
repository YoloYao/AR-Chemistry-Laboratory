using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadChemElementsScene() {
        SceneManager.LoadScene("Scene1_ChemElements");
    }

    public void LoadExperimentScene() {
        SceneManager.LoadScene("Scene2_ChemicalExperiment");
    }

    public void LoadLessonsScene() {
        SceneManager.LoadScene("Scene3_Lessons");
    }

    public void ReturnToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
