using System;

public class LogicaFuzzy
{
    #region Temperatura
    private double Frio(double temp)
    {
        if (temp <= 10)
        {
            return 1.0;
        }else if (temp >10 && temp < 20)
        {
            return (20 - temp)/10;
        }
        else
        {
            return 0;
        }
    }
    private double Morno(double temp)
    {
        if (temp > 10 && temp<=20)
        {
            return(temp-10)/10;
        }else if(temp > 20 && temp < 30)
        {
            return(30- temp)/10;
        }
        else
        {
            return 0;
        }
    }
    private double Quente(double temp)
    {
        if(temp >= 30)
        {
            return 1.0;
        }else if (temp > 20 && temp<30)
        {
            return(temp-20)/10;
        }
        else
        {
            return 0;
        }
    }
    #endregion

    #region Umidade
    private double Baixa(double umidade)
    {
        if (umidade <= 40)
        {
            return 1;
        }else if (umidade > 40 && umidade <60)
        {
            return(60-umidade)/20;
        }
        else
        {
            return 0;
        }
    }
    
    private double Moderado(double umidade)
    {
        if(umidade > 40 && umidade <= 60)
        {
            return (umidade - 40) / 20;
        }else if (umidade >60 && umidade < 80)
        {
            return(80 - umidade)/20;
        }
        else
        {
            return 0;
        }
    }

    private double Alto(double umidade)
    {
        if(umidade >= 80)
        {
            return 1;
        }else if(umidade >60 && umidade < 80)
        {
            return(umidade - 60) / 20;
        }
        else
        {
            return 0;
        }
    }
    #endregion

    #region Lógica
    private double FuzzyInferencia(double temp, double umidade)
    {
        double frio = Frio(temp);
        double morno = Morno(temp);
        double quente = Quente(temp);

        double baixaUmidade = Baixa(umidade);
        double moderadaUmidade = Moderado(umidade);
        double altaUmidade = Alto(umidade);
        double velocidade = 0.0;


        velocidade = Math.Max(velocidade, Math.Min(frio, baixaUmidade));

        velocidade = Math.Max(velocidade, Math.Min(morno, moderadaUmidade));

        velocidade = Math.Max(velocidade, Math.Min(quente, altaUmidade));

        return velocidade;
    }

    public double CalcularVelocidade(double temp, double umidade)
    {
        return FuzzyInferencia(temp, umidade);
    }
    #endregion
}


public class Programa
{
    public static void Main()
    {
        Console.Write("Informe o valor da temperatura: ");
        double temperatura = Convert.ToDouble(Console.ReadLine());

        Console.Write("Informe o valor da umidade: ");
        double umidade = Convert.ToDouble(Console.ReadLine());

        LogicaFuzzy fuzzy = new LogicaFuzzy();
        double velocidade = fuzzy.CalcularVelocidade(temperatura, umidade);

        Console.WriteLine($"Velocidade do ventilador deve ficar em {velocidade}");
    }
}