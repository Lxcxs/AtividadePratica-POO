using System;
using System.Collections.Generic;

namespace Trabalho
{
    public class AtividadeComplementar
    {
        public string nome;
        public int carga;
        public DateTime DataRealizacao;
        public List<Aluno> alunos;

        public AtividadeComplementar(string nome, int carga, DateTime DataRealizacao)
        {
            this.nome = nome;
            this.carga = carga;
            this.DataRealizacao = DataRealizacao;
            this.alunos = new List<Aluno>();
        }

        public void RegistrarAluno(Aluno aluno)
        {
            alunos.Add(aluno);
        }
    }

    public class Palestra : AtividadeComplementar
    {
        public string palestrante;

        public Palestra(string palestrante, string nome, int carga, DateTime DataRealizacao) : base(nome, carga, DataRealizacao)
        {
            this.palestrante = palestrante;
        }

        public override string ToString()
        {
            return $"Nome: {nome}, Carga: {carga}, Data de Realização: {DataRealizacao}";
        }
    }

    public class Minicurso : AtividadeComplementar
    {
        public string urlCertificado;

        public Minicurso(string urlCertificado, string nome, int carga, DateTime DataRealizacao) : base(nome, carga, DataRealizacao)
        {
            this.urlCertificado = urlCertificado;
        }
    }

    public class Aluno
    {
        public string nome;
        public string email;

        public Aluno(string nome, string email)
        {
            this.nome = nome;
            this.email = email;
        }
    }

    public class Registro
    {
        public DateTime DataValidacao;

        public void RegistrarAtividade(AtividadeComplementar atividade, Aluno aluno)
        {
            if (atividade.DataRealizacao > DataValidacao)
            {
                atividade.RegistrarAluno(aluno);
                Console.WriteLine("Aluno registrado na atividade!");
            }
            else
            {
                Console.WriteLine("Não é possível registrar a atividade. A data de realização é anterior à data de validação.");
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            DateTime data = DateTime.Now;
            Palestra palestra = new Palestra("Palestrante 1", "Palestra 1", 10, data);
            Registro registro = new Registro();
            registro.DataValidacao = DateTime.Now; // Definindo a data de validação como a data atual

            Aluno aluno = new Aluno("Mahtma Gandli", "mahtma.mah@glandi.com");
            registro.RegistrarAtividade(palestra, aluno);
        }
    }
}