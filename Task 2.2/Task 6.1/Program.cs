using System;

namespace Adapter 
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ITypeCCharger laptopCharger = new TypeCCharger();
            laptopCharger.ChargeWithTypeC();

            OldMicroUsbCharger oldCharger = new OldMicroUsbCharger();

            ITypeCCharger adapter = new MicroUsbToTypeCAdapter(oldCharger);

            Console.WriteLine("\nПідключаємо старий зарядний пристрій через адаптер:");
            adapter.ChargeWithTypeC();

            Console.ReadKey();
        }
    }

    public interface ITypeCCharger
    {
        void ChargeWithTypeC();
    }

    public class TypeCCharger : ITypeCCharger
    {
        public void ChargeWithTypeC()
        {
            Console.WriteLine("Заряджання через Type-C кабель");
        }
    }
    public class OldMicroUsbCharger
    {
        public void ChargeWithMicroUsb()
        {
            Console.WriteLine("Заряджання через старий Micro-USB кабель");
        }
    }

    public class MicroUsbToTypeCAdapter : ITypeCCharger
    {
        private readonly OldMicroUsbCharger _oldCharger;

        public MicroUsbToTypeCAdapter(OldMicroUsbCharger oldCharger)
        {
            _oldCharger = oldCharger;
        }

        public void ChargeWithTypeC()
        {
            _oldCharger.ChargeWithMicroUsb();
        }
    }
}