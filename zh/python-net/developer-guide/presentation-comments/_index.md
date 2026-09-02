---
title: 在 Python 中管理演示文稿批注
linktitle: 演示文稿批注
type: docs
weight: 100
url: /zh/python-net/presentation-comments/
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
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 管理演示文稿批注：在 PowerPoint 演示文稿中添加、读取、编辑、回复和移除批注。"
---
## **概述**

本文解释如何使用 Aspose.Slides for Python via .NET 管理演示文稿中的批注。它介绍了主要的批注相关类型，并演示了如何向幻灯片添加批注、访问现有批注、处理回复和现代批注以及从演示文稿中删除批注。

示例涵盖了 PowerPoint 中常见的审阅和协作场景，例如为作者分配批注、读取批注文本和元数据、构建回复链以及删除选定的批注或全部批注。

在 PowerPoint 中，批注以幻灯片上的注释形式出现。选择批注后会显示其文本和相关讨论。

## **为什么要向演示文稿添加批注？**

在审阅演示文稿时，您可以使用批注提供反馈并与同事协作。

Aspose.Slides for Python via .NET 提供以下用于处理批注的 API：

* The [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) class, which provides access to the presentation's comment authors.
* The [CommentCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/commentcollection/) class, which represents the comments associated with an individual author.
* The [Comment](https://reference.aspose.com/slides/zh/python-net/aspose.slides/comment/) class, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/zh/python-net/aspose.slides/commentauthor/) class, which provides information about an author, including their name, initials, and associated comments.

## **向幻灯片添加批注**

以下示例演示如何向 PowerPoint 演示文稿的幻灯片添加批注：

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = draw.PointF(0.2, 0.2)
    created_time = datetime.now()

    author.comments.add_comment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.comments.add_comment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.get_slide_comments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.text)

        comment_text = first_comment.author.comments[0].text
        print(comment_text)

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)
```

## **访问幻灯片批注**

以下示例演示如何访问 PowerPoint 演示文稿中已有的批注：

```python
import aspose.slides as slides

with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("Slide: " + str(comment.slide.slide_number))
            print("Comment: " + comment.text)
            print("Author: " + comment.author.name)
            print("Posted at: " + str(comment.created_time))
            print()
```

## **回复批注**

父批注是回复层级顶部的原始批注。[Comment](https://reference.aspose.com/slides/zh/python-net/aspose.slides/comment/) 类的[parent_comment](https://reference.aspose.com/slides/zh/python-net/aspose.slides/comment/parent_comment/) 属性允许获取或设置批注的父批注。

以下示例演示如何添加回复并检查生成的批注层级结构：

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    position = draw.PointF(10, 10)
    created_time = datetime.now()

    author1 = presentation.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment 1", slide, position, created_time)

    author2 = presentation.comment_authors.add_author("Author_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    reply1.parent_comment = comment1

    reply2 = author2.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    reply2.parent_comment = comment1

    sub_reply = author1.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = reply2

    author2.comments.add_comment("comment 2", slide, position, created_time)
    comment3 = author2.comments.add_comment("comment 3", slide, position, created_time)

    reply3 = author1.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    reply3.parent_comment = comment3

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    comment1.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* 当使用 [Comment](https://reference.aspose.com/slides/zh/python-net/aspose.slides/comment/) 类的[remove](https://reference.aspose.com/slides/zh/python-net/aspose.slides/comment/remove/) 方法删除批注时，所有对该批注的回复也会被删除。  
* 如果[parent_comment](https://reference.aspose.com/slides/zh/python-net/aspose.slides/comment/parent_comment/) 属性导致循环引用，则会抛出 [PptxEditException](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **添加现代批注**

现代批注可以关联到幻灯片本身、特定形状或 AutoShape 内的文本范围。[CommentCollection.add_modern_comment](https://reference.aspose.com/slides/zh/python-net/aspose.slides/commentcollection/add_modern_comment/) 方法接受一个 [Shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/) 参数，除了幻灯片和批注标记坐标之外。

当 `None` 传递给 shape 参数时，批注为幻灯片级批注。其标记由提供的坐标定位，但不关联到特定形状，因此 [ModernComment.shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/moderncomment/shape/) 返回 `None`。当提供了 [Shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/) 时，批注锚定到该形状。坐标仍定义批注标记在幻灯片上的位置，而形状关联可通过 [ModernComment.shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/moderncomment/shape/) 获取。

### **将现代批注锚定到形状**

以下示例创建了一个幻灯片级现代批注和一个锚定到特定 AutoShape 的现代批注。随后读取每个批注关联的形状。

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = draw.PointF(20, 20)
    shape_comment_position = draw.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **将批注锚定到不同的形状类型**

任何从 [Shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/) 派生的幻灯片对象都可以用作形状锚点。常见示例包括 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)、[PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/)、[GroupShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/groupshape/)、[Connector](https://reference.aspose.com/slides/zh/python-net/aspose.slides/connector/) 和 [GraphicalObject](https://reference.aspose.com/slides/zh/python-net/aspose.slides/graphicalobject/) 实例（如图表）。

以下示例创建了几种常见的形状类型，并为每种形状关联了一个现代批注。

```python
import base64
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"
    auto_shape_comment_position = draw.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = draw.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = draw.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = draw.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = draw.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **将批注锚定到文本并设置其状态**

