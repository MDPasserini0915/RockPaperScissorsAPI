
namespace RPSLS_API.Models
{
	public class RoundResult
	{
		public string Name { get; set; }
		public GameOptions PlayerChoice { get; set; }
		public GameOptions ComputerChoice { get; set; }
		public string Winner { get; set; }

	}
}
