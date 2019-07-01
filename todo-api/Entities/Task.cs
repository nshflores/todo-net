using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todo_api.Entities {
  public class Task {
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Done { get; set; } = false;

    public Task (string name, string description = "", bool done = false) {
      this.Name = name;
      this.Description = description;
      this.Done = done;
    }
  }
}