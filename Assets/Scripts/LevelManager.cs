using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Current { get; private set; }
    [SerializeField] private PlayerEntity player;

    public PlayerEntity Player
    {
        get { return player; }
        private set { }
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        if (Current != null && Current != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Current = this;
        }
    }
}