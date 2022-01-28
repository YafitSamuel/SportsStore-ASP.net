using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportsStore.Controllers.api
{
    public class PanttsController : ApiController
    {
        ShoesStoreDataContextDataContext DC = new ShoesStoreDataContextDataContext();
        // GET: api/Pants
        public IHttpActionResult Get()
        {
            try
            {
                List<Clothing> ClothingList = DC.Clothings.Where(pantsItem=> pantsItem.TypeOfClothing=="Pants").ToList();
                return Ok(new { ClothingList });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Pants/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Clothing clothing = DC.Clothings.Where(pantsItem => pantsItem.TypeOfClothing == "Pants").First((pantsItem) => pantsItem.Id == id);
                return Ok(new { clothing });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: api/Pants
        public IHttpActionResult Post([FromBody] Clothing OnePants)
        {
            try
            {
                DC.Clothings.InsertOnSubmit(OnePants);
                DC.SubmitChanges();
                return Ok("Add");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Pants/5
        public IHttpActionResult Put(int id, [FromBody] Clothing Pants)
        {
            try
            {
                Clothing PantsToUpdate = DC.Clothings.Where(item => item.TypeOfClothing == "Pants").Single(pantsItem => pantsItem.Id == id);
                PantsToUpdate = Pants;
                DC.SubmitChanges();
                return Ok("Eddit");

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Pants/5
        public IHttpActionResult Delete(int id)
        {

            try
            {
                Clothing RemovePants = DC.Clothings.Where(item => item.TypeOfClothing == "Pants").First(pantsItem => pantsItem.Id == id);
                DC.Clothings.DeleteOnSubmit(RemovePants);
                DC.SubmitChanges();
                return Ok("Removed");
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
