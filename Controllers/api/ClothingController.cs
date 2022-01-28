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
    public class ClothingController : ApiController
    {
        ShoesStoreDataContextDataContext DC = new ShoesStoreDataContextDataContext();
        // GET: api/Clothing
        public IHttpActionResult Get()
        {
            try
            {
                List<Clothing> ClothingList = DC.Clothings.ToList();
                return Ok(new { ClothingList });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Clothing/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Clothing clothing = DC.Clothings.First((clothingItem) => clothingItem.Id == id);
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

        // POST: api/Clothing
        public IHttpActionResult Post([FromBody]Clothing OneClothing)
        {
            try
            {
                DC.Clothings.InsertOnSubmit(OneClothing);
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

        // PUT: api/Clothing/5
        public IHttpActionResult Put(int id , [FromBody]Clothing clothing)
        {
            try
            {
                Clothing clothingToUpdate = DC.Clothings.Single(clothingItem => clothingItem.Id == id);
                clothingToUpdate = clothing;
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

        // DELETE: api/Clothing/5
        public IHttpActionResult Delete(int id)
        {

            try
            {
                Clothing RemoveClothing = DC.Clothings.First(ClothingItem => ClothingItem.Id == id);
                DC.Clothings.DeleteOnSubmit(RemoveClothing);
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
