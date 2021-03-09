using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc; 

namespace indiminchallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class TaskController : ControllerBase
    { 

        private readonly ApiDbContext _context;

        public TaskController(ApiDbContext context)
        {
            _context = context;
        }

 
        [HttpGet]
        public ActionResult<List<Task>> Get()
        {

            try
            {

                return _context.Tasks.ToList();
            }
            catch (Exception Error)
            {
                return BadRequest(Error);
            }
        }
        [HttpGet("/api/task/detail/")]
        public ActionResult<List<Task>> GetByCityzen(int id)
        {

            try
            {

                return _context.Tasks.Where(  b => b.CitizenId==id).Select((c) => new Task{
                        Id= c.Id,
                        Description =  c.Description,
                        CitizenId =  c.CitizenId,
                        Day = c.Day,
                        Month = c.Month,
                        Year = c.Year
                    }).ToList();


            }
            catch (Exception Error)
            {
                return BadRequest(Error);
            }
        }

        [HttpPost]
        public IActionResult Create(Task model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Citizen citizen = _context.Citizens.Where(p => p.Id == model.CitizenId).FirstOrDefault();

                    if (citizen == null)
                    {
                         return BadRequest();
                        
                    }
                    else
                    {
                       _context.Tasks.Add(model);
                        _context.SaveChanges();
                        return Ok();
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
        public IActionResult Update(Task model)
        {
            {
                if (0 == model.Id)
                    return BadRequest();
                try
                {

                    var trackedEntity = _context.Tasks.Update(model);
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
                 Task task = _context.Tasks.Where(p => p.Id == Id).FirstOrDefault();

            if (task != null)
            {
                _context.Tasks.Remove(task);
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
