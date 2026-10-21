using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics;

public class Course
{
    public int Id { get; set; }

    public string Title { get; set; }

    public decimal Price { get; set; }

    public Course(int id, string title, decimal price)
    {
        Id = id;
        Title = title;
        Price = price;
    }
}
