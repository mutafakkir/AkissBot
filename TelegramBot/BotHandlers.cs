﻿using AkissBot.Entities;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace AkissBot.TelegramBot;
public class BotHandlers
{
    private readonly ILogger<BotHandlers> _logger;

    public BotHandlers(ILogger<BotHandlers> logger)
    {
        _logger = logger;
    }
    public Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken ctoken)
    {
        var errorMessage = exception switch
        {
            ApiRequestException => $"Error occured with Telegram Client: {exception.Message}",
            _ => exception.Message
        };
        _logger.LogCritical(errorMessage);
        return Task.CompletedTask;
    }
    public async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken ctoken)
    {
        var handler = update.Type switch
        {
            UpdateType.Message => BotOnMessageRecieved(client, update.Message),
            _ => UnknownUpdateHandler(client, update)
        };
        try
        {
            await handler;
        }
        catch (Exception e)
        {
            _logger.LogWarning(e.Message);
        }
    }

    private Task UnknownUpdateHandler(ITelegramBotClient client, Update update)
    {
        throw new Exception("This type update can't be handled.");
    }

    private async Task BotOnMessageRecieved(ITelegramBotClient client, Message message)
    {
        if (message.Text == "/start")
        {
            await client.SendTextMessageAsync(
                message.Chat.Id,
                "Assalomu alaykum.\n\n Al-Xorazmiy nomidagi xalqaro ixtisoslashtirilgan maktabiga hush kelibsiz. Iltimos, familiya, ismingiz va sharifingizni kiriting.\nMasalan: Abdullayev Abror Asad o'g'li."
            );
        }
        if (message.Document != null)
        {
            //await client.SendTextMessageAsync(message.Chat.Id, message.Document.MimeType);
            if(message.Document.MimeType == "application/pdf")
            await client.SendTextMessageAsync(message.Chat.Id, "ok");
            //await client.SendDocumentAsync(message.Chat.Id, message.Document.FileId);
        }
    }
}
