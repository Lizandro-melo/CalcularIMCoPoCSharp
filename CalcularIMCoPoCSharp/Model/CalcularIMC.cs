using System;


namespace CalcularIMCoPoCSharp.Model
{
    public class Usuario
    {
        private string nome;
        private float peso;
        private float altura;
        private float imcAtual;
        private float imcDesejavel;

        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public float Peso
        {
            get { return this.peso; }
            set { this.peso = value; }
        }

        public float Altura
        {
            get { return this.altura; }
            set { this.altura = value; }
        }

        public float IMCAtual
        {
            get { return this.imcAtual; }
            set { this.imcAtual = value; }
        }

        public float IMCDesejavel
        {
            get { return this.imcDesejavel; }
            set { this.imcDesejavel = value; }
        }
        
        public Usuario(string nome, float peso, float altura, float imcDesejavel)
        {
            this.Nome = nome;
            this.Peso = peso;
            this.Altura = altura;
            this.IMCDesejavel = imcDesejavel;
        }
    }

    public class CalcularIMC
	{

        private Usuario usuario;
        private List<float> mediasIMC = new List<float> { 18.5f, 24.9f, 30, 35};
        private float kgNecessarios;


        public CalcularIMC()
		{
			Console.WriteLine("Bem Vindo, essa é a sua calculadora de IMC!");
            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine();
			Console.Write("Digite seu peso: ");
			float peso = float.Parse(Console.ReadLine());
			Console.Write("Digite sua Altura: ");
			float altura = float.Parse(Console.ReadLine());
            Console.Write("Digite seu IMC desejavel: ");
			float IMCDesejavel = float.Parse(Console.ReadLine());
            this.usuario = new Usuario(nome, peso, altura, IMCDesejavel);
            float IMC = (float) Math.Round(this.efetuarOperacaoIMC(), 2);
            this.usuario.IMCAtual = IMC;
            this.calcularKgNecessario();
			Console.WriteLine($"Seu IMC é: {usuario.IMCAtual}");
            if (this.usuario.IMCAtual < this.mediasIMC[0])
            {
                this.abaixoDoPeso();
            }
            else if (this.usuario.IMCAtual < this.mediasIMC[1])
            {
                this.pesoNormal();
            }
            else if (this.usuario.IMCAtual < this.mediasIMC[2])
            {
                this.excessoDePeso();
            }
            else if (this.usuario.IMCAtual > this.mediasIMC[2] || this.usuario.IMCAtual < this.mediasIMC[3])
            {
                this.obesidade();
            }
            else
            {
                this.obesidadeExtrema();
            }
		}


		private float efetuarOperacaoIMC()
		{
            float peso = this.usuario.Peso;
            float altura = this.usuario.Altura;
			return peso / (altura * altura);
		}

        private void calcularKgNecessario()
        {
            float IMC = this.usuario.IMCDesejavel;
            float altura = this.usuario.Altura;
            float kgUsuario = this.usuario.Peso;
            float kgIdeial = IMC * altura * altura;
            if (kgIdeial > kgUsuario)
            {
                this.kgNecessarios = (float) Math.Round(kgIdeial - kgUsuario, 2);
            }
            else
            {
                this.kgNecessarios = (float) Math.Round(kgUsuario - kgIdeial, 2);
            }
        }

        private void abaixoDoPeso()
        {
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Você está abaixo do seu peso ideal.");
            Console.WriteLine($"Com base no que você informou, \nnós avaliamos que você precisa ganhar {this.kgNecessarios}kg \npara chegar em seu IMC desejavel!");
            Console.WriteLine("--------------------------------------------------------");
        }

        private void pesoNormal()
        {
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Você está bem!");
            Console.WriteLine($"Informamos que você está com um IMC muito bom!");
            Console.WriteLine("--------------------------------------------------------");
        }

        private void excessoDePeso()
        {
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Você está na cadegoria de excesso de Peso");
            Console.WriteLine($"Com base no que você informou, \nnós avaliamos que você precisa perder {this.kgNecessarios}kg \npara chegar em seu IMC desejavel!");
            Console.WriteLine("--------------------------------------------------------");
        }

        private void obesidade()
        {
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Você está na cadegoria da obesidade");
            Console.WriteLine($"Com base no que você informou, \nnós avaliamos que você precisa perder {this.kgNecessarios}kg \npara chegar em seu IMC desejavel!");
            Console.WriteLine("--------------------------------------------------------");
        }

        private void obesidadeExtrema()
        {
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Você está na cadegoria da obesidade extrema");
            Console.WriteLine($"Com base no que você informou, \nnós avaliamos que você precisa perder {this.kgNecessarios}kg \npara chegar em seu IMC desejavel!");
            Console.WriteLine("--------------------------------------------------------");
        }
	}

}

