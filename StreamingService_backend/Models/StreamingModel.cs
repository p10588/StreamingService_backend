using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SS.Model{
    public class StreamingTitle{
        public int Id {get; set;}

        [StringLength(20)]
        public required string Name {get; set;}

        public required int Type {get; set;} //0: 1: 2:

        [StringLength(500)]
        public required string Description {get; set;}

        public List<StreamingContent>? StreamingContents {get; set;}
    }

    public class StreamingContent{
        public int Id {get; set;}

        public required int TitleId {get; set;}
        
        public required StreamingTitle StreamingTitle {get; set;}

        [StringLength(20)]
        public required string Name {get; set;}

        [StringLength(500)]
        public required string Description {get; set;}

        [StringLength(2000)]
        public required string Url{get; set;}

    }
}
