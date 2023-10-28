using System;


namespace CalcularIMCoPoCSharp.Model
{
    public class Usuario
    {
        private string nome;
        private float peso;
        private float altura;
        private float IMCAtual;
        private float IMCDesejavel;

        public Usuario(string nome, string peso, string altura, string IMCDesejavel)
        {
            this.setNome(nome);
            List<float> dados = this.converterOsDados(peso, altura, IMCDesejavel);
            this.setPesoAndAltura(dados[0], dados[1]);
            this.setIMCDesejavel(dados[2]);
        }

        public void setIMCAtual(float IMCAtual)
        {
            this.IMCAtual = IMCAtual;
        }

        public void setIMCDesejavel(float IMCDesejavel)
        {
            this.IMCDesejavel = IMCDesejavel;
        }

        public void setPesoAndAltura(float peso, float altura)
        {
            this.peso = peso;
            this.altura = altura;
        }

        private List<float> converterOsDados(string peso, string altura, string IMCDesejavel)
        {
            float pesoFLoat = float.Parse(peso);
            float alturaFLoat = float.Parse(altura);
            float imcDesejavelFLoat = float.Parse(IMCDesejavel);
            List<float> list = new List<float> { pesoFLoat, alturaFLoat, imcDesejavelFLoat};
            return list;
        }

        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public float getPeso()
        {
            return this.peso;
        }

        public float getAltura()
        {
            return this.altura;
        }

        public string getNome()
        {
            return this.nome;
        }

        public float getIMCAtual()
        {
            return this.IMCAtual;
        }

        public float getIMCDesejavel()
        {
            return this.IMCDesejavel;
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
			string peso = Console.ReadLine();
			Console.Write("Digite sua Altura: ");
			string altura = Console.ReadLine();
            Console.Write("Digite seu IMC desejavel: ");
			string IMCDesejavel = Console.ReadLine();
            this.usuario = new Usuario(nome, peso, altura, IMCDesejavel);
            float IMC = (float) Math.Round(this.efetuarOperacaoIMC(), 2);
            this.usuario.setIMCAtual(IMC);
            this.calcularKgNecessario();
			Console.WriteLine($"Seu IMC é: {usuario.getIMCAtual()}");
            if (this.usuario.getIMCAtual() < this.mediasIMC[0])
            {
                this.abaixoDoPeso();
            }
            else if (this.usuario.getIMCAtual() < this.mediasIMC[1])
            {
                this.pesoNormal();
            }
            else if (this.usuario.getIMCAtual() < this.mediasIMC[2])
            {
                this.excessoDePeso();
            }
            else if (this.usuario.getIMCAtual() > this.mediasIMC[2] || this.usuario.getIMCAtual() < this.mediasIMC[3])
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
            float peso = this.usuario.getPeso();
            float altura = this.usuario.getAltura();
			return peso / (altura * altura);
		}

        private void calcularKgNecessario()
        {
            float IMC = this.usuario.getIMCDesejavel();
            float altura = this.usuario.getAltura();
            float kgUsuario = this.usuario.getPeso();
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

