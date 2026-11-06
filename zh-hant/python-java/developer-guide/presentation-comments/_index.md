---
title: 在 Python via Java 中管理簡報批註
linktitle: 簡報批註
type: docs
weight: 100
url: /zh-hant/python-java/presentation-comments/
keywords:
- 批註
- 現代批註
- PowerPoint 批註
- 簡報批註
- 投影片批註
- 新增批註
- 存取批註
- 編輯批註
- 回覆批註
- 移除批註
- 刪除批註
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 管理簡報批註：快速且輕鬆地在 PowerPoint 簡報中新增、讀取、編輯、回覆及移除批註。"
---
## **概覽**

本文說明如何使用 Aspose.Slides for Python via Java 來管理簡報批註。它會介紹主要的批註相關類型，並示範如何在投影片上加入批註、存取現有批註、處理回覆與現代批註，以及如何從簡報中移除批註。

示例涵蓋在 PowerPoint 中常見的審閱與協作情境，例如為作者指派批註、讀取批註文字與中繼資料、建立回覆鏈，以及移除選取的批註或全部批註。

在 PowerPoint 中，批註會以投影片上的註解形式顯示。選取批註時會顯示其文字與相關討論。

若要在開啟簡報時請求顯示或隱藏批註（而不變更批註本身），請參閱[開啟簡報時顯示或隱藏批註](/slides/zh-hant/python-java/presentation-view-properties/)。

## **為什麼要在簡報中加入批註？**

在審閱簡報時，您可以使用批註提供回饋並與同事協同合作。

Aspose.Slides for Python via Java 提供以下用於處理批註的 API：

