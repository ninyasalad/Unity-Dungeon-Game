
using UnityEngine;
//Import this library if you have loads of scene to change, if you have only one scene, try using the function below.(Any can do the same thing, it's up to you to decide.)
//using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    public string[] sceneNames;
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            //Teleport the player
            GameManager.instance.SaveState();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            //UnityEngine.SceneMangement...
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
