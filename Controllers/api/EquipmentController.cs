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
    public class EquipmentController : ApiController
    {
        ShoesStoreDataContextDataContext DC = new ShoesStoreDataContextDataContext();
        // GET: api/Equipment
        public IHttpActionResult Get()
        {
            try
            {
                List<SportsEquipment> SportsEquipmentList = DC.SportsEquipments.ToList();
                return Ok(new { SportsEquipmentList });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Equipment/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                SportsEquipment OneEquipment = DC.SportsEquipments.First((Item) => Item.Id == id);
                return Ok(new { OneEquipment });
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

        // POST: api/Equipment
        public IHttpActionResult Post([FromBody] SportsEquipment Equipment)
        {
            try
            {
                DC.SportsEquipments.InsertOnSubmit(Equipment);
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

        // PUT: api/Equipment/5
        public IHttpActionResult Put(int id, [FromBody] SportsEquipment equipment)
        {
            try
            {
                SportsEquipment EquipmentToUpdate = DC.SportsEquipments.Single(Item => Item.Id == id);
              EquipmentToUpdate = equipment;
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

        // DELETE: api/Equipment/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                SportsEquipment RemoveEquipment = DC.SportsEquipments.First(Item => Item.Id == id);
                DC.SportsEquipments.DeleteOnSubmit(RemoveEquipment);
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
