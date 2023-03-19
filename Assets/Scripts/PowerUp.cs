using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public GameObject powerUpPrefab;
    public Text powerUpText;
    private GameObject powerUp;

    static string[] powerUps = { "2X Bonus", "God Mode" };
    int[] powerUpsEnabled = new int[powerUps.Length];

    public float minDelay = 1f;
    public float maxDelay = 2f;

    public float powerUpDuration = 120;
    int powerUpIndex;

    private bool powerUpSpawned;
    private bool powerUpDestroyed;
    private float powerUpStartTime;

    private void Start()
    {
        powerUpSpawned = false;
        powerUpDestroyed = false;
    }

    private void FixedUpdate()
    {
        if (!powerUpSpawned)
        {
            powerUpSpawned = true;
            StartCoroutine(WaitForSpawn());
        }
        else if (powerUpDestroyed && (Time.timeSinceLevelLoad - powerUpStartTime >= powerUpDuration))
        {
            powerUpsEnabled[powerUpIndex] = 0;
            powerUpDestroyed = false;
            powerUpSpawned = false;
            powerUpText.text = "";
        }
    }

    IEnumerator WaitForSpawn()
    {
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        SpawnPowerUp();
    }

    private void SpawnPowerUp()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        powerUp = Instantiate(powerUpPrefab, new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f), Quaternion.identity) as GameObject;
        powerUp.transform.parent = this.transform;
    }

    private void DisplayPowerUp(int index)
    {
        powerUpText.text = powerUps[index];
        powerUpText.color = Color.cyan;
    }

    public void PowerUpDestroyed()
    {
        Destroy(powerUp);
        powerUpDestroyed = true;

        powerUpStartTime = Time.timeSinceLevelLoad;
        powerUpIndex = Random.Range(0, powerUps.Length);

        powerUpsEnabled[powerUpIndex] = 1;
        DisplayPowerUp(powerUpIndex);
    }

    public bool GodModeEnabled()
    {
        if (powerUpsEnabled[1] == 1)
            return true;
        return false;
    }

    public bool DoubleModeEnabled()
    {
        if (powerUpsEnabled[0] == 1)
            return true;
        return false;
    }

}
