---
title: Presentation Comments
type: docs
weight: 100
url: /net/presentation-comments/
keywords: "Comments, PowerPoint comments, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Add comments and replies in PowerPoint presentation in C# or .NET"
---



Slide comment is like an annotation in PDF file or a note that one can attach with a slide. Slide comments are generally used while reviewing the slides in PowerPoint. However, they can also serve as a useful utility for highlighting something important in the presentation slide and giving the needed explanation for that.
## **Add Slide Comment**
In Aspose.Slides for .NET, the presentation slide comment are associated with a particular author. The [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class holds the collection of authors in [**ICommentAuthorCollection** ](https://apireference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/properties/index)that are responsible for adding slide comments. For each author, there is a collection of comments in [**ICommentCollection**](https://apireference.aspose.com/slides/net/aspose.slides/icommentcollection). The [**IComment**](https://apireference.aspose.com/slides/net/aspose.slides/icomment) class includes information like an author who added slide comment, time of creation, slide where a comment is added, the position of slide comment on the selected slide and the comment text. The [**CommentAuthor**](https://apireference.aspose.com/slides/net/aspose.slides/commentauthor) class includes the author's name, his initials and list of associated comments. In the following example, we have added the code snippet for adding the slide comments.

```c#
// Instantiate Presentation class
using (Presentation presentation = new Presentation())
{
    // Adding Empty slide
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // Adding Author
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // Position of comments
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // Adding slide comment for an author on slide 1
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // Adding slide comment for an author on slide 1
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // Accessing ISlide 1
    ISlide slide = presentation.Slides[0];

    // if null is passed as an argument then it will bring comments from all authors on selected slide
    IComment[] Comments = slide.GetSlideComments(author);

    // Accessin the comment at index 0 for slide 1
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // Select comments collection of Author at index 0
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```



## **Access Slide Comments**
In the following example, we will learn how to access the existing slide comments and can even modify the comments as well.

```c#
// Instantiate Presentation class
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
A new property [**ParentComment**](https://apireference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) has been added to [**IComment**](https://apireference.aspose.com/slides/net/aspose.slides/icomment) interface and [**Comment**](https://apireference.aspose.com/slides/net/aspose.slides/comment) class in Aspose.Slides for .NET. It allows to get or set the parent comment, thus creating a dialog in the form of a hierarchy of comments and replies.

The code snippet below shows a sample of adding some comments and some replies to them:

```c#
using (Presentation pres = new Presentation())
{
    // Add comment
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Add reply for comment1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Add reply for comment1
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Add reply to reply
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Display hierarchy on console
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

    // Remove comment1 and all its replies
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Attention" %}} 
Remove method of [**IComment**](https://apireference.aspose.com/slides/net/aspose.slides/icomment) interface removes the comment with all its replies.
{{% /alert %}}

{{% alert color="info" title="Note" %}} 
If setting [**ParentComment**](https://apireference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) leads to a circular reference, the exception of type **PptxEditException** will be thrown.
{{% /alert %}}