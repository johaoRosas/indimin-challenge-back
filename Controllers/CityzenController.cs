using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace indiminchallenge.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class CityzenController : ControllerBase
    {

        private readonly ApiDbContext _context;

        public CityzenController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Citizen>> Get()
        {

            try
            {

                return _context.Citizens.ToList();
            }
            catch (Exception Error)
            {
                return BadRequest(Error);
            }
        }

        [HttpPost]
        public IActionResult Create(Citizen model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Citizen citizen = _context.Citizens.Where(p => p.Email.Trim() == model.Email.Trim()).FirstOrDefault();
                    if (citizen == null)
                    {
                        _context.Citizens.Add(model);
                        _context.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Citizen model)
        {
            {
                if (0 == model.Id)
                    return BadRequest();
                try
                {

                    var trackedEntity = _context.Citizens.Update(model);
                    _context.SaveChanges();
                }
                catch (Exception Error)
                {
                    return BadRequest(Error);
                }
                return Ok();
            }
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            try
            {
                 Citizen citizen = _context.Citizens.Where(p => p.Id == Id).FirstOrDefault();

            if (citizen != null)
            {
                _context.Citizens.Remove(citizen);
                _context.SaveChanges();
                
            }
            }
            catch(Exception Error)
            {
                
                 return BadRequest(Error);
            }

             return Ok();
           
        }
    }
}
