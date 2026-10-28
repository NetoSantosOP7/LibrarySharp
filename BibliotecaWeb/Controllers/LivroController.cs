using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace BibliotecaWeb.Controllers
{
    public class LivroController : Controller
    {
        private readonly string connectionString;

        public LivroController(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BibliotecaDB");
        }
        public IActionResult Index()
        {
            var livros = LivroRepository.ObterLivros(connectionString);
            return View(livros);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(string Titulo, string Autor, int AnoPublicacao, bool Disponivel, IFormFile Imagem)
        {
            string caminhoImagem = null;

            if (Imagem != null && Imagem.Length > 0)
            {
                string nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(Imagem.FileName);
                string caminhoCompleto = Path.Combine("wwwroot/imagens", nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    Imagem.CopyTo(stream);
                }

                caminhoImagem = nomeArquivo;
            }

            LivroRepository.CriarLivro(connectionString, Titulo, Autor, AnoPublicacao, Disponivel, caminhoImagem);

            return RedirectToAction("Index");
        }

        public IActionResult Detalhes(int id)
        {
            var livro = LivroRepository.ObterLivroPorId(connectionString, id);

            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var livro = LivroRepository.ObterLivroPorId(connectionString, id);

            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        [HttpPost]
        public IActionResult Atualizar(string Titulo, string Autor, int AnoPublicacao, bool Disponivel, IFormFile Imagem, string CaminhoImagemAtual, int Id)
        {
            string caminhoImagem = CaminhoImagemAtual;

            if (Imagem != null && Imagem.Length > 0)
            {
                string nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(Imagem.FileName);
                string caminhoCompleto = Path.Combine("wwwroot/imagens", nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    Imagem.CopyTo(stream);
                }

                caminhoImagem = nomeArquivo;
            }

            LivroRepository.AtualizarLivro(connectionString, Titulo, Autor, AnoPublicacao, Disponivel, caminhoImagem, Id);
            return RedirectToAction("Index");
        }

        public IActionResult Deletar(int id)
        {
            LivroRepository.ExcluirLivro(connectionString, id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ReordenarLivros([FromBody] List<int> ids)
        {
            LivroRepository.AtualizarOrdem(connectionString, ids);
            return Ok();
        }
    }
}
