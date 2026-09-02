---
title: 在 Python 中管理簡報註解
linktitle: 簡報註解
type: docs
weight: 100
url: /zh-hant/python-net/presentation-comments/
keywords:
- 註解
- 現代註解
- PowerPoint 註解
- 簡報註解
- 投影片註解
- 新增註解
- 存取註解
- 編輯註解
- 回覆註解
- 移除註解
- 刪除註解
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 管理簡報註解：在 PowerPoint 簡報中新增、讀取、編輯、回覆和移除註解。"
---
## **概觀**

本文章說明如何使用 Aspose.Slides for Python via .NET 來管理簡報註解。它介紹了主要的註解相關類型，並示範如何向投影片新增註解、存取現有註解、處理回覆與現代註解，以及從簡報中移除註解。

這些範例涵蓋 PowerPoint 中常見的審閱與協作情境，例如指派註解給作者、讀取註解文字與中繼資料、建立回覆鏈，以及移除選取的註解或全部註解。

在 PowerPoint 中，註解會以投影片上的標註形式顯示。選取註解時會顯示其文字與相關討論。

## **為什麼要在簡報中加入註解？**

您可以在審閱簡報時使用註解提供回饋，並與同事協作。

Aspose.Slides for Python via .NET 提供以下用於操作註解的 API：

* [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別，可取得簡報的註解作者。
* [CommentCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/commentcollection/) 類別，代表與單一作者相關的註解。
* [Comment](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/comment/) 類別，提供關於註解的資訊，包括作者、建立時間、位置與文字。
* [CommentAuthor](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/commentauthor/) 類別，提供作者資訊，包括姓名、縮寫與相關註解。

## **新增投影片註解**

以下範例示範如何在 PowerPoint 簡報的投影片中新增註解：

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

## **存取投影片註解**

以下範例示範如何在 PowerPoint 簡報中存取現有註解：

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

## **回覆註解**

父註解是回覆階層最上層的原始註解。[Comment](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/comment/) 類別的 [parent_comment](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/comment/parent_comment/) 屬性讓您取得或設定註解的父註解。

以下範例示範如何新增回覆並檢查產生的註解階層：

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

{{% alert color="warning" title="警告" %}}
* 使用 [Comment](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/comment/) 類別的 [remove](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/comment/remove/) 方法刪除註解時，該註解的所有回覆也會被刪除。
* 若 [parent_comment](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/comment/parent_comment/) 屬性產生循環參照，會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **新增現代註解**

現代註解可以關聯至投影片本身、特定形狀，或是 AutoShape 內的文字範圍。[CommentCollection.add_modern_comment](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/commentcollection/add_modern_comment/) 方法除了投影片與註解標記座標外，還接受一個 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 參數。

When `None` 被傳遞給 shape 參數時，註解為投影片層級註解。其標記依提供的座標定位，但不會關聯至任何特定形狀，因此 [ModernComment.shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/moderncomment/shape/) 會回傳 `None`。當提供 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 時，註解會錨定至該形狀。座標仍然定義註解標記在投影片上的位置，而形狀關聯可透過 [ModernComment.shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/moderncomment/shape/) 取得。

### **將現代註解錨定至形狀**

以下範例同時建立投影片層級的現代註解以及錨定至特定 AutoShape 的現代註解，然後從每個註解讀取其關聯的形狀。

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

### **將註解錨定至不同形狀類型**

任何繼承自 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/) 的投影片物件皆可用作形狀錨點。常見範例包括 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)、[PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/)、[GroupShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/groupshape/)、[Connector](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/connector/) 與如圖表等 [GraphicalObject](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/graphicalobject/) 實例。

以下範例建立多種常見形狀類型，並為每個形狀關聯一個現代註解。

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

### **將註解錨定至文字並設定其狀態**

對於關聯至 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 的現代註解，[ModernComment.text_selection_start](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/moderncomment/text_selection_start/) 指定形狀文字框中所選文字的起始位置，而 [ModernComment.text_selection_length](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/moderncomment/text_selection_length/) 指定選取的長度。兩者結合可將註解關聯至 AutoShape 內的特定文字範圍。

[ModernComment.status](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/moderncomment/status/) 屬性可讀取或以 [ModernCommentStatus](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/moderncommentstatus/) 列舉中的值進行更新：

- `NOT_DEFINED` — 未定義特定的現代註解狀態。
- `ACTIVE` — 註解處於活躍狀態。
- `RESOLVED` — 註解已解決。
- `CLOSED` — 註解已關閉。

以下範例建立一個錨定至形狀的現代註解，將其關聯至文字選取區域，將狀態標記為已解決，儲存簡報，並在再次開啟檔案後驗證其值。

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

### **檢查現有的現代註解**

若要檢查現有簡報，先確認哪些註解是 [ModernComment](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/moderncomment/) 實例，然後檢查 [ModernComment.shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/moderncomment/shape/)、[ModernComment.text_selection_start](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/moderncomment/text_selection_start/)、[ModernComment.text_selection_length](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/moderncomment/text_selection_length/) 與 [ModernComment.status](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/moderncomment/status/)。`None` 形狀代表投影片層級的註解。若為 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 錨定，文字選取屬性則指出形狀文字框中的相關範圍。

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

## **移除註解**

### **移除所有註解與註解作者**

以下範例示範如何從簡報中移除全部註解與註解作者：

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **移除特定註解**

以下範例示範如何從投影片中移除特定註解：

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

## **常見問答**

**Aspose.Slides 是否支援現代註解的已解決狀態？**

是的。[ModernComment.status](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/moderncomment/status/) 可讀取且可以 [ModernCommentStatus](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/moderncommentstatus/) 的值設定，包括 `RESOLVED`。此狀態會儲存在簡報中，重新開啟檔案後仍可再次讀取。

**是否支援串接式討論（回覆鏈），且有巢狀深度限制嗎？**

是的。每個註解都可以參照其 [parent comment](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/comment/parent_comment/)，從而形成回覆鏈。API 未定義特定的巢狀深度上限。

**註解標記在投影片上的位置是以哪種坐標系定義的？**

標記位置是以投影片坐標系的浮點座標定義，讓您能精確地將其放置於投影片上。