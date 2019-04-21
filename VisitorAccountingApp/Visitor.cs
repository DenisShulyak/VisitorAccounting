using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorAccountingApp
{
   public class Visitor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateTimeToComeIn { get; set; } // Дата и время захода
        public string DateTimeToComeOut { get; set; } // Дата и время выхода
        public long NumberIdentification { get; set; } //Номер удостоверения
        public string VisitPurpose { get; set; } // Цель посищения
        public bool Condition { get; set; } //true - Вышел из здания, false - до сих пор в нем
        public Visitor(string name, long numberIdentification, string visitPurpose)
        {
            Name = name;
            DateTimeToComeIn = DateTime.Now.ToString();
            NumberIdentification = numberIdentification;
            VisitPurpose = visitPurpose;
            Condition = false;
        }
        public Visitor()
        {

        }
    }
}
