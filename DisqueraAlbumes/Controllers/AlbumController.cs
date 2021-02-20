using DisqueraAlbumes.Domain.Entities;
using DisqueraAlbumesServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace DisqueraAlbumes.Controllers
{
    public class AlbumController : Controller
    {
        private AlbumServices services = new AlbumServices();
        // GET: Album
        public ActionResult Index()
        {
            var albumes = services.Get();
            return View(albumes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Album album)
        {
            HttpPostedFileBase FileBase = Request.Files[0];
            WebImage image = new WebImage(FileBase.InputStream);
            album.Foto = image.GetBytes();
            if (ModelState.IsValid)
            {
                services.Insert(album);
            }
            
            return View();
        }

        public ActionResult getImage(int id)
        {
            var albumes = services.Get(id);

            byte[] byteImage = albumes.Foto;

            MemoryStream memoryStream = new MemoryStream(byteImage); //Crea un flujo de datos de bytes que se guardan en la memoria ram
            Image image = Image.FromStream(memoryStream);

            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;

            return File(memoryStream, "image/jpg");
        }
    }
}