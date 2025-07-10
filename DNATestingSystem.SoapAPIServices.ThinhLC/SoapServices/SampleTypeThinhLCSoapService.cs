using DNATestingSystem.Repository.ThinhLC.Models;
using DNATestingSystem.Services.ThinhLC;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace DNATestingSystem.SoapAPIServices.ThinhLC.SoapServices
{
    [ServiceContract]
    public interface ISampleTypeThinhLCSoapService
    {
        [OperationContract]
        Task<List<SampleTypeThinhLc>> GetSampleTypeThinhLCsAsync();
        [OperationContract]
        Task<SampleTypeThinhLc> GetSampleTypeThinhLCByIdAsync(int id);
        [OperationContract]
        Task<int> CreateSampleTypeThinhLCAsync(SampleTypeThinhLc sampleType);
        [OperationContract]
        Task<int> UpdateSampleTypeThinhLCAsync(SampleTypeThinhLc sampleType);
        [OperationContract]
        Task<bool> DeleteSampleTypeThinhLCAsync(int id);
    }

    public class SampleTypeThinhLCSoapService : ISampleTypeThinhLCSoapService
    {
        private readonly ISampleTypeThinhLCService _service;
        public SampleTypeThinhLCSoapService(ISampleTypeThinhLCService service)
        {
            _service = service;
        }
        public async Task<List<SampleTypeThinhLc>> GetSampleTypeThinhLCsAsync()
            => await _service.GetAllAsync();
        public async Task<SampleTypeThinhLc> GetSampleTypeThinhLCByIdAsync(int id)
            => await _service.GetByIdAsync(id);
        public async Task<int> CreateSampleTypeThinhLCAsync(SampleTypeThinhLc sampleType)
        {
            sampleType.CreatedAt = System.DateTime.Now;
            sampleType.UpdatedAt = System.DateTime.Now;
            return await _service.CreateAsync(sampleType);
        }
        public async Task<int> UpdateSampleTypeThinhLCAsync(SampleTypeThinhLc sampleType)
        {
            sampleType.UpdatedAt = System.DateTime.Now;
            return await _service.UpdateAsync(sampleType);
        }
        public async Task<bool> DeleteSampleTypeThinhLCAsync(int id)
            => await _service.RemoveAsync(id);
    }
}
