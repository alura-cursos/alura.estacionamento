using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Alura.Estacionamento.Modelos
{
    public class Veiculo
    {
        //Campos
        private string _placa;
        private string _proprietario;
        private TipoVeiculo _tipo;
        private string _ticket;

        public string IdTicket { get; set; }
        public string Ticket { get => _ticket; set => _ticket = value; }

        //Propriedades
        public string Placa
        {
            get
            {
                return _placa;
            }
            set
            {
                // Checa se o valor possui pelo menos 8 caracteres
                if (value.Length != 8)
                {
                    throw new FormatException(" Na formatação a placa deve possuir 8 caracteres");
                }
                for (int i = 0; i < 3; i++)
                {
                    //checa se os 3 primeiros caracteres são numeros
                    if (char.IsDigit(value[i]))
                    {
                        throw new FormatException("Os 3 primeiros caracteres devem ser letras somente!");
                    }
                }
                //checa o Hifem
                if (value[3] != '-')
                {
                    throw new FormatException("O 4° caractere deve ser um hífen");
                }
                //checa se os 3 primeiros caracteres são numeros
                for (int i = 4; i < 8; i++)
                {
                    if (!char.IsDigit(value[i]))
                    {
                        throw new FormatException("Entre 5º e 8º caractere deve-se ter um número!");
                    }
                }
                _placa = value;

            }
        }
        /// <summary>
        /// { get; set; } cria uma propriedade automática, ou seja,
        /// durante a compilação, é gerado um atributo para armazenar
        /// o valor da propriedade e os metodos get e set, respectivamente,
        /// lêem e escrevem diretamente no atributo gerado, sem
        /// qualquer validação. É um recurso útil, pois as propriedades
        /// permitem fazer melhor uso do recurso de Reflection do .Net
        /// Framework, entre outros benefícios.
        /// </summary>
        public string Cor { get; set; }
        public double Largura { get; set; }
        public double VelocidadeAtual { get; set; }
        public string Modelo { get; set; }
        public string Proprietario
        {
            get
            {
                return _proprietario;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new System.FormatException(" Nome de proprietário deve ter no mínimo 3 caracteres.");
                }
                _proprietario = value;
            }

        }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public TipoVeiculo Tipo { get => _tipo; set => _tipo = value; }

        //Métodos
        public void Acelerar(int tempoSeg)
        {
            this.VelocidadeAtual += (tempoSeg * 10);
        }

        public void Frear(int tempoSeg)
        {
            this.VelocidadeAtual -= (tempoSeg * 15);
        }

        //Construtor
        public Veiculo()
        {

        }

        public Veiculo(string proprietario)
        {
            Proprietario = proprietario;
        }

        public void AlterarDados(Veiculo veiculoAlterado)
        {
            this.Proprietario = veiculoAlterado.Proprietario;
            this.Modelo = veiculoAlterado.Modelo;
            this.Largura = veiculoAlterado.Largura;
            this.Cor = veiculoAlterado.Cor;

        }

        public override string ToString()
        {
            return $"Ficha do Veículo:\n " +
                    $"Tipo do Veículo: {this.Tipo.ToString()}\n " +
                    $"Proprietário: {this.Proprietario}\n" +
                    $"Modelo: {this.Modelo}\n" +
                    $"Cor: {this.Cor}\n" +
                    $"Placa: {this.Placa}\n";

        }



    }
}
