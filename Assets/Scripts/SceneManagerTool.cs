using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerTool : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
