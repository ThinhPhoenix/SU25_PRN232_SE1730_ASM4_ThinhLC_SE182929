using DNATestingSystem.Repository.ThinhLC.Basic;
using DNATestingSystem.Repository.ThinhLC.DBContext;
using DNATestingSystem.Repository.ThinhLC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATestingSystem.Repository.ThinhLC
{
    public class SampleTypeThinhLCRepository : GenericRepository<SampleTypeThinhLc>
    {
        public SampleTypeThinhLCRepository() { }
        public SampleTypeThinhLCRepository(Se18Prn232Se1730G3DnatestingSystemContext context) => _context = context;

        public async Task<int> UpdateAsync(SampleTypeThinhLc sampleType)
        {
            var existing = await _context.SampleTypeThinhLcs.FindAsync(sampleType.SampleTypeThinhLcid);
            if (existing == null) return -1;
            existing.TypeName = sampleType.TypeName;
            existing.Description = sampleType.Description;
            existing.IsActive = sampleType.IsActive;
            existing.Count = sampleType.Count;
            existing.CreatedAt = sampleType.CreatedAt;
            existing.UpdatedAt = DateTime.Now;
            existing.DeletedAt = sampleType.DeletedAt;
            return await _context.SaveChangesAsync();
        }
        public async Task<int> CreateAsync(SampleTypeThinhLc sampleType)
        {
            _context.SampleTypeThinhLcs.Add(sampleType);
            return await _context.SaveChangesAsync();
        }
        public async Task<bool> RemoveAsync(SampleTypeThinhLc sampleType)
        {
            _context.SampleTypeThinhLcs.Remove(sampleType);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<SampleTypeThinhLc> GetByIdAsync(int id)
        {
            return await _context.SampleTypeThinhLcs.FindAsync(id) ?? new SampleTypeThinhLc();
        }
        public async Task<List<SampleTypeThinhLc>> GetAllAsync()
        {
            return await _context.SampleTypeThinhLcs.ToListAsync();
        }
    }
}
