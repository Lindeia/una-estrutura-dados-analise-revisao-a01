Console.WriteLine("\nInfluenza H5N1 - identificação de pessoas sintomáticas ");

Console.WriteLine("Olá! Irei te fazer algumas perguntas para identicarmos se você pode estar ou não com o vírus Influenza H5N1:");
Console.WriteLine("Qual seu nome? ");
string nome = Console.ReadLine();

Console.WriteLine("Informe a sua idade:");
int idade;
while (!int.TryParse(Console.ReadLine(), out idade) || idade < 0)
{
    Console.WriteLine("Idade inválida! Tente novamente.");
}

bool vacina = Questionario("Seu cartão de vacina está em dia?");
bool sintomas = Questionario("Teve algum dos sintomas recentemente? (dor de cabeça, febre, náusea, dor articular, gripe)");
bool pessoaInfectada = Questionario("Teve contato com pessoas com sintomas gripais nos últimos dias?");
bool viagem = Questionario("Está retornando de viagem realizada no exterior?");

double risco = CalcularRisco(vacina, sintomas, pessoaInfectada, viagem);

Console.WriteLine("\n ~~~~ Pronto! Já tenho o resultado da sua análise. Essas são suas orientações: " + Orientacao(risco, viagem)+"~~~~");

ImprimirDados(nome, idade, vacina, sintomas, pessoaInfectada, viagem, risco);




    static bool Questionario(string questionario)
{
    for (int tentativas = 0; tentativas < 3; tentativas++)
    {
        Console.WriteLine(questionario + " (SIM/NAO):");
        string resposta = Console.ReadLine().Trim().ToUpper();
        if (resposta == "SIM") return true;
        if (resposta == "NAO") return false;
    }

    Console.WriteLine("Não foi possível realizar o diagnóstico.");
    Console.WriteLine("Gentileza procurar ajuda médica caso apareça algum sintoma.");
    Environment.Exit(0);
    return false;
}

static double CalcularRisco(bool vacina, bool sintomas, bool pessoaInfectada, bool viagem)
{
    double porcentagem = 0.0;

    if (!vacina)
        porcentagem += 10.0;
    if (sintomas)
        porcentagem += 30.0;
    if (pessoaInfectada)
        porcentagem += 30.0;
    if (viagem)
        porcentagem += 30.0;

    return porcentagem;
}

static string Orientacao(double risco, bool viagem)
{
    if (viagem)
        return "Você ficará sob observação por 05 dias.";

    if (risco <= 30.0)
        return "Paciente sob observação. Caso apareça algum sintoma, gentileza buscar assistência médica.";
    else if (risco <= 60.0)
        return "Paciente com risco de estar infectado. Gentileza aguardar em lockdown por 02 dias para ser acompanhado.";
    else if (risco <= 89.0)
        return "Paciente com alto risco de estar infectado. Gentileza aguardar em lockdown por 05 dias para ser acompanhado.";
    else if (risco >= 90.0)
        return "Paciente crítico! Gentileza aguardar em lockdown por 10 dias para ser acompanhado.";
    else
        return "Orientação inválida";
}

static void ImprimirDados(string nome, int idade, bool vacina, bool sintomas, bool pessoaInfectada, bool viagem, double risco)
{
    Console.WriteLine("Nome: " + nome);
    Console.WriteLine("Idade: " + idade);
    Console.WriteLine("Cartão de Vacina em Dia: " + (vacina ? "Sim" : "Não"));
    Console.WriteLine("Teve Sintomas Recentemente: " + (sintomas ? "Sim" : "Não"));
    Console.WriteLine("Teve Contato com Pessoas Infectadas: " + (pessoaInfectada ? "Sim" : "Não"));
    Console.WriteLine("Retornando de Viagem: " + (viagem ? "Sim" : "Não"));
    Console.WriteLine("Probabilidade de Infecção: " + risco + "%");
}
Console.ReadLine(); 