---
title: 在 .NET 中管理演示文稿批注
linktitle: 演示文稿批注
type: docs
weight: 100
url: /zh/net/presentation-comments/
keywords:
- 批注
- 现代批注
- PowerPoint 批注
- 演示文稿批注
- 幻灯片批注
- 添加批注
- 访问批注
- 编辑批注
- 回复批注
- 移除批注
- 删除批注
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 精通演示文稿批注：在 PowerPoint 文件中快速轻松地添加、读取、编辑和删除批注。"
---

在 PowerPoint 中，批注显示为幻灯片上的备注或注释。单击批注时，会显示其内容或信息。 

## **为什么要向演示文稿添加批注？**

在审阅演示文稿时，您可能希望使用批注来提供反馈或与同事沟通。

* The [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类，包含作者集合（来自 [CommentAuthorCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/properties/index) 属性）。作者向幻灯片添加批注。 
* The [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) 接口，包含各个作者的批注集合。 
* The [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) 类，提供有关作者及其批注的信息：谁添加了批注、添加时间、批注位置等。 
* The [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) 类，包含单个作者的信息：作者姓名、缩写、与该作者关联的批注等。 

## **添加幻灯片批注**
以下 C# 代码演示了如何在 PowerPoint 演示文稿的幻灯片上添加批注：
```c#
// 实例化 Presentation 类
using (Presentation presentation = new Presentation())
{
    // 添加空幻灯片
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // 添加作者
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // 设置批注的位置
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // 为作者在第 1 张幻灯片添加幻灯片批注
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // 为作者在第 2 张幻灯片添加幻灯片批注
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // 访问 ISlide 1
    ISlide slide = presentation.Slides[0];

    // 当参数为 null 时，将所有作者的批注带到所选幻灯片
    IComment[] Comments = slide.GetSlideComments(author);

    // 访问第 1 张幻灯片的索引 0 处的批注
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // 选择索引 0 处的作者批注集合
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```


## **访问幻灯片批注**
以下 C# 代码演示了如何访问 PowerPoint 演示文稿中幻灯片上的现有批注：
```c#
// 实例化 Presentation 类
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


## **回复批注**
父批注是批注或回复层级中的顶层（原始）批注。使用 [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) 属性（来自 [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) 接口），可以设置或获取父批注。 

以下 C# 代码演示了如何添加批注以及获取其回复：
```c#
using (Presentation pres = new Presentation())
{
    // 添加批注
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // 为 comment1 添加回复
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // 为 comment1 添加另一个回复
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // 为已有的回复添加回复
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // 在控制台显示批注层级结构
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

    // 删除 comment1 及其所有回复
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```


{{% alert color="warning" title="Attention" %}} 

* 当使用来自 [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) 接口的 [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/methods/remove) 方法删除批注时，批注的回复也会被删除。 
* 如果 [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) 设置导致循环引用，将抛出 [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception)。 

{{% /alert %}}

## **添加现代批注**

2021 年，Microsoft 在 PowerPoint 中引入了 *现代批注*。现代批注功能显著提升了 PowerPoint 的协作能力。通过现代批注，PowerPoint 用户可以对批注进行解决、将批注固定到对象和文本上，并且交互更加便捷。

在 [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-11-release-notes/) 中，我们通过添加 [ModernComment](https://reference.aspose.com/slides/net/aspose.slides/moderncomment) 类实现了对现代批注的支持。为 [CommentCollection](https://reference.aspose.com/slides/net/aspose.slides/commentcollection) 类新增了 [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/addmoderncomment) 和 [InsertModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/insertmoderncomment) 方法。

以下 C# 代码演示了如何在 PowerPoint 演示文稿的幻灯片上添加现代批注：
```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **删除批注**

### **删除所有批注和作者**

以下 C# 代码演示了如何在演示文稿中删除所有批注和作者：
```c#
using (var presentation = new Presentation("example.pptx"))
{
    // 删除演示文稿中的所有批注
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // 删除所有作者
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```


### **删除特定批注**

以下 C# 代码演示了如何删除幻灯片上的特定批注：
```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // 添加批注...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // 删除所有包含 "comment 1" 文本的批注
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


## **常见问题**

**Aspose.Slides 是否支持现代批注的“已解决”等状态？**

是的。[Modern comments](https://reference.aspose.com/slides/net/aspose.slides/moderncomment/) 提供了一个 [Status](https://reference.aspose.com/slides/net/aspose.slides/moderncomment/status/) 属性；您可以读取和设置 [批注的状态](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/)（例如，将其标记为已解决），该状态会保存在文件中并被 PowerPoint 识别。

**是否支持线程式讨论（回复链），以及是否有嵌套层级限制？**

是的。每个批注都可以引用其 [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/) ，从而实现任意深度的回复链。API 未声明具体的嵌套深度限制。

**批注标记在幻灯片上的位置是基于哪种坐标系定义的？**

该位置以浮点坐标点存储在幻灯片的坐标系中。这使您能够将批注标记精确放置在所需位置。