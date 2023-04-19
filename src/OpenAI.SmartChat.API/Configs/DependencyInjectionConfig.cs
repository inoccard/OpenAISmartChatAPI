using OpenAI.SmartChat.API.Services;

namespace OpenAI.SmartChat.API.Configs
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterComponents(this IServiceCollection services)
        {
            services.AddScoped<ISmartChatService, SmartChatService>();

        }
    }
}