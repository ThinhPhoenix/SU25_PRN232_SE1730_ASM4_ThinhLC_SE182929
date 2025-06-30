using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DNATestingSystem.SoapAPIServices.ThinhLC.SoapModels;

[DataContract]
public partial class AppointmentsTienDm
{
    [DataMember]
    public int AppointmentsTienDmid { get; set; }
    [DataMember]
    public int UserAccountId { get; set; }
    [DataMember]
    public int ServicesNhanVtid { get; set; }
    [DataMember]
    public int AppointmentStatusesTienDmid { get; set; }
    [DataMember]
    public DateOnly AppointmentDate { get; set; }
    [DataMember]
    public TimeOnly AppointmentTime { get; set; }
    [DataMember]
    public string SamplingMethod { get; set; } = null!;
    [DataMember]
    public string? Address { get; set; }
    [DataMember]
    public string ContactPhone { get; set; } = null!;
    [DataMember]
    public string? Notes { get; set; }
    [DataMember]
    public DateTime? CreatedDate { get; set; }
    [DataMember]
    public DateTime? ModifiedDate { get; set; }
    [DataMember]
    public decimal TotalAmount { get; set; }
    [DataMember]
    public bool? IsPaid { get; set; }
    [DataMember]
    public virtual AppointmentStatusesTienDm AppointmentStatusesTienDm { get; set; } = null!;
    [DataMember]
    public virtual ICollection<SampleThinhLc> SampleThinhLcs { get; set; } = new List<SampleThinhLc>();
    [DataMember]
    public virtual ServicesNhanVt ServicesNhanVt { get; set; } = null!;
    [DataMember]
    public virtual SystemUserAccount UserAccount { get; set; } = null!;
}
