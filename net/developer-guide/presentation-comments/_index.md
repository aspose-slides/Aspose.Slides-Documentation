---
title: Presentation Comments
type: docs
weight: 100
url: /net/presentation-comments/
keywords: "Comments, PowerPoint comments, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Add comments and replies in PowerPoint presentation in C# or .NET"
---

In PowerPoint, a comment appears as a note or annotation on a slide. When a comment is clicked, its contents or messages are revealed. 

### **Why Add Comments to Presentations?**

You may want to use comments to provide feedback or communicate with your colleagues when you review presentations.

To allow you to use comments in PowerPoint presentations, Aspose.Slides for .NET provides

* The [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class, which contains the collections of authors (from the [CommentAuthorCollection](https://apireference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/properties/index) property). The authors add comments to slides. 
* The  [ICommentCollection](https://apireference.aspose.com/slides/net/aspose.slides/icommentcollection) interface, which contains the collection of comments for individual authors. 
* The  [IComment](https://apireference.aspose.com/slides/net/aspose.slides/icomment) class, which contains information on authors and their comments: who added the comment, the time the comment was added, the comment's position, etc. 
* The [CommentAuthor](https://apireference.aspose.com/slides/net/aspose.slides/commentauthor) class, which contains information on individual authors: the author's name, his initials, comments associated with the author's name, etc. 

## **Add Slide Comment**
This C# code shows you how to add a comment to a slide in a PowerPoint presentation:

```c#
// Instantiates the Presentation class
using (Presentation presentation = new Presentation())
{
    // Adds an empty slide
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // Adds an author
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // Sets the position for comments
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // Adds slide comment for an author on slide 1
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // Adds slide comment for an author on slide 2
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // Accesses ISlide 1
    ISlide slide = presentation.Slides[0];

    // When null is passed as an argument, comments from all authors are brought to the selected slide
    IComment[] Comments = slide.GetSlideComments(author);

    // Accesses the comment at index 0 for slide 1
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // Selects the Author's comments collection at index 0
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **Access Slide Comments**
This C# code shows you how to access an existing comment on a slide in a PowerPoint presentation:

```c#
// Instantiates the Presentation class
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " has comment: " + comment.Text + " with Author: " + comment.Author.Name + " posted on time :" + comment.CreatedTime + "\n");
        }
    }
}
```


## **Reply Comments**
A parent comment is the top or original comment in a hierarchy of comments or replies. Using the [ParentComment](https://apireference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) property (from the [IComment](https://apireference.aspose.com/slides/net/aspose.slides/icomment) interface), you can set or get a parent comment. 

This C# code shows you how to add comments and get replies to them:

```c#
using (Presentation pres = new Presentation())
{
    // Adds a comment
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Adds a reply to comment1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Adds another reply to comment1
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Adds a reply to existing reply
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Displays the comments hierarchy on console
    ISlide slide = pres.Slides[0];
    var comments = slide.GetSlideComments(null);
    for (int i = 0; i < comments.Length; i++)
    {
        IComment comment = comments[i];
        while (comment.ParentComment != null)
        {
            Console.Write("\t");
            comment = comment.ParentComment;
        }

        Console.Write("{0} : {1}", comments[i].Author.Name, comments[i].Text);
        Console.WriteLine();
    }

    pres.Save("parent_comment.pptx",SaveFormat.Pptx);

    // Removes comment1 and all replies to it
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Attention" %}} 

* When the [Remove](https://apireference.aspose.com/slides/net/aspose.slides/icomment/methods/remove) method (from the [IComment](https://apireference.aspose.com/slides/net/aspose.slides/icomment) interface) is used to delete a comment, the replies to the comment also get deleted. 
* If the [ParentComment](https://apireference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) setting results in a circular reference, [PptxEditException](https://apireference.aspose.com/slides/net/aspose.slides/pptxeditexception) will be thrown.

{{% /alert %}}

## **Add Modern Comment**

In 2021, Microsoft introduced *modern comments* in PowerPoint. The modern comments feature significantly improves collaboration in PowerPoint. Through modern comments, PowerPoint users get to resolve comments, anchor comments to objects and texts, and engage in interactions a lot more easily than before. 

In [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-11-release-notes/), we implemented support for modern comments by adding the [ModernComment](https://apireference.aspose.com/slides/net/aspose.slides/moderncomment) class. The [AddModernComment](https://apireference.aspose.com/slides/net/aspose.slides/commentcollection/methods/addmoderncomment) and [InsertModernComment](https://apireference.aspose.com/slides/net/aspose.slides/commentcollection/methods/insertmoderncomment) methods were added to the [CommentCollection](https://apireference.aspose.com/slides/net/aspose.slides/commentcollection) class. 

This C# code shows you how to add a modern comment to a slide in a PowerPoint presentation: 

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Remove Comment**

### **Delete All Comments and Authors**

This C# code shows you how to remove all comments and authors in a presentation:

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // Deletes all comments from the presentation
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // Deletes all authors
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **Delete Specific Comments**

This C# code shows you how to delete specific comments on a slide:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // add comments...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // remove all comments that contain "comment 1" text
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "comment 1")
            {
                toRemove.Add(comment);
            }
        }
        
        foreach (IComment comment in toRemove)
        {
            commentAuthor.Comments.Remove(comment);
        }
    }
    
    presentation.Save("pres.pptx", SaveFormat.Pptx);
}
```


