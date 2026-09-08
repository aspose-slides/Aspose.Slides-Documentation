---
title: 在 Python via Java 中管理演示文稿批注
linktitle: 演示文稿批注
type: docs
weight: 100
url: /zh/python-java/presentation-comments/
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
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 管理演示文稿批注：快速轻松地在 PowerPoint 演示文稿中添加、读取、编辑、回复和删除批注。"
---
## **概述**

本文说明如何使用 Aspose.Slides for Python via Java 管理演示文稿中的批注。它介绍了主要的批注相关类型，并演示如何向幻灯片添加批注、访问现有批注、处理回复和现代批注，以及从演示文稿中删除批注。

示例涵盖了 PowerPoint 中常见的审阅与协作场景，例如为作者分配批注、读取批注文本和元数据、构建回复链，以及删除选定批注或全部批注。

在 PowerPoint 中，批注显示为幻灯片上的注释。选中批注后会显示其文本及相关讨论。

## **为什么要在演示文稿中添加批注？**

在审阅演示文稿时，您可以使用批注提供反馈并与同事协作。

Aspose.Slides for Python via Java 提供了以下用于处理批注的 API：

* The [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) class, which provides access to the presentation's comment authors.
* The [CommentCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/commentcollection/) class, which represents the comments associated with an individual author.
* The [Comment](https://reference.aspose.com/slides/zh/python-java/aspose.slides/comment/) class, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/commentauthor/) class, which provides information about an author, including their name, initials, and associated comments.

## **添加幻灯片批注**

以下示例展示了如何向 PowerPoint 演示文稿的幻灯片添加批注：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0))
    author = presentation.getCommentAuthors().addAuthor("Jawad", "MF")
    position = Point2DFloat(0.2, 0.2)
    created_time = Date()

    author.getComments().addComment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.getComments().addComment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.getSlideComments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.getText())

        author_comments = first_comment.getAuthor().getComments()
        comment_text = author_comments.get_Item(0).getText()
        print(comment_text)

    presentation.save("Comments_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **访问幻灯片批注**

以下示例展示了如何访问 PowerPoint 演示文稿中已有的批注：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Comments1.pptx")
try:
    for author in presentation.getCommentAuthors():
        for comment in author.getComments():
            print("Slide: ", comment.getSlide().getSlideNumber())
            print("Comment: ", comment.getText())
            print("Author: ", comment.getAuthor().getName())
            print("Posted at: ", comment.getCreatedTime())
            print()
finally:
    presentation.dispose()
```

## **回复批注**

父批注是回复层级顶部的原始批注。[Comment.getParentComment](https://reference.aspose.com/slides/zh/python-java/aspose.slides/comment/#getParentComment) 和 [Comment.setParentComment](https://reference.aspose.com/slides/zh/python-java/aspose.slides/comment/#setParentComment) 方法用于获取或设置批注的父批注。

以下示例展示了如何添加回复并检查生成的批注层级：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    position = Point2DFloat(10, 10)
    created_time = Date()

    thread_author = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.")
    root_comment = thread_author.getComments().addComment("comment 1", slide, position, created_time)

    responding_author = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.")
    direct_reply = responding_author.getComments().addComment("reply 1 for comment 1", slide, position, created_time)
    direct_reply.setParentComment(root_comment)

    branch_reply = responding_author.getComments().addComment("reply 2 for comment 1", slide, position, created_time)
    branch_reply.setParentComment(root_comment)

    nested_reply = thread_author.getComments().addComment("subreply 3 for reply 2", slide, position, created_time)
    nested_reply.setParentComment(branch_reply)

    responding_author.getComments().addComment("comment 2", slide, position, created_time)
    separate_thread_comment = responding_author.getComments().addComment("comment 3", slide, position, created_time)

    separate_thread_reply = thread_author.getComments().addComment("reply 4 for comment 3", slide, position, created_time)
    separate_thread_reply.setParentComment(separate_thread_comment)

    comments = slide.getSlideComments(None)
    for i in range(len(comments)):
        comment = comments[i]
        while comment.getParentComment() is not None:
            print("\t", end="")
            comment = comment.getParentComment()

        print(f"{comments[i].getAuthor().getName()}: {comments[i].getText()}")

    presentation.save("parent_comment.pptx", SaveFormat.Pptx)

    root_comment.remove()
    presentation.save("remove_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="警告" %}}
* 当使用 [Comment.remove](https://reference.aspose.com/slides/zh/python-java/aspose.slides/comment/#remove) 方法删除批注时，该批注的所有回复也会被删除。
* 如果 [Comment.setParentComment](https://reference.aspose.com/slides/zh/python-java/aspose.slides/comment/#setParentComment) 产生循环引用，则会抛出 [PptxEditException](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **添加现代批注**

现代批注可以与幻灯片本身、特定形状或 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/) 内的文本范围关联。[CommentCollection.addModernComment](https://reference.aspose.com/slides/zh/python-java/aspose.slides/commentcollection/#addModernComment) 方法除了接收幻灯片和批注标记坐标外，还接受一个 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/) 参数。

当 shape 参数为 `None` 时，批注为幻灯片级批注。其标记由提供的坐标定位，但不关联到具体形状，因此 [ModernComment.getShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncomment/#getShape) 返回 `None`。当提供了 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/) 时，批注锚定到该形状。坐标仍定义批注标记在幻灯片上的位置，而形状关联可通过 [ModernComment.getShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncomment/#getShape) 获取。

### **将现代批注锚定到形状**

以下示例创建了一个幻灯片级现代批注和一个锚定到特定 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/) 的现代批注。随后读取每个批注关联的形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80)
    shape.setName("Revenue title")
    shape.getTextFrame().setText("Quarterly revenue")

    created_time = Date()
    slide_comment_position = Point2DFloat(20, 20)
    shape_comment_position = Point2DFloat(60, 60)
    slide_comment = author.getComments().addModernComment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.getComments().addModernComment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.getShape() is None)
    print(shape_comment.getShape().getName())

    presentation.save("modern_comments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **将批注锚定到不同的形状类型**

任何继承自 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/) 的幻灯片对象都可用作形状锚定。常见示例包括 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)、[PictureFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/)、[GroupShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/groupshape/)、[Connector](https://reference.aspose.com/slides/zh/python-java/aspose.slides/connector/) 和图表等 [GraphicalObject](https://reference.aspose.com/slides/zh/python-java/aspose.slides/graphicalobject/) 实例。

以下示例创建了几种常见形状类型，并为每种形状关联了一个现代批注。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")
Base64 = jpype.JClass("java.util.Base64")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    created_time = Date()

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60)
    auto_shape.getTextFrame().setText("AutoShape")
    auto_shape_comment_position = Point2DFloat(30, 30)
    author.getComments().addModernComment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = Base64.getDecoder().decode(image_base64)
    image = presentation.getImages().addImage(image_data)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image)
    picture_comment_position = Point2DFloat(230, 30)
    author.getComments().addModernComment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.getShapes().addGroupShape()
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40)
    group_shape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40)
    group_comment_position = Point2DFloat(40, 150)
    author.getComments().addModernComment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40)
    connector_comment_position = Point2DFloat(240, 150)
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180)
    chart_comment_position = Point2DFloat(420, 40)
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **将批注锚定到文本并设置其状态**

对于与 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/) 关联的现代批注，[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncomment/#getTextSelectionStart) 和 [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncomment/#setTextSelectionStart) 用于访问形状文本框中已选中文本的起始位置。[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncomment/#getTextSelectionLength) 和 [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncomment/#setTextSelectionLength) 用于访问选区长度。这些值共同将批注关联到 AutoShape 内的特定文本范围。

[ModernComment.getStatus](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncomment/#getStatus) 和 [ModernComment.setStatus](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncomment/#setStatus) 方法访问 [ModernCommentStatus](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncommentstatus/) 常量中的值：

- [NotDefined](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncommentstatus/#NotDefined) — 未定义特定的现代批注状态。
- [Active](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncommentstatus/#Active) — 批注处于活动状态。
- [Resolved](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncommentstatus/#Resolved) — 批注已解决。
- [Closed](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncommentstatus/#Closed) — 批注已关闭。

以下示例创建了一个锚定到形状的现代批注，关联文本选区，将其标记为已解决，保存演示文稿，并在重新打开文件后验证这些值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ModernComment, ModernCommentStatus, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.find(selected_text)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    shape.setName("Forecast text")
    shape.getTextFrame().setText(shape_text)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    comment_position = Point2DFloat(60, 60)
    created_time = Date()
    comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, comment_position, created_time)
    comment.setTextSelectionStart(expected_selection_start)
    comment.setTextSelectionLength(len(selected_text))
    comment.setStatus(ModernCommentStatus.Resolved)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_comments = reopened_slide.getSlideComments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, ModernComment):
            continue

        modern_comment = reopened_comment
        shape_matches = modern_comment.getShape() is not None and modern_comment.getShape().getName() == "Forecast text"
        selection_start_matches = modern_comment.getTextSelectionStart() == expected_selection_start
        selection_length_matches = modern_comment.getTextSelectionLength() == len(selected_text)
        status_matches = modern_comment.getStatus() == ModernCommentStatus.Resolved

        print("Shape anchor preserved: ", shape_matches)
        print("Text selection start preserved: ", selection_start_matches)
        print("Text selection length preserved: ", selection_length_matches)
        print("Resolved status preserved: ", status_matches)
finally:
    reopened_presentation.dispose()
```

### **检查现有的现代批注**

要检查现有演示文稿，先判断批注是否为 [ModernComment](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncomment/) 实例，然后检查 [ModernComment.getShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncomment/#getShape)、[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncomment/#getTextSelectionStart)、[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncomment/#getTextSelectionLength) 和 [ModernComment.getStatus](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncomment/#getStatus)。`None` 形状表示幻灯片级批注。对于锚定到 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/) 的批注，文本选区方法指示该形状文本框中的关联范围。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ModernComment, Presentation

presentation = Presentation("comments.pptx")
try:
    for slide in presentation.getSlides():
        comments = slide.getSlideComments(None)
        for comment in comments:
            if not isinstance(comment, ModernComment):
                continue

            modern_comment = comment
            print("Slide: ", slide.getSlideNumber())
            print("Text: ", modern_comment.getText())
            print("Status: ", modern_comment.getStatus())

            shape = modern_comment.getShape()
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: ", shape.getName())
                print("Anchor type: ", shape.getClass().getSimpleName())

                if isinstance(shape, AutoShape):
                    print("Text selection start: ", modern_comment.getTextSelectionStart())
                    print("Text selection length: ", modern_comment.getTextSelectionLength())

            print()
finally:
    presentation.dispose()
```

## **删除批注**

### **删除所有批注和批注作者**

以下示例展示了如何删除演示文稿中的所有批注和批注作者：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("example.pptx")
try:
    for author in presentation.getCommentAuthors():
        author.getComments().clear()

    presentation.getCommentAuthors().clear()
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **删除特定批注**

以下示例展示了如何从幻灯片中删除特定批注：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("Author", "A")
    created_time = Date()

    first_comment_position = Point2DFloat(0.2, 0.2)
    second_comment_position = Point2DFloat(0.3, 0.2)
    author.getComments().addComment("comment 1", slide, first_comment_position, created_time)
    author.getComments().addComment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.getCommentAuthors():
        comments_to_remove = []
        comments = slide.getSlideComments(comment_author)

        for comment in comments:
            if comment.getText() == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.getComments().remove(comment)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**Aspose.Slides 是否支持现代批注的已解决状态？**

是的。[ModernComment.getStatus](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncomment/#getStatus) 和 [ModernComment.setStatus](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncomment/#setStatus) 可访问 [ModernCommentStatus](https://reference.aspose.com/slides/zh/python-java/aspose.slides/moderncommentstatus/) 值，包括 `Resolved`。该状态会保存到演示文稿中，并在文件重新打开后可再次读取。

**是否支持线程式讨论（回复链），是否有嵌套层级限制？**

是的。每个批注都可以引用其 [parent comment](https://reference.aspose.com/slides/zh/python-java/aspose.slides/comment/#getParentComment)，从而形成回复链。API 未定义具体的嵌套深度限制。

**批注标记在幻灯片上的位置使用何种坐标系定义？**

标记位置使用幻灯片坐标系中的浮点坐标定义，允许您精确地将其放置在幻灯片上。