namespace DemolitionFalcons.Service.Front
{
    public class WeaponFront
    {
        public WeaponFront(string name, int damage, string core)
        {
            this.Name = name;
            this.Damage = damage;
            this.Core = core;
        }


        //public int Id { get; set; }
        
        public string Name { get; set; }

        public int Damage { get; set; }

        public string Core { get; set; }
    }
}
