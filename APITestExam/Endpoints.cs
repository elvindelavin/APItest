using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestExam
{
    public class Endpoints
    {
        //Base url
        private const string baseUrl = "https://jsonplaceholder.typicode.com/";
        //API endpoint for todos
        public static string todos = $"{baseUrl}todos/1";
        //API endpoint for posts (with int paramter)
        public static string post(int id) => $"{baseUrl}posts/{id}";
        //API endpoint for post (with string paramater)
        public static string invalidpostpath(string letter) => $"{baseUrl}posts/{letter}";
    }
}
