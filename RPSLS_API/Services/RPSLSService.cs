using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Blob;
using RPSLS_API.Models;

namespace RPSLS_API.Services
{
    public class RPSLSService : IRPSLSService
    {
        private readonly RPSLSContext _context;
        public RPSLSService(RPSLSContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RPSLSItem>> GetRPSLSItems()
        {
            return await _context.RPSLSItems.ToListAsync();
        }
        public async Task<RPSLSItem> GetRPSLSItem(int id)
        {
            var rpslsItem = await _context.RPSLSItems.FindAsync(id);
            return rpslsItem;
        }
        public async Task PutRPSLSItem(int id, RPSLSItem rpslsItem)
        {
            _context.Entry(rpslsItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<RPSLSItem> CreateRPSLSItem(RPSLSItem rpslsItem)
        {
            _context.RPSLSItems.Add(rpslsItem);
            await _context.SaveChangesAsync();
            return rpslsItem;
        }
        public async Task<RPSLSItem> DeleteRPSLSItem(int id)
        {
            var rpslsItem = await _context.RPSLSItems.FindAsync(id);
            _context.RPSLSItems.Remove(rpslsItem);
            await _context.SaveChangesAsync();
            return rpslsItem;
        }
        public bool RPSLSItemExists(int id)
        {
            return _context.RPSLSItems.Any(e => e.Id == id);
        }
        public async Task<RoundResult> NewRound(PlayerRoundInfo playerRoundInfo)
        {
            // retrieve or create computer pick
            int computerPick = ComputerPick();
            // compare and retrieve winner
            string winner = WinnerCheck(playerRoundInfo.PlayerChoice, (GameOptions)computerPick, playerRoundInfo.Name);
            // save data to database
            RPSLSItem rpslsItem = AssignRPSLSObject(winner, playerRoundInfo.PlayerChoice, (GameOptions)computerPick);
            await CreateRPSLSItem(rpslsItem);
            RoundResult roundResult = AssignFinalObject(rpslsItem, playerRoundInfo.Name);
            // return the final object
            return roundResult;
        }
        //public async Task<CloudBlob> GetImage(string imageUrl, string containerName)
        //{
        //    CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=mariotesting;AccountKey=UjmUGDiFmRpCnOSCfiXzpAt9s4sCL4c8XvZX3KOzN/0eqwm+TLZguorN5D9hvmPMbkltMSBPcQB1+zgwLN/zmw==;EndpointSuffix=core.windows.net");
        //    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        //    CloudBlobContainer container = blobClient.GetContainerReference(containerName);
        //    CloudBlob image = container.GetBlobReference(imageUrl);
        //    image.GetSharedAccessSignature(new SharedAccessBlobPolicy());
        //    return image;
        //}
        public RPSLSItem AssignRPSLSObject(string winner, GameOptions playerChoice, GameOptions computerChoice)
        {
			RPSLSItem rpslsItem = new RPSLSItem
			{
				Player1Choice = playerChoice,
				Player2Choice = computerChoice,
				Winner = winner,
				TimeStamp = DateTime.Now
			};
			return rpslsItem;
        }
        public RoundResult AssignFinalObject(RPSLSItem rpslsItem, string name)
        {
			RoundResult roundResult = new RoundResult
			{
				Name = name,
				PlayerChoice = rpslsItem.Player1Choice,
				ComputerChoice = rpslsItem.Player2Choice,
				Winner = rpslsItem.Winner
			};
			return roundResult;
        }
        private int ComputerPick()
        {

            Random random = new Random();
            int computerPick = random.Next(0, 5);

            /********************************************************************************************
                This method is required to return an integer and that is the only reason this return is 
                here. Please make sure to edit it when you start editing the code so you get the 
                proper results.
            **********************************************************************************************/
            //Console.WriteLine("This is inside of the computerPick method:");
            return computerPick;
        }
        private string WinnerCheck(GameOptions user, GameOptions computer, string name)
        {
            //Console.WriteLine("This is inside the WinnerCheck method and displays the winner!");
            string winner;
            if (user == GameOptions.Rock & computer == GameOptions.Paper)
            {
                winner = "Computer";
            }
            else if (user == GameOptions.Rock & computer == GameOptions.Scissors)
            {
                winner = name; 
            }
            else if (user == GameOptions.Paper & computer == GameOptions.Rock)
            {
                winner = name;
            }
            else if (user == GameOptions.Paper & computer == GameOptions.Scissors)
            {
                winner = "Computer";
            }
            else if (user == GameOptions.Scissors & computer == GameOptions.Rock)
            {
                winner = "Computer";
            }
            else if (user == GameOptions.Scissors & computer == GameOptions.Paper)
            {
                winner = name;
            }
            else if (user == GameOptions.Rock & computer == GameOptions.Lizard)
            {
                winner = name;
            }
            else if (user == GameOptions.Lizard & computer == GameOptions.Rock)
            {
                winner = "Computer";
            }
            else if (user == GameOptions.Lizard & computer == GameOptions.Spock)
            {
                winner = name;
            }
            else if (user == GameOptions.Spock & computer == GameOptions.Lizard)
            {
                winner = "Computer";
            }
            else if (user == GameOptions.Spock & computer == GameOptions.Scissors)
            {
                winner = name;
            }
            else if (user == GameOptions.Scissors & computer == GameOptions.Spock)
            {
                winner = "Computer";
            }
            else if (user == GameOptions.Scissors & computer == GameOptions.Lizard)
            {
                winner = name;
            }
            else if (user == GameOptions.Lizard & computer == GameOptions.Scissors)
            {
                winner = "Computer";
            }
            else if (user == GameOptions.Lizard & computer == GameOptions.Paper)
            {
                winner = name;
            }
            else if (user == GameOptions.Paper & computer == GameOptions.Lizard)
            {
                winner = "Computer";
            }
            else if (user == GameOptions.Paper & computer == GameOptions.Spock)
            {
                winner = name;
            }
            else if (user == GameOptions.Spock & computer == GameOptions.Paper)
            {
                winner = "Computer";
            }
            else if (user == GameOptions.Spock & computer == GameOptions.Rock)
            {
                winner = name;
            }
            else if (user == GameOptions.Rock & computer == GameOptions.Spock)
            {
                winner = "Computer";
            }
            else
            {
                winner = "Tie";
            }
            return winner;
        }
    }
}
