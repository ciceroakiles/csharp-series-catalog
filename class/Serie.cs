using System;

namespace series_catalog
{
    public class Serie : Base
    {
        private int ano { get; set; }
        private string titulo { get; set; }
        private string descricao { get; set; }
        private Genero genero { get; set; }
        private bool existe { get; set; }

        public Serie(int id, int ano, string titulo, string descricao, Genero genero)
        {
            this.id = id;
            this.ano = ano;
            this.titulo = titulo;
            this.descricao = descricao;
            this.genero = genero;
            
            // Atributo adicional apenas para checagem
            this.existe = true;
        }

        public int getId() {
            return this.id;
        }

        public string getTitulo() {
            return this.titulo;
        }

        // Apenas marcar o registro como excluído, sem excluir propriamente
        public void excluir() {
            this.existe = false;
        }

        public override string ToString() {
            string res = "";
            res += "Gênero: " + this.genero + Environment.NewLine;
            res += "Título: " + this.titulo + Environment.NewLine;
            res += "Descrição: " + this.descricao + Environment.NewLine;
            res += "Ano de lançamento: " + this.ano;
            return res;
        }
    }
}
