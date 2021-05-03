
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using Microsoft.WindowsAzure.Storage.Blob;
using RPSLS_API.Models;

namespace RPSLS_API.Services
{
	public interface IRPSLSService
	{
        Task<IEnumerable<RPSLSItem>> GetRPSLSItems();
        Task<RPSLSItem> GetRPSLSItem(int id);
        Task PutRPSLSItem(int id, RPSLSItem rpslsItem);
        Task<RPSLSItem> CreateRPSLSItem(RPSLSItem rpslsItem);
        Task<RPSLSItem> DeleteRPSLSItem(int id);
        bool RPSLSItemExists(int id);
        Task<RoundResult> NewRound(PlayerRoundInfo playerRoundInfo);
        RPSLSItem AssignRPSLSObject(string winner, GameOptions playerChoice, GameOptions computerChoice);
        RoundResult AssignFinalObject(RPSLSItem rpslsItem, string name);
    }
}
