---
title: 評論
type: docs
weight: 230
url: /zh-hant/python-java/examples/elements/comment/
keywords:
- 評論
- 現代評論
- 新增評論
- 存取評論
- 移除評論
- 回覆評論
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中管理現代投影片評論：新增、讀取、刪除及回覆 PowerPoint 與 OpenDocument 簡報中的評論。"
---
本文示範如何使用 **Aspose.Slides for Python via Java** 新增、讀取、刪除及回覆現代評論。

依照[Installation](/slides/zh-hant/python-java/installation/) 中的說明安裝套件。每個範例在啟動 JVM 之前先匯入 `asposeslides`，之後在 JVM 運行時匯入 API 及所需的 Java 類型。存取與刪除範例使用由第一個範例建立的 `modern_comment.pptx`。

## **新增現代評論**

建立由使用者撰寫的評論，並儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt.geom import Point2D
from java.util import Date

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("User", "U1")
    position = Point2D.Float(100, 100)
    author.getComments().addModernComment("This is a modern comment", slide, None, position, Date())

    presentation.save("modern_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **存取現代評論**

從現有簡報中讀取第一則現代評論。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("modern_comment.pptx")
try:
    if presentation.getCommentAuthors().size() > 0:
        author = presentation.getCommentAuthors().get_Item(0)
        if author.getComments().size() > 0:
            comment = author.getComments().get_Item(0)
            print("Author:", author.getName())
            print("Comment:", comment.getText())
            print("Position:", comment.getPosition())
        else:
            print("The first author has no comments.")
    else:
        print("The presentation has no comment authors.")
finally:
    presentation.dispose()
```

## **移除現代評論**

移除第一則評論，並儲存更新後的簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("modern_comment.pptx")
try:
    if presentation.getCommentAuthors().size() > 0:
        author = presentation.getCommentAuthors().get_Item(0)
        if author.getComments().size() > 0:
            comment = author.getComments().get_Item(0)
            comment.remove()
        else:
            print("The first author has no comments.")
    else:
        print("The presentation has no comment authors.")

    presentation.save("modern_comment_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **回覆現代評論**

建立父層評論，新增兩則回覆，並儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt.geom import Point2D
from java.util import Date

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("User", "U1")
    created_time = Date()

    parent_position = Point2D.Float(100, 100)
    parent_comment = author.getComments().addModernComment("Parent comment", slide, None, parent_position, created_time)

    reply1_position = Point2D.Float(110, 100)
    reply1 = author.getComments().addModernComment("Reply 1", slide, None, reply1_position, created_time)

    reply2_position = Point2D.Float(120, 100)
    reply2 = author.getComments().addModernComment("Reply 2", slide, None, reply2_position, created_time)

    reply1.setParentComment(parent_comment)
    reply2.setParentComment(parent_comment)

    presentation.save("modern_comment_replies.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```