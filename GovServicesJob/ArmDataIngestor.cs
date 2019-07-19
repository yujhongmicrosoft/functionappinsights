using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.Documents.Client;
using ParityServices.Common.Models;
using ParityServices.Common.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.ApplicationInsights;

namespace GovServicesJob
{
    public class ArmDataIngestor
    {
        public TelemetryClient telemetry;
        public ArmDataIngestor(TelemetryClient telemetryClient)
        {
            this.telemetry = telemetryClient;
        }

        //0 30 9 * * 1-5
        [FunctionName("ArmDataIngestor")]
        public async Task Run([TimerTrigger("0 */2 * * * *")]TimerInfo myTimer,
            ExecutionContext context)
           {
            var config = new ConfigurationBuilder()
            .SetBasePath(context.FunctionAppDirectory)
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

            Config jobConfig = config.GetSection("Config").Get<Config>();
           
            //TelemetryClient telemetry = new TelemetryClient();
            //telemetry.InstrumentationKey = System.Environment.GetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY");
            //telemetry.
            this.telemetry.TrackEvent("ParityServices Job Executed Successfully on :" + DateTime.UtcNow);

            //var client = new DocumentClient(new Uri(jobConfig.CosmosConfig.CosmosUri), jobConfig.CosmosConfig.CosmosKey);
            //var repo = new ParityRepository(client);
            //var secrets = new SecretsService(jobConfig.KVConfig);
            //var aad = new AzureAdService(secrets);
            //ArmClient armClient = new ArmClient(aad);
            //var orchestrator = new ParityOrchestrator(armClient, repo);
            //await orchestrator.ExecuteMainAnalysis();

        }
    }
}
