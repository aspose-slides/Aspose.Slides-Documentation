---
title: 在 Node.js 中管理演示文稿批注
linktitle: 演示文稿批注
type: docs
weight: 100
url: /zh/nodejs-java/presentation-comments/
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
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 管理演示文稿批注：在 PowerPoint 演示稿中添加、读取、编辑、回复和删除批注。"
---
## **概述**

本文介绍如何使用 Aspose.Slides for Node.js via Java 管理演示文稿批注。它概述了主要的批注相关类型，并演示了如何向幻灯片添加批注、访问已有批注、处理回复和现代批注，以及如何从演示文稿中删除批注。

示例涵盖了 PowerPoint 中常见的审阅和协作场景，例如为作者分配批注、读取批注文本和元数据、构建回复链，以及删除选定的批注或全部批注。

在 PowerPoint 中，批注显示为幻灯片上的注释。选中批注后会显示其文本和相关讨论。

如需在打开演示文稿时请求显示或隐藏批注（不更改批注本身），请参阅 [打开演示文稿时显示或隐藏批注](/slides/zh/nodejs-java/presentation-view-properties/)。

## **为什么要向演示文稿添加批注？**

在审阅演示文稿时，可以使用批注提供反馈并与同事协作。

Aspose.Slides for Node.js via Java 提供以下用于处理批注的 API：

* [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类，提供对演示文稿批注作者的访问。
* [CommentCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/commentcollection/) 类，表示与单个作者关联的批注集合。
* [Comment](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/comment/) 类，提供批注的信息，包括作者、创建时间、位置和文本。
* [CommentAuthor](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/commentauthor/) 类，提供作者的信息，包括名称、首字母缩写和关联的批注。

## **添加幻灯片批注**

以下示例展示了如何在 PowerPoint 演示文稿的幻灯片中添加批注：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    const author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const createdTime = java.newInstanceSync("java.util.Date");

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    const comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        const firstComment = comments[0];
        console.log(firstComment.getText());

        const authorComments = firstComment.getAuthor().getComments();
        const commentText = authorComments.get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **访问幻灯片批注**

以下示例展示了如何访问 PowerPoint 演示文稿中已有的批注：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("Comments1.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const author = authors.get_Item(authorIndex);
        const comments = author.getComments();

        for (let commentIndex = 0; commentIndex < comments.size(); commentIndex++) {
            const comment = comments.get_Item(commentIndex);
            console.log("Slide: " + comment.getSlide().getSlideNumber());
            console.log("Comment: " + comment.getText());
            console.log("Author: " + comment.getAuthor().getName());
            console.log("Posted at: " + comment.getCreatedTime());
            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **回复批注**

父批注是回复层次结构顶部的原始批注。`[Comment.getParentComment](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/comment/getparentcomment/)` 和 `[Comment.setParentComment](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/comment/setparentcomment/)` 方法可用于获取或设置批注的父批注。

以下示例展示了如何添加回复并检查生成的批注层次结构：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    const author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    const reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    const subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    const comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    const reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    const comments = slide.getSlideComments(null);
    for (let index = 0; index < comments.length; index++) {
        let comment = comments[index];
        let indentation = "";
        while (comment.getParentComment() != null) {
            indentation += "\t";
            comment = comment.getParentComment();
        }

        console.log(indentation + comments[index].getAuthor().getName() + ": " + comments[index].getText());
    }

    presentation.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* 当使用 `[Comment.remove](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/comment/remove/)` 方法删除批注时，该批注的所有回复也会被删除。
* 如果 `[Comment.setParentComment](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/comment/setparentcomment/)` 创建了循环引用，则会抛出 `[PptxEditException](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pptxeditexception/)`。
{{% /alert %}}

## **添加现代批注**

现代批注可以关联到整张幻灯片、特定形状或 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/) 内的文本范围。`[CommentCollection.addModernComment](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/commentcollection/addmoderncomment/)` 方法除了接受幻灯片和批注标记坐标外，还接受一个 `[Shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/)` 参数。

当形状参数传入 `null` 时，批注为幻灯片级批注。其标记位置由提供的坐标决定，但不关联到特定形状，因此 `[ModernComment.getShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/moderncomment/getshape/)` 返回 `null`。当提供 `[Shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/)` 时，批注锚定到该形状。坐标仍定义批注标记在幻灯片上的位置，而形状关联可通过 `[ModernComment.getShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/moderncomment/getshape/)` 获取。

### **将现代批注锚定到形状**

以下示例创建了一个幻灯片级现代批注和一个锚定到特定 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/) 的现代批注，然后读取每个批注关联的形状。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    const createdTime = java.newInstanceSync("java.util.Date");
    const slideCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));
    const shapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    const shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    console.log(slideComment.getShape() == null);
    console.log(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **将批注锚定到不同的形状类型**

任何从 `[Shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/)` 派生的幻灯片对象都可用作形状锚点。常见示例包括 `[AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)`、`[PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/)`、`[GroupShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/groupshape/)`、`[Connector](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/connector/)` 和图形对象（如图表）等实例。

以下示例创建了几种常见形状类型，并为每种形状关联了一个现代批注。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const createdTime = java.newInstanceSync("java.util.Date");

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    const autoShapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(30), java.newFloat(30));
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    const imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    const imageData = java.newArray("byte", Array.from(Buffer.from(imageBase64, "base64")));
    const image = presentation.getImages().addImage(imageData);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 120, 80, image);
    const pictureCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(230), java.newFloat(30));
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    const groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 100, 0, 80, 40);
    const groupCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(40), java.newFloat(150));
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 220, 150, 140, 40);
    const connectorCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(240), java.newFloat(150));
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 400, 20, 250, 180);
    const chartCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(420), java.newFloat(40));
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **将批注锚定到文本并设置其状态**

