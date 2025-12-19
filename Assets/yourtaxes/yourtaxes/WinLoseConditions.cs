using UnityEngine;

namespace yourtaxes
{
    public class WinLoseConditions : MonoBehaviour
    {
        //determines if the player has survived until the time to win, and brings up the correct screen
        public bool hasWon;
        public float timeToWin;
        [SerializeField]
        private GameObject loseScreen;
        [SerializeField]
        private GameObject winScreen;
        private GuamRestraint guamRestraint;
        private float timer;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            timer = 0;
            guamRestraint = GetComponent<GuamRestraint>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!guamRestraint.guamTipped)
            {
                timer += Time.deltaTime;
                if (timer >= timeToWin)
                {
                    hasWon = true;
                    guamRestraint.lockGuam();
                    winScreen.SetActive(true);
                    Managers.MinigamesManager.DeclareCurrentMinigameWon();
                }
            } else {
                loseScreen.SetActive(true);
                Managers.MinigamesManager.DeclareCurrentMinigameLost();
            }
        }
    }
}