对于关联到 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/) 的现代批注，[ModernComment.text_selection_start](https://reference.aspose.com/slides/zh/python-net/aspose.slides/moderncomment/text_selection_start/) 指定形状文本框中所选文本的起始位置，而 [ModernComment.text_selection_length](https://reference.aspose.com/slides/zh/python-net/aspose.slides/moderncomment/text_selection_length/) 指定选区的长度。这两个属性共同将批注关联到 AutoShape 内的特定文本范围。

[ModernComment.status](https://reference.aspose.com/slides/zh/python-net/aspose.slides/moderncomment/status/) 属性可读取或使用 [ModernCommentStatus](https://reference.aspose.com/slides/zh/python-net/aspose.slides/moderncommentstatus/) 枚举中的值进行更新：

- `NOT_DEFINED` — 未定义特定的现代批注状态。  
- `ACTIVE` — 批注处于活动状态。  
- `RESOLVED` — 批注已解决。  
- `CLOSED` — 批注已关闭。

以下示例创建了一个锚定到形状的现代批注，将其与文本选区关联，标记为已解决，保存演示文稿，并在重新打开文件后验证这些值。

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.index(selected_text)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 100)
    shape.name = "Forecast text"
    shape.text_frame.text = shape_text

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    comment_position = draw.PointF(60, 60)
    comment = author.comments.add_modern_comment("Verify this forecast wording.", slide, shape, comment_position, datetime.now())
    comment.text_selection_start = expected_selection_start
    comment.text_selection_length = len(selected_text)
    comment.status = slides.ModernCommentStatus.RESOLVED

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_comments = reopened_slide.get_slide_comments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, slides.ModernComment):
            continue

        shape_matches = reopened_comment.shape.name == "Forecast text"
        selection_start_matches = reopened_comment.text_selection_start == expected_selection_start
        selection_length_matches = reopened_comment.text_selection_length == len(selected_text)
        status_matches = reopened_comment.status == slides.ModernCommentStatus.RESOLVED

        print("Shape anchor preserved: " + str(shape_matches))
        print("Text selection start preserved: " + str(selection_start_matches))
        print("Text selection length preserved: " + str(selection_length_matches))
        print("Resolved status preserved: " + str(status_matches))
```

### **检查现有的现代批注**

要检查现有演示文稿，首先确定哪些批注是 [ModernComment](https://reference.aspose.com/slides/zh/python-net/aspose.slides/moderncomment/) 实例，然后检查 [ModernComment.shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/moderncomment/shape/)、[ModernComment.text_selection_start](https://reference.aspose.com/slides/zh/python-net/aspose.slides/moderncomment/text_selection_start/)、[ModernComment.text_selection_length](https://reference.aspose.com/slides/zh/python-net/aspose.slides/moderncomment/text_selection_length/) 和 [ModernComment.status](https://reference.aspose.com/slides/zh/python-net/aspose.slides/moderncomment/status/)。`None` 形状表示幻灯片级批注。对于 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/) 锚点，文本选区属性标识形状文本框中的关联范围。

```python
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    for slide in presentation.slides:
        comments = slide.get_slide_comments(None)
        for comment in comments:
            if not isinstance(comment, slides.ModernComment):
                continue

            print("Slide: " + str(slide.slide_number))
            print("Text: " + comment.text)
            print("Status: " + str(comment.status))

            shape = comment.shape
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: " + shape.name)
                print("Anchor type: " + type(shape).__name__)

                if isinstance(shape, slides.AutoShape):
                    print("Text selection start: " + str(comment.text_selection_start))
                    print("Text selection length: " + str(comment.text_selection_length))

            print()
```

## **删除批注**

### **删除所有批注和批注作者**

以下示例演示如何从演示文稿中删除所有批注和批注作者：

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **删除特定批注**

以下示例演示如何从幻灯片中删除特定批注：

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = draw.PointF(0.2, 0.2)
    second_comment_position = draw.PointF(0.3, 0.2)
    author.comments.add_comment("comment 1", slide, first_comment_position, created_time)
    author.comments.add_comment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.comment_authors:
        comments_to_remove = []
        comments = slide.get_slide_comments(comment_author)

        for comment in comments:
            if comment.text == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.comments.remove(comment)

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**Aspose.Slides 是否支持现代批注的已解决状态？**

是的。可以读取和设置 [ModernComment.status](https://reference.aspose.com/slides/zh/python-net/aspose.slides/moderncomment/status/)，使用 [ModernCommentStatus](https://reference.aspose.com/slides/zh/python-net/aspose.slides/moderncommentstatus/) 枚举值，包括 `RESOLVED`。该状态会存储在演示文稿中，并在重新打开文件后仍可读取。

**是否支持线程化讨论（回复链），以及是否有嵌套限制？**

是的。每个批注都可以引用其[parent comment](https://reference.aspose.com/slides/zh/python-net/aspose.slides/comment/parent_comment/)，从而实现回复链。API 并未定义具体的嵌套深度限制。

**批注标记在幻灯片上的位置使用何种坐标系定义？**

标记位置使用幻灯片坐标系中的浮点坐标定义，您可以精确地将其放置在幻灯片上。