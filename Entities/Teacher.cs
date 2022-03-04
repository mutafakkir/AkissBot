namespace AkissBot.Entities;
public class Teacher : User
{
    public Teacher(User copy) : base(copy) { }
    public string Subject { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int ExperienceInYears { get; set; } = 0;
    public EnglishLevel EnglishLevel { get; set; } = EnglishLevel.A0;
    public string Resume { get; set; } = string.Empty;
}
