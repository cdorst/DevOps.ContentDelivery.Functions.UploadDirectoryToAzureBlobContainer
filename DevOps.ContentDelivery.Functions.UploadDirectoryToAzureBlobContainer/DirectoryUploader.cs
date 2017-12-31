using System.Threading.Tasks;
using static Common.Functions.GetRelativePath.RelativePathGetter;
using static Common.Functions.ListFilesUnderDirectory.DirectoryFileLister;
using static DevOps.ContentDelivery.Functions.GetOrCreateAzureBlobContainer.ContainerReferenceGetter;
using static DevOps.ContentDelivery.Functions.UploadAzureBlob.BlobUploader;

namespace DevOps.ContentDelivery.Functions.UploadDirectoryToAzureBlobContainer
{
    public static class DirectoryUploader
    {
        public static async Task UploadFiles(string containerName, string path, string connectionString = null)
        {
            var container = await Container(containerName, connectionString);
            foreach (string file in ListFiles(path))
                await Upload(container,
                    name: Relative(path, file),
                    path: file);
        }
    }
}
