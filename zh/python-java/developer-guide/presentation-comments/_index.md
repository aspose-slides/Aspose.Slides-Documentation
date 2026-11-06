---
title: 使用 Python via Java 管理演示文稿评论
linktitle: 演示文稿评论
type: docs
weight: 100
url: /zh/python-java/presentation-comments/
keywords:
- 评论
- 现代评论
- PowerPoint 评论
- 演示文稿评论
- 幻灯片评论
- 添加评论
- 访问评论
- 编辑评论
- 回复评论
- 移除评论
- 删除评论
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 管理演示文稿评论：在 PowerPoint 演示文稿中快速轻松地添加、读取、编辑、回复和删除评论。"
---
## **概述**

本文介绍了如何使用 Aspose.Slides for Python via Java 管理演示文稿评论。它介绍了主要的与评论相关的类型，并演示了如何向幻灯片添加评论、访问现有评论、处理回复和现代评论，以及如何从演示文稿中删除评论。

这些示例覆盖了 PowerPoint 中常见的审阅和协作场景，例如将评论分配给作者、读取评论文本和元数据、构建回复链以及删除选定的评论或全部评论。

在 PowerPoint 中，评论显示为幻灯片上的注释。选择评论会显示其文本和相关讨论。

要在打开演示文稿时显示或隐藏评论而不更改评论本身，请参阅[在打开演示文稿时显示或隐藏评论](/slides/zh/python-java/presentation-view-properties/)。

## **为什么要向演示文稿添加评论？**

在审阅演示文稿时，您可以使用评论提供反馈并与同事协作。

Aspose.Slides for Python via Java 提供以下 API 用于处理评论：
* The [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class, which provides access to the presentation's comment authors.
* The [CommentCollection](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/) class, which represents the comments associated with an individual author.
* The [Comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/) class, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/) class, which provides information about an author, including their name, initials, and associated comments.

## **添加幻灯片评论**

示例创建了两张幻灯片，并使用 [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) 注册了一个评论作者。它使用 [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) 在每张幻灯片上放置一个评论，然后使用 [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) 获取该作者在第一张幻灯片上的评论。控制台两次显示第一条评论的文本，演示了通过幻灯片和作者两种方式访问，并且保存的演示文稿包含这两个评论。

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

## **查找或创建评论作者**

当自动审阅反复处理同一演示文稿时，应在添加作者之前搜索由 [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors) 返回的集合。[findByNameAndInitials](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByNameAndInitials) 同时匹配姓名和缩写，并返回匹配作者的数组；如果没有匹配项，则返回空数组。相比之下，[findByName](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByName) 仅按姓名搜索，不考虑缩写。使用已在集合中存在的姓名和缩写调用 [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) 会抛出异常。

示例需要一个至少包含一张幻灯片的演示文稿文件。在两次遍历中，它复用第一个匹配的作者，只有在结果为空时才创建新作者。如果有多个匹配项，它会选择数组的第一个元素，而不合并或删除其他作者。然后对所选作者调用 [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) 并保存演示文稿。第二次遍历打开第一次遍历的输出并重复该操作。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = Point2DFloat(20, 20)

for pass_number in range(1, 3):
    presentation = Presentation(input_file)
    try:
        matches = presentation.getCommentAuthors().findByNameAndInitials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.getCommentAuthors().addAuthor(author_name, author_initials)
        created_time = Date()
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, created_time)

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, SaveFormat.Pptx)
        input_file = output_file
    finally:
        presentation.dispose()
