namespace LocadoraVHS
{
    public enum FilmeStatus
    {
        Disponivel = 0,
        EmEspera = 1,
        EmReparo = 2,
        Extraviado = 3,
        Alugado = 4
    }
}

// Ciclo de vida normal do filme:
// Disponível -> Alugado -> Em Espera (recem devolvido) -> Disponível