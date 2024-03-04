public static class PlayerStats
{
    public static int lives = 3;
    public static int score { get; set; }

    public static void ResetStats()
    {
        lives = 3;
        score = 0;
    }
}