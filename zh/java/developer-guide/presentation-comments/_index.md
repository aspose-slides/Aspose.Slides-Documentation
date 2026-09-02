---
title: 管理 Java 中的演示文稿批注
linktitle: 演示文稿批注
type: docs
weight: 100
url: /zh/java/presentation-comments/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 管理演示文稿批注：在 PowerPoint 演示文稿中快速轻松地添加、读取、编辑、回复和删除批注。"
---
## **概述**

本文介绍如何使用 Aspose.Slides for Java 管理演示文稿的批注。它介绍了主要的批注相关类型，并演示了如何向幻灯片添加批注、访问现有批注、处理回复和现代批注，以及从演示文稿中删除批注。

示例涵盖了 PowerPoint 中常见的审阅和协作场景，例如为作者分配批注、读取批注文本和元数据、构建回复链，以及删除选定的批注或全部批注。

在 PowerPoint 中，批注显示为幻灯片上的注释。选择批注时会显示其文本和相关讨论。

## **为什么向演示文稿添加批注？**

在审阅演示文稿时，可以使用批注提供反馈并与同事协作。

Aspose.Slides for Java 提供以下 API 用于操作批注：

* The [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类，提供对演示文稿批注作者的访问。
* The [ICommentCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icommentcollection/) 接口，表示与单个作者关联的批注集合。
* The [IComment](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icomment/) 接口，提供有关批注的信息，包括作者、创建时间、位置和文本。
* The [CommentAuthor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/commentauthor/) 类，提供有关作者的信息，包括姓名、缩写和关联的批注。

## **添加幻灯片批注**

以下示例演示如何向 PowerPoint 演示文稿的幻灯片添加批注：

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ICommentCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    Point2D.Float position = new Point2D.Float(0.2f, 0.2f);
    Date createdTime = new Date();

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    IComment[] comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        IComment firstComment = comments[0];
        System.out.println(firstComment.getText());

        ICommentCollection authorComments = firstComment.getAuthor().getComments();
        String commentText = authorComments.get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **访问幻灯片批注**

以下示例演示如何访问 PowerPoint 演示文稿中已有的批注：

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        for (IComment comment : author.getComments()) {
            System.out.println("Slide: " + comment.getSlide().getSlideNumber());
            System.out.println("Comment: " + comment.getText());
            System.out.println("Author: " + comment.getAuthor().getName());
            System.out.println("Posted at: " + comment.getCreatedTime());
            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **回复批注**

父批注是回复层级顶部的原始批注。The [IComment.getParentComment](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icomment/#getParentComment--) and [IComment.setParentComment](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) 方法让您获取或设置批注的父批注。

以下示例演示如何添加回复并检查生成的批注层级：

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Point2D.Float position = new Point2D.Float(10, 10);
    Date createdTime = new Date();

    ICommentAuthor author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    IComment comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++) {
        IComment comment = comments[i];
        while (comment.getParentComment() != null) {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() + ": " + comments[i].getText());
    }

    presentation.save("parent_comment.pptx", SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* When the [IComment.remove](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icomment/#remove--) method is used to delete a comment, all replies to that comment are also deleted.
* If [IComment.setParentComment](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) creates a circular reference, a [PptxEditException](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pptxeditexception/) is thrown.
{{% /alert %}}

## **添加现代批注**

现代批注可以关联到幻灯片本身、特定形状或 AutoShape 内的文本范围。The [ICommentCollection.addModernComment](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) 方法在接受 [IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/) 参数的同时，还需要提供幻灯片和批注标记的坐标。

当为 shape 参数传入 `null` 时，批注为幻灯片级批注。其标记由提供的坐标定位，但不关联特定形状，因此 [IModernComment.getShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imoderncomment/#getShape--) 返回 `null`。当提供 [IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/) 时，批注锚定到该形状。坐标仍定义批注标记在幻灯片上的位置，而形状关联可通过 [IModernComment.getShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imoderncomment/#getShape--) 获取。

### **将现代批注锚定到形状**

以下示例创建了一个幻灯片级现代批注和一个锚定到特定 AutoShape 的现代批注。随后读取每个批注关联的形状。

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    Date createdTime = new Date();
    Point2D.Float slideCommentPosition = new Point2D.Float(20, 20);
    Point2D.Float shapeCommentPosition = new Point2D.Float(60, 60);
    IModernComment slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    IModernComment shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    System.out.println(slideComment.getShape() == null);
    System.out.println(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **将批注锚定到不同的形状类型**

实现了 [IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/) 的任何幻灯片对象都可以作为形状锚点。常见示例包括 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)、[IPictureFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipictureframe/)、[IGroupShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/igroupshape/)、[IConnector](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iconnector/) 和 [IGraphicalObject](https://reference.aspose.com/slides/zh/java/com.aspose.slides/igraphicalobject/)（如图表）实例。

以下示例创建了几种常见形状类型并为每一种关联了现代批注。

```java
import com.aspose.slides.ChartType;
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IChart;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IConnector;
import com.aspose.slides.IGroupShape;
import com.aspose.slides.IPPImage;
import com.aspose.slides.IPictureFrame;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Base64;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Date createdTime = new Date();

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    Point2D.Float autoShapeCommentPosition = new Point2D.Float(30, 30);
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    String imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    byte[] imageData = Base64.getDecoder().decode(imageBase64);
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
    Point2D.Float pictureCommentPosition = new Point2D.Float(230, 30);
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    IGroupShape groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
    Point2D.Float groupCommentPosition = new Point2D.Float(40, 150);
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
    Point2D.Float connectorCommentPosition = new Point2D.Float(240, 150);
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
    Point2D.Float chartCommentPosition = new Point2D.Float(420, 40);
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **将批注锚定到文本并设置其状态**

对于关联到 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/) 的现代批注，[IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--) 和 [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) 访问形状文本框中所选文本的起始位置。[IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) 和 [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) 访问选区长度。这些值共同将批注关联到 AutoShape 中文本的特定范围。

[IModernComment.getStatus](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imoderncomment/#getStatus--) 和 [IModernComment.setStatus](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imoderncomment/#setStatus-byte-) 方法访问 [ModernCommentStatus](https://reference.aspose.com/slides/zh/java/com.aspose.slides/moderncommentstatus/) 常量中的值：

- `NotDefined` — 未定义特定的现代批注状态。
- `Active` — 批注处于活动状态。
- `Resolved` — 批注已解决。
- `Closed` — 批注已关闭。

以下示例创建了一个锚定到形状的现代批注，关联文本选区，将其标记为已解决，保存演示文稿并在重新打开文件后验证这些值。

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.ModernCommentStatus;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Date;

String outputFile = "modern_comment_text_anchor.pptx";
String shapeText = "Review the quarterly revenue forecast.";
String selectedText = "quarterly revenue";
int expectedSelectionStart = shapeText.indexOf(selectedText);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Point2D.Float commentPosition = new Point2D.Float(60, 60);
    IModernComment comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, new Date());
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length());
    comment.setStatus(ModernCommentStatus.Resolved);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IComment[] reopenedComments = reopenedSlide.getSlideComments(null);

    for (IComment reopenedComment : reopenedComments) {
        if (!(reopenedComment instanceof IModernComment)) {
            continue;
        }

        IModernComment modernComment = (IModernComment) reopenedComment;
        boolean shapeMatches = modernComment.getShape() != null && "Forecast text".equals(modernComment.getShape().getName());
        boolean selectionStartMatches = modernComment.getTextSelectionStart() == expectedSelectionStart;
        boolean selectionLengthMatches = modernComment.getTextSelectionLength() == selectedText.length();
        boolean statusMatches = modernComment.getStatus() == ModernCommentStatus.Resolved;

        System.out.println("Shape anchor preserved: " + shapeMatches);
        System.out.println("Text selection start preserved: " + selectionStartMatches);
        System.out.println("Text selection length preserved: " + selectionLengthMatches);
        System.out.println("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **检查现有的现代批注**

要检查已有的演示文稿，先判断批注是否实现了 [IModernComment](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imoderncomment/)，然后检查 [IModernComment.getShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imoderncomment/#getShape--)、[IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--)、[IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) 和 [IModernComment.getStatus](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imoderncomment/#getStatus--)。`null` 形状表示幻灯片级批注。对于 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/) 锚点，文本选区方法可识别形状文本框中的关联范围。

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.IModernComment;
import com.aspose.slides.IShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("comments.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        IComment[] comments = slide.getSlideComments(null);
        for (IComment comment : comments) {
            if (!(comment instanceof IModernComment)) {
                continue;
            }

            IModernComment modernComment = (IModernComment) comment;
            System.out.println("Slide: " + slide.getSlideNumber());
            System.out.println("Text: " + modernComment.getText());
            System.out.println("Status: " + modernComment.getStatus());

            IShape shape = modernComment.getShape();
            if (shape == null) {
                System.out.println("Anchor: slide level");
            } else {
                System.out.println("Anchor shape: " + shape.getName());
                System.out.println("Anchor type: " + shape.getClass().getSimpleName());

                if (shape instanceof IAutoShape) {
                    System.out.println("Text selection start: " + modernComment.getTextSelectionStart());
                    System.out.println("Text selection length: " + modernComment.getTextSelectionLength());
                }
            }

            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **删除批注**

### **删除所有批注和批注作者**

以下示例演示如何从演示文稿中删除所有批注和批注作者：

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("example.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        author.getComments().clear();
    }

    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **删除特定批注**

以下示例演示如何从幻灯片中删除特定批注：

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    Date createdTime = new Date();

    Point2D.Float firstCommentPosition = new Point2D.Float(0.2f, 0.2f);
    Point2D.Float secondCommentPosition = new Point2D.Float(0.3f, 0.2f);
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors()) {
        List<IComment> commentsToRemove = new ArrayList<IComment>();
        IComment[] comments = slide.getSlideComments(commentAuthor);

        for (IComment comment : comments) {
            if ("comment 1".equals(comment.getText())) {
                commentsToRemove.add(comment);
            }
        }

        for (IComment comment : commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**Aspose.Slides 是否支持现代批注的已解决状态？**

是的。[IModernComment.getStatus](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imoderncomment/#getStatus--) 和 [IModernComment.setStatus](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imoderncomment/#setStatus-byte-) 可访问 [ModernCommentStatus](https://reference.aspose.com/slides/zh/java/com.aspose.slides/moderncommentstatus/) 中的值，包括 `Resolved`。该状态会存储在演示文稿中，重新打开文件后仍可读取。

**是否支持线程式讨论（回复链），并且是否有限制层级深度？**

是的。每个批注都可以引用其 [parent comment](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icomment/#getParentComment--)，从而实现回复链。API 并未定义具体的嵌套深度限制。

**批注标记在幻灯片上的位置使用何种坐标系定义？**

标记位置使用幻灯片坐标系中的浮点坐标定义，您可以在幻灯片上精确定位。