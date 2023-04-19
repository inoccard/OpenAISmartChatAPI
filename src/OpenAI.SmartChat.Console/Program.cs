internal class Program
{
    private static async Task Main(string[] args)
    {
        var text = "";

        Console.WriteLine("En: Hello, ask your question or type 'Exit' to finish\n");
        Console.WriteLine("pt-BR: Olá, faça sua pergunta ou digite 'Sair' para finalizar\n");
        Console.WriteLine("Es: Hola, haz tu pregunta o escribe 'Salir' para terminar\n");

        while (ProgramHelpers.Validate(text))
        {
            Console.WriteLine("Me: ");
            text = Console.ReadLine();

            if (ProgramHelpers.Validate(text))
            {
                var response = await new HttpClient().GetStringAsync($"{ProgramHelpers.URL}{text}");

                Console.WriteLine($"\nSmartChat: {response}\n");
            }
        }
    }
}