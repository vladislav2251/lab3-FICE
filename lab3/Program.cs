using System;

public class User
{
    private readonly int Id;
    private string Name;
    private int accessLevel;

    private static int Users = 0;

    public int AccessLevel
    {
        get { return accessLevel; }
    }
    
    public static int GetUserCount()
    {
        return Users;
    }
    
    public User(string name, int accessLevel)
    {
        Id = ++Users;
        Name = name;
        this.accessLevel = accessLevel;
    }
    
    public void IncreaseAccessLevel()
    {
        accessLevel++;
    }
    
    public bool IsAdmin()
    {
        return accessLevel >= 5;
    }
};
public class Program
{
    public static void Main()
    {}
}