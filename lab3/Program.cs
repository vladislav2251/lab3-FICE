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