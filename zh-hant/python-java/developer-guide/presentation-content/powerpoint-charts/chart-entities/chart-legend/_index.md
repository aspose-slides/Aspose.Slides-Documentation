---
title: 使用 Python 在簡報中自訂圖表圖例
linktitle: 圖表圖例
type: docs
url: /zh-hant/python-java/chart-legend/
keywords:
- 圖表圖例
- 圖例位置
- 字型大小
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 自訂圖表圖例，優化 PowerPoint 簡報的圖例格式。"
---
## **概觀**

Aspose.Slides 提供在 PowerPoint 簡報中自訂圖表圖例的選項。本文件說明如何設定圖例的位置與大小、為整個圖例設定字型大小，以及對單一圖例項目套用格式設定。

文件亦在 FAQ 中說明多項相關行為，包括使用非覆蓋模式讓繪圖區留出空間給圖例、允許長圖例標籤自動換列或使用換行符號，以及在未明確設定文字與填色時，讓圖例格式繼承簡報主題的配色方案。

## **圖例定位**

若要設定圖例屬性，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的執行個體。
1. 取得投影片的參考。
1. 在投影片上新增圖表。
1. 設定圖例屬性。
1. 將簡報儲存為 PPTX 檔。

以下範例示範如何設定圖表圖例的位置與大小。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# 建立空白簡報。
presentation = Presentation()
try:
    # 取得投影片的參考。
    slide = presentation.getSlides().get_Item(0)

    # 在投影片上加入叢集直條圖。
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # 設定圖例屬性。
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # 將簡報儲存至磁碟。
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定圖例的字型大小**

Aspose.Slides for Python via Java 允許您設定圖例的字型大小。請依照以下步驟操作：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別。
1. 建立預設圖表。
1. 設定字型大小。
1. 設定最小軸值。
1. 設定最大軸值。
1. 將簡報儲存至磁碟。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# 建立空白簡報。
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定單一圖例項目的字型大小**

Aspose.Slides for Python via Java 允許您設定單一圖例項目的字型大小。請依照以下步驟操作：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別。
1. 建立預設圖表。
1. 存取圖例項目。
1. 設定字型大小。
1. 將簡報儲存至磁碟。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# 建立空白簡報。
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**我可以啟用圖例，使圖表自動為其分配空間而不是覆蓋嗎？**

可以。使用 [setOverlay](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/legend/#setOverlay) 並將參數設為 `False` 以啟用非覆蓋模式；此時繪圖區會縮小以容納圖例。

**我可以製作多行圖例標籤嗎？**

可以。當空間不足時，長標籤會自動換列；亦可在系列名稱中加入換行字元以強制換行。

**如何讓圖例遵循簡報主題的配色方案？**

請不要為圖例或其文字設定明確的顏色、填色或字型。如此一來，圖例會從主題繼承設定，且在版面設計變更時會正確更新。