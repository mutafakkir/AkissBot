using Telegram.Bot.Types.ReplyMarkups;

namespace AkissBot.TelegramBot;
public class Buttons
{
    public static IReplyMarkup SendContact()
        => new ReplyKeyboardMarkup(new List<List<KeyboardButton>>()
        {
            new List<KeyboardButton>()
            {
                new KeyboardButton("📞 Kontaktni jo'natish"){ RequestContact = true}
            }
        })
        {
            ResizeKeyboard = true,
            OneTimeKeyboard = true
        };
    public static IReplyMarkup JoiningButton()
        => new ReplyKeyboardMarkup(new List<List<KeyboardButton>>()
        {
            new List<KeyboardButton>()
            {
                new KeyboardButton("Maktabga hujjat topshirish"),
                new KeyboardButton("Jamoaga qo'shilish")
            }
        })
        {
            ResizeKeyboard = true,
            OneTimeKeyboard = true
        };
    public static IReplyMarkup ForTeachers()
        => new ReplyKeyboardMarkup(new List<List<KeyboardButton>>()
        {
            new List<KeyboardButton>()
            {
                new KeyboardButton("Ishga"),
                new KeyboardButton("Malaka oshirishga")
            }
        })
        {
            ResizeKeyboard = true,
            OneTimeKeyboard = true
        };
}