对于关联到 `[AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)` 的现代批注，`[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/)` 与 `[ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/moderncomment/settextselectionstart/)` 访问形状文本框中所选文本的起始位置。`[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/)` 与 `[ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/moderncomment/settextselectionlength/)` 访问选区的长度。这些值共同将批注与 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/) 中文本的特定范围关联。

`[ModernComment.getStatus](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/moderncomment/getstatus/)` 与 `[ModernComment.setStatus](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/moderncomment/setstatus/)` 方法访问来自 `[ModernCommentStatus](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/moderncommentstatus/)` 枚举的值：

- `NotDefined` — 未定义特定的现代批注状态。
- `Active` — 批注处于活动状态。
- `Resolved` — 批注已解决。
- `Closed` — 批注已关闭。

以下示例创建了一个锚定到形状的现代批注，将其关联到文本选区，将状态标记为已解决，保存演示文稿，并在重新打开文件后验证这些值。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const outputFile = "modern_comment_text_anchor.pptx";
const shapeText = "Review the quarterly revenue forecast.";
const selectedText = "quarterly revenue";
const expectedSelectionStart = shapeText.indexOf(selectedText);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const commentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const createdTime = java.newInstanceSync("java.util.Date");
    const comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, createdTime);
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length);
    comment.setStatus(aspose.slides.ModernCommentStatus.Resolved);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedComments = reopenedSlide.getSlideComments(null);

    for (let index = 0; index < reopenedComments.length; index++) {
        const reopenedComment = reopenedComments[index];
        if (!java.instanceOf(reopenedComment, "com.aspose.slides.IModernComment")) {
            continue;
        }

        const shapeMatches = reopenedComment.getShape() != null && reopenedComment.getShape().getName() === "Forecast text";
        const selectionStartMatches = reopenedComment.getTextSelectionStart() === expectedSelectionStart;
        const selectionLengthMatches = reopenedComment.getTextSelectionLength() === selectedText.length;
        const statusMatches = reopenedComment.getStatus() === aspose.slides.ModernCommentStatus.Resolved;

        console.log("Shape anchor preserved: " + shapeMatches);
        console.log("Text selection start preserved: " + selectionStartMatches);
        console.log("Text selection length preserved: " + selectionLengthMatches);
        console.log("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **检查现有的现代批注**

要检查现有演示文稿中的批注，请先识别哪些批注是 `[ModernComment](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/moderncomment/)` 实例，然后查看 `[ModernComment.getShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/moderncomment/getshape/)`、`[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/)`、`[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/)` 和 `[ModernComment.getStatus](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/moderncomment/getstatus/)`。`null` 形状表示幻灯片级批注。对于锚定到 `[AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)` 的批注，文本选区方法可确定该形状文本框中的关联范围。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("comments.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const comments = slide.getSlideComments(null);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (!java.instanceOf(comment, "com.aspose.slides.IModernComment")) {
                continue;
            }

            console.log("Slide: " + slide.getSlideNumber());
            console.log("Text: " + comment.getText());
            console.log("Status: " + comment.getStatus());

            const shape = comment.getShape();
            if (shape == null) {
                console.log("Anchor: slide level");
            } else {
                console.log("Anchor shape: " + shape.getName());
                console.log("Anchor type: " + shape.getClass().getSimpleName());

                if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                    console.log("Text selection start: " + comment.getTextSelectionStart());
                    console.log("Text selection length: " + comment.getTextSelectionLength());
                }
            }

            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **删除批注**

### **删除所有批注和批注作者**

以下示例展示了如何从演示文稿中删除所有批注和批注作者：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let index = 0; index < authors.size(); index++) {
        authors.get_Item(index).getComments().clear();
    }

    authors.clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **删除特定批注**

以下示例展示了如何从幻灯片中删除特定批注：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Author", "A");
    const createdTime = java.newInstanceSync("java.util.Date");

    const firstCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const secondCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.3), java.newFloat(0.2));
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const commentAuthor = authors.get_Item(authorIndex);
        const commentsToRemove = [];
        const comments = slide.getSlideComments(commentAuthor);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (comment.getText() === "comment 1") {
                commentsToRemove.push(comment);
            }
        }

        for (const comment of commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**Aspose.Slides 是否支持现代批注的已解决状态？**

是的。`[ModernComment.getStatus](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/moderncomment/getstatus/)` 与 `[ModernComment.setStatus](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/moderncomment/setstatus/)` 可访问 `[ModernCommentStatus](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/moderncommentstatus/)` 枚举值，其中包括 `Resolved`。该状态存储在演示文稿中，重新打开文件后仍可读取。

**是否支持线程式讨论（回复链），以及是否有嵌套限制？**

支持。每个批注都可以引用其 `[parent comment](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/comment/getparentcomment/)`，从而形成回复链。API 未对嵌套深度设定具体限制。

**批注标记在幻灯片上的位置使用哪种坐标系定义？**

标记位置采用幻灯片坐标系中的浮点坐标定义，允许您将其精确放置在幻灯片的任意位置。