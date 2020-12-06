using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class BossLevel2Controller : MonoBehaviour
{
    public enum AIState
    {
        PhaseOne,
        PhaseTwo,
        PhaseThree,
    }
    [SerializeField] private GameObject[] weaponRoots;

    public Animator animator;
    [Tooltip("Fraction of the enemy's attack range at which it will stop moving towards target while attacking")]
    [Range(0f, 1f)]
    public float attackStopDistanceRatio = 0.5f;
    [Tooltip("The random hit damage effects")]
    public ParticleSystem[] randomHitSparks;
    public ParticleSystem[] onDetectVFX;
    public AudioClip onDetectSFX;

    [Header("Sound")]
    public AudioClip MovementSound;
    public MinMaxFloat PitchDistortionMovementSpeed;

    public AIState aiState { get; private set; }
    EnemyController m_EnemyController;
    //AudioSource m_AudioSource;
    Health m_health;

    const string k_AnimMoveSpeedParameter = "MoveSpeed";
    const string k_AnimAttackParameter = "Attack";
    const string k_AnimAlertedParameter = "Alerted";
    const string k_AnimOnDamagedParameter = "OnDamaged";

    void Start()
    {
        m_EnemyController = GetComponent<EnemyController>();
        DebugUtility.HandleErrorIfNullGetComponent<EnemyController, BossLevel2Controller>(m_EnemyController, this, gameObject);

        //m_EnemyController.onAttack += OnAttack;
        //m_EnemyController.onDetectedTarget += OnDetectedTarget;
        //m_EnemyController.onLostTarget += OnLostTarget;
        //m_EnemyController.SetPathDestinationToClosestNode();
        //m_EnemyController.onDamaged += OnDamaged;

        m_health = GetComponent<Health>();

        // Start patrolling
        aiState = AIState.PhaseOne;

        //// adding a audio source to play the movement sound on it
        //m_AudioSource = GetComponent<AudioSource>();
        //DebugUtility.HandleErrorIfNullGetComponent<AudioSource, EnemyMobile>(m_AudioSource, this, gameObject);
        //m_AudioSource.clip = MovementSound;
        //m_AudioSource.Play();

        weaponRoots[0].SetActive(true);
        for (int i = 1; i < weaponRoots.Length; i++)
        {
            weaponRoots[i].SetActive(false);
        }
    }

    void Update()
    {
        UpdateAIStateTransitions();
        UpdateCurrentAIState();
    }

    void UpdateAIStateTransitions()
    {
        if (m_health.currentHealth <= m_health.maxHealth * 0.8 && aiState == AIState.PhaseOne)
        {
            aiState = AIState.PhaseTwo;
            weaponRoots[1].SetActive(true);
        }
        if (m_health.currentHealth <= m_health.maxHealth * 0.4 && aiState == AIState.PhaseTwo)
        {
            aiState = AIState.PhaseThree;
            weaponRoots[2].SetActive(true);
            weaponRoots[3].SetActive(true);
        }
    }

    void UpdateCurrentAIState()
    {
        m_EnemyController.TryAtack(m_EnemyController.knownDetectedTarget.transform.position);
    }

    //void OnAttack()
    //{
    //    animator.SetTrigger(k_AnimAttackParameter);
    //}

    //void OnDetectedTarget()
    //{
    //    animator.SetBool(k_AnimAlertedParameter, true);
    //}

    //void OnLostTarget()
    //{
    //    animator.SetBool(k_AnimAlertedParameter, false);
    //}

    //void OnDamaged()
    //{
    //    if (randomHitSparks.Length > 0)
    //    {
    //        int n = Random.Range(0, randomHitSparks.Length - 1);
    //        randomHitSparks[n].Play();
    //    }

    //    animator.SetTrigger(k_AnimOnDamagedParameter);
    //}
}
