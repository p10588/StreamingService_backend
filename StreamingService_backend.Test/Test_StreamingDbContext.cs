using Microsoft.EntityFrameworkCore;
using SS.Infrastructure;
using SS.Model;

namespace SS.Test{

    public class TestStreamingDbContext{

        private DbContextOptions<StreamingDbContext_pgsql>? _options;
        private StreamingRepo? _repo;

        private int titleId_temp = 0;
        private int contentId_temp = 0;
        private string CONNECT_STRING = "Host=localhost;Port=5432;Username=postgres;Password=testadmin;Database=postgres;";
        [SetUp]
        public void Setup(){
            try{
                _options = new DbContextOptionsBuilder<StreamingDbContext_pgsql>()
                         .UseNpgsql(CONNECT_STRING).Options;
                var context = new StreamingDbContext_pgsql(this._options);
                this._repo = new StreamingRepo(context);
            }catch(Exception e){
                Console.WriteLine($"An error occurred: {e.Message}");
            }
            
        }

        [Test]
        public void Test_Connection(){
            try{
                var _options = new DbContextOptionsBuilder<StreamingDbContext_pgsql>()
                         .UseNpgsql(this.CONNECT_STRING).Options;
                Assert.That(true);
            }catch(Exception e){
                Console.WriteLine($"An error occurred: {e.Message}");
                Assert.That(false);
            }
            
        }

        [Test, Order(1)]
        public void Test_AddTitle(){
            try{
                if(this._repo == null) throw new ArgumentNullException();

                var streamingTitle = new StreamingTitle(){
                    Name = "TestTitle",
                    Type = 0,
                    Description = "TestDescription",
                };
                this.titleId_temp = this._repo.AddTitle(streamingTitle);
                Assert.That(this.titleId_temp, Is.Not.EqualTo(0));
            }catch(Exception e){
                Console.WriteLine($"An error occurred: {e.Message}");
                Assert.That(false);
            }
            
        }

        [Test, Order(2)]
        public void Test_AddContent(){
            try{
                if(this._repo == null) 
                    throw new ArgumentNullException();

                var title = this._repo.GetTitleById(-1);

                var streamingContent = new StreamingContent(){
                    Name = "TestContent",
                    TitleId = 0,
                    StreamingTitle = title,
                    Description = "TestContentDescription",
                    Url = "http://"
                };

                this.contentId_temp = this._repo.AddContent(streamingContent);

                Assert.That(this.contentId_temp, Is.Not.EqualTo(0));

            }catch(Exception e){
                Console.WriteLine($"An error occurred: {e}");
                Assert.That(false);
            }
           
        }

        

        [Test]
        public void Test_UpdateTitleData(){
            try{
                if(this._repo == null) 
                    throw new ArgumentNullException();
                var streamingTitle = this._repo.GetTitleById(-1);
                streamingTitle.Description = "TestDescriptionUpdate";
                this._repo.UpdateTitleData(streamingTitle);
                Assert.That(true);
            }catch(Exception e){
                Assert.That(false);
                Console.WriteLine(e);
            }
        }

        [Test]
        public void Test_UpdateContentData(){
            try{
                if(this._repo == null) 
                    throw new ArgumentNullException();
                var streamingContent = this._repo.GetContentById(-1);
                streamingContent.Description = "TestContentDescriptionUpdate";
                this._repo.UpdateContentData(streamingContent);
                Assert.That(true);
            }catch(Exception e){
                Assert.That(false);
                Console.WriteLine(e);
            }
        }

        [Test]
        public void Test_GetAllTitle(){
            try{
                if(this._repo == null) throw new ArgumentNullException("Repo is null");
                var titles = this._repo.GetAllTitles();
                Assert.That(titles.Count, Is.Not.EqualTo(0));
                var titlesOffset = this._repo.GetAllTitles(0,1);
                Assert.That(titlesOffset.Count+1, Is.EqualTo(titles.Count));
                var titlesLimitOffset = this._repo.GetAllTitles(1,1);
                Assert.That(titlesLimitOffset.Count, Is.EqualTo(1));
            }catch(Exception e){
                Console.WriteLine($"An error occurred: {e}");
                Assert.That(false);
            }
        }

        [TestCase(-1)]
        public void Test_GetTitleById(int titleId){
            try{
                if(this._repo == null) throw new ArgumentNullException("Repo is null");
                var title = this._repo.GetTitleById(titleId);
                Assert.That(title.Id, Is.EqualTo(titleId));
            }catch(Exception e){
                Console.WriteLine($"An error occurred: {e}");
                Assert.That(false);
            }
        }

        [Test]
        public void Test_GetAllContentsByTitleId(){
            try{
                if(this._repo == null) throw new ArgumentNullException();
                var contents = this._repo.GetAllContentsByTitleId(-1);
                Assert.That(contents.Count, Is.Not.EqualTo(0));
            }catch(Exception e){   
                Console.WriteLine($"An error occurred: {e.Message}");
                Assert.That(false);
            }
        }


        [Test,Order(8)]
        public void Test_RemoveContent(){
            try{
                if(this._repo == null) throw new ArgumentNullException();
                this._repo.RemoveContent(this.contentId_temp);
                Assert.That(true);
            }catch(Exception e){   
                Console.WriteLine($"An error occurred: {e.Message}");
                Assert.That(false);
            }
        }

        [Test, Order(9)]
        public void Test_RemoveTitle(){
            try{
                if(this._repo == null) throw new ArgumentNullException();
                this._repo.RemoveTitle(this.titleId_temp);
                Assert.That(true);
            }catch(Exception e){   
                Console.WriteLine($"An error occurred: {e.Message}");
                Assert.That(false);
            }
        }


        [TearDown]
        public void TearDown(){
        }

        
    }
}