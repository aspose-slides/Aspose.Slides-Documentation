---
title: 在 Python 中管理演示文稿注释
linktitle: 演示文稿注释
type: docs
weight: 100
url: /zh/python-net/presentation-comments/
keywords:
- 注释
- 现代注释
- PowerPoint 注释
- 演示文稿注释
- 幻灯片注释
- 添加注释
- 访问注释
- 编辑注释
- 回复注释
- 移除注释
- 删除注释
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 管理演示文稿注释：在 PowerPoint 演示文稿中添加、读取、编辑、回复和删除注释。"
---
## **概览**

本文介绍了如何使用 Aspose.Slides for Python via .NET 管理演示文稿注释。它介绍了主要的与注释相关的类型，并演示了如何向幻灯片添加注释、访问现有注释、处理回复和现代注释以及从演示文稿中删除注释。

示例覆盖了 PowerPoint 中常见的审阅和协作场景，例如将注释分配给作者、读取注释文本和元数据、构建回复链，以及删除选定的注释或所有注释。

要在打开演示文稿时请求显示或隐藏注释而不更改注释本身，请参阅[打开演示文稿时显示或隐藏注释](/slides/zh/python-net/presentation-view-properties/)。

## **为什么向演示文稿添加注释？**

在审阅演示文稿时，您可以使用注释提供反馈并与同事协作。

Aspose.Slides for Python via .NET 提供以下用于操作注释的 API：

