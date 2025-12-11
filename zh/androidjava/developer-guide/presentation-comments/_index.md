---
title: 在 Android 上管理演示文稿批注
linktitle: 演示文稿批注
type: docs
weight: 100
url: /zh/androidjava/presentation-comments/
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
- 删除批注
- 删除批注
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 轻松快速地管理演示文稿批注：在 PowerPoint 文件中添加、读取、编辑和删除批注。"
---

在 PowerPoint 中，批注显示为幻灯片上的备注或注释。单击批注后，会显示其内容或信息。

### **为什么要在演示文稿中添加批注？**

在审阅演示文稿时，您可能希望使用批注来提供反馈或与同事交流。

为了让您在 PowerPoint 演示文稿中使用批注，Aspose.Slides for Android via Java 提供

* [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类，包含作者集合（来自 [ICommentAuthorCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentAuthorCollection) 接口）。作者向幻灯片添加批注。
* [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentCollection) 接口，包含各个作者的批注集合。
* [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment) 类，包含作者及其批注的信息：谁添加了批注、添加时间、批注位置等。
* [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentAuthor) 类，包含单个作者的信息：作者姓名、首字母缩写、与作者姓名关联的批注等。

## **添加幻灯片批注**
以下 Java 代码演示如何在 PowerPoint 演示文稿的幻灯片中添加批注：
```java
// 实例化 Presentation 类
Presentation pres = new Presentation();
try {
    // 添加空幻灯片
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // 添加作者
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // 设置批注位置
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // 为作者在幻灯片 1 添加幻灯片批注
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // 为作者在幻灯片 2 添加幻灯片批注
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // 访问 ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // 当参数为 null 时，将从所有作者获取批注到所选幻灯片
    IComment[] Comments = slide.getSlideComments(author);

    // 访问幻灯片 1 索引 0 处的批注
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // 选择索引 0 处的作者批注集合
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **访问幻灯片批注**
以下 Java 代码演示如何访问 PowerPoint 演示文稿中幻灯片上的已有批注：
```java
// 实例化 Presentation 类
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **回复批注**
父批注是批注或回复层级中的最高或原始批注。使用来自 [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment) 接口的 [getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#getParentComment--) 或 [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) 方法，您可以获取或设置父批注。

以下 Java 代码演示如何添加批注并获取其回复：
```java
Presentation pres = new Presentation();
try {
    // 添加批注
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // 为 comment1 添加回复
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // 为 comment1 添加另一个回复
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // 为已有回复添加回复
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // 在控制台显示批注层次结构
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // 删除 comment1 以及它的所有回复
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" title="Attention" %}} 
* 当使用来自 [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment) 接口的 [Remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#remove--) 方法删除批注时，批注的回复也会被删除。
* 如果对 [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) 的设置导致循环引用，将抛出 [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException)。
{{% /alert %}}

## **添加现代批注**
2021 年，Microsoft 在 PowerPoint 中引入了 *现代批注*。现代批注功能显著提升了 PowerPoint 的协作能力。通过现代批注，PowerPoint 用户可以解析批注、将批注锚定到对象和文本上，并且更轻松地进行交互。

在 [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-11-release-notes/) 中，我们通过添加 [ModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ModernComment) 类实现了对现代批注的支持。向 [CommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection) 类添加了 [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) 和 [insertModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) 方法。

以下 Java 代码演示如何在 PowerPoint 演示文稿的幻灯片中添加现代批注： 
```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **删除批注**

### **删除所有批注和作者**
以下 Java 代码演示如何在演示文稿中删除所有批注和作者：
```java
Presentation presentation = new Presentation("example.pptx");
try {
    // 删除演示文稿中的所有批注
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // 删除所有作者
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


### **删除特定批注**
以下 Java 代码演示如何删除幻灯片上的特定批注：
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加批注...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // 删除所有包含 "comment 1" 文本的批注
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **常见问题**

**Aspose.Slides 是否支持现代批注的类似 ‘已解决’ 的状态？**  
是的。[Modern comments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncomment/) 提供了 [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncomment/#setStatus-byte-) 方法；您可以写入 [comment’s state](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/)（例如，将其标记为已解决），该状态会保存在文件中并被 PowerPoint 识别。

**是否支持线程式讨论（回复链），以及是否有嵌套深度限制？**  
是的。每个批注都可以引用其 [parent comment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/comment/#getParentComment--)，从而实现任意的回复链。API 并未声明具体的嵌套深度限制。

**批注标记在幻灯片上的位置是基于哪种坐标系定义的？**  
位置以浮点数点的形式存储在幻灯片的坐标系中。这样即可将批注标记精确放置在所需位置。