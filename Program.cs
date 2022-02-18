using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Ivory.TesteEstagio.CampoMinado
{
    class Program
    {

        static void Main(string[] args)
        {
            var campoMinado = new CampoMinado();
            Console.WriteLine("Início do jogo\n=========");
            Console.WriteLine(campoMinado.Tabuleiro);

              // Realize sua codificação a partir deste ponto, boa sorte!

            Console.WriteLine("\n");

            var resolveCampo = new ResolveCampo(campoMinado.Tabuleiro);

            /////////////////////////////
          
            List<Posicao> bombas = new List<Posicao>();  //// Marcando as Bombas
            var status = 0;


            while (status == 0){ ////// Enquanto o jogo possuir status "Em aberto", novas iterações acontecem;

                var campo = resolveCampo.getCampo();

                for (int y = 0; y < 9; y++)      ///// Percorre a Matriz do Campo Minado 
                {
                    for (int x = 0; x < 9; x++)
                    {
                        var num_fechados = 0;
                        var num_bombas = 0;
                        
                        List<Posicao> fechados = new List<Posicao>(); //// Armazena a Posição dos Vizinhos "fechados" de cada item na matriz
                        
                        if (campo[x,y] != "-" && campo[x,y] != "*" && x != 0 && x != 8 && y != 0 && y != 8)
                        {

                            var vizinhos = resolveCampo.geraVizinhos(x, y);   /////// Indica as coordenadas dos Vizinhos de cada item da matriz

                            foreach (var pos in vizinhos)  ///// Verifica quais vizinhos estão fechados, armazena as coordenadas destes e incrementa a contagem de fechados
                            {
                                if (campo[pos.x, pos.y] == "-"){  
                                    num_fechados++;
                                    fechados.Add(pos);
                                }
                                else if (campo[pos.x, pos.y] == "*"){  //// Verifica quantas bombas estão na vizinhança
                                    num_bombas++;
                                }
                                
                            }

                            if ((num_fechados + num_bombas).ToString() == campo[x,y]) ///// Verifica se a soma das bombas e posições fechadas, na vizinhança, é igual ao numero do campo, se for 
                            {                                                         ///// os campos fechados são marcados como bomba.         
                                foreach (var pos in fechados)
                                {
                                    campo.SetValue("*", pos.x, pos.y);
                                    bombas.Add(pos);
                                }
                            }
                            else if (num_bombas.ToString() == campo[x,y]){   //////// Verifica se o numero de bombas é igual ao numero do campo, caso positivo, todos os campos fechados na vizinhaça 
                                foreach (var pos in fechados)                //////// podem ser abertos;   
                                {
                                    campoMinado.Abrir(pos.y+1, pos.x+1);
                                }
                            }
                            var novo_tabuleiro = campoMinado.Tabuleiro;      /////// Atualiza o Tabuleiro para a próxima iteração;
                            resolveCampo.renova_tabuleiro(novo_tabuleiro);
                            resolveCampo.marca_bombas(bombas);
                            
                        }         
                    }
                }

                
                status = campoMinado.JogoStatus;
            }


            //////////////////////////////////////// Fim ///////////////////////////////////////////
                      

            if (status == 1){
                Console.WriteLine("Você ganhou!");
            }
            else if (status == 2){
                Console.WriteLine("Você perdeu!");
            }

            Console.WriteLine("\n");

            Console.WriteLine(resolveCampo);


        }
    }
}