```

第二次遍历会添加另一条评论，但不会添加新作者或删除已有评论。最终文件 `review_pass_2.pptx` 包含两个新评论以及任何原始评论。复用作者不会对评论去重：为避免重复添加相同的评论，需要在添加之前实现单独的重复检测。

## **访问幻灯片评论**

示例打开现有演示文稿，并读取由 [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors) 返回的集合。对于每个作者，它遍历由 [getComments](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/#getComments) 返回的集合，并打印幻灯片编号、评论文本、作者姓名和创建时间。输入的演示文稿必须包含评论才能产生控制台输出。

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

## **回复评论**

父评论是回复层级顶部的原始评论。[Comment.getParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment) 和 [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) 方法允许获取或设置评论的父级。

示例从两个作者创建评论，并使用 [setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) 构建回复，包括对另一个回复的回复。向 [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) 传递 `None` 可检索所有作者的评论；控制台根据其在回复层级中的深度对每个条目进行缩进。示例保存完整的讨论，对第一个根评论调用 [remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove)，并保存第二个演示文稿，该文稿已删除该评论及其回复。

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

{{% alert color="warning" title="Warning" %}}
* 当使用 [Comment.remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) 方法删除评论时，该评论的所有回复也会被删除。
* 如果 [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) 创建循环引用，则会抛出 [PptxEditException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **添加现代评论**

现代评论可以关联到幻灯片本身、特定形状或 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) 中的文本范围。[CommentCollection.addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) 方法接受一个 [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 参数，除了幻灯片和评论标记坐标外。

当形状参数传入 `None` 时，评论为幻灯片级别的评论。其标记由提供的坐标定位，但不关联到特定形状，因此 [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) 返回 `None`。当提供了 [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 时，评论锚定到该形状。坐标仍定义评论标记在幻灯片上的位置，而形状关联可通过 [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) 获取。

### **将现代评论锚定到形状**

示例调用两次 [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment)：一次使用 `None` 形状创建幻灯片级别的评论，一次使用矩形作为锚点。读取 [getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) 对于幻灯片级别评论的 `None` 检查打印 `True`，对于锚定的评论打印 `Revenue title`。两个评论都随演示文稿一起保存。

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

### **将评论锚定到不同的形状类型**

任何继承自 [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 的幻灯片对象都可以用作形状锚点。常见示例包括 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)、[PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/)、[GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/)、[Connector](https://reference.aspose.com/slides/python-java/aspose.slides/connector/) 和 [GraphicalObject](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobject/) 实例，如图表。

示例使用 [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) 将评论分别关联到五种形状类型：AutoShape、图片框、组合、连接线和图表。图片使用嵌入的图像数据，无需外部图像。每个评论都有其独立的标记位置，保存的演示文稿保留了这五种形状的关联。

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

### **将评论锚定到文本并设置其状态**

对于关联到 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) 的现代评论，[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart) 和 [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) 可获取形状文本框中所选文本的起始位置。[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) 和 [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) 可获取选区的长度。这些值共同将评论关联到 AutoShape 内的特定文本范围。

[ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) 和 [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) 方法访问 [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/) 常量中的值：
- [NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#NotDefined) — 未定义特定的现代评论状态。
- [Active](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Active) — 评论处于激活状态。
- [Resolved](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Resolved) — 评论已解决。
- [Closed](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Closed) — 评论已关闭。

示例将现代评论锚定到矩形文本中的 "quarterly revenue" 一词。它根据文本计算零基选区起始位置，并将其传递给 [setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart)，使用 [setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) 设置选中字符数。调用 [setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) 并传入 `Resolved` 后，保存并重新打开演示文稿。四个控制台检查应各自打印 `True`，确认形状锚点、文本范围和状态均已保留。

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

### **检查现有的现代评论**

示例需要一个包含现代评论的现有演示文稿，并打印它们的文本、状态和锚点详细信息。要检查它，首先判断哪些评论是 [ModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/) 的实例，然后检查 [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape)、[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart)、[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) 和 [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus)。`None` 形状表示幻灯片级别的评论。对于 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) 锚点，文本选择方法会识别形状文本框中的关联范围。

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

## **删除评论**

Aspose.Slides for Python via Java 允许您从演示文稿中删除所有评论及其作者，或仅删除选定的评论而保留其余内容。以下示例演示这两种方法并保存更新后的演示文稿。

### **删除所有评论及其作者**

示例打开现有演示文稿，对每个作者调用 [CommentCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#clear)，随后调用 [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#clear) 删除作者本身。保存的演示文稿既没有评论，也没有评论作者。使用包含评论的演示文稿可观察到删除效果。

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

### **删除特定评论**

示例在同一幻灯片上创建两个评论，并使用 [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) 按作者查找评论。在调用 [CommentCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#remove) 之前，收集文本等于 "comment 1" 的评论，以避免在选择期间修改集合。保存的演示文稿仅保留 "comment 2"。

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

**Aspose.Slides 是否支持现代评论的已解决状态？**

是的。[ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) 和 [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) 访问 [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/) 中的值，包括 `Resolved`。该状态存储在演示文稿中，文件重新打开后仍可读取。

**是否支持线程式讨论（回复链），并且是否有嵌套深度限制？**

是的。每个评论可以引用其 [parent comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment)，从而实现回复链。API 未定义具体的嵌套深度限制。

**评论标记在幻灯片上的位置采用什么坐标系定义？**

标记位置使用幻灯片坐标系中的浮点坐标定义，可在幻灯片上精确定位。