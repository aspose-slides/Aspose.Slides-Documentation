---
title: 演示文稿评论
type: docs
weight: 100
url: /zh/net/presentation-comments/
keywords: "评论, PowerPoint评论, PowerPoint演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在C#或.NET中向PowerPoint演示文稿添加评论和回复"
---

在PowerPoint中，评论作为幻灯片上的注释或注解出现。当单击评论时，将显示其内容或消息。

## **为什么要在演示文稿中添加评论？**

您可能希望在审核演示文稿时使用评论来提供反馈或与同事沟通。

为了让您能够在PowerPoint演示文稿中使用评论，Aspose.Slides for .NET提供了

* [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类，该类包含作者的集合（来自 [CommentAuthorCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/properties/index) 属性）。作者将评论添加到幻灯片上。
* [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) 接口，该接口包含每个作者的评论集合。
* [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) 类，该类包含有关作者及其评论的信息：谁添加了评论，评论添加的时间，评论的位置等。
* [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) 类，该类包含有关单个作者的信息：作者的姓名、他的首字母、与作者姓名相关的评论等。

## **添加幻灯片评论**
以下C#代码向您展示如何在PowerPoint演示文稿中向幻灯片添加评论：

```c#
// 实例化Presentation类
using (Presentation presentation = new Presentation())
{
    // 添加一个空幻灯片
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // 添加作者
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // 设置评论的位置
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // 为作者在幻灯片1上添加幻灯片评论
    author.Comments.AddComment("你好Jawad，这是幻灯片评论", presentation.Slides[0], point, DateTime.Now);

    // 为作者在幻灯片2上添加幻灯片评论
    author.Comments.AddComment("你好Jawad，这是第二个幻灯片评论", presentation.Slides[1], point, DateTime.Now);

    // 访问ISlide 1
    ISlide slide = presentation.Slides[0];

    // 当传入null作为参数时，将所有作者的评论带到所选幻灯片
    IComment[] Comments = slide.GetSlideComments(author);

    // 访问幻灯片1的索引0处的评论
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // 选择索引0处的作者评论集合
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **访问幻灯片评论**
以下C#代码向您展示如何访问PowerPoint演示文稿中的现有评论：

```c#
// 实例化Presentation类
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " 有评论: " + comment.Text + " 来自作者: " + comment.Author.Name + " 发表时间 :" + comment.CreatedTime + "\n");
        }
    }
}
```

## **回复评论**
父评论是评论或回复层次结构中的顶层或原始评论。使用 [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) 属性（来自 [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) 接口），可以设置或获取父评论。

以下C#代码向您展示如何添加评论并获取对其的回复：

```c#
using (Presentation pres = new Presentation())
{
    // 添加评论
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("评论1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // 为评论1添加回复
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("回复1关于评论1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // 为评论1添加另一个回复
    IComment reply2 = author2.Comments.AddComment("回复2关于评论1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // 为现有回复添加回复
    IComment subReply = author1.Comments.AddComment("子回复3关于回复2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("评论2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("评论3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("回复4关于评论3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // 在控制台上显示评论层级
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

    // 删除评论1及其所有回复
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="注意" %}} 

* 当使用 [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/methods/remove) 方法（来自 [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) 接口）删除评论时，该评论的回复也将被删除。 
* 如果 [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) 设置导致循环引用，将抛出 [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception)。

{{% /alert %}}

## **添加现代评论**

2021年，微软在PowerPoint中引入了*现代评论*。现代评论特性显著改善了PowerPoint中的协作。通过现代评论，PowerPoint用户可以更方便地解决评论、将评论锚定到对象和文本上，并进行互动。

在 [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-11-release-notes/) 中，我们通过添加 [ModernComment](https://reference.aspose.com/slides/net/aspose.slides/moderncomment) 类实现了对现代评论的支持。 [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/addmoderncomment) 和 [InsertModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/insertmoderncomment) 方法被添加到 [CommentCollection](https://reference.aspose.com/slides/net/aspose.slides/commentcollection) 类中。

以下C#代码向您展示如何向PowerPoint演示文稿中的幻灯片添加现代评论：

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("某些作者", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("这是一条现代评论", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **删除评论**

### **删除所有评论和作者**

以下C#代码向您展示如何删除演示文稿中的所有评论和作者：

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // 删除演示文稿中的所有评论
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // 删除所有作者
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **删除特定评论**

以下C#代码向您展示如何删除幻灯片上的特定评论：

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // 添加评论...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("作者", "A");
    author.Comments.AddComment("评论1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("评论2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // 删除所有包含“评论1”文本的评论
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "评论1")
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