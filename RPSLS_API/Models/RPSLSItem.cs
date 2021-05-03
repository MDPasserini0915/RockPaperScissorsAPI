using System;

namespace RPSLS_API.Models
{
    public class RPSLSItem
    {
        public int Id { get; set; }
        public GameOptions Player1Choice { get; set; }
        public GameOptions Player2Choice { get; set; }
        public string Winner { get; set; }
        public DateTime TimeStamp { get; set; }
    }

}
