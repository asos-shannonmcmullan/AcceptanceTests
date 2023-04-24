using BDDFY;
using TestStack.BDDfy;

namespace Asos.Sct.CustomerThreshold.AcceptanceTests
{

    [Story(
        AsA = "Warehouse management system",
        IWant = "to get the price threshold for orders which require customs documentation",
        SoThat = "I can decide on which orders require customs documentation"
        )]


    public class AcceptanceTests
    {
        [Fact]
        public void RequestThresholdForExistingWarehouseAndDestination()
        {
            this.Given("Given a threshold exists for warehouse and destination ")
                .When("the request to get a customers thresholds for this warehouse and destination is received")
                .Then("the API returns a response with HTTP status code 200")
                .And("the response body contains the threshold for that warehouse and destination combination")
                ;
        }

        [Fact]
        public void RequestThresholdForExistingWarehouse()
        {
            this.Given("Given a threshold exists for warehouse and destination ")
                .When("the request to get a customers thresholds for this warehouse and destination is received")
                .Then("the API returns a response with HTTP status code 200")
                .And("the response body contains the threshold for that warehouse")
                ;
        }

        [Fact]
        public void RequestThresholdForNonExistingWarehouse()
        {
            this.Given("Given a threshold DOES NOT exist for warehouse and destination ")
                .When("the request to get a customers thresholds for this warehouse and destination is recieved")
                .Then("the API returns a response with HTTP status code 404")
                ;
        }

        [Fact]
        public void RequestThresholdForExistingWarehouseButNonExistingDestination()
        {
            this.Given("Given a threshold exists for warehouse but does not exists for the destination ")
                .When("the request to get a customers thresholds for this warehouse and destination is received")
                .Then("the API returns a response with HTTP status code 404")
                ;
        }

        [Fact]
        public void RequestThresholdButCannotConnectToDatabase()
        {
            this.Given("the customs threshold database is inaccessible")
                .When("the request to customers thresholds is received")
                .Then("the API returns a response with HTTP status code 500")
                ;
        }

        [Fact]
        public void HealthCheckSuccess()
        {
            this.Given("the customs threshold database is accessible")
                .When("the request to health check is received")
                .Then("the API returns a response with HTTP status code 200")
                ;
        }

        [Fact]
        public void HealthCheckFailure()
        {
            this.Given("the customs threshold database is inaccessible")
                .When("the request to health check is recieved")
                .Then("the API returns a response with HTTP status code 500")
                .And("the response body contains information indicating what is failing")
                ;
        }

    }
}