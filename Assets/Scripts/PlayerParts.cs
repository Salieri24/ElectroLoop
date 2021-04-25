namespace Assets.Scripts.PlayerScripts
{
    public class PlayerParts
    {
        public float thrust;
        public float maxSpeed;
        public float mass;

        public float energyCost = 0;
        public float energyGenerate = 0;
        public float maxEnergy = 5;

        private Dynamo dynamo;
        private Battery battery;
        private Engine engine;

        //setters and getters

        //dynamo
        public void setDynamo(Dynamo d)
        {
            if(dynamo != null)
            {
                removeDynamo();
            }

            dynamo = d;
            mass += d.mass;
            energyGenerate = d.energyGeneration;
        }
        public Dynamo getDynamo()
        {
            return dynamo;
        }
        public void removeDynamo()
        {
            if (dynamo != null) { 
            mass -= dynamo.mass;
            energyGenerate -= dynamo.energyGeneration;
            dynamo = null;
            }
        }
        //Battery
        public void SetBattery(Battery b)
        {
            if(battery != null)
            {
                removeBattery();
            }
            this.battery = b;
            this.mass += b.mass;
            this.maxEnergy += b.maxEnergy;
        }
        public Battery GetBattery()
        {
            return battery;
        }
        public void removeBattery()
        {
            if (battery != null) { 
            mass -= battery.mass;
            maxEnergy -= maxEnergy;
            battery = null;
            }
        }
        //Engine
        public void SetEngine(Engine e)
        {
            if (engine != null)
            {
                this.removeEngine();
            }
            this.engine = e;
            this.energyCost += e.energyCost;
            this.mass += e.mass;
            this.maxSpeed += e.maxSpeed;
            this.thrust += e.thrust;
        }
        public Engine GetEngine()
        {
            return this.engine;
        }
        public void removeEngine()
        {
            if (engine != null) { 
            this.mass -= engine.mass;
            this.maxSpeed -= engine.maxSpeed;
            this.thrust -= engine.thrust;
            this.engine = null;
            }
        }

    }
}