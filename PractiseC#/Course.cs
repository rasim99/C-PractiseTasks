using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseC_
{
    internal class Course
    {
        private static int id = 1;
        public int Id { get; private set; }
        public string  Name { get; set; }
        public List<Group> Groups { get; private set; }
        public Course(string name)
        {
            Id = id++;
            Name = name;
            Groups = new List<Group>();
        }

        public void AddGroup(Group group)
        {
            Groups.Add(group);
        }

        public void GetAllGroupDetails()
        {
            foreach (var group in Groups)
            {
                group.GetDetails();
            }
        }
        public void DeleteGroup(Group group)
        {
            Groups.Remove(group);
        }

    }
}
