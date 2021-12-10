using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_13
{
    class Tasks
    {
        private string[] tasks = { "задание 1", "задание 2", "задание 3", "задание 4", "задание 5", "задание 6", "задание 7", "задание 8", "задание 9", "задание 10" };
        private string this[int index]
        {
            get { return tasks[index]; }
        }
    }
}
