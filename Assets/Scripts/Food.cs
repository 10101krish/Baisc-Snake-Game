using System.Collections;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;

    public GameObject goldenFoodPrefab;
    private GameObject goldenFood;
    bool goldenFoodSpawned;


    private void Start()
    {
        RandomizePosition();
        goldenFoodSpawned = false;
    }

    private void FixedUpdate()
    {
        if (!goldenFoodSpawned)
        {
            goldenFoodSpawned = true;
            StartCoroutine(WaitGolden());
        }
    }

    IEnumerator WaitGolden()
    {
        yield return new WaitForSeconds(Random.Range(goldenFoodPrefab.GetComponent<GoldenFood>().GetMinDelay(), goldenFoodPrefab.GetComponent<GoldenFood>().GetMaxDelay()));
        SpawnGolden();
    }

    private void SpawnGolden()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        goldenFood = Instantiate(goldenFoodPrefab, new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f), Quaternion.identity);
        goldenFood.transform.parent = this.transform.parent;
    }

    public void GoldenDestroyed()
    {
        Destroy(goldenFood);
        goldenFoodSpawned = false;
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            RandomizePosition();
        Debug.Log("Hello");
    }
}
