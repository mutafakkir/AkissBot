using AkissBot.Services;
using AkissBot.TelegramBot;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<TelegramBotClient>(b => new TelegramBotClient(builder.Configuration["Telegram:Token"]));
builder.Services.AddHostedService<Bot>();
builder.Services.AddTransient<BotHandlers>();
builder.Services.AddSingleton<GoogleSecretsService>();

var app = builder.Build();

app.Run();
