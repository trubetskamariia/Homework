using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.ChristmasTree 
{
    class Program
    {
        static void Main()
        {

            ChristmasTree tree = new BaseChristmasTree();

            ToyDecorator decoratedTree = new ToyDecorator();
            decoratedTree.SetComponent(tree);
            decoratedTree.AddToy("Red Ball");
            decoratedTree.AddToy("Golden Star");

            GarlandDecorator fullyDecoratedTree = new GarlandDecorator();
            fullyDecoratedTree.SetComponent(decoratedTree);

            Console.WriteLine("Christmas Tree State ");
            fullyDecoratedTree.Operation();

            Console.WriteLine("Turning on the Garland ");
            fullyDecoratedTree.LightUp();

            Console.ReadKey();
        }
    }

    abstract class ChristmasTree
    {
        public abstract void Operation();
    }

    class BaseChristmasTree : ChristmasTree
    {
        public override void Operation()
        {
            Console.WriteLine("Plain green Christmas tree");
        }
    }

    abstract class TreeDecorator : ChristmasTree
    {
        protected ChristmasTree component;

        public void SetComponent(ChristmasTree component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    class ToyDecorator : TreeDecorator
    {
        private List<string> toys = new List<string>();

        public void AddToy(string toyName)
        {
            toys.Add(toyName);
        }

        public override void Operation()
        {
            base.Operation();
            ShowToys();
        }

        private void ShowToys()
        {
            Console.WriteLine("Tree decorated with toys: " + string.Join(", ", toys));
        }
    }

    class GarlandDecorator : TreeDecorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("A colorful garland has been hung on the tree.");
        }

        public void LightUp()
        {
            Console.WriteLine("The garland flickers and shines with bright lights!");
        }
    }
}