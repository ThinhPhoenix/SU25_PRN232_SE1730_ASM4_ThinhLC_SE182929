using DNATestingSystem.Services.ThinhLC;
using DNATestingSystem.SoapAPIServices.ThinhLC.SoapModels;
using System.ServiceModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DNATestingSystem.SoapAPIServices.ThinhLC.SoapServices
{
    [ServiceContract]
    public interface ISampleThinhLCSoapService
    {
        [OperationContract]
        Task<List<SampleThinhLc>> GetSampleThinhLCsAsync();
        [OperationContract]
        Task<SampleThinhLc> GetSampleThinhLCByIdAsync(int id);
        [OperationContract]
        Task<int> CreateSampleThinhLCAsync(SampleThinhLc sample);
        [OperationContract]
        Task<int> UpdateSampleThinhLCAsync(SampleThinhLc sample);
        [OperationContract]
        Task<int> DeleteSampleThinhLCAsync(int id);
    }

    public class SampleThinhLCSoapService : ISampleThinhLCSoapService
    {
        private readonly IServiceProviders _serviceProviders;
        public SampleThinhLCSoapService(IServiceProviders serviceProviders) => _serviceProviders = serviceProviders;

        public async Task<int> CreateSampleThinhLCAsync(SampleThinhLc sample)
        {
            try
            {
                // Configure JSON serialization options
                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

                // Serialize SOAP model to JSON
                var sampleJsonString = JsonSerializer.Serialize(sample, opt);

                // Deserialize to service layer model
                var serviceModel = JsonSerializer.Deserialize<DNATestingSystem.Repository.ThinhLC.Models.SampleThinhLc>(sampleJsonString, opt);

                if (serviceModel != null)
                {
                    var result = await _serviceProviders.SampleThinhLCService.CreateAsync(serviceModel);
                    return result;
                }
            }
            catch (Exception)
            {
                // Log exception if needed
            }

            return -1;
        }

        public async Task<int> DeleteSampleThinhLCAsync(int id)
        {
            try
            {
                var result = await _serviceProviders.SampleThinhLCService.RemoveAsync(id);
                return result ? 1 : 0;
            }
            catch (Exception)
            {
                // Log exception if needed
            }

            return -1;
        }

        public async Task<SampleThinhLc> GetSampleThinhLCByIdAsync(int id)
        {
            try
            {
                var sample = await _serviceProviders.SampleThinhLCService.GetByIdAsync(id);

                if (sample != null)
                {
                    // Configure JSON serialization options
                    var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

                    // Serialize the service layer model to JSON
                    var sampleJsonString = JsonSerializer.Serialize(sample, opt);

                    // Deserialize to SOAP model format
                    var result = JsonSerializer.Deserialize<SampleThinhLc>(sampleJsonString, opt);

                    return result ?? new SampleThinhLc();
                }
            }
            catch (Exception)
            {
                // Log exception if needed
            }

            return new SampleThinhLc();
        }

        public async Task<List<SampleThinhLc>> GetSampleThinhLCsAsync()
        {
            try
            {
                var samples = await _serviceProviders.SampleThinhLCService.GetAllAsync();

                // Configure JSON serialization options
                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

                // Serialize the service layer models to JSON
                var samplesJsonString = JsonSerializer.Serialize(samples, opt);

                // Deserialize to SOAP model format
                var result = JsonSerializer.Deserialize<List<SampleThinhLc>>(samplesJsonString, opt);

                return result ?? new List<SampleThinhLc>();
            }
            catch (Exception)
            {
                // Log exception if needed
            }

            return new List<SampleThinhLc>();
        }

        public async Task<int> UpdateSampleThinhLCAsync(SampleThinhLc sample)
        {
            try
            {
                // Configure JSON serialization options
                var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

                // Serialize SOAP model to JSON
                var sampleJsonString = JsonSerializer.Serialize(sample, opt);

                // Deserialize to service layer model
                var serviceModel = JsonSerializer.Deserialize<DNATestingSystem.Repository.ThinhLC.Models.SampleThinhLc>(sampleJsonString, opt);

                if (serviceModel != null)
                {
                    var result = await _serviceProviders.SampleThinhLCService.UpdateAsync(serviceModel);
                    return result;
                }
            }
            catch (Exception)
            {
                // Log exception if needed
            }

            return -1;
        }
    }
}
