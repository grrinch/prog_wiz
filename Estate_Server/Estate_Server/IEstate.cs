using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Estate_Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEstate
    {
        /*[OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);*/

        [OperationContract]
        String echo();

        [OperationContract]
        String test();

        [OperationContract]
        String GetAllEstates();

        [OperationContract]
        String GetEstateById(int id);

        [OperationContract]
        String GetEstatesByAgentId(int id);

        [OperationContract]
        String GetEstatesByAgentName(string partialAgentName);

        [OperationContract]
        String GetEstatesByCityId(int id);

        [OperationContract]
        String GetEstatesByCityName(string partialCityName);

        [OperationContract]
        String GetCities();

        [OperationContract]
        String GetAgents();

        [OperationContract]
        String GetEstates();
    }

    // rozwiązanie znalezione na http://stackoverflow.com/questions/1731189/wcf-problem-sending-object-to-client
    // This class has the method named GetKnownTypes that returns a generic IEnumerable.
    static class Helper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            System.Collections.Generic.List<System.Type> knownTypes =
                new System.Collections.Generic.List<System.Type>();
            // Add any types to include here.
            knownTypes.Add(typeof(DataTable));
            //knownTypes.Add(typeof(Hashtable));
            //knownTypes.Add(typeof(List<DataRow>));
            return knownTypes;
        }
    }



    /*
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "Estate_Server.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }*/
}
