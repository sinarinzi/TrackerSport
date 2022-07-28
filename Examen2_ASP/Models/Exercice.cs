namespace Examen2_ASP.Models
{
    public class Exercice
    {
        public int ExerciceId { get; set; }

        public string Title { get; set; }
        public string Icon { get; set; }
        public string? Category { get; set; } = "Upper Body";
    }
}