* [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別，提供對簡報批註作者的存取。
* [CommentCollection](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/) 類別，表示與單一作者相關的批註集合。
* [Comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/) 類別，提供批註的資訊，包括作者、建立時間、位置與文字。
* [CommentAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/) 類別，提供作者的資訊，包括名稱、縮寫與相關批註。

## **新增投影片批註**

此範例建立兩張投影片，並使用[addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor)註冊一位批註作者。接著使用[addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment)在每張投影片上放置一則批註，然後使用[getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments)取得該作者在第一張投影片的批註。主控台會兩次顯示第一則批註的文字，示範透過投影片與作者兩種方式存取，且儲存的簡報會包含兩則批註。

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

## **尋找或建立批註作者**

當自動化審閱多次處理相同簡報時，請在加入作者之前先以[getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors)取得的集合進行搜尋。[findByNameAndInitials](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByNameAndInitials)同時比對名稱與縮寫，並回傳符合的作者陣列，若無符合則回傳空陣列。相較之下，[findByName](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByName)僅依名稱搜尋，與縮寫無關。若以已存在於集合中的名稱與縮寫呼叫[addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor)，會拋出例外。

此範例需要一個至少包含一張投影片的簡報檔。於兩次執行中，它會重複使用第一個符合的作者，或在結果為空時才建立新作者。若有多個符合項目，會選取陣列的第一個元素，而不會合併或移除其他作者。然後它會對選取的作者呼叫[addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment)並儲存簡報。第二次執行會開啟第一次的輸出並重複此操作。

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

第二次執行會在不新增作者或移除現有批註的情況下加入另一則批註。最終檔案 `review_pass_2.pptx` 會同時包含兩則新批註與任何原有批註。重複使用作者不會自動去除重複批註：若要避免重複加入相同批註，請在加入前自行實作重複檢測。

## **存取投影片批註**

此範例開啟現有簡報，並讀取[getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors)回傳的集合。對每位作者，它會遍歷[getComments](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/#getComments)回傳的集合，並列印投影片編號、批註文字、作者名稱與建立時間。輸入的簡報必須包含批註才能產生主控台輸出。

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

## **回覆批註**

父批註是回覆層級頂端的原始批註。[Comment.getParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment) 與 [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) 方法可取得或設定批註的父批註。

此範例建立兩位作者的批註，並使用[setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) 建立回覆，包括對另一則回覆的回覆。將 `None` 傳遞給[getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) 會取得所有作者的批註；主控台會根據回覆層級的深度縮排每個項目。範例儲存完整的討論，對第一個根批註呼叫[remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove)，並儲存第二個不含該批註及其回覆的簡報。

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
* 當使用 [Comment.remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) 方法刪除批註時，該批註的所有回覆也會被刪除。
* 若 [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) 建立了循環參照，會拋出 [PptxEditException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxeditexception/)。
{{% /alert %}}

## **新增現代批註**

現代批註可以與投影片本身、特定圖形，或與 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) 內的文字範圍相關聯。[CommentCollection.addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) 方法除了接受投影片與批註標記座標外，還接受一個 [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 參數。

當形狀參數傳遞 `None` 時，批註為投影片層級批註。其標記會根據提供的座標定位，但不會與特定圖形關聯，因此 [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) 會回傳 `None`。若提供 [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) ，批註則會錨定到該圖形。座標仍定義批註標記在投影片上的位置，而圖形關聯可透過 [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) 取得。

### **將現代批註錨定至圖形**

此範例兩次呼叫 [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment)：一次使用 `None` 圖形建立投影片層級批註，另一次使用矩形作為錨點。讀取 [getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) 會對投影片層級批註的 `None` 檢查列印 `True`，對錨定批註則列印 `Revenue title`。兩則批註皆已儲存於簡報中。

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

### **將批註錨定至不同類型的圖形**

任何繼承自 [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 的投影片物件皆可作為圖形錨點。常見例子包括 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)、[PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/)、[GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/)、[Connector](https://reference.aspose.com/slides/python-java/aspose.slides/connector/) 與 [GraphicalObject](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobject/)（如圖表）實例。

此範例使用 [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) 為五種圖形類型分別關聯批註：AutoShape、圖片框、群組、連線與圖表。圖片使用內嵌影像資料，無需外部影像檔。每則批註都有自己的標記位置，且儲存的簡報會保留所有五種圖形的關聯。

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

### **將批註錨定至文字並設定其狀態**

對於與 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) 相關的現代批註，[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart) 與 [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) 可取得形狀文字框中所選文字的起始位置。[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) 與 [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) 可取得選取的長度。這兩個值共同將批註與 AutoShape 內特定文字範圍關聯。

[ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) 與 [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) 方法會存取 [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/) 常數中的值：

- [NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#NotDefined) — 未定義特定的現代批註狀態。
- [Active](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Active) — 批註為活動狀態。
- [Resolved](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Resolved) — 批註已解決。
- [Closed](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Closed) — 批註已關閉。

此範例將現代批註錨定於矩形文字中的「quarterly revenue」一詞。它會根據文字計算零基礎的選取起始位置，傳遞給 [setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart)，再使用 [setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) 設定選取的字元數量。之後以 `Resolved` 呼叫 [setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus)，儲存並重新開啟簡報。四個主控台檢查皆應印出 `True`，以確認圖形錨點、文字範圍與狀態均已保留。

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

### **檢查現有的現代批註**

此範例需要一個已包含現代批註的簡報，並印出其文字、狀態與錨點細節。檢查時，先判斷批註是否為 [ModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/) 實例，然後檢查 [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape)、[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart)、[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) 與 [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus)。`None` 形狀表示投影片層級批註。對於 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) 錨點，文字選取方法會辨識形狀文字框中的相關範圍。

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

## **移除批註**

Aspose.Slides for Python via Java 允許您移除簡報中所有批註及其作者，或在保留其餘批註的情況下刪除特定批註。以下範例示範兩種做法，並儲存更新後的簡報。

### **移除所有批註與批註作者**

此範例開啟現有簡報，對每位作者呼叫 [CommentCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#clear)，然後呼叫 [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#clear) 移除作者本身。儲存後的簡報將不含任何批註與批註作者。請使用包含批註的簡報以觀察移除效果。

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

### **移除特定批註**

此範例在同一張投影片上建立兩則批註，並使用 [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) 依作者取得批註。它會收集文字等於「comment 1」的批註，然後呼叫 [CommentCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#remove) 移除它們，以避免在選取期間變更集合。儲存後的簡報僅保留「comment 2」。

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

## **常見問題**

**Aspose.Slides 是否支援現代批註的已解決狀態？**

是的。[ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) 與 [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) 皆可存取 [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/) 的值，包括 `Resolved`。此狀態會儲存在簡報中，重新開啟檔案後仍可讀取。

**是否支援串列討論（回覆鏈），且有嵌套深度限制嗎？**

是的。每則批註皆可參照其 [parent comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment)，因此可形成回覆鏈。API 並未定義特定的嵌套深度上限。

**批註標記在投影片上的位置是以哪種座標系統定義的？**

標記位置以投影片座標系統的浮點座標定義，讓您能精確地將其放置在投影片上。