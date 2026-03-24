using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public class User
{
    [JsonInclude]
    private int Id;
    
    [JsonInclude]
    private string Name;
    
    [JsonInclude]
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
    
    public User() {}
    
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

    public void SaveToJson(string filePath)
    {
        var options = new JsonSerializerOptions { IncludeFields = true };
        File.WriteAllText(filePath, JsonSerializer.Serialize(this, options));
    }

    public static User LoadFromJson(string filePath)
    {
        var options = new JsonSerializerOptions { IncludeFields = true };
        return JsonSerializer.Deserialize<User>(File.ReadAllText(filePath), options);
    }
}

public class Program
{
    public static void Main()
    {
        User user1 = new User("Анна");
        User user2 = new User("Стас", 4);
        User user3 = new User("Мама", 6);
        
        Console.WriteLine(user1);
        Console.WriteLine(user2);
        Console.WriteLine(user3);

        Console.WriteLine($"Всього користувачів: {User.GetUserCount()}");
        
        Console.WriteLine($"Стас адмін? {user2.IsAdmin()}");
        
        Console.WriteLine($"Підвищую рівень Стаса");
        user2.IncreaseAccessLevel();
        
        Console.WriteLine(user2);
        Console.WriteLine($"Чи є Стас адміном? {user2.IsAdmin()}");

        user1.SaveToJson("user1.json");
        User loadedUser = User.LoadFromJson("user1.json");
        
        Console.WriteLine($"\nВідновлений об'єкт: {loadedUser}");
    }
}