using DisqueraAlbumes.Domain.Contexto;
using DisqueraAlbumes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisqueraAlbumesServices
{
    public class AlbumServices
    {
        public bool Insert(Album album)
        {
            bool respuesta = false;
            try
            {
                using (var contexto = new DisqueraAlbumesContext())
                {
                    contexto.Albumes.Add(album);
                    contexto.SaveChanges();
                    respuesta = true;
                }
            }

            catch (Exception ex)
            {

                string mensajeErr = ex.Message;
            }
            return respuesta;
        }

        public List<Album> Get()
        {
            List<Album> albumes = new List<Album>();
            try
            {
                using (var contexto = new DisqueraAlbumesContext())
                {
                    albumes = contexto.Albumes.ToList();
                    
                }
            }
            catch (Exception ex)
            {

                string mensajeErr = ex.Message;
            }
            return albumes;
        }

        public Album Get(int id)
        {
            Album albumes = new Album();
            try
            {
                using (var contexto = new DisqueraAlbumesContext())
                {
                    albumes = contexto.Albumes.FirstOrDefault(p => p.Id == id);
                }
            }
            catch (Exception ex)
            {


                string mensajeErr = ex.Message;
            }
            return albumes;
        }
    }
}
