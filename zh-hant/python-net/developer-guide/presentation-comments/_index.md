---
title: 在 Python 中管理簡報評論
linktitle: 簡報評論
type: docs
weight: 100
url: /zh-hant/python-net/presentation-comments/
keywords:
- 評論
- 現代評論
- PowerPoint 評論
- 簡報評論
- 投影片評論
- 新增評論
- 存取評論
- 編輯評論
- 回覆評論
- 移除評論
- 刪除評論
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 管理簡報評論：在 PowerPoint 簡報中新增、閱讀、編輯、回覆和移除評論。"
---
## **概述**

本文說明如何使用 Aspose.Slides for Python via .NET 來管理簡報評論。它介紹了主要的與評論相關的類型，並示範如何在投影片上加入評論、存取現有評論、處理回覆與現代評論，以及從簡報中移除評論。

這些範例涵蓋了 PowerPoint 中常見的審閱與協作情境，例如指派評論給作者、讀取評論文字與中繼資料、建立回覆串，以及移除選取的評論或全部評論。

在 PowerPoint 中，評論會顯示為投影片上的註釋。選取評論時會顯示其文字與相關討論。若要在開啟簡報時請求顯示或隱藏評論（而不更改評論本身），請參閱 [在開啟簡報時顯示或隱藏評論](/slides/zh-hant/python-net/presentation-view-properties/)。

## **為何要在簡報中加入評論？**

在審閱簡報時，您可以使用評論提供回饋並與同事協作。

Aspose.Slides for Python via .NET 提供以下用於操作評論的 API：

* [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別，提供存取簡報的評論作者的功能。
* [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) 類別，代表與單一作者相關聯的評論。
* [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) 類別，提供有關評論的資訊，包括作者、建立時間、位置與文字。
* [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) 類別，提供作者資訊，包括名稱、縮寫與相關評論。

## **加入投影片評論**

此範例建立兩張投影片，並使用 [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) 註冊評論作者。它使用 [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) 在每張投影片上放置一則評論，然後使用 [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) 取得該作者在第一張投影片的評論。主控台會顯示第一次評論的文字兩次，示範透過投影片與作者兩種方式存取，且儲存的簡報包含兩則評論。

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

## **尋找或建立評論作者**

當自動化審閱重複處理相同的簡報時，請在新增作者之前先搜尋其 [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) 集合。

[find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) 同時比對名稱與縮寫，回傳匹配作者的陣列，若無匹配則回傳空陣列。  
相較之下，[find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) 僅依名稱搜尋，與縮寫無關。  
若以已存在於集合中的名稱與縮寫呼叫 [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/)，將拋出例外。

此範例需要一個至少包含一張投影片的簡報檔案。在兩次傳遞的每一次中，它會重複使用第一個匹配的作者，若結果為空則建立新作者。若有多個匹配，則選取陣列的第一個元素，且不會合併或移除其他作者。接著針對選取的作者呼叫 [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) 並儲存簡報。第二次傳遞會開啟第一次傳遞的輸出並再次執行相同操作。

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

第二次傳遞會再加入一則評論，而不會新增作者或移除既有評論。最終檔案 `review_pass_2.pptx` 包含兩則新評論以及任何原始評論。重複使用作者不會去除重複的評論：若要避免重複加入相同評論，請在加入前實作獨立的重複偵測機制。

## **存取投影片評論**

此範例開啟現有簡報並讀取其 [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) 集合。對於每位作者，它會遍歷 [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) 並列印投影片編號、評論文字、作者名稱與建立時間。輸入的簡報必須包含評論才能產生主控台輸出。

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

## **回覆評論**

父評論是回覆層級最上層的原始評論。[Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) 類別的 [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) 屬性可讓您取得或設定評論的父項。

此範例由兩位作者建立評論，並使用 [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) 建立回覆，包括回覆其他回覆。將 `None` 傳遞給 [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) 會取得所有作者的評論；主控台會根據回覆層級的深度縮排每個項目。範例儲存完整的討論，對第一個根評論呼叫 [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/)，並儲存第二個已移除該評論及其回覆的簡報。

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
* 當使用 [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) 類別的 [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) 方法刪除評論時，該評論的所有回覆亦會被刪除。  
* 如果 [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) 屬性形成循環參考，則會拋出 [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **加入現代評論**

現代評論可以與投影片本身、特定圖形，或 AutoShape 內的文字範圍關聯。[CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) 方法除了接受投影片與評論標記座標外，亦接受一個 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 參數。

當形狀參數傳入 `None` 時，評論為投影片層級的評論。其標記依提供的座標定位，但不會關聯到特定圖形，因此 [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) 會回傳 `None`。若提供 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)，則評論會錨定到該圖形。座標仍然定義評論標記在投影片上的位置，而圖形關聯可透過 [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) 取得。

### **將現代評論錨定至圖形**

此範例呼叫 [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) 兩次：一次使用 `None` 形狀作為投影片層級評論，另一次使用矩形作為錨點。讀取 [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) 時，會為投影片層級評論的空檢查印出 `True`，而錨定的評論則印出 `Revenue title`。兩則評論皆隨簡報儲存。

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

### **將評論錨定至不同圖形類型**

任何繼承自 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 的投影片物件皆可作為圖形錨點。常見範例包括 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)、[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)、[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)、[Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) 以及如圖表等 [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/) 實例。

