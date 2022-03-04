using AkissBot.Entities;

namespace AkissBot.Services;
public class InternalStorageService
{
    private readonly ILogger<InternalStorageService> _logger;
    private readonly List<User> _users;
    private readonly List<Teacher> _teachers;
    private readonly List<Pupil> _pupils;

    public InternalStorageService(ILogger<InternalStorageService> logger)
    {
        _logger = logger;
        _users = new List<User>();
        _teachers = new List<Teacher>();
        _pupils = new List<Pupil>();
    }
    public bool ExistsUser(long chatId)
        => _users.Any(u => u.ChatId == chatId);
    public User GetUser(long chatId)
        => _users.FirstOrDefault(u => u.ChatId == chatId);
    public Teacher GetTeacher(long chatId)
        => _teachers.FirstOrDefault(t => t.ChatId == chatId);
    public Pupil GetPupil(long chatId)
        => _pupils.FirstOrDefault(p => p.ChatId == chatId);
    public void InsertUser(long chatId)
    {
        var user = new User(chatId);
        _users.Add(user);
    }
    public void InsertTeacher(User user)
    {
        var teacher = new Teacher(user);
        _teachers.Add(teacher);
    }
    public void InsertPupil(User user)
    {
        var pupil = new Pupil(user);
        _pupils.Add(pupil);
    }
    public void UpdateUser(User user)
    {
        var old = GetUser(user.ChatId);
        _users.Remove(old);
        _users.Add(user);
    }
    public void UpdateTeacher(Teacher teacher)
    {
        var old = GetTeacher(teacher.ChatId);
        _teachers.Remove(old);
    }
    public void UpdatePupil(Pupil pupil)
    {
        var old = GetPupil(pupil.ChatId);
        _pupils.Remove(old);
        _pupils.Add(pupil);
    }
}
