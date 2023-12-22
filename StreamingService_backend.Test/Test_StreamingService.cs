using SS.Service;
using Microsoft.AspNetCore.Mvc.Versioning;
using SS.Model;
using Npgsql.Replication;

namespace SS.Test{
    [TestFixture]
    public class Test_StreamingService{
        
        IStreamingRepo _fakeRepo;
        StreamingService _service;

        [SetUp]
        public void Setup(){
            this._service = new StreamingService(this._fakeRepo);
        }

        [Test]
        public void Test_CreateNewTitle(){
            StreamingTitle testTitle = new StreamingTitle{
                Name = "AAAA",
                Type = 1,
                Description = "AAAAAAAAAAAAAAAAAAA"
            };
            int id = this._service.CreateNewTitle(testTitle);
            Assert.That(id, Is.Not.EqualTo(0));
            StreamingTitle? testNull = null; 
            id = this._service.CreateNewTitle(testNull);
            Assert.That(id, Is.Not.EqualTo(0));
        }

        [Test]
        public void Test_UpdateTitleData(){
            try{
                StreamingTitle testTitle = new StreamingTitle{
                    Name = "AAAA",
                    Type = 1,
                    Description = "AAAAAAAAAAAAAAAAAAA"
                };
                int id = this._service.CreateNewTitle(testTitle);
                testTitle.Description = "AAAAAAAAAAAAAAAAAAAUpdate";
                this._service.UpdateTitleData(testTitle);
                Assert.Pass();
            }catch(Exception e){
                Assert.Fail();
                Console.WriteLine(e);
            } 
        }

        [Test]
        public void Test_GetAllTitle(){
            try{
                List<StreamingTitle> titles = this._service.GetAllTitle();
                
                Assert.That(titles.Count, Is.EqualTo(3));
            }catch(Exception e){
                Assert.Fail();
                Console.WriteLine(e);
            }
        }


        [TestCase(1)]
        public void Test_CreateNewContentInTitle(int titleId){
            try{
                StreamingContent testContent = new StreamingContent{
                    Name = "AAAAContent",
                    TitleId = 1,
                    StreamingTitle = null,
                    Description = "AAAAAAAAAAAAAAAAAAA",
                    Url = "https://"
                };
                int id = this._service.CreateNewContentInTitle(titleId, testContent);
                
                Assert.That(id, Is.Not.EqualTo(0));
            }catch(Exception e){
                Assert.Fail();
                Console.WriteLine(e);
            } 
        }

        [TestCase(1)]
        public void Test_UpdateContentData(int titleId){
            try{
                StreamingContent testContent = new StreamingContent{
                    Name = "AAAAContent",
                    TitleId = 1,
                    StreamingTitle = null,
                    Description = "AAAAAAAAAAAAAAAAAAA",
                    Url = "https://"
                };
                int id = this._service.CreateNewContentInTitle(titleId, testContent);
                testContent.Description = "AAAAAAAAAAAAAAAAAAAUpdate";
                this._service.UpdateContentData(testContent);
                Assert.Pass();
            }catch(Exception e){
                Assert.Fail();
                Console.WriteLine(e);
            } 
        }

        [TestCase(1)]
        public void Test_GetAllContentInTitle(int titleId){
            try{
                List<StreamingContent> contents = this._service.GetAllContentInTitle(titleId);

                Assert.That(contents.Count, Is.EqualTo(3));
            }catch(Exception e){
                Assert.Fail();
                Console.WriteLine(e);
            } 
        }

        [TestCase(1,1)]
        public void Test_RemoveContentInTitle(int titleId, int contentId){
            try{
                this._service.RemoveContentInTitle(titleId, contentId);
                Assert.Pass();
            }catch(Exception e){
                Assert.Fail();
                Console.WriteLine(e);
            } 
        }

        [TestCase(1)]
        public void Test_RemoveTitle(int titleId){
            try{
                this._service.RemoveTitle(titleId);
                Assert.Pass();
            }catch(Exception e){
                Assert.Fail();
                Console.WriteLine(e);
            } 
        }

        [TearDown]
        public void TearDown(){

        }


    }
}