---
title: 演示文稿批注
type: docs
weight: 100
url: /zh/nodejs-java/presentation-comments/
keywords: "批注, PowerPoint 批注, PowerPoint 演示文稿, Java, Aspose.Slides for Node.js via Java"
description: "在 PowerPoint 演示文稿中使用 JavaScript 添加批注和回复"
---

在 PowerPoint 中，批注显示为幻灯片上的备注或注释。点击批注后，批注的内容或信息会显示出来。 

## **为什么向演示文稿添加批注？**

在审阅演示文稿时，您可能希望使用批注来提供反馈或与同事沟通。

为了让您在 PowerPoint 演示文稿中使用批注，Aspose.Slides for Node.js via Java 提供以下功能：

* [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类，包含作者集合（来自 [CommentAuthorCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthorCollection) 类）。作者向幻灯片添加批注。
* [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection) 类，包含各个作者的批注集合。
* [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment) 类，包含作者及其批注的信息：谁添加了批注、添加批注的时间、批注的位置等。
* [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthor) 类，包含单个作者的信息：作者姓名、缩写、与作者姓名关联的批注等。

## **添加幻灯片批注**
下面的 JavaScript 代码展示了如何向 PowerPoint 演示文稿中的幻灯片添加批注：
```javascript
// 实例化 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 添加一个空幻灯片
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // 添加作者
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // 设置批注位置
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // 为作者在幻灯片 1 上添加批注
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // 为作者在幻灯片 2 上添加批注
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // 访问 ISlide 1
    var slide = pres.getSlides().get_Item(0);
    // 当参数为 null 时，会将所有作者的批注带到选定的幻灯片
    var Comments = slide.getSlideComments(author);
    // 访问幻灯片 1 上索引 0 的批注
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // 选择索引 0 处的作者批注集合
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **访问幻灯片批注**
下面的 JavaScript 代码展示了如何访问 PowerPoint 演示文稿中幻灯片的现有批注：
```javascript
var pres = new aspose.slides.Presentation("Comments1.pptx");
try {
    for (let i = 0; i < pres.getCommentAuthors().size(); i++) {
        let commentAuthor = pres.getCommentAuthors().get_Item(i);
        for (let j = 0; j < commentAuthor.getComments().size(); j++) {
            const comment = commentAuthor.getComments().get_Item(j);
            console.log("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() + " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **回复批注**
父批注是批注或回复层级结构中的顶层或原始批注。使用来自 [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment) 类的 [getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#getParentComment--) 或 [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) 方法，您可以设置或获取父批注。

下面的 JavaScript 代码展示了如何添加批注并获取其回复：
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 添加批注
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // 为 comment1 添加回复
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // 为 comment1 添加另一个回复
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // 为已有回复添加回复
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // 在控制台显示批注层级结构
    var slide = pres.getSlides().get_Item(0);
    var comments = slide.getSlideComments(null);
    for (var i = 0; i < comments.length; i++) {
        var comment = comments[i];
        while (comment.getParentComment() != null) {
            console.log("\t");
            comment = comment.getParentComment();
        }
        console.log((comments[i].getAuthor().getName() + " : ") + comments[i].getText());
        console.log();
    }
    pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
    // 删除 comment1 以及它的所有回复
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="warning" title="Attention" %}} 

* 当使用来自 [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment) 类的 [Remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#remove--) 方法删除批注时，该批注的回复也会被删除。
* 如果 [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) 的设置导致循环引用，将抛出 [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException)。

{{% /alert %}}

## **添加现代批注**
2021 年，Microsoft 在 PowerPoint 中引入了 *现代批注*。现代批注功能显著提升了 PowerPoint 的协作能力。通过现代批注，PowerPoint 用户可以解决批注、将批注锚定到对象和文本上，并且更轻松地进行交互。

在 [Aspose.Slides for Node.js via Java 21.11](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-21-11-release-notes/) 中，我们通过添加 [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ModernComment) 类实现了对现代批注的支持。向 [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection) 类中添加了 [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) 和 [insertModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) 方法。

下面的 JavaScript 代码展示了如何向 PowerPoint 演示文稿的幻灯片添加现代批注：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **删除批注**

### **删除所有批注和作者**
下面的 JavaScript 代码展示了如何在演示文稿中删除所有批注和作者：
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // 删除演示文稿中的所有批注
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // 删除所有作者
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


### **删除特定批注**
下面的 JavaScript 代码展示了如何删除幻灯片上的特定批注：
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // 添加批注...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // 删除所有包含 "comment 1" 文本的批注
    
    
    for (var i = 0; i < presentation.getCommentAuthors().length; i++) {
        var commentAuthor = presentation.getCommentAuthors().get_Item(i);
        var toRemove = java.newInstanceSync("java.util.ArrayList");
        for (let j = 0; j < slide.getSlideComments(commentAuthor).size(); j++) {
            let comment = slide.getSlideComments(commentAuthor).get_Item(j);
            if (comment.getText() === "comment 1") {
                toRemove.add(comment);
            }
        }
        for (var i = 0; i < toRemove.length; i++) {
            var comment = toRemove.get_Item(i);
            commentAuthor.getComments().remove(comment);
        }
    }
    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **常见问题**

**Aspose.Slides 是否支持现代批注的“已解决”等状态？**

是的。[Modern comments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/) 提供了 [getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) 和 [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setStatus/) 方法；您可以读取和设置 [comment’s state](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/)（例如，将其标记为已解决），此状态会保存在文件中并被 PowerPoint 识别。

**是否支持线程式讨论（回复链），以及是否有嵌套深度限制？**

是的。每个批注都可以引用其 [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/)，从而实现任意的回复链。API 未声明具体的嵌套深度限制。

**批注标记的位置在幻灯片上使用的坐标系是什么？**

该位置以浮点坐标点的形式存储在幻灯片的坐标系中。这使您能够将批注标记精确放置在所需位置。