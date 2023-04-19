internal static class ProgramHelpers
{
    public const string URL = "https://localhost:7107/api/v1/smart-chat/ask-a-question?text=";

    public static bool Validate(string text) =>
        text switch
        {
            "Exit" => false,
            "exit" => false,
            "Sair" => false,
            "sair" => false,
            "Salir" => false,
            "salir" => false,
            null => false,
            _ => true,
        };
}