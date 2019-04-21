using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorAccountingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("1) Список посищений");
                Console.WriteLine("2) Добавить посетителя который зашел");
                Console.WriteLine("3) Дозаполнеие данных при выходи из заведения");
                Console.WriteLine("4) Выход");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Список посищений: ");
                    using (var context = new VisitorAccountingContext())
                    {

                        var visitors = context.Visitors.ToList();
                        for (int i = 0; i < visitors.Count; i++)
                        {
                            if (visitors[i].Condition == true)
                            {
                                Console.WriteLine(visitors[i].Id + ") " + visitors[i].Name + " Пришел в: " + visitors[i].DateTimeToComeIn + " | Ушел в:" + visitors[i].DateTimeToComeOut + " Удостовернеие: " +visitors[i].NumberIdentification);
                                Console.WriteLine("Цель визита: " + visitors[i].VisitPurpose + " Статус: покинул заведение");
                            }
                            else
                            {
                                Console.WriteLine(visitors[i].Id + ") " + visitors[i].Name + " Пришел в: " + visitors[i].DateTimeToComeIn + " Удостоверение: " + visitors[i].NumberIdentification);
                                Console.WriteLine("Цель визита: " + visitors[i].VisitPurpose + " Статус: еще в заведении");
                            }
                        }
                        Console.ReadLine();
                    }
                }
                else if (choice == 2)
                {
                    using (var context = new VisitorAccountingContext())
                    {
                        Console.Clear();
                        Console.WriteLine("Введите имя посетителя: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите номер удостоверения: ");
                        long numberIdentification = long.Parse(Console.ReadLine());
                        Console.WriteLine("Введите цель посищения: ");
                        string visitPurpose = Console.ReadLine();
                        Visitor visitor = new Visitor
                        {
                            Name = name,
                            DateTimeToComeIn = DateTime.Now.ToString(),
                            DateTimeToComeOut = DateTime.MinValue.ToString(),
                            NumberIdentification = numberIdentification,
                            VisitPurpose = visitPurpose,
                            Condition = false

                        };
                        context.Visitors.Add(visitor);
                        context.SaveChanges();
                    }
                }
                else if (choice == 3)
                {
                    using (var context = new VisitorAccountingContext())
                    {
                        Console.Clear();
                        Console.WriteLine("Введите номер удостоверения посетителя: ");
                        long numberIdentification = long.Parse(Console.ReadLine());
                        var visitors = context.Visitors.ToList();
                        for (int i = 0; i < visitors.Count; i++)
                        {
                            if(visitors[i].NumberIdentification == numberIdentification)
                            {
                                Visitor visitor = new Visitor
                                {
                                    Name = visitors[i].Name,
                                    DateTimeToComeIn = visitors[i].DateTimeToComeIn,
                                    DateTimeToComeOut = DateTime.Now.ToString(),
                                    NumberIdentification = visitors[i].NumberIdentification,
                                    VisitPurpose = visitors[i].VisitPurpose,
                                    Condition = true
                                };
                                context.Visitors.Remove(visitors[i]);
                                context.Visitors.Add(visitor);
                                context.SaveChanges();
                            }
                        }
                    } 
                }
                else if(choice == 4)
                {
                    break;
                }
            }
        }
    }
}
