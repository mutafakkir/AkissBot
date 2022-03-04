using AkissBot.TelegramBot;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<TelegramBotClient>(b => new TelegramBotClient(builder.Configuration["Telegram:Token"]));
builder.Services.AddHostedService<Bot>();
builder.Services.AddTransient<BotHandlers>();

var app = builder.Build();

app.Run();
