using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DNATestingSystem.SoapAPIServices.ThinhLC.SoapModels;

[DataContract]
public partial class SampleTypeThinhLc
{
    [DataMember]
    public int? SampleTypeThinhLcid { get; set; }
    [DataMember]
    public string? TypeName { get; set; } = null!;
    [DataMember]
    public string? Description { get; set; }
    [DataMember]
    public bool? IsActive { get; set; }
    [DataMember]
    public int? Count { get; set; }
    [DataMember]
    public DateTime? CreatedAt { get; set; }
    [DataMember]
    public DateTime? UpdatedAt { get; set; }
    [DataMember]
    public DateTime? DeletedAt { get; set; }
    [DataMember]
    public virtual ICollection<SampleThinhLc> SampleThinhLcs { get; set; } = new List<SampleThinhLc>();
}
