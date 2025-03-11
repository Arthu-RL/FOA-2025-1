using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Academico.Models;
using System.IO;
using System.Security.AccessControl;

namespace Academico.Controllers
{
    [Route("Aluno")]
    public class AlunoController : Controller
    {
        //private readonly ApplicationDbContext _context;
        //private readonly IPasswordHasher<AlunoViewModel> _passwordHasher;
        private static List<AlunoViewModel> alunos = new List<AlunoViewModel>();

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            return View(alunos);
        }

        [HttpPost("New")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Name", "Email", "PasswordHash", "Telefone", "Endereco", 
            "Complemento", "Bairro", "Municipio", "Uf", "Cep")]
            AlunoViewModel aluno)
        {
            if (!ModelState.IsValid)
            {
                return View(aluno);
            }

            //aluno.PasswordHash = _passwordHasher.HashPassword(null, aluno.PasswordHash);

            //_context.Alunos.Add(new Aluno
            //{
            //    Name = aluno.Name,
            //    Email = aluno.Email,
            //    PasswordHash = aluno.PasswordHash,
            //    Telefone = aluno.Telefone,
            //    Endereco = aluno.Endereco,
            //    Complemento = aluno.Complemento,
            //    Bairro = aluno.Bairro,
            //    Municipio = aluno.Municipio,
            //    Uf = aluno.Uf,
            //    Cep = aluno.Cep
            //});

            alunos.Add(new AlunoViewModel
            {
                Id = alunos.Count,
                Name = aluno.Name,
                Email = aluno.Email,
                PasswordHash = aluno.PasswordHash,
                Telefone = aluno.Telefone,
                Endereco = aluno.Endereco,
                Complemento = aluno.Complemento,
                Bairro = aluno.Bairro,
                Municipio = aluno.Municipio,
                Uf = aluno.Uf,
                Cep = aluno.Cep
            });

            //await _context.SaveChangesAsync();

            return View();
        }

        [HttpGet("Edit")]
        public IActionResult Edit(int id)
        {
            if (id < 0 && id > alunos.Count)
            { return BadRequest("Id invalido"); }

            return View(alunos[id]);
        }

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id, Name, Email, Telefone, Endereco, Complemento, Bairro, Municipio, Uf, Cep")] AlunoViewModel aluno)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest("Algum campo invalido"); ;
            }

            alunos[aluno.Id] = aluno;
            return RedirectToAction("Details", "Aluno");
        }

        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            return View(alunos.ElementAt(id));
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= alunos.Count)
            { return BadRequest("Id invalido"); }

            return View(alunos.ElementAt(id));
        }

        [HttpPost("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id < 0 || id >= alunos.Count)
            { return BadRequest("Id invalido"); }

            alunos.Remove(alunos[id]);

            for (int i = 0; i < alunos.Count; i++)
            {
                alunos[i].Id = i;
            }

            return RedirectToAction("List", "Aluno");
        }
    }
}
