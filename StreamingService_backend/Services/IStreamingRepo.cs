using SS.Model;

namespace SS.Service{
    public interface IStreamingRepo{
        int AddTitle(Model.StreamingTitle title);

        int AddContent(Model.StreamingContent content);

        List<StreamingTitle> GetAllTitles(int limit=0, int offset=0);
        Model.StreamingTitle GetTitleById(int id);

        List<Model.StreamingContent> GetAllContentsByTitleId(int titleId);

        void UpdateTitleData(StreamingTitle newTitle);

        void UpdateContentData(StreamingContent newContent);

        void RemoveTitle(int id);

        void RemoveContent(int id);
    }
}