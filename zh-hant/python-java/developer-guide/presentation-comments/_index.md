---
title: 在 Python via Java 中管理簡報註解
linktitle: 簡報註解
type: docs
weight: 100
url: /zh-hant/python-java/presentation-comments/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 來管理簡報註解：快速且輕鬆地在 PowerPoint 簡報中新增、閱讀、編輯、回覆以及移除註解。"
---
## **概觀**

本篇說明如何使用 Aspose.Slides for Python via Java 來管理簡報的註解。它會介紹主要的註解相關類型，並示範如何將註解新增至投影片、存取現有註解、處理回覆與現代註解，以及如何從簡報中移除註解。

這些範例涵蓋 PowerPoint 中常見的審閱與協作情境，例如指派註解給作者、讀取註解文字與中繼資料、建立回覆鏈，以及移除選取的註解或全部註解。

在 PowerPoint 中，註解會以投影片上的批註形式顯示。選取某個註解時會顯示其文字與相關討論。

## **為何要在簡報中加入註解？**

在審閱簡報時，您可以使用註解提供回饋並與同事協作。

Aspose.Slides for Python via Java 提供以下 API 以處理註解：

* *[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/)* 類別，提供存取簡報的註解作者。
* *[CommentCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/commentcollection/)* 類別，表示與單一作者相關的註解集合。
* *[Comment](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/comment/)* 類別，提供註解的資訊，包括作者、建立時間、位置與文字。
* *[CommentAuthor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/commentauthor/)* 類別，提供作者資訊，包括名稱、縮寫與其相關的註解。

## **新增投影片註解**

以下範例示範如何在 PowerPoint 簡報的投影片上新增註解：

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

## **存取投影片註解**

以下範例示範如何在 PowerPoint 簡報中存取現有註解：

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

## **回覆註解**

父註解是回覆層級最上方的原始註解。*[Comment.getParentComment](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/comment/#getParentComment)* 與 *[Comment.setParentComment](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/comment/#setParentComment)* 方法可取得或設定註解的父註解。

以下範例示範如何新增回覆並檢查產生的註解層級結構：

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
* 當使用 *[Comment.remove](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/comment/#remove)* 方法刪除註解時，該註解的所有回覆也會一併被刪除。  
* 若 *[Comment.setParentComment](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/comment/#setParentComment)* 產生循環參照，將拋出 *[PptxEditException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxeditexception/)*。
{{% /alert %}}

## **新增現代註解**

現代註解可以與投影片本身、特定形狀，或是 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 內的文字範圍相關聯。*[CommentCollection.addModernComment](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/commentcollection/#addModernComment)* 方法除了接受投影片與註解指標座標外，還接受一個 *[Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/)* 參數。

當形狀參數傳入 *None* 時，該註解為投影片層級註解。其標記位置由提供的座標決定，但不屬於特定形狀，因此 *[ModernComment.getShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncomment/#getShape)* 會傳回 *None*。若提供了 *[Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/)*，則註解會錨定於該形狀。座標仍決定註解標記在投影片上的位置，而形狀關聯可透過 *[ModernComment.getShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncomment/#getShape)* 取得。

### **將現代註解錨定至形狀**

以下範例同時建立投影片層級的現代註解與錨定於特定 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 的現代註解，並讀取每個註解所關聯的形狀：

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

### **將註解錨定至不同形狀類型**

任何繼承自 *[Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/)* 的投影片物件皆可作為形狀錨點。常見範例包括 *[AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/)*、*[PictureFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/)*、*[GroupShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/groupshape/)*、*[Connector](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/connector/)*，以及如圖表等 *[GraphicalObject](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/graphicalobject/)* 實例。

以下範例建立多種常見形狀類型，並為每個形狀關聯一個現代註解：

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

### **將註解錨定至文字並設定其狀態**

對於與 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 相關聯的現代註解，*[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncomment/#getTextSelectionStart)* 與 *[ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncomment/#setTextSelectionStart)* 取得形狀文字框中所選文字的起始位置。*[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncomment/#getTextSelectionLength)* 與 *[ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncomment/#setTextSelectionLength)* 取得選取長度。這些值共同將註解與 AutoShape 內的特定文字範圍關聯。

*[ModernComment.getStatus](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncomment/#getStatus)* 與 *[ModernComment.setStatus](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncomment/#setStatus)* 方法會存取 *[ModernCommentStatus](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncommentstatus/)* 常數中的值：

- *[NotDefined](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncommentstatus/#NotDefined)* — 未定義特定的現代註解狀態。  
- *[Active](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncommentstatus/#Active)* — 註解為啟用狀態。  
- *[Resolved](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncommentstatus/#Resolved)* — 註解已解決。  
- *[Closed](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncommentstatus/#Closed)* — 註解已關閉。

以下範例建立一個錨定於形狀的現代註解、將其與文字選取關聯、標記為已解決、儲存簡報，並在重新開啟檔案後驗證其值：

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

### **檢查現有的現代註解**

若要檢查既有簡報，先判斷哪些註解是 *[ModernComment](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncomment/)* 的實例，然後檢查 *[ModernComment.getShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncomment/#getShape)*、*[ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncomment/#getTextSelectionStart)*、*[ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncomment/#getTextSelectionLength)* 與 *[ModernComment.getStatus](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncomment/#getStatus)*。若形狀為 *None*，表示為投影片層級註解。對於錨定於 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 的情況，文字選取方法會指出該形狀文字框中的相關範圍。

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

## **移除註解**

### **移除所有註解與註解作者**

以下範例示範如何從簡報中移除所有註解與註解作者：

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

### **移除特定註解**

以下範例示範如何從投影片中移除特定註解：

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

**Aspose.Slides 是否支援現代註解的已解決狀態？**

是的。*[ModernComment.getStatus](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncomment/#getStatus)* 與 *[ModernComment.setStatus](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncomment/#setStatus)* 可存取 *[ModernCommentStatus](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/moderncommentstatus/)* 的值，包括 `Resolved`。此狀態會儲存在簡報中，檔案重新開啟後仍可讀取。

**是否支援串列式討論（回覆鏈），且有巢狀深度限制嗎？**

是的。每個註解都可以參照其 *[parent comment](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/comment/#getParentComment)*，從而形成回覆鏈。API 未定義具體的巢狀深度上限。

**註解標記在投影片上的位置是以何種座標系統定義的？**

標記位置以投影片座標系統的浮點座標來定義，讓您能夠精確地將其放置於投影片上。