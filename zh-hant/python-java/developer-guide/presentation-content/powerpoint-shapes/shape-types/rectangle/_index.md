---
title: 在 Python（透過 Java）為簡報新增矩形
linktitle: 矩形
type: docs
weight: 80
url: /zh-hant/python-java/rectangle/
keywords:
- 新增矩形
- 建立矩形
- 矩形形狀
- 簡單矩形
- 格式化矩形
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "透過 Aspose.Slides for Python via Java 為您的 PowerPoint 簡報新增矩形，輕鬆以程式方式設計與修改形狀。"
---
## **概述**

本文說明如何使用 Aspose.Slides 向 PowerPoint 投影片新增矩形形狀。它涵蓋了建立簡單矩形、建立格式化矩形，以及將更新後的簡報儲存為 PPTX 檔案。  
您還會看到如何套用基本的矩形格式設定，例如實心填色、線條顏色與線寬。此外，本文的 FAQ 也指向相關的矩形操作，包括圓角、圖片填充、視覺效果、超連結、形狀鎖定、匯出選項與有效屬性。

## **在投影片中新增矩形**

若要在簡報中選定的投影片加入簡單矩形，請遵循以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
- 依索引取得投影片的參考。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/) 物件所提供的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addAutoShape) 方法，加入類型為矩形的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/)。
- 將修改後的簡報寫入為 PPTX 檔案。

在下方示例中，我們已在簡報的第一張投影片加入一個簡單的矩形。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 建立代表 PPTX 檔案的 Presentation 類別實例。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 新增矩形形狀。
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # 將 PPTX 檔案寫入磁碟。
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在投影片中新增格式化矩形**

若要在投影片中新增格式化矩形，請遵循以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
- 依索引取得投影片的參考。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/) 物件所提供的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addAutoShape) 方法，加入類型為矩形的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/)。
- 將矩形的 [fill type](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/filltype/) 設為實心。
- 使用與 [Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/) 物件關聯的 [FillFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fillformat/) 之實心填色，透過 [setColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/colorformat/#setColor) 方法設定矩形的顏色。
- 設定矩形輪廓的顏色。
- 設定矩形輪廓的寬度。
- 將修改後的簡報寫入為 PPTX 檔案。

上述步驟已在下方的示例中實作。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# 建立代表 PPTX 檔案的 Presentation 類別實例。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 新增矩形形狀。
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # 設定矩形的填色。
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # 設定矩形的輪廓。
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # 將 PPTX 檔案寫入磁碟。
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**如何新增帶有圓角的矩形？**

使用圓角 [shape type](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/)，並在形狀屬性中調整角半徑；亦可透過幾何調整對各個角分別套用圓角。

**如何使用圖片（紋理）填充矩形？**

選取圖片 [fill type](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/filltype/)，提供影像來源，並設定 [stretching/tiling modes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillmode/)。

**矩形可以有陰影與發光效果嗎？**

可以。可使用 [Outer/inner shadow, glow, and soft edges](/slides/zh-hant/python-java/shape-effect/) 並透過可調參數設定。

**我可以將矩形轉換成帶有超連結的按鈕嗎？**

可以。可於形狀點擊時 [Assign a hyperlink](/slides/zh-hant/python-java/manage-hyperlinks/)（跳至投影片、檔案、網址或電子郵件）。

**如何保護矩形不被移動或變更？**

[Use shape locks](/slides/zh-hant/python-java/applying-protection-to-presentation/)：可禁止移動、調整大小、選取或文字編輯，以保護版面配置。

**我可以將矩形轉換為點陣圖或 SVG 嗎？**

可以。您可以使用 [render the shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getImage) 將形狀渲染為指定尺寸/比例的影像，或 [export it as SVG](/slides/zh-hant/python-java/create-shape-thumbnails/) 以向量格式匯出。

**如何快速取得考慮佈景主題與繼承的矩形實際（有效）屬性？**

[Use the shape’s effective properties](/slides/zh-hant/python-java/shape-effective-properties/)：API 會回傳考慮佈景主題樣式、版面配置與本機設定的計算值，簡化格式分析。