using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuComponent pancakeHouseMenu = new Menu("MENU PANCAKE HOUSE", "Breakfast");
            pancakeHouseMenu.Add(new MenuPosition("Pancake with eggs", "Pancake with scrumbled eggs and toast", true, 2.99));
            pancakeHouseMenu.Add(new MenuPosition("Normal pancake", "Pancake with sausages", false, 5.99));

            MenuComponent dessertsMenu = new Menu("DESSERTS MENU", "Desserts, ofcourse!");
            dessertsMenu.Add(new MenuPosition("Cake", "Cake with vanilia ice cream", true, 1.59));

            MenuComponent dinnerMenu = new Menu("DINNER MENU", "Lunch");
            dinnerMenu.Add(new MenuPosition("Vege Sandwitch", "Sandwitch with cucumber, tomato and cheese", true, 1.99));
            dinnerMenu.Add(new MenuPosition("Normal Sandwitch", "Sandwitch with ham and tomato", true, 2.49));
            dinnerMenu.Add(dessertsMenu);

            MenuComponent allMenus = new Menu("ALL MENUS", "All menus");
            allMenus.Add(pancakeHouseMenu);
            allMenus.Add(dinnerMenu);                        

            Waitress waitress = new Waitress(allMenus);
            waitress.Print();
        }

        public abstract class MenuComponent
        {
            protected string Name;
            protected string Description;

            public virtual void Add(MenuComponent menuComponent)
            {
                throw new NotSupportedException();
            }

            public virtual void Remove(MenuComponent menuComponent)
            {
                throw new NotSupportedException();
            }

            public virtual MenuComponent GetChild(int i)
            {
                throw new NotSupportedException();
            }

            public virtual string GetName()
            {
                throw new NotSupportedException();
            }

            public virtual string GetDescription()
            {
                throw new NotSupportedException();
            }

            public virtual double GetCost()
            {
                throw new NotSupportedException();
            }

            public virtual bool IsVege()
            {
                throw new NotSupportedException();
            }

            public virtual void Print()
            {
                throw new NotSupportedException();
            }
        }

        public class MenuPosition : MenuComponent
        {            
            bool Vege;
            double Cost;

            public MenuPosition(string name, string description, bool vege, double cost)
            {
                this.Name = name;
                this.Description = description;
                this.Vege = vege;
                this.Cost = cost;
            }

            public override string GetName()
            {
                return Name;
            }

            public override string GetDescription()
            {
                return Description;
            }

            public override double GetCost()
            {
                return Cost;
            }

            public override bool IsVege()
            {
                return Vege;
            }

            public override void Print()
            {
                Console.Write(" " + GetName());
                if(IsVege())
                {
                    Console.Write("(w)");
                }
                Console.WriteLine(", " + GetCost());
                Console.WriteLine(" -- " + GetDescription());
            }
        }

        public class Menu : MenuComponent
        {
            List<MenuComponent> MenuComponents = new List<MenuComponent>();            

            public Menu(string name, string description)
            {
                this.Name = name;
                this.Description = description;
            }

            public override void Add(MenuComponent menuComponent)
            {
                this.MenuComponents.Add(menuComponent);
            }

            public override void Remove(MenuComponent menuComponent)
            {
                this.MenuComponents.Remove(menuComponent);
            }

            public override MenuComponent GetChild(int i)
            {
                return (MenuComponent)this.MenuComponents.ElementAt(i);
            }

            public override string GetName()
            {
                return Name;
            }

            public override string GetDescription()
            {
                return Description;
            }            

            public override void Print()
            {
                Console.Write("\n" + GetName());
                Console.Write(", " + GetDescription());
                Console.WriteLine("\n------------");

                foreach(MenuComponent menuComponent in this.MenuComponents)
                {
                    menuComponent.Print();
                }
            }            
        }

        public class Waitress
        {
            MenuComponent AllMenus;

            public Waitress(MenuComponent allMenu)
            {
                this.AllMenus = allMenu;
            }

            public void Print()
            {
                AllMenus.Print();
                Console.ReadKey();
            }
        }
    }
}
