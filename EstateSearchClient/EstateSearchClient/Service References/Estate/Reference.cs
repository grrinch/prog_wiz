﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EstateSearchClient.Estate {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Estate.IEstate")]
    public interface IEstate {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/echo", ReplyAction="http://tempuri.org/IEstate/echoResponse")]
        string echo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/echo", ReplyAction="http://tempuri.org/IEstate/echoResponse")]
        System.Threading.Tasks.Task<string> echoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/test", ReplyAction="http://tempuri.org/IEstate/testResponse")]
        string test();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/test", ReplyAction="http://tempuri.org/IEstate/testResponse")]
        System.Threading.Tasks.Task<string> testAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/GetAllEstates", ReplyAction="http://tempuri.org/IEstate/GetAllEstatesResponse")]
        string GetAllEstates();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/GetAllEstates", ReplyAction="http://tempuri.org/IEstate/GetAllEstatesResponse")]
        System.Threading.Tasks.Task<string> GetAllEstatesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/GetEstateById", ReplyAction="http://tempuri.org/IEstate/GetEstateByIdResponse")]
        string GetEstateById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/GetEstateById", ReplyAction="http://tempuri.org/IEstate/GetEstateByIdResponse")]
        System.Threading.Tasks.Task<string> GetEstateByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/GetEstatesByAgentId", ReplyAction="http://tempuri.org/IEstate/GetEstatesByAgentIdResponse")]
        string GetEstatesByAgentId(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/GetEstatesByAgentId", ReplyAction="http://tempuri.org/IEstate/GetEstatesByAgentIdResponse")]
        System.Threading.Tasks.Task<string> GetEstatesByAgentIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/GetEstatesByAgentName", ReplyAction="http://tempuri.org/IEstate/GetEstatesByAgentNameResponse")]
        string GetEstatesByAgentName(string partialAgentName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/GetEstatesByAgentName", ReplyAction="http://tempuri.org/IEstate/GetEstatesByAgentNameResponse")]
        System.Threading.Tasks.Task<string> GetEstatesByAgentNameAsync(string partialAgentName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/GetEstatesByCityId", ReplyAction="http://tempuri.org/IEstate/GetEstatesByCityIdResponse")]
        string GetEstatesByCityId(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/GetEstatesByCityId", ReplyAction="http://tempuri.org/IEstate/GetEstatesByCityIdResponse")]
        System.Threading.Tasks.Task<string> GetEstatesByCityIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/GetEstatesByCityName", ReplyAction="http://tempuri.org/IEstate/GetEstatesByCityNameResponse")]
        string GetEstatesByCityName(string partialCityName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/GetEstatesByCityName", ReplyAction="http://tempuri.org/IEstate/GetEstatesByCityNameResponse")]
        System.Threading.Tasks.Task<string> GetEstatesByCityNameAsync(string partialCityName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/GetCities", ReplyAction="http://tempuri.org/IEstate/GetCitiesResponse")]
        string GetCities();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/GetCities", ReplyAction="http://tempuri.org/IEstate/GetCitiesResponse")]
        System.Threading.Tasks.Task<string> GetCitiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/GetAgents", ReplyAction="http://tempuri.org/IEstate/GetAgentsResponse")]
        string GetAgents();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/GetAgents", ReplyAction="http://tempuri.org/IEstate/GetAgentsResponse")]
        System.Threading.Tasks.Task<string> GetAgentsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/GetEstates", ReplyAction="http://tempuri.org/IEstate/GetEstatesResponse")]
        string GetEstates();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEstate/GetEstates", ReplyAction="http://tempuri.org/IEstate/GetEstatesResponse")]
        System.Threading.Tasks.Task<string> GetEstatesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEstateChannel : EstateSearchClient.Estate.IEstate, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EstateClient : System.ServiceModel.ClientBase<EstateSearchClient.Estate.IEstate>, EstateSearchClient.Estate.IEstate {
        
        public EstateClient() {
        }
        
        public EstateClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EstateClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EstateClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EstateClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string echo() {
            return base.Channel.echo();
        }
        
        public System.Threading.Tasks.Task<string> echoAsync() {
            return base.Channel.echoAsync();
        }
        
        public string test() {
            return base.Channel.test();
        }
        
        public System.Threading.Tasks.Task<string> testAsync() {
            return base.Channel.testAsync();
        }
        
        public string GetAllEstates() {
            return base.Channel.GetAllEstates();
        }
        
        public System.Threading.Tasks.Task<string> GetAllEstatesAsync() {
            return base.Channel.GetAllEstatesAsync();
        }
        
        public string GetEstateById(int id) {
            return base.Channel.GetEstateById(id);
        }
        
        public System.Threading.Tasks.Task<string> GetEstateByIdAsync(int id) {
            return base.Channel.GetEstateByIdAsync(id);
        }
        
        public string GetEstatesByAgentId(int id) {
            return base.Channel.GetEstatesByAgentId(id);
        }
        
        public System.Threading.Tasks.Task<string> GetEstatesByAgentIdAsync(int id) {
            return base.Channel.GetEstatesByAgentIdAsync(id);
        }
        
        public string GetEstatesByAgentName(string partialAgentName) {
            return base.Channel.GetEstatesByAgentName(partialAgentName);
        }
        
        public System.Threading.Tasks.Task<string> GetEstatesByAgentNameAsync(string partialAgentName) {
            return base.Channel.GetEstatesByAgentNameAsync(partialAgentName);
        }
        
        public string GetEstatesByCityId(int id) {
            return base.Channel.GetEstatesByCityId(id);
        }
        
        public System.Threading.Tasks.Task<string> GetEstatesByCityIdAsync(int id) {
            return base.Channel.GetEstatesByCityIdAsync(id);
        }
        
        public string GetEstatesByCityName(string partialCityName) {
            return base.Channel.GetEstatesByCityName(partialCityName);
        }
        
        public System.Threading.Tasks.Task<string> GetEstatesByCityNameAsync(string partialCityName) {
            return base.Channel.GetEstatesByCityNameAsync(partialCityName);
        }
        
        public string GetCities() {
            return base.Channel.GetCities();
        }
        
        public System.Threading.Tasks.Task<string> GetCitiesAsync() {
            return base.Channel.GetCitiesAsync();
        }
        
        public string GetAgents() {
            return base.Channel.GetAgents();
        }
        
        public System.Threading.Tasks.Task<string> GetAgentsAsync() {
            return base.Channel.GetAgentsAsync();
        }
        
        public string GetEstates() {
            return base.Channel.GetEstates();
        }
        
        public System.Threading.Tasks.Task<string> GetEstatesAsync() {
            return base.Channel.GetEstatesAsync();
        }
    }
}
