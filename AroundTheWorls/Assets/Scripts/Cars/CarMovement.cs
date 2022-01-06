using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class CarMovement : MonoBehaviour
{
    public ParticleSystem explosionParticleBoom;
    public ParticleSystem explosionParticleSmoke;
    [SerializeField] float speed = 0.2f;
    [SerializeField] public StartPoint startPoint = null;

    Scene scene;
    public List<Vector3> waypoints = new List<Vector3>();
    public BoxCollider collider;
    
    private bool _isCrashed = false;
    private Quaternion _startRotation;
    private Vector3 _startPosition;
    private Rigidbody _rigidBody;
    private BotMovement _botMovement;

    private void Awake() {
        _startRotation = transform.rotation;
        _startPosition = transform.position;
        _rigidBody = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
        _rigidBody.sleepThreshold = 0.0f;
        _rigidBody.useGravity = true;
        _rigidBody.isKinematic = true;
    }
    private void Start()
    {
        
        explosionParticleBoom.Pause();
        explosionParticleSmoke.Pause();
        scene = SceneManager.GetActiveScene();
       
        if (scene.buildIndex > 2)
        {
            _botMovement = GameObject.Find("RedCar").GetComponent<BotMovement>();
        }
    }

    public Vector3 ReturnRealPos(Vector3 pos)
    {
        //return pos - new Vector3(0, collider.size.y, 0);
        return new Vector3(pos.x, 1.01f, pos.z);
    }

    public void FollowPath()
    {   
        _isCrashed = false;
        collider.isTrigger = true;
        collider.enabled = true;
        _rigidBody.isKinematic = true;
        float duration = waypoints.Count * speed;
        transform.DOPath(waypoints.ToArray(), duration).SetLookAt(0.01f);
    }

    public bool IsMoving()
    {
        if(waypoints.Count == 0)
        {
            return false;
        }
        var distance = Vector3.Distance(waypoints[waypoints.Count - 1], transform.position);
        return  distance > 2f ? true : false;
    }

    public void Move(Vector3 point)
    {
        transform.DOMove(point, speed);
    }

    public void Crash(Vector3 crashPoint)
    {   
        _isCrashed = true;
        collider.isTrigger = false;
        _rigidBody.isKinematic = false;
        var dir = (transform.position - crashPoint) + transform.up;
        dir.Normalize();
        
        _rigidBody.AddTorque(transform.up * 10000f);
        //_rigidBody.AddForce(-dir * 100f, ForceMode.VelocityChange);
        StopMoving();
    }

    public bool IsCrashed()
    {
        // Before any crash, cars rigid bodies are setted off
        return _isCrashed;
    }

    public void Restart()
    {
       
        waypoints.Clear();
        StopMoving();
        ReturnStart();        
    }


    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void StopMoving()
    {
        DOTween.Kill(transform);
    }

    public void ReturnStart()
    {   
        
        _isCrashed = false;
        collider.enabled = false;
        collider.isTrigger = true;
        _rigidBody.isKinematic = true;
        var waypoints = new Vector3[]{transform.position, _startPosition};
        transform.DOPath(waypoints, speed);
        transform.rotation = _startRotation;
        GeneralScore._generalScore -= GameManager._instance.scoreCount;
        GeneralScore._generalCard -= GameManager._instance.cardsScoreCount;
        PlayerPrefs.SetInt("coinss", GeneralScore._generalScore);
        PlayerPrefs.SetInt("cardd", GeneralScore._generalCard);
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.tag == "Car" || other.transform.tag == "Obstacle")
        {
            AudioManager.PlaySounds("Crash");
            Crash(other.transform.position);
            explosionParticleBoom.Play();
            explosionParticleSmoke.Play();
            if (scene.buildIndex > 2)
            {
                _botMovement.CrashBot();
            }
            if (GameManager._instance.check == false)
            {

                GeneralScore._generalScore -= GameManager._instance.scoreCount;
                GeneralScore._generalCard -= GameManager._instance.cardsScoreCount;
                GameManager._instance.check = true;
                PlayerPrefs.SetInt("coinss", GeneralScore._generalScore);
                PlayerPrefs.SetInt("cardd", GeneralScore._generalCard);
            }
        }        
    }


}
