using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSLS_API.Services
{
	public static class StorageService
	{

		public static Uri getSASUri() 
		{
			//CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=mariotesting;AccountKey=UjmUGDiFmRpCnOSCfiXzpAt9s4sCL4c8XvZX3KOzN/0eqwm+TLZguorN5D9hvmPMbkltMSBPcQB1+zgwLN/zmw==;EndpointSuffix=core.windows.net");
			//CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
			//if(blobClient.can)
			BlobClient blobClient = new BlobClient("DefaultEndpointsProtocol=https;AccountName=mariotesting;AccountKey=UjmUGDiFmRpCnOSCfiXzpAt9s4sCL4c8XvZX3KOzN/0eqwm+TLZguorN5D9hvmPMbkltMSBPcQB1+zgwLN/zmw==;EndpointSuffix=core.windows.net", "default", "aboutpic.png");
			if (!blobClient.CanGenerateSasUri) 
			{
				throw new Exception("Cannot Generate SAS Uri");
			}
			BlobSasBuilder sasBuilder = new BlobSasBuilder()
			{
				BlobContainerName = blobClient.GetParentBlobContainerClient().Name,
				BlobName = blobClient.Name,
				Resource = "b"
			};
			sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);
			sasBuilder.SetPermissions(BlobAccountSasPermissions.Read |
				BlobAccountSasPermissions.Write);

			Uri sasUri = blobClient.GenerateSasUri(sasBuilder);
			Console.WriteLine("SAS URI for blob is: {0}", sasUri);
			Console.WriteLine();
			return sasUri;
		}

	}
}
