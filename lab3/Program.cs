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
    
    public User(string name) : this(name, 0)
    {}
    
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

    public override string ToString()
    {
        string role = IsAdmin() ? "Admin" : "User";
        return $"ID: [{Id}] Name: {Name} Level: {accessLevel} Role: {role}";
    }
};
public class Program
{
    public static void Main()
    {
        User user1 = new User("Стас");
        User user2 = new User("Анна", 4);
        User user3 = new User("Мама", 6);
        
        Console.WriteLine(user1);
        Console.WriteLine(user2);
        Console.WriteLine(user3);
        
    }
}