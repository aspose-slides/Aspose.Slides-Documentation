---
title: 使用 Python 自訂簡報中的 3D 圖表
linktitle: 3D 圖表
type: docs
url: /zh-hant/python-java/3d-chart/
keywords:
- 3D 圖表
- 旋轉
- 深度
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via Java 中建立與自訂 3-D 圖表，支援 PPT 與 PPTX 檔案——立即提升您的簡報。"
---
## **概觀**

本文說明如何透過設定 [Rotation3D](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/rotation3d/) 的 [setRotationX](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/rotation3d/#setRotationX)、[setRotationY](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/rotation3d/#setRotationY)、[setDepthPercents](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/rotation3d/#setDepthPercents) 以及 [setRightAngleAxes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/rotation3d/#setRightAngleAxes) 參數，來自訂 Aspose.Slides 中的 3D 圖表。內容會示範如何建立簡報、加入含預設資料的 3D 圖表、套用必要的 3D 檢視設定，並將修改後的簡報儲存為 PPTX 檔案。

## **設定 3D 圖表的 X 旋轉、Y 旋轉和深度**
Aspose.Slides for Python via Java 提供簡易的 API 以設定這些屬性。以下範例示範如何設定 3D 圖表的 X 旋轉、Y 旋轉以及深度。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
2. 取得第一張投影片。
3. 新增一個具有預設資料的圖表。
4. 設定 3D 旋轉屬性。
5. 將已修改的簡報寫入 PPTX 檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 加入具有預設資料的圖表。
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # 設定圖表資料工作表索引。
    default_worksheet_index = 0

    # 取得圖表資料工作簿。
    workbook = chart.getChartData().getChartDataWorkbook()

    # 新增系列。
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # 新增類別。
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # 設定 3D 旋轉屬性。
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # 取得第二個圖表系列。
    series = chart.getChartData().getSeries().get_Item(1)

    # 填入系列資料。
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # 儲存簡報。
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**哪一些圖表類型在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援柱狀圖的 3D 變體，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 以及 100% Stacked Column 3D，並可透過 [ChartType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/charttype/) 類別取得相關的 3D 類型。欲取得完整且最新的清單，請參考您所安裝版本的 API 參考文件中的 [ChartType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖以用於報告或網站嗎？**

可以。您可以透過 [chart API](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getImage) 將圖表匯出為圖像，或是將整張投影片 [render the entire slide](/slides/zh-hant/python-java/convert-powerpoint-to-png/) 轉換成 PNG、JPEG 等格式。這在您需要像素級預覽或將圖表嵌入文件、儀表板或網頁而不需 PowerPoint 時非常有用。

**建構與呈現大型 3D 圖表的效能如何？**

效能取決於資料量與視覺複雜度。為取得最佳結果，請盡量減少 3D 效果、避免在牆面與圖表區域使用大型紋理，盡可能限制每個系列的資料點數量，並將輸出解析度與尺寸設定為符合目標顯示或列印需求的適當大小。