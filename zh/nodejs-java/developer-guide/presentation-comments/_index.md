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
description: "使用 Aspose.Slides for Node.js via Java 管理 PowerPoint 演示文稿中的批注：添加、读取、编辑、回复和删除批注。"
---
## **概述**

本文说明如何使用 Aspose.Slides for Node.js via Java 管理演示文稿批注。它介绍了主要的批注相关类型，并演示了如何向幻灯片添加批注、访问现有批注、使用回复和现代批注以及从演示文稿中删除批注。

这些示例涵盖了 PowerPoint 中常见的审阅和协作场景，例如将批注分配给作者、读取批注文本和元数据、构建回复链以及删除选定的批注或全部批注。

在 PowerPoint 中，批注显示为幻灯片上的注释。选择批注时会显示其文本和相关讨论。

要在打开演示文稿时请求显示或隐藏批注而不更改批注本身，请参见[打开演示文稿时显示或隐藏批注](/slides/zh/nodejs-java/presentation-view-properties/)。

## **为何向演示文稿添加批注？**

在审阅演示文稿时，您可以使用批注提供反馈并与同事协作。

Aspose.Slides for Node.js via Java 提供以下用于处理批注的 API：

* The [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class，提供对演示文稿的批注作者的访问。
* The [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/) class，表示与单个作者关联的批注。
* The [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/) class，提供有关批注的信息，包括作者、创建时间、位置和文本。
* The [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/) class，提供有关作者的信息，包括姓名、首字母和关联的批注。

## **添加幻灯片批注**

示例创建了两个幻灯片，并使用 [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) 注册一个批注作者。它使用 [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) 在每个幻灯片上放置一个批注，然后使用 [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) 检索该作者的第一张幻灯片的批注。控制台两次显示第一条批注的文本，演示了通过幻灯片和作者两种方式访问，并且保存的演示文稿包含两个批注。

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

        const commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **查找或创建批注作者**

当自动审阅重复处理同一演示文稿时，应在添加作者之前搜索由 [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) 返回的集合。[findByNameAndInitials](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbynameandinitials/) 同时匹配名称和首字母，并返回匹配作者的数组，如果没有匹配则返回空数组。相反，[findByName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbyname/) 仅按名称搜索，忽略首字母。使用已在集合中存在的名称和首字母调用 [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) 将抛出异常。

示例需要一个至少包含一张幻灯片的演示文稿文件。 在两次遍历中，它复用第一个匹配的作者，只有在结果为空时才创建新作者。如果有多个匹配，它选择数组的第一个元素，不合并或删除其他作者。然后它为选定的作者调用 [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) 并保存演示文稿。第二次遍历打开第一次遍历的输出并重复该操作。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const authorName = "Reviewer";
const authorInitials = "RV";

let inputFile = "input.pptx";
const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));

