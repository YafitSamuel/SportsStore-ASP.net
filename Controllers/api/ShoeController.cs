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
    public class ShoeController : ApiController
    {

        ShoesStoreDataContextDataContext DC = new ShoesStoreDataContextDataContext();
        // GET: api/Shoe
        public IHttpActionResult Get()
        {
            try
            {
                List<Shoe> ShoesList = DC.Shoes.ToList();
                return Ok(new { ShoesList });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Shoe/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Shoe OneShoe = DC.Shoes.First((shoeItem) => shoeItem.Id == id);
                return Ok(new { OneShoe });
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

        // POST: api/Shoe
        public IHttpActionResult Post([FromBody]Shoe Shoe)
        { 
            try
            {
                DC.Shoes.InsertOnSubmit(Shoe);
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

        // PUT: api/Shoe/5
        public IHttpActionResult Put(int id, [FromBody] Shoe shoe)
        {
            try
            {
                Shoe ShoeToUpdate = DC.Shoes.Single(shoeItem => shoeItem.Id == id);
                ShoeToUpdate = shoe;
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

        // DELETE: api/Shoe/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Shoe RemoveShoe = DC.Shoes.First(OldItem => OldItem.Id == id);
                DC.Shoes.DeleteOnSubmit(RemoveShoe);
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
