using System;

namespace Mymusic
{
    public class Musicas : EntidadeBase
    {
        // Atributos
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Artista { get; set; }
        private string Album { get; set; }
        private bool Excluido { get; set; }

        // Métodos
        public Musicas(int id, Genero genero, string titulo, string artista, string album)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Artista = artista;
            this.Album = album;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Artista: " + this.Artista + Environment.NewLine;
            retorno += "Album: " + this.Album + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}