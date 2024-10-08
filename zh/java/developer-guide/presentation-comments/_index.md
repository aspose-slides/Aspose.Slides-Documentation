---
title: 演示评论
type: docs
weight: 100
url: /java/presentation-comments/
keywords: "评论，PowerPoint评论，PowerPoint演示，Java，Aspose.Slides for Java"
description: "在Java中为PowerPoint演示添加评论和回复"
---

在PowerPoint中，评论作为幻灯片上的注释或注解出现。当单击评论时，其内容或消息将显示出来。

### **为什么要在演示中添加评论？**

在审阅演示文稿时，您可能希望使用评论来提供反馈或与同事进行沟通。

为了允许您在PowerPoint演示中使用评论，Aspose.Slides for Java提供了

* [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类，其中包含作者集合（来自[ICommentAuthorCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICommentAuthorCollection)接口）。作者可以在幻灯片上添加评论。
* [ICommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICommentCollection)接口，该接口包含单个作者的评论集合。
* [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment)类，包含有关作者及其评论的信息：谁添加了评论，评论添加的时间，评论的位置等。
* [CommentAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/CommentAuthor)类，包含有关单个作者的信息：作者的姓名、首字母、与作者姓名相关的评论等。

## **添加幻灯片评论**
以下Java代码显示如何在PowerPoint演示中向幻灯片添加评论：

```java
// 实例化Presentation类
Presentation pres = new Presentation();
try {
    // 添加一个空幻灯片
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // 添加一个作者
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // 设置评论的位置
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // 在幻灯片1上为作者添加幻灯片评论
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // 在幻灯片2上为作者添加幻灯片评论
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // 访问幻灯片1
    ISlide slide = pres.getSlides().get_Item(0);

    // 当null作为参数传递时，所有作者的评论将带到所选幻灯片
    IComment[] Comments = slide.getSlideComments(author);

    // 访问幻灯片1上索引为0的评论
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // 选择索引为0的作者评论集合
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **访问幻灯片评论**
以下Java代码显示如何访问PowerPoint演示中幻灯片上的现有评论：

```java
// 实例化Presentation类
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

## **回复评论**
父评论是评论或回复层次结构中的顶层或原始评论。使用[getParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#getParentComment--)或[setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-)方法（来自[IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment)接口），您可以设置或获取父评论。

以下Java代码显示如何添加评论并获取其回复：

```java
Presentation pres = new Presentation();
try {
    // 添加评论
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // 为comment1添加回复
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // 为comment1添加另一个回复
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // 给现有回复添加回复
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // 在控制台上显示评论层次结构
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

    // 移除comment1及其所有回复
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="注意" %}} 

* 当[Remove](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#remove--)方法（来自[IComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment)接口）被用来删除评论时，该评论的回复也会被删除。 
* 如果[setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-)设置导致循环引用，将抛出[PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/PptxEditException)。

{{% /alert %}}

## **添加现代评论**

在2021年，Microsoft在PowerPoint中引入了*现代评论*。现代评论功能显著改善了PowerPoint中的协作。通过现代评论，PowerPoint用户能够更轻松地解决评论、将评论锚定到对象和文本，并进行更多的互动。

在[Aspose Slides for Java 21.11](https://docs.aspose.com/slides/java/aspose-slides-for-java-21-11-release-notes/)中，我们通过添加[ModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/ModernComment)类实现了对现代评论的支持。[addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-)和[insertModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-)方法被添加到[CommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/CommentCollection)类中。

以下Java代码显示如何在PowerPoint演示中向幻灯片添加现代评论：

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

## **删除评论**

### **删除所有评论和作者**

以下Java代码显示如何移除演示中的所有评论和作者：

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // 删除演示中的所有评论
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

### **删除特定评论**

以下Java代码显示如何删除幻灯片上的特定评论：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加评论...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // 移除所有包含“comment 1”文本的评论
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