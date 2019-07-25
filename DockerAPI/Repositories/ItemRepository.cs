using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using DockerAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DockerAPI.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private const string S3Host = "http://localhost:5002/";
        private const string Bucket = "demo-bucket";
        private const string Key = "item";

        public async Task<Item> GetItem()
        {
            var s3Client = new AmazonS3Client(new AmazonS3Config
            {
                ServiceURL = S3Host,
                ForcePathStyle = true,
            });

            var response = await s3Client.GetObjectAsync(new GetObjectRequest()
            {
                BucketName = "demo-bucket",
                Key = "item"
            });

            using (StreamReader reader = new StreamReader(response.ResponseStream))
            {
                try
                {
                    var json = reader.ReadToEnd();
                    var item = JsonConvert.DeserializeObject<Item>(json);
                    return item;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public async Task SaveItem(Item item)
        {
            var s3Client = new AmazonS3Client(new AmazonS3Config
            {
                ServiceURL = S3Host,
                ForcePathStyle = true,
            });

            var bucket = await s3Client.PutBucketAsync(new PutBucketRequest
            {
                BucketName = Bucket,
                UseClientRegion = true
            });

            var fileTransferUtility =
                new TransferUtility(s3Client);

            string json = JsonConvert.SerializeObject(item);
            using (var stream = GenerateStreamFromString(json))
            {
                await fileTransferUtility.UploadAsync(stream, Bucket, Key);
            }
        }

        private Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
