namespace FrameworkTask.Models
{
    public class ComputeEngineModel
    {
        public int NumberOfInstances { get; set; }
        public string OperatingSystem { get; set; }
        public string ProvisioningModel { get; set; }
        public string Series { get; set; }
        public string MachineType { get; set; }
        public bool AddGPUs { get; set; }
        public string GPUType { get; set; }
        public int NumberOfGPUs { get; set; }
        public string LocalSSD { get; set; }
        public string DatacenterLocation { get; set; }
    }
}
