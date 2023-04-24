using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using RestSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Asos.Sct.CustomerThreshold.AcceptanceTests.Models;

namespace BDDFY.TESTS
{
    [TestClass]
    public class Tests
    {
        private RestClient _client;
        private RestRequest _request;

        [TestInitialize]
        public void Setup()
        {
            _client = new RestClient();
            _request = new RestRequest("/scdsl/customsplatform/v1/getcustomsthresholds", Method.Post);
        }

        [TestMethod]
        public async Task GivenThresholdExistsForWarehouseAndDestination_WhenTheRequestIsSent_ThenTheResponseShouldBeOk_AndResponseContainsThresholdForWarehouseAndDestinationCombination()
        {
            var body = new CustomsThresholdRequestModel()
            {
                warehouseid = "",
                destinationIS03CountryCode = ""
            };

            _request.AddBody(body);

            var response = await _client.ExecuteAsync(_request);
            var deserialised = JsonConvert.DeserializeObject<CustomsThresholdResponseModel>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(body.destinationIS03CountryCode, deserialised.destinationIS03CountryCode);
            Assert.AreEqual(body.warehouseid, deserialised.warehouseid);
            //how to check if response contains threshold for destination and warehouse combination?
        }

        [TestMethod]
        public async Task GivenThresholdExistsForWarehouse_WhenTheRequestIsSent_ThenTheResponseShouldBeOk_AndResponseContainsAllThresholdsForWarehouse()
        {
            var body = new CustomsThresholdRequestModel()
            {
                warehouseid = ""
            };

            _request.AddBody(body);

            var response = await _client.ExecuteAsync(_request);
            var deserialised = JsonConvert.DeserializeObject<CustomsThresholdResponseModel>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode );
            Assert.AreEqual(body.destinationIS03CountryCode, deserialised.destinationIS03CountryCode);
            //Unsure how to check if response contains all thresholds for given warehouse?
        }

        [TestMethod]
        public async Task GivenThresholdDoesNotExistForWarehouseAndDestination_WhenTheRequestIsSent_ThenTheResponseStatusCodeShouldBe404NotFound()
        {
            var body = new CustomsThresholdRequestModel()
            {
                warehouseid = "",
                destinationIS03CountryCode = ""
            };

            _request.AddBody(body);

            var response = await _client.ExecuteAsync(_request);
            var deserialised = JsonConvert.DeserializeObject<CustomsThresholdResponseModel>(response.Content);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task GivenThresholdExistsForWarehouseButNotForDestination_WhenTheRequestIsSent_ThenTheResponseStatusCodeShouldBe404NotFound()
        {
            var body = new CustomsThresholdRequestModel()
            {
                warehouseid = "",
                destinationIS03CountryCode = ""
            };

            _request.AddBody(body);

            var response = await _client.ExecuteAsync(_request);
            var deserialised = JsonConvert.DeserializeObject<CustomsThresholdResponseModel>(response.Content);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public async Task GivenCustomsThresholdDatabaseIsInaccessible_WhenTheRequestIsSent_ThenTheResponseStatusCodeShouldBe500InternalServerError()
        {
            var body = new CustomsThresholdRequestModel()
            {
                warehouseid = "",
                destinationIS03CountryCode = ""
            };

            _request.AddBody(body);

            var response = await _client.ExecuteAsync(_request);

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [TestMethod]
        public async Task GivenTheCustomsDatabaseIsAccessible_WhenTheRequestToHealthCheckIsReceived_ThenTheResponseStatusCodeShouldBe200Ok()
        {
            var body = new CustomsThresholdRequestModel()
            {
                warehouseid = "",
                destinationIS03CountryCode = ""
            };

            _request.AddBody(body);

            var response = await _client.ExecuteAsync(_request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GivenTheCustomsThresholdDatabaseIsInaccessible_WhenTheRequestToHealthCheckIsReceived_ThenTheResponseStatusCodeShouldBe500InternalServerError_AndContainsInformationIndicatingWhatIsFailing()
        {
            var body = new CustomsThresholdRequestModel()
            {
                warehouseid = "",
                destinationIS03CountryCode = ""
            };

            _request.AddBody(body);

            var response = await _client.ExecuteAsync(_request);

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
            //Unsure how to check if response body contains information indicating what is failing??
        }

    }
}
