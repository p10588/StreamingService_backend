using SS.Service;
using SS.Model;
using SS.Infrastructure;
using NUnit.Framework.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore;

public class StreamingRepo:IStreamingRepo{

    private readonly StreamingDbContext_pgsql _context;

    public StreamingRepo(StreamingDbContext_pgsql context){
        Console.WriteLine("Start StreamingRepo");
        this._context = context;
    }

    public int AddContent(StreamingContent content)
    {
        this._context.StreamingContents.Add(content);
        this._context.SaveChanges();
        return content.Id;
    }

    public int AddTitle(StreamingTitle title)
    {
        this._context.StreamingTitles.Add(title);
        this._context.SaveChanges();
        return title.Id;
    }

    public List<StreamingContent> GetAllContentsByTitleId(int titleId)
    {
        var contents = this._context.StreamingContents
                        .Where(content => content.StreamingTitle.Id == titleId)
                        .ToList();
        // var contents = this._context.StreamingTitles
        //     .Where(title=>title.Id == titleId)
        //     .Include(title => title.StreamingContents)
        //     .FirstOrDefault()?.StreamingContents;

        if(contents==null) 
            throw new ArgumentNullException("No relative content in title" + titleId);

        return contents;
    }

    public List<StreamingTitle> GetAllTitles(int limit=0, int offset=0)
    {
        List<StreamingTitle>? titles;
        if(limit!=0){
            titles = this._context.StreamingTitles
            .OrderBy(title => title.Id)
            .Skip(offset)
            .Take(limit)
            .ToList();
        }else{
            titles = this._context.StreamingTitles
            .OrderBy(title => title.Id)
            .Skip(offset)
            .ToList();
        }

        if(titles == null) 
            throw new ArgumentNullException("Titles is Empty");

        return titles;
    }
    public StreamingTitle GetTitleById(int id)
    {
        var title = this._context.StreamingTitles.Find(id);

        if(title==null) 
            throw new ArgumentNullException("title " + id + "doesnt exist");

        return title;
    }

    public StreamingContent GetContentById(int id)
    {
        var content = this._context.StreamingContents.Find(id);

        if(content==null) 
            throw new ArgumentNullException("title " + id + "doesnt exist");

        return content;
    }

    public void RemoveContent(int id)
    {
        var removeContent = this._context.StreamingContents.Find(id);

        if(removeContent==null) 
            throw new ArgumentNullException("title id is not exsit in DB");
        
        this._context.StreamingContents.Remove(removeContent);
        this._context.SaveChanges();
    }

    public void RemoveTitle(int id)
    {
        var removeTitle = this._context.StreamingTitles.Find(id);

        if(removeTitle==null) 
            throw new ArgumentNullException("title id is not exsit in DB");
        
        this._context.StreamingTitles.Remove(removeTitle);
        this._context.SaveChanges();
    }

    public void UpdateContentData(StreamingContent newContent)
    {
        var title = this.GetContentById(newContent.Id);
        if(title==null)
            throw new ArgumentNullException("Content id "+ newContent.Id +" isnt exist");
        
        this._context.StreamingContents.Update(newContent);
        this._context.SaveChanges();
    }

    public void UpdateTitleData(StreamingTitle newTitle)
    {
        var title = this.GetTitleById(newTitle.Id);
        if(title==null)
            throw new ArgumentNullException("Title id "+ newTitle.Id +" isnt exist");
        
        this._context.StreamingTitles.Update(newTitle);
        this._context.SaveChanges();
    }

    
}