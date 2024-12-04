using System.Collections; // Necesario para IEnumerator
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public Transform respawnPoint;  // Punto de reaparición
    public GameObject playerPrefab; // Prefab del jugador
    public float delayBeforeDestruction = 2f; // Tiempo de retraso antes de la destrucción

    public void RespawnPlayer()
    {
        if (respawnPoint != null && playerPrefab != null)
        {
            // Instancia una nueva copia del jugador en el punto de reaparición
            GameObject newPlayer = Instantiate(playerPrefab, respawnPoint.position, respawnPoint.rotation);
            StartCoroutine(DestroyAfterDelay(newPlayer));
        }
        else
        {
            Debug.LogError("RespawnPoint o playerPrefab no asignado.");
        }
    }

    private IEnumerator DestroyAfterDelay(GameObject player)
    {
        // Espera por el tiempo especificado antes de destruir al jugador
        yield return new WaitForSeconds(delayBeforeDestruction);
        // Destruir el objeto jugador actual
        Destroy(player);
    }
}

