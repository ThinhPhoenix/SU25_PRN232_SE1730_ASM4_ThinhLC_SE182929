using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DNATestingSystem.SoapAPIServices.ThinhLC.SoapModels;

[DataContract]
public partial class SampleThinhLc
{
    [DataMember]
    public int? SampleThinhLcid { get; set; }
    [DataMember]
    public int? ProfileThinhLcid { get; set; }
    [DataMember]
    public int? SampleTypeThinhLcid { get; set; }
    [DataMember]
    public int? AppointmentsTienDmid { get; set; }
    [DataMember]
    public string? Notes { get; set; }
    [DataMember]
    public bool? IsProcessed { get; set; }
    [DataMember]
    public int? Count { get; set; }
    [DataMember]
    public DateTime? CollectedAt { get; set; }
    [DataMember]
    public DateTime? CreatedAt { get; set; }
    [DataMember]
    public DateTime? UpdatedAt { get; set; }
    [DataMember]
    public DateTime? DeletedAt { get; set; }
    [DataMember]
    public virtual AppointmentsTienDm AppointmentsTienDm { get; set; } = null!;
    [DataMember]
    public virtual ProfileThinhLc ProfileThinhLc { get; set; } = null!;
    [DataMember]
    public virtual SampleTypeThinhLc SampleTypeThinhLc { get; set; } = null!;
}
