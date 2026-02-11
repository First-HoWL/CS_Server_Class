using C__Server_Class.Models;
using C__Server_Class.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

// https://sansushi.md/ - красивые картинки суши

namespace C__Server_Class.Pages
{
    public class SushiStoreModel : PageModel
    {
        private readonly SushiService _Sushies;
        private readonly SushiSetService _SushiSets;
        private readonly BucketService _Bucket;
        private int _bucketLastId = 0;
        public List<Sushi> Sushies => _Sushies.GetAll();
        public List<SushiSet> SushiSets => _SushiSets.GetAll();
        public List<Bucket> Buckets => _Bucket.GetAll();

        public int GetLastId() => ++_bucketLastId;

        public SushiStoreModel(SushiService SushiService,SushiSetService SushiSetService, BucketService BucketService)
        {
            _Sushies = SushiService;
            _Bucket = BucketService;
            _SushiSets = SushiSetService;
        }

        public void OnGet()
        {
        }
        public IActionResult OnGetBucketId()
        {
            Bucket bucket = new Bucket();
            bucket.GeneratePublicId(GetLastId());
            Buckets.Add(bucket);
            return new JsonResult(new
                {
                    //error = errors,
                    publicId = bucket.PublicId,
                    success = true
                }); 
        }
        public IActionResult OnGetBucket(int publicId)
        {
            Bucket bucket = Buckets.Where(i => i.PublicId == publicId).FirstOrDefault();
            
            return new JsonResult(new
                {
                //error = errors,
                    bucket,
                    success = true
                }); 
        }
        public async Task<IActionResult> OnPostUpdate(int publicId)
        {
            bool result = true;
            int SushiId = await Request.ReadFromJsonAsync<int>();
            var sushi = Sushies.Where(i => i.Id == SushiId).FirstOrDefault();
            // Console.WriteLine(JsonSerializer.Serialize(Employee));
            Bucket bucket = Buckets.Where(i => (i.PublicId == publicId)).FirstOrDefault();
            //List<string> errors = Validation(Employee);
            //if (errors.Count == 0)
            //{
            //    result = _TrainEmployees.Update(Employee);
            //}
            bucket.Sushies.Add(sushi);
            

            return new JsonResult(new
            {
                //error = errors,
                success = result
            });
        }
    }
}
