using UnityEngine;

public class HarrSpawner : MonoBehaviour {
    public Collider2D polygonCollider;
    [SerializeField] GameObject harrPrefab;
    [SerializeField] float spawnDelayMin = 5f;
    [SerializeField] float spawnDelayMax = 3f;
    float timer;


    protected void Start() {
        StartTimer();
    }

    protected void Update() {
        timer -= Time.deltaTime;
        if (timer < 0f ) {
            Spawn();
        }
    }

    Vector2 GenerateRandomPointInPolygon(Collider2D collider) {
        var bounds = collider.bounds;

        while (true) {
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);

            var randomPoint = new Vector2(randomX, randomY);

            if (IsPointInsidePolygon(randomPoint, collider)) {
                return randomPoint;
            }
        }
    }

    bool IsPointInsidePolygon(Vector2 point, Collider2D collider) {
        var hit = Physics2D.Raycast(point, Vector2.zero);

        // Check if the ray hits the collider
        if (hit.collider != null && hit.collider == collider) {
            return true;
        }

        return false;
    }

    void StartTimer() {
        timer = Random.Range(spawnDelayMin, spawnDelayMax);
    }

    void Spawn() {
        var randomPoint = GenerateRandomPointInPolygon(polygonCollider);
        var harr = Instantiate(harrPrefab, randomPoint, Quaternion.identity);
        StartTimer();
    }

    public void OnSpawn() {
        Spawn();
    }
}
