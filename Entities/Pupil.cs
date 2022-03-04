namespace AkissBot.Entities;
public class Pupil : User
{
    public Pupil(User copy) : base(copy) { }
    public int Grade { get; set; } = 0;
    public bool AttendedOlympiads { get; set; } = false;
    public string AboutOlympiad { get; set; } = string.Empty;

}
