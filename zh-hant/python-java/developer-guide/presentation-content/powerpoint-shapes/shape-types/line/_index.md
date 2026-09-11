---
title: 在 Python via Java 中向簡報新增線條圖形
linktitle: 線條
type: docs
weight: 50
url: /zh-hant/python-java/line/
keywords:
- 線條
- 建立線條
- 新增線條
- 純線條
- 設定線條
- 自訂線條
- 虛線樣式
- 箭頭
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "學習使用 Aspose.Slides for Python via Java 操作 PowerPoint 簡報中的線條格式設定。探索其屬性、方法與範例。"
---
## **概觀**

Aspose.Slides 允許您以程式方式在 PowerPoint 投影片中加入線條圖形。本文說明如何建立簡單的線條，以及如何自訂線條使其顯示為箭頭。

您將學習如何將線條圖形加入投影片、調整其外觀，並儲存更新後的簡報。範例聚焦於實用的線條格式設定，例如樣式、寬度、虛線模式、箭頭選項以及填色。

## **建立純線條**

若要在簡報的選定投影片中加入簡單的線條，請依照以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
- 依索引取得投影片的參考。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/) 物件的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addAutoShape) 方法，加入線條圖形。
- 將修改後的簡報寫入為 PPTX 檔案。

以下範例在簡報的第一張投影片加入線條：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 建立表示 PPTX 檔案的 Presentation 類別實例。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 新增線條圖形。
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # 將 PPTX 檔案寫入磁碟。
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **建立箭頭形狀的線條**

Aspose.Slides for Python via Java 亦允許開發人員設定線條屬性，使線條更具吸引力。若要將線條設定為箭頭外觀，請依照以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
- 依索引取得投影片的參考。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/) 物件的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addAutoShape) 方法，加入線條圖形。
- [line style](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/linestyle/) 設為 Aspose.Slides for Python via Java 所提供的樣式之一。
- 設定線條的寬度。
- [dash style](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/linedashstyle/) 設為 Aspose.Slides for Python via Java 所提供的樣式之一。
- 在線條起點設定 [arrowhead style](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/linearrowheadstyle/) 與 [length](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/linearrowheadlength/)。
- 在線條終點設定 [arrowhead style](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/linearrowheadstyle/) 與 [length](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/linearrowheadlength/)。
- 將修改後的簡報寫入為 PPTX 檔案。

```python
import jpate
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# 建立表示 PPTX 檔案的 Presentation 類別實例。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 新增線條圖形。
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # 套用線條的格式設定。
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # 將 PPTX 檔案寫入磁碟。
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**我可以將一般線條轉換為連接線，使其「自動貼齊」形狀嗎？**

不會。一般線條（[AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 類型為 [Line](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/)）不會自動變成連接線。若要讓它貼齊形狀，請使用專用的 [Connector](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/connector/) 類型以及用於連接的 [corresponding APIs](/slides/zh-hant/python-java/connector/)。

**如果線條的屬性繼承自佈景主題，且難以確定最終值，我該怎麼辦？**

請[閱讀線條及其填充的有效屬性](/slides/zh-hant/python-java/shape-effective-properties/)，這些屬性已考慮了繼承與佈景主題樣式。

**我可以鎖定線條以防止編輯（移動、調整大小）嗎？**

可以。形狀提供 [lock objects](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/#getAutoShapeLock)，讓您[禁止編輯操作](/slides/zh-hant/python-java/applying-protection-to-presentation/)。