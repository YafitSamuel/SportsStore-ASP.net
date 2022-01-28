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
    public class ShirtController : ApiController
    {
        ShoesStoreDataContextDataContext DC = new ShoesStoreDataContextDataContext();
        // GET: api/Shirt
        public IHttpActionResult Get()
        {
            try
            {
                List<Clothing> ClothingList = DC.Clothings.Where(ShirtItem => ShirtItem.TypeOfClothing == "Shirts").ToList();
                return Ok(new { ClothingList });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Shirt/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Clothing clothing = DC.Clothings.Where(ShirtItem => ShirtItem.TypeOfClothing == "Shirts").First((ShirtItem) => ShirtItem.Id == id);
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

        // POST: api/Shirt
        public IHttpActionResult Post([FromBody] Clothing OneShirt)
        {
            try
            {
                DC.Clothings.InsertOnSubmit(OneShirt);
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

        // PUT: api/Shirt/5
        public IHttpActionResult Put(int id, [FromBody] Clothing Shirt)
        {
            try
            {
                Clothing ShirtToUpdate = DC.Clothings.Where(ShirtItem => ShirtItem.TypeOfClothing == "Shirts").Single(ShirtItem => ShirtItem.Id == id);
                ShirtToUpdate = Shirt;
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

        // DELETE: api/Shirt/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Clothing RemoveShirt = DC.Clothings.Where(ShirtItem => ShirtItem.TypeOfClothing == "Shirts").First(ShirtItem => ShirtItem.Id == id);
                DC.Clothings.DeleteOnSubmit(RemoveShirt);
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
