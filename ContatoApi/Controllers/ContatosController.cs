using ContatoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace ContatoApi.Controllers
{
    public class ContatosController : Controller
    {
        // GET: Contatos
        public ActionResult Index()
        {
            IEnumerable<Contato> contatos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61785/api/");
                //aqui trago  o endereço da api pra ser consumnida

                //HTTP GET
                var responseTask = client.GetAsync("contatos");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Contato>>();
                    readTask.Wait();

                    contatos = readTask.Result;
                }
                else
                {
                    contatos = Enumerable.Empty<Contato>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(contatos);
            }
        }

        [HttpGet]
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(ContatoEndereco contato)
        {
            if (contato == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61785/api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<ContatoEndereco>("contatos", contato);
                postTask.Wait();
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");

            return View(contato);
        }

     

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Contato contato = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61785/api/");

                //HTTP GET
                var responseTask = client.GetAsync("?id=" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Contato>();
                    readTask.Wait();

                    contato = readTask.Result;
                }
            }

            return View(contato);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Contato contato = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61785/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("contatos/" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(contato);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Contato contato = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61785/api/");

                //HTTP GET
                var responseTask = client.GetAsync("?id=" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Contato>();
                    readTask.Wait();

                    contato = readTask.Result;
                }
            }
            return View(contato);
        }
    }

}



//