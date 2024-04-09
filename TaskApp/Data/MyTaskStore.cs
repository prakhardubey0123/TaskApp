using TaskApp.Models.DTO;

namespace TaskApp.Data
{
    public class MyTaskStore
    {
        public static List<MyTaskDTO> TaskList=new List<MyTaskDTO>
        {
            new MyTaskDTO
            {
                Id = 1,
                TaskName= "DemoTask1",
                TaskDescription="This is Demo Task 1"
            },
            new MyTaskDTO
            {
                Id=2,
                TaskName="DemoTask2",
                TaskDescription="This is Demotask2"
            }
        };
    }
}