* The [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类，提供对演示文稿的注释作者的访问。
* The [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) 类，表示与单个作者关联的注释集合。
* The [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) 类，提供关于注释的信息，包括作者、创建时间、位置和文本。
* The [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) 类，提供关于作者的信息，包括姓名、缩写和关联的注释。

## **添加幻灯片注释**

示例创建了两个幻灯片，并使用 [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) 注册了一个注释作者。它使用 [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) 在每个幻灯片上放置一个注释，然后使用 [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) 检索该作者在第一张幻灯片上的注释。控制台两次显示第一条注释的文本，演示了通过幻灯片和作者两种方式访问，保存的演示文稿包含两个注释。

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = slides.PointF(0.2, 0.2)
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

## **查找或创建注释作者**

在自动审阅反复处理同一演示文稿时，应在添加作者之前搜索其 [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) 集合。[find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) 同时匹配姓名和缩写并返回匹配作者的数组，若无匹配则返回空数组。相比之下，[find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) 仅按姓名搜索，不考虑缩写。使用已存在的姓名和缩写调用 [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) 会抛出异常。

示例需要一个至少包含一张幻灯片的演示文稿。在两次遍历中，它复用第一个匹配的作者，若结果为空则创建新作者。如果有多个匹配，则选择数组的第一个元素，不合并或删除其他作者。随后为选定的作者调用 [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) 并保存演示文稿。第二次遍历打开第一次的输出并重复操作。

```python
from datetime import datetime

import aspose.slides as slides

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = slides.PointF(20, 20)

for pass_number in range(1, 3):
    with slides.Presentation(input_file) as presentation:
        matches = presentation.comment_authors.find_by_name_and_initials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.comment_authors.add_author(author_name, author_initials)
        author.comments.add_comment("Please review this slide.", presentation.slides[0], position, datetime.now())

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, slides.export.SaveFormat.PPTX)
        input_file = output_file
```

第二次遍历在不添加新作者或删除现有注释的情况下添加另一条注释。最终文件 `review_pass_2.pptx` 包含两个新注释以及任何原始注释。复用作者不会去重注释：若要避免重复添加相同注释，需要在添加之前实现单独的重复检测。

## **访问幻灯片注释**

示例打开现有演示文稿并读取其 [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) 集合。对每个作者，它遍历 [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) 并打印幻灯片编号、注释文本、作者姓名和创建时间。输入演示文稿必须包含注释才能产生控制台输出。

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

## **回复注释**

父注释是回复层级顶部的原始注释。[Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) 类的 [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) 属性可获取或设置注释的父级。

示例创建了来自两个作者的注释，并使用 [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) 构建回复，包括对另一个回复的回复。向 [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) 传入 `None` 可检索所有作者的注释；控制台根据回复层级深度对每条条目进行缩进。示例保存完整讨论，对第一个根注释调用 [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/)，并保存第二个演示文稿，其中该注释及其回复已被删除。

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    position = slides.PointF(10, 10)
    created_time = datetime.now()

    original_author = presentation.comment_authors.add_author("Author_1", "A.A.")
    root_comment = original_author.comments.add_comment("comment 1", slide, position, created_time)

    reviewer = presentation.comment_authors.add_author("Author_2", "B.B.")
    first_reply = reviewer.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    first_reply.parent_comment = root_comment

    second_reply = reviewer.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    second_reply.parent_comment = root_comment

    sub_reply = original_author.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = second_reply

    reviewer.comments.add_comment("comment 2", slide, position, created_time)
    separate_comment = reviewer.comments.add_comment("comment 3", slide, position, created_time)

    separate_reply = original_author.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    separate_reply.parent_comment = separate_comment

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    root_comment.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* 当使用 [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) 类的 [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) 方法删除注释时，所有对此注释的回复也将被删除。
* 如果 [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) 属性形成循环引用，则会抛出 [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **添加现代注释**

现代注释可以关联到幻灯片本身、特定形状或 AutoShape 中的文本范围。[CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) 方法除了接受幻灯片和注释标记坐标外，还接受一个 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 参数。

当为 shape 参数传入 `None` 时，注释为幻灯片级别注释。其标记由提供的坐标定位，但未关联特定形状，因而 [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) 返回 `None`。当提供 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 时，注释锚定到该形状。坐标仍定义注释标记在幻灯片上的位置，而形状关联可通过 [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) 获得。

### **将现代注释锚定到形状**

示例两次调用 [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/)：一次使用 `None` shape 创建幻灯片级别注释，另一次使用矩形作为锚点。读取 [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) 对于幻灯片级别注释的空检查打印 `True`，对于锚定的注释打印 `Revenue title`。两个注释均随演示文稿保存。

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = slides.PointF(20, 20)
    shape_comment_position = slides.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **将注释锚定到不同的形状类型**

任何派生自 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 的幻灯片对象都可用作形状锚点。常见示例包括 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)、[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)、[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)、[Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) 和 [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/) 实例（如图表）。

示例使用 [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) 将注释关联到五种形状类型：AutoShape、图片框、组合、连接线和图表。图片使用嵌入的图像数据，无需外部图像。每个注释都有自己的标记位置，保存的演示文稿保留所有五种形状关联。

```python
import base64
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"

    auto_shape_comment_position = slides.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = slides.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = slides.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = slides.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = slides.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **将注释锚定到文本并设置其状态**

对于与 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 关联的现代注释，[ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) 指定形状文本框中选中文本的起始位置，而 [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) 指定选区的长度。两者共同将注释关联到 AutoShape 中文本的特定范围。

[ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) 属性可读取或使用 [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) 枚举的值进行更新：

- `NOT_DEFINED` — 未定义特定的现代注释状态。
- `ACTIVE` — 注释处于活动状态。
- `RESOLVED` — 注释已解决。
- `CLOSED` — 注释已关闭。

示例将现代注释锚定到矩形文本中的 “quarterly revenue” 词组。它根据文本计算零基的 [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/)，并将 [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) 设置为选中字符数。将 [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) 设置为 `RESOLVED` 后，保存并重新打开演示文稿。四个控制台检查应各输出 `True`，确认形状锚点、文本范围和状态均已保留。

```python
from datetime import datetime

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
    comment_position = slides.PointF(60, 60)
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

### **检查现有的现代注释**

示例需要一个包含现代注释的现有演示文稿，并打印其文本、状态和锚点细节。检查时，先判断哪些注释是 [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) 实例，然后检查 [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/)、[ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/)、[ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) 和 [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/)。`None` shape 表示幻灯片级别注释。对于 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 锚点，文本选择属性标识形状文本框中的关联范围。

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

## **删除注释**

Aspose.Slides for Python via .NET 允许您删除演示文稿中所有注释及其作者，或在保留其余注释的情况下删除选定的注释。以下示例演示两种方法并保存更新后的演示文稿。

### **删除所有注释和注释作者**

示例打开现有演示文稿，对每个作者调用 [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/)，随后调用 [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) 删除作者本身。保存的演示文稿既不包含注释也不包含注释作者。使用包含注释的演示文稿可观察到删除效果。

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **删除特定注释**

示例在同一幻灯片上创建两个注释，并使用 [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) 按每个作者查找注释。它收集文本等于 “comment 1” 的注释后调用 [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/)，避免在选择期间修改集合。保存的演示文稿仅保留 “comment 2”。

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = slides.PointF(0.2, 0.2)
    second_comment_position = slides.PointF(0.3, 0.2)
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

**Aspose.Slides 是否支持现代注释的已解决状态？**

是的。可以读取和设置 [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/)，使用 [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) 枚举值，包括 `RESOLVED`。该状态保存在演示文稿中，重新打开文件后仍可读取。

**是否支持线程化讨论（回复链），以及是否有嵌套深度限制？**

是的。每条注释都可以引用其 [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/)，从而实现回复链。API 并未定义具体的嵌套深度限制。

**注释标记在幻灯片上的位置使用何种坐标系定义？**

标记位置使用幻灯片坐标系中的浮点坐标，可精确定位于幻灯片上的任意位置。