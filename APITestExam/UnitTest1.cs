using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace APITestExam
{
    [TestClass]
    public class UnitTest1
    {
        private readonly RestClient apiClient = new RestClient();

        // Validate todos endpoint
        [TestMethod]
        public void GetTodos()
        {
            var request = new RestRequest(Endpoints.todos);
            var result = apiClient.GetAsync<TodosJsonModel>(request);
            Assert.AreEqual("delectus aut autem", result.Result.Title);
            Assert.AreEqual((int)HttpStatusCode.OK, 200);
        }

        //Validate post endpoint using valid parameter (id)
        [TestMethod]
        public void GetPost()
        {            
            var request = new RestRequest(Endpoints.post(2));
            var result = apiClient.GetAsync<PostJsonModel>(request);
            Assert.AreEqual("qui est esse", result.Result.Title);
            Assert.AreEqual("est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla", result.Result.Body);
            Assert.AreEqual((int)HttpStatusCode.OK, 200);
        }

        //Validate post endpoint using invalid parameter
        [TestMethod]
        public void GetInvalidPostPath()
        {
            var request = new RestRequest(Endpoints.invalidpostpath("a"));
            var result =  apiClient.GetAsync<PostJsonModel>(request);
            Assert.AreEqual((int)HttpStatusCode.NotFound, 404);
        }
    }
}
