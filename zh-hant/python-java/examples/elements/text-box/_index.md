---
title: 文字方塊
type: docs
weight: 40
url: /zh-hant/python-java/examples/elements/text-box/
keywords:
- 程式碼範例
- 文字方塊
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中處理文字方塊：新增、格式化、搜尋及移除 PowerPoint 和 OpenDocument 簡報中的文字。"
---
在 **Aspose.Slides for Python via Java** 中，文字方塊是一種自動圖形，可包含文字。幾乎任何圖形都可以包含文字，但典型的文字方塊沒有填充或邊框，僅顯示文字。

本指南說明如何以程式方式新增、存取和移除文字方塊。

按照[Installation](/slides/zh-hant/python-java/installation/)中的說明安裝套件。每個範例在啟動 JVM 之前先匯入 `asposeslides`，然後在 JVM 執行後匯入 API。

## **新增文字方塊**

建立一個矩形，移除其填充與邊框，並指派格式化文字。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 建立一個矩形形狀。
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # 移除填充與邊框，只顯示文字。
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # 設定預設文字格式。
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **依內容存取文字方塊**

新增一個示例文字方塊，然後找出文字中包含關鍵字「Slide」的圖形。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                # 使用匹配的文字方塊。
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **依內容移除文字方塊**

在第一張投影片上找出並刪除包含特定關鍵字的文字方塊。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    shapes_to_remove = []
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}
在移除之前，先將符合條件的圖形收集到單獨的清單中，以避免在迭代時修改圖形集合。
{{% /alert %}}