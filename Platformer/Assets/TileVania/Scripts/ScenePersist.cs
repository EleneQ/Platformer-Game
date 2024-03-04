using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
	static ScenePersist instance = null;

	int startingSceneIndex;

	void Start()
	{
		if (instance == null)
		{
			instance = this;
			startingSceneIndex = SceneManager.GetActiveScene().buildIndex;

			SceneManager.sceneLoaded += OnSceneLoaded;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (startingSceneIndex != scene.buildIndex)
		{
			instance = null;

			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy(gameObject);
		}
	}
}