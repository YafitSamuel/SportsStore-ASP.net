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
    public class SportEquipmentController : ApiController
    {
        ShoesStoreDataContextDataContext DataContxt = new ShoesStoreDataContextDataContext();
        // GET: api/SportEquipment
       

        public IHttpActionResult Get()
        {
            try
            { 
                List<sportEquipment> SportsEquipmentList = DataContxt.sportEquipments.ToList();
                return Ok(new { SportsEquipmentList });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/SportEquipment/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                sportEquipment OneEquipment = DataContxt.sportEquipments.First((Item) => Item.Id == id);
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

        // POST: api/SportEquipment
        public IHttpActionResult Post([FromBody] sportEquipment Equipment)
        {
            try
            {
                DataContxt.sportEquipments.InsertOnSubmit(Equipment);
                DataContxt.SubmitChanges();
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

        // PUT: api/SportEquipment/5
        public IHttpActionResult Put(int id, [FromBody] sportEquipment equipment)
        {
            try
            {
                sportEquipment EquipmentToUpdate = DataContxt.sportEquipments.Single(Item => Item.Id == id);
                EquipmentToUpdate = equipment;
                DataContxt.SubmitChanges();
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

        // DELETE: api/SportEquipment/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                sportEquipment RemoveEquipment = DataContxt.sportEquipments.First(Item => Item.Id == id);
                DataContxt.sportEquipments.DeleteOnSubmit(RemoveEquipment);
                DataContxt.SubmitChanges();
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
