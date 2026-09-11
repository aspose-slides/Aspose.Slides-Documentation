---
title: 在 Python 透過 Java 向簡報新增橢圓形
linktitle: 橢圓形
type: docs
weight: 30
url: /zh-hant/python-java/ellipse/
keywords:
- 橢圓形
- 形狀
- 新增橢圓形
- 建立橢圓形
- 繪製橢圓形
- 格式化橢圓形
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via Java 中建立、格式化和操作橢圓形狀，支援 PPT 與 PPTX 簡報——包含 Python 程式碼範例。"
---
## **概述**

本文說明如何使用 Aspose.Slides 在 PowerPoint 投影片中新增橢圓形狀。內容包括建立簡單橢圓、建立格式化橢圓，以及將更新後的簡報儲存為 PPTX 檔案。還會涉及相關問題，例如處理橢圓的位置與大小、控制堆疊順序，以及套用動畫效果。

## **建立橢圓**

要在簡報的選取投影片中加入簡單橢圓，請依照以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
- 依索引取得投影片的參照。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/) 物件的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addAutoShape) 方法新增橢圓。
- 將修改後的簡報寫入為 PPTX 檔案。

以下範例將橢圓新增到第一張投影片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 實例化代表 PPTX 檔案的 Presentation 類別。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 新增一個橢圓形狀。
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # 將 PPTX 檔案寫入磁碟。
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **建立格式化橢圓**

要在投影片中加入格式化橢圓，請依照以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
- 依索引取得投影片的參照。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/) 物件的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addAutoShape) 方法新增橢圓。
- 將橢圓的填充類型設為實心。
- 透過與 [Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/) 物件關聯的 [FillFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fillformat/) 物件，呼叫 [getSolidFillColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fillformat/#getSolidFillColor) 以設定橢圓的填充顏色。
- 設定橢圓輪廓的顏色。
- 設定橢圓輪廓的寬度。
- 將修改後的簡報寫入為 PPTX 檔案。

以下範例將格式化的橢圓新增到簡報的第一張投影片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# 實例化代表 PPTX 檔案的 Presentation 類別。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 新增一個橢圓形狀。
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # 設定橢圓的填充。
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # 設定橢圓的輪廓。
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # 將 PPTX 檔案寫入磁碟。
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**如何設定橢圓相對於投影片單位的精確位置與尺寸？**

座標與尺寸通常以 **點 (points)** 為單位。為了取得可預測的結果，請以投影片大小為基礎計算，並在指派值之前將所需的毫米或英吋轉換為點。

**如何將橢圓置於其他物件之上或之下（控制堆疊順序）？**

可透過將物件移至最前層或最底層來調整其繪製順序。這樣即可讓橢圓覆蓋其他物件或顯示其下方的內容。

**如何為橢圓設定出現或強調的動畫效果？**

[Apply](/slides/zh-hant/python-java/shape-animation/) 入口、強調或退出效果於該形狀，並設定觸發條件與時間，以協調動畫的播放時機與方式。