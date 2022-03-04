namespace AkissBot.Entities;
public class User
{
    public long ChatId { get; set; }
    public string FullName { get; set; }
    public string Adress { get; set; }
    public string PhoneNumber { get; set; }
    public Role Role { get; set; }

    [Obsolete("Only entity binding")]
    public User(){}
    public User(long chatId)
    {
        ChatId = chatId;
        FullName = string.Empty;
        Adress = string.Empty;
        PhoneNumber = string.Empty;
        Role = Role.None;
    }
    public User(User copy)
    {
        this.ChatId = copy.ChatId;
        this.FullName = copy.FullName;
        this.Adress = copy.Adress;
        this.PhoneNumber = copy.PhoneNumber;
        this.Role = copy.Role;
    }
}
