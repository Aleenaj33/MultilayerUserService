using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using WCFOnionService.Infrastructure;

namespace WCFOnionService.Presentation
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet(UriTemplate = "users", ResponseFormat = WebMessageFormat.Json)]
        List<UserDTO> Get();

        [OperationContract]
        [WebGet(UriTemplate = "users/{id}", ResponseFormat = WebMessageFormat.Json)]
        UserDTO GetUserById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "users", 
                  RequestFormat = WebMessageFormat.Json, 
                  ResponseFormat = WebMessageFormat.Json)]
        bool InsertUser(UserDTO user);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "users", 
                  RequestFormat = WebMessageFormat.Json)]
        void UpdateUser(UserDTO user);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "users/{id}")]
        void DeleteUser(string id);
    }
}