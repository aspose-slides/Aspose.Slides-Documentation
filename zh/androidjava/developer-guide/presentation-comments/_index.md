---
title: 演示文稿评论
type: docs
weight: 100
url: /androidjava/presentation-comments/
keywords: "评论，PowerPoint评论，PowerPoint演示文稿，Java，Aspose.Slides for Android via Java"
description: "在Java中为PowerPoint演示文稿添加评论和回复"
---

在PowerPoint中，评论作为幻灯片上的备注或注释出现。当点击评论时，其内容或消息会被显示。

### **为什么要在演示文稿中添加评论？**

在审阅演示文稿时，您可能希望使用评论来提供反馈或与同事沟通。

为了让您能够在PowerPoint演示文稿中使用评论，Aspose.Slides for Android via Java 提供了

* [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类，它包含作者的集合（来自 [ICommentAuthorCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentAuthorCollection) 接口）。作者将评论添加到幻灯片中。
* [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICommentCollection) 接口，它包含单个作者的评论集合。
* [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment) 类，它包含关于作者和其评论的信息：谁添加了评论，评论添加的时间，评论的位置等。
* [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentAuthor) 类，它包含有关单个作者的信息：作者的姓名、首字母缩写、与作者姓名相关的评论等。

## **添加幻灯片评论**
以下Java代码演示如何在PowerPoint演示文稿的幻灯片上添加评论：

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

    // 为幻灯片1的作者添加幻灯片评论
    author.getComments().addComment("你好Jawad，这是幻灯片评论", pres.getSlides().get_Item(0), point, new Date());

    // 为幻灯片2的作者添加幻灯片评论
    author.getComments().addComment("你好Jawad，这是第二个幻灯片评论", pres.getSlides().get_Item(1), point, new Date());

    // 访问幻灯片1
    ISlide slide = pres.getSlides().get_Item(0);

    // 当传入null作为参数时，将所有作者的评论带到所选幻灯片
    IComment[] Comments = slide.getSlideComments(author);

    // 访问幻灯片1的索引0处的评论
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // 选择索引0处的作者评论集合
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **访问幻灯片评论**
以下Java代码演示如何访问PowerPoint演示文稿中幻灯片上的现有评论：

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
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " 有评论: " + comment.getText() +
                    " 作者: " + comment.getAuthor().getName() + " 发布时间 :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **回复评论**
父评论是评论或回复层次结构中的顶部或原始评论。通过使用 [getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#getParentComment--) 或 [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) 方法（来自 [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment) 接口），您可以设置或获取父评论。

以下Java代码演示如何添加评论并获取对其的回复：

```java
Presentation pres = new Presentation();
try {
    // 添加评论
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("评论1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // 对评论1添加回复
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("评论1的回复1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // 对评论1添加另一个回复
    IComment reply2 = author2.getComments().addComment("评论1的回复2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // 对现有回复添加回复
    IComment subReply = author1.getComments().addComment("回复2的子回复3", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("评论2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("评论3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("评论3的回复4", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
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

    // 移除评论1及其所有回复
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="注意" %}} 

* 当使用 [Remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#remove--) 方法（来自 [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment) 接口）删除评论时，该评论的回复也会被删除。
* 如果 [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) 设置导致循环引用，将抛出 [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException)。

{{% /alert %}}

## **添加现代评论**

在2021年，微软在PowerPoint中引入了*现代评论*。现代评论功能显著改善了PowerPoint中的协作。通过现代评论，PowerPoint用户能够更轻松地解决评论，将评论锚定到对象和文本，并进行互动。

在 [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-11-release-notes/) 中，我们通过添加 [ModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ModernComment) 类实现了对现代评论的支持。 [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) 和 [insertModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) 方法被添加到 [CommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommentCollection) 类。

以下Java代码演示如何在PowerPoint演示文稿中的幻灯片上添加现代评论： 

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("某作者", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("这是一个现代评论", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **删除评论**

### **删除所有评论和作者**

以下Java代码演示如何删除演示文稿中的所有评论和作者：

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // 从演示文稿中删除所有评论
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

以下Java代码演示如何删除幻灯片上的特定评论：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加评论...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("作者", "A");
    author.getComments().addComment("评论1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("评论2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // 移除所有包含“评论1”文本的评论
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("评论1"))
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