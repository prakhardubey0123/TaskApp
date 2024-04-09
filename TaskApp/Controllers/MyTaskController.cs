using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskApp.Data;
using TaskApp.Models.DTO;

namespace TaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyTaskController : ControllerBase
    {
        public MyTaskController()
        {
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<MyTaskDTO>> GetAllTasks() 
        {
            return Ok(MyTaskStore.TaskList);
        }

        [HttpGet("{id:int}", Name = "GetMyTaskByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<MyTaskDTO> GetTasks(int id)
        {
            if(id== 0)
            {
                return BadRequest();
            }
            var taskbyid= MyTaskStore.TaskList.FirstOrDefault(x => x.Id == id);

            if(taskbyid== null)
            {
                return NotFound();
            }
            return Ok(taskbyid);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<MyTaskDTO> CreateTask([FromBody] MyTaskDTO mytasks) 
        {
            if(mytasks== null)
            {
                return BadRequest(mytasks);
            }
            if(mytasks.Id > 0) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            if(MyTaskStore.TaskList.FirstOrDefault(u=>u.TaskName.ToLower()== mytasks.TaskName.ToLower())!=null)
            {
                ModelState.AddModelError("Custom Error", "This task already exsists");
                return BadRequest(ModelState);
            }

            mytasks.Id= MyTaskStore.TaskList.OrderByDescending(x=>x.Id).FirstOrDefault().Id+1;
            MyTaskStore.TaskList.Add(mytasks);
            return Ok(mytasks);
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteByID")]

        public ActionResult DeleteTask(int id)
        {
            var mytasks=MyTaskStore.TaskList.FirstOrDefault(x=>x.Id==id);
            if (id==0)
            {
                return BadRequest();
            }
            if(mytasks==null)
            {
                return NotFound();
            }
            MyTaskStore.TaskList.Remove(mytasks);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        public ActionResult Updatetasks(int id, [FromBody]MyTaskDTO myTaskDTO ) 
        {
            if(myTaskDTO==null || id!= myTaskDTO.Id)
            {
                return BadRequest("This is not possible as id not exists with this");
            }
            var mytasks= MyTaskStore.TaskList.FirstOrDefault(u=>u.Id==id);
            if(mytasks==null)
            {
                ModelState.AddModelError("CustomError", "Not Possible as this id does not exist");
                    return BadRequest(ModelState);
            }
            mytasks.TaskName= myTaskDTO.TaskName;
            mytasks.TaskDescription= myTaskDTO.TaskDescription;
            return NoContent();
        }

    }
}
