namespace InventoryMgmt.Models
{
    public class Inhouse : Part
    {
        public int MachineID { get; set; }
        public Inhouse(int partID, string name, double price, int inStock, int min, int max, int machineID)
            : base(partID, name, price, inStock, min, max)
        {
            MachineID = machineID;
        }
    }
}