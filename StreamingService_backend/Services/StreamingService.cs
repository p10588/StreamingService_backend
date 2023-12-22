using SS.Model;

namespace SS.Service{
    public class StreamingService{
        

        private IStreamingRepo _repo;
        public StreamingService(IStreamingRepo repo){
            Console.WriteLine("Start Service");
            this._repo = repo;
        }

        public int CreateNewContentInTitle(int titleId, StreamingContent testContent)
        {
            throw new NotImplementedException();
        }

        public int CreateNewTitle(StreamingTitle title)
        {
            if(title == null)
                throw new ArgumentNullException();

            int id = this._repo.AddTitle(title);
            return id;
        }

        public List<StreamingContent> GetAllContentInTitle(int titleId)
        {
            throw new NotImplementedException();
        }

        public List<StreamingTitle> GetAllTitle()
        {
            throw new NotImplementedException();
        }

        public void RemoveContentInTitle(int titleId, int contentId)
        {
            throw new NotImplementedException();
        }

        public void RemoveTitle(int titleId)
        {
            throw new NotImplementedException();
        }

        public void UpdateContentData(StreamingContent testContent)
        {
            throw new NotImplementedException();
        }

        public void UpdateTitleData(StreamingTitle testTitle)
        {
            throw new NotImplementedException();
        }
    }
}