此範例使用 [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) 來為五種圖形類型（AutoShape、圖片框、群組、連接線與圖表）各關聯一則評論。圖片使用嵌入的影像資料，無需外部圖像。每則評論皆有自己的標記位置，且儲存的簡報保留所有五種圖形的關聯。

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

### **將評論錨定至文字並設定其狀態**

對於與 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 關聯的現代評論，[ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) 指定形狀文字框中所選文字的起始位置，而 [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) 指定選取的長度。兩者共同將評論關聯至 AutoShape 內的特定文字範圍。

[ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) 屬性可使用 [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) 的值（包括 `RESOLVED`）讀取或設定。  

- `NOT_DEFINED` — 未定義特定的現代評論狀態。  
- `ACTIVE` — 評論為啟用狀態。  
- `RESOLVED` — 評論已解決。  
- `CLOSED` — 評論已關閉。

此範例將現代評論錨定至矩形文字中的「quarterly revenue」字樣。它從文字計算零基的 [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) 並將 [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) 設為選取字符的數量。將 [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) 設為 `RESOLVED` 後，儲存並重新開啟簡報。四個主控台檢查皆應印出 `True`，以確認圖形錨點、文字範圍與狀態皆已保留。

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

### **檢視現有的現代評論**

此範例需要一個包含現代評論的既有簡報，並列印其文字、狀態與錨定細節。要檢查它，先判斷哪些評論是 [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/) 實例，然後檢視 [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/)、[ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/)、[ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) 以及 [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/)。`None` 形狀表示投影片層級的評論。對於 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 錨點，文字選取屬性指示形狀文字框中相關的範圍。

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

## **移除評論**

Aspose.Slides for Python via .NET 允許您從簡報中移除全部評論及其作者，或僅刪除選取的評論而保留其他評論。以下範例示範這兩種做法，並儲存更新後的簡報。

### **移除所有評論與評論作者**

此範例開啟現有簡報，對每位作者呼叫 [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/)，接著呼叫 [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) 移除作者本身。儲存的簡報不會包含任何評論或評論作者。請使用含有評論的簡報以觀察移除效果。

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **移除特定評論**

此範例在同一投影片上建立兩則評論，並使用 [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) 找出每位作者的評論。它會收集文字等於 "comment 1" 的評論，再呼叫 [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/)，以避免在選取期間修改集合。儲存的簡報僅保留 "comment 2"。

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

## **常見問題**

**Aspose.Slides 是否支援現代評論的已解決狀態？**

是的。[ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) 可使用 [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/) 的值（包括 `RESOLVED`）讀取或設定。此狀態會儲存在簡報中，重新開啟檔案後仍可讀取。

**是否支援串狀討論（回覆鏈）？是否有巢狀深度限制？**

是的。每則評論皆可參照其 [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/)，從而形成回覆鏈。API 並未定義特定的巢狀深度限制。

**評論標記在投影片上的位置是以何種座標系統定義的？**

標記位置以投影片座標系統中的浮點座標定義，讓您能精確地將其放置於投影片上。