using System.Collections.Generic;



namespace Ivory.TesteEstagio.CampoMinado
{

    public struct Posicao {
        public int x;
        public int y;

        public Posicao(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }

    public class ResolveCampo
    {

        private string _tabuleiro;

        private string[,] campo = new string[9, 9];

        // private  List<Posicao> bombas = new List<Posicao>() {};
        private List<Posicao> fechados = new List<Posicao>() {};


        public ResolveCampo(string tabuleiro)
        {
            _tabuleiro = tabuleiro;

            limpa_tabuleiro();    //// prepara a String Tabuleiro para popular a matriz

            converte_tabuleiro_para_matriz();  /// popula a matriz com a String tabuleiro Tratada;

        }

        public void renova_tabuleiro(string tabuleiro)
        {
            _tabuleiro = tabuleiro;

            limpa_tabuleiro();

            converte_tabuleiro_para_matriz();

            // identifica_fechados();
        }

        public void marca_bombas(List<Posicao> bombas)
        {
            foreach (var bomba in bombas)
            {
                campo.SetValue("*", bomba.x, bomba.y);
            }
        }

        public string[,] getCampo(){
            return campo;
        }

        public List<Posicao> getFechados() {
            return fechados;
        }

        public void identifica_fechados(){
                
                fechados.Clear();
                for (int y = 0; y < 9; y++)
                {
    
                    for (int x = 0; x < 9; x++)
                    {
    
                        if (campo[x, y] == "-")
                        {
                            Posicao posicao = new Posicao(x, y);
                            fechados.Add(posicao);
                        }
    
                    }
    
                }
    
        }

        public void limpa_tabuleiro(){

            string tabuleiro_limpo = "";
            foreach (char value in _tabuleiro)
            {

                if (value == '0' || value == '1' || value == '2' || value == '3' || value == '4' || value == '-')
                {
                    tabuleiro_limpo += value;
                }

            }
            _tabuleiro = tabuleiro_limpo;
        }

        public void converte_tabuleiro_para_matriz(){
            int item = 0;
            for (int y = 0; y < 9; y++)
            {

                for (int x = 0; x < 9; x++)
                {

                    campo.SetValue(_tabuleiro[item].ToString(), x, y);
                    item++;

                }

            }
        }

        public override string ToString(){
            string aux = "";
            for (int y = 0; y < 9; y++)
            {

                for (int x = 0; x < 9; x++)
                {

                    aux += campo.GetValue(x, y);

                }
                aux += "\n";

            }
            return aux;
        }
    
        public List<Posicao> geraVizinhos(int x, int y){

            List<Posicao> vizinhos = new List<Posicao>() {
                new Posicao(x - 1, y - 1),
                new Posicao(x    , y - 1),
                new Posicao(x + 1, y - 1),
                new Posicao(x - 1, y),
                new Posicao(x + 1, y),
                new Posicao(x - 1, y + 1),
                new Posicao(x    , y + 1),
                new Posicao(x + 1, y + 1),
            };

            return vizinhos;
        }


    }
}