for (let pass = 1; pass <= 2; pass++) {
    const presentation = new aspose.slides.Presentation(inputFile);
    try {
        const matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        const author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        const createdTime = java.newInstanceSync("java.util.Date");
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, createdTime);

        const outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

第二次遍历添加了另一个批注，但未添加新的作者，也未删除现有批注。最终文件 `review_pass_2.pptx` 包含新的批注以及任何原始批注。复用作者并不会去重批注：为避免重复添加相同批注，需要在添加前实现单独的重复检测。

## **访问幻灯片批注**

示例打开一个现有演示文稿，并读取由 [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) 返回的集合。对于每个作者，它遍历由 [getComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/getcomments/) 返回的集合，并打印幻灯片编号、批注文本、作者姓名和创建时间。输入的演示文稿必须包含批注才能在控制台产生输出。

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

父批注是回复层次结构顶部的原始批注。[Comment.getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) 和 [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) 方法可让您获取或设置批注的父批注。

示例创建了两个作者的批注，并使用 [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) 构建回复，包括对另一个回复的回复。将 `null` 传递给 [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) 可检索所有作者的批注；控制台根据回复层次的深度对每条记录进行缩进。示例保存完整讨论，对第一条根批注调用 [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/)，并保存第二个演示文稿，该文稿已删除该批注及其所有回复。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    const reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    const secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    const subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    const separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    const separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

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

    rootComment.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* 当使用 [Comment.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) 方法删除批注时，该批注的所有回复也会被删除。
* 如果 [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) 创建循环引用，则会抛出 [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **添加现代批注**

现代批注可以关联到幻灯片本身、特定形状或 AutoShape 内的文本范围。[CommentCollection.addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) 方法除了接受幻灯片和批注标记坐标外，还接受一个 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 参数。

当形状参数为 `null` 时，批注为幻灯片级批注。其标记由提供的坐标定位，但不关联特定形状，因此 [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) 返回 `null`。当提供 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 时，批注锚定到该形状。坐标仍定义批注标记在幻灯片上的位置，而形状关联可通过 [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) 获取。

### **将现代批注锚定到形状**

示例两次调用 [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/)：一次使用 `null` 形状创建幻灯片级批注，一次使用矩形作为锚点。读取 [getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) 对幻灯片级批注的空检查打印 `true`，对锚定批注打印 `Revenue title`。两个批注都随演示文稿一起保存。

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

任何从 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 派生的幻灯片对象都可以用作形状锚点。常见示例包括 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)，[PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/)，[GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/)，[Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/)，以及如图表等 [GraphicalObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobject/) 实例。

示例使用 [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) 将批注分别关联到五种形状类型：AutoShape、图片框、组合、连接线和图表。图片使用嵌入的图像数据，无需外部图像。每个批注都有自己的标记位置，保存的演示文稿保留了所有五个形状的关联。

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

对于关联到 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) 的现代批注，[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) 和 [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) 可访问形状文本框中所选文本的起始位置。[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) 和 [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) 可访问所选文本的长度。这些值共同将批注关联到 AutoShape 内的特定文本范围。

以下是 [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) 和 [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) 方法从 [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) 枚举中获取的值：

- `NotDefined` — 未定义特定的现代批注状态。
- `Active` — 批注处于活动状态。
- `Resolved` — 批注已解决。
- `Closed` — 批注已关闭。

示例将现代批注锚定到矩形文本中的 “quarterly revenue” 这几个词。它根据文本计算零基的选择起始位置并传递给 [setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/)，并使用 [setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) 设置所选字符的数量。调用带有 `Resolved` 参数的 [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) 后，保存并重新打开演示文稿。四个控制台检查应各自打印 `true`，确认形状锚点、文本范围和状态均已保留。

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
    comment.setStatus(java.newByte(aspose.slides.ModernCommentStatus.Resolved));

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

示例需要一个包含现代批注的现有演示文稿，并打印其文本、状态和锚点细节。要检查它，首先判断批注是否为 [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/) 的实例，然后检查 [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/)，[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/)，[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/)，和 [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/)。`null` 形状表示幻灯片级批注。对于 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) 锚点，文本选择方法用于识别形状文本框中的相应范围。

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

Aspose.Slides for Node.js via Java 允许您从演示文稿中删除所有批注及其作者，或仅删除选定批注而保留其余内容。以下示例演示这两种方法并保存更新后的演示文稿。

### **删除所有批注及批注作者**

示例打开一个现有演示文稿，对每个作者调用 [CommentCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/clear/)，随后调用 [CommentAuthorCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/clear/) 删除作者本身。保存的演示文稿既不包含批注，也不包含批注作者。使用包含批注的演示文稿即可观察删除效果。

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

示例在同一幻灯片上创建两个批注，并使用 [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) 按作者查找批注。在调用 [CommentCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/remove/) 之前，收集文本等于 “comment 1” 的批注，以避免在选择期间修改集合。保存的演示文稿仅保留 “comment 2”。

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

是的。[ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) 和 [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) 可访问 [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) 的值，包括 `Resolved`。该状态存储在演示文稿中，文件重新打开后仍可读取。

**是否支持线程式讨论（回复链），以及是否有嵌套深度限制？**

是的。每个批注都可以引用其 [父批注](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/)，从而实现回复链。API 未定义具体的嵌套深度限制。

**批注标记在幻灯片上的位置采用什么坐标系定义？**

标记位置由幻灯片坐标系中的浮点坐标定义，您可以精确地将其放置在幻灯片上。