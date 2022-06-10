using System.Collections.Generic;
using UnityEngine;

public class LaserPool : MonoBehaviour
{

    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private List<GameObject> listaLasers;
    [SerializeField] private int tamanhoLista = 5;

    private static LaserPool instance;
    
    public static LaserPool Instance { 
        get {
            return instance;
        }
    }

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
       AdicionarLasers(tamanhoLista);
    }

    private void AdicionarLasers(int amount) {
        for (int i = 0; i < amount; i++) {
            GameObject laser = Instantiate(laserPrefab);
            laser.SetActive(false);
            listaLasers.Add(laser);
            laser.transform.parent = transform;
        }
    }

    public GameObject Atirar() {
        for (int i = 0; i < listaLasers.Count; i++) {
            if(!listaLasers[i].activeSelf) {
                listaLasers[i].SetActive(true);
                return listaLasers[i];
            }
        }

        AdicionarLasers(1);
        listaLasers[listaLasers.Count - 1].SetActive(true);
        return listaLasers[listaLasers.Count - 1];
    }
}
