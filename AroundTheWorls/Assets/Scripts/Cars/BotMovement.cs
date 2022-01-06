using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BotMovement : MonoBehaviour
{
    private bool _isCrashed = false;
    private Quaternion _startRotation;
    public bool Crashing = false;
    private Vector3 _startPosition;
    private Rigidbody _rigidBody;
    public BoxCollider collider;
    [SerializeField] private Transform StartPosition, endPosition;
    private Sequence sequence;

    CarMovement car;
    private void Awake()
    {
        Crashing = false;
        _startRotation = transform.rotation;
        _startPosition = transform.position;
        _rigidBody = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
        _rigidBody.sleepThreshold = 0.0f;
        _rigidBody.useGravity = true;
        _rigidBody.isKinematic = true;
    }
    public void ReturnStart()
    {
        Crashing = true;
        _isCrashed = false;
        collider.enabled = true;
        collider.isTrigger = true;
        _rigidBody.isKinematic = true;
        transform.position = StartPosition.position;
        transform.rotation = _startRotation;
        MovingBot();
    }
    void Start()
    {
        car = GetComponent<CarMovement>();
       
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(endPosition.transform.position, 4).SetEase(Ease.OutQuart));
        sequence.AppendInterval(1);
        sequence.Append(transform.DORotate(new Vector3(0, transform.rotation.eulerAngles.y+180, 0), 2));

        sequence.Append(transform.DOMove(StartPosition.transform.position, 4).SetEase(Ease.OutQuart));
        sequence.AppendInterval(1);
        sequence.Append(transform.DORotate(new Vector3(0, transform.rotation.eulerAngles.y -360 , 0), 2));
        sequence.SetLoops(-1);

    }
    public void Crash()
    {
        _isCrashed = true;
        collider.isTrigger = false;
        _rigidBody.isKinematic = false;


        _rigidBody.AddTorque(transform.up * 10000f);


    }

    void Update()
    {

    }
    public void MovingBot()
    {


        sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(endPosition.transform.position, 4).SetEase(Ease.OutQuart));
        sequence.AppendInterval(1);
        sequence.Append(transform.DORotate(new Vector3(0, transform.rotation.eulerAngles.y + 180, 0), 2));

        sequence.Append(transform.DOMove(StartPosition.transform.position, 4).SetEase(Ease.OutQuart));
        sequence.AppendInterval(1);
        sequence.Append(transform.DORotate(new Vector3(0, transform.rotation.eulerAngles.y - 360, 0), 2));
        sequence.SetLoops(-1);

    }
    public void CrashBot()
    {
        Crashing = true;
        Debug.Log("Нормик");
        sequence.Kill();
        Crash();
    }

}