namespace Examen2_ASP.Models
{
    public class Action
    {
        public int ActionId { get; set; }

        /***---- we define the foreign key related to category--***/
        public int ExerciceId { get; set; }
        public Exercice Exercice { get; set; }

        /***---- END define the foreign key related to category--***/
        public int Weigth { get; set; }
        public int Reps { get; set; }
        public DateTime Rest { get; set; }
        public string? Note { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
