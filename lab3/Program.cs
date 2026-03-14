using System;
public class User
{
    private readonly int Id;
    private string Name;
    private int AccessLevel = 0;

    private static int Users = 0;

    public void IncreaseAccessLevel()
    {
        AccessLevel++;
    }
};