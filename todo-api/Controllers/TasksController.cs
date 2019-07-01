using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using todo_api.Entities;
using System.Net;
using Newtonsoft.Json;

namespace todo_api.Controllers{

  [Route("/api/[controller]")]
  [ApiController]
  public class TasksController : ControllerBase {
    private const string V = "hola";
    private TodoContext _context;
    public TasksController(TodoContext context) {
      _context = context;
    }

    // GET /api/tasks
    [HttpGet]
    public ActionResult<IEnumerable<Task>> GetAll() {
      return _context.Tasks.ToList();
    }

    // POST /api/tasks
    [HttpPost]
    public ActionResult<Task> create ([FromBody] Task taskObject) {
        Console.WriteLine(taskObject.Name, taskObject.Done);
        return taskObject;
    }

    [HttpGet("/api/tasks/{id}")]
    public ActionResult<Task> findOne (string id) {
      Console.WriteLine(id);

      return _context.Tasks.ToList().Find(t => {
        return t.Id == id;
      });
    }

    // PUT /api/tasks
    [HttpPut("/api/tasks/{id}")]
    public ActionResult<Task> update ([FromBody] Task taskObject, string id) {
      Console.WriteLine(id, taskObject.Name, taskObject.Done);
      return taskObject;
    }
  }
}