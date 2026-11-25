---
title: 使用 Python 在簡報中自訂 3D 圖表
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
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 簡報中建立 3D 圖表。透過 Python 範例調整旋轉、 高度比例、 圖表深度 與 系列間距。"
---
## **概觀**

Aspose.Slides for Python via Java 讓您可以透過 [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D) 方法自訂 3D 圖表的檢視。本篇說明如何調整旋轉、 高度比例、 深度、 直角座標軸，以及系列之間的間距，然後將簡報儲存為 PPTX 格式。

## **設定 3D 圖表的旋轉與深度**

以下範例建立一個 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)，並使用 [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) 在第一張投影片加入堆疊 3D 柱狀圖。它會以兩個各有三個值的系列取代預設的系列與類別。工作表索引 `0` 代表圖表的第一個資料工作表；第 `0` 列放置系列名稱，第 `0` 欄放置類別標籤。

[setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) 與 [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) 方法分別將圖表的旋轉設定為 40 與 270 度。[setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) 將深度設定為寬度的 150%，而 [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) 則啟用直角座標軸（非透視）。最終簡報包含已套用這些 3D 觀察設定的圖表。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **對 3D 圖表表面套用圖片填充**

3D 圖表有三個表面可分別填充：[side wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getSideWall)、[back wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) 與 [floor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor)。將表面的 [fill type](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) 設為 `Picture` 並指定圖片。將 [picture fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) 與表面的 [picture type](https://reference.aspose.com/slides/python-java/aspose.slides/chartwall/#setPictureType) 都設為 `Stretch`，即可讓單一圖片複本填滿整個表面。

將 [arrow.png](arrow.png) 儲存於工作目錄。範例會旋轉圖表並提升垂直軸的最大值，使得底面在柱狀之間可見。接著將投影片複製兩次，並在每張投影片的不同表面套用箭頭。三個圖表保留相同的資料、檢視角度與背景。

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, PictureFillMode, PictureType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(30)
    
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(24)

    back_slide = presentation.getSlides().addClone(slide)
    floor_slide = presentation.getSlides().addClone(slide)
    back_chart = back_slide.getShapes().get_Item(0)
    floor_chart = floor_slide.getShapes().get_Item(0)

    image_bytes = Path("arrow.png").read_bytes()
    arrow = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_bytes))

    surfaces = (chart.getSideWall(), back_chart.getBackWall(), floor_chart.getFloor())
    for surface in surfaces:
        fill = surface.getFormat().getFill()
        fill.setFillType(FillType.Picture)
        picture_fill = fill.getPictureFillFormat()
        picture_fill.getPicture().setImage(arrow)
        picture_fill.setPictureFillMode(PictureFillMode.Stretch)
        surface.setPictureType(PictureType.Stretch)

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Microsoft PowerPoint 會如下顯示這三張投影片。

| 側牆 | 背牆 | 底面 |
| --- | --- | --- |
| ![箭頭指向圖表的側牆](side-wall.png) | ![箭頭指向背牆的右側](back-wall.png) | ![箭頭指向柱狀之間的底面](floor.png) |

## **調整 3D 圖表的高度比例**

使用 [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) 可將 3D 圖表的高度設定為寬度的百分比。此操作會改變 3D 場景的比例，卻不會改變投影片上圖表物件的大小。

以下範例建立一個 [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 圖表，使用預設資料：三個系列與四個類別。它會產生三個簡報，分別以 50%、100% 與 200% 的高度比例儲存。圖表的位置、寬度與高度保持不變。資料、旋轉、深度、系列間距與格式在所有三個檔案中皆相同，唯一改變的是高度百分比。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

以下圖片說明了在等效 .NET 範例中相同的高度設定，這些圖片是使用 Microsoft PowerPoint 匯出的。較小的百分比會產生較平的場景，較大的百分比則在相同的圖表物件中產生較高的場景。PowerPoint 也可能會調整座標軸刻度間隔與標籤位置，以適應場景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![高度設定為寬度 50% 的 3D 柱狀圖](height_percent_50.png) | ![高度設定為寬度 100% 的 3D 柱狀圖](height_percent_100.png) | ![高度設定為寬度 200% 的 3D 柱狀圖](height_percent_200.png) |

以下方法控制圖表的不同面向：

| 方法 | 效果 |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | 3D 場景的高度佔寬度的百分比。 |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | 投影片上圖表物件的高度（單位：點）。 |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | 3D 場景的深度佔寬度的百分比。 |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | 系列沿深度軸的間距，以標記寬度的百分比表示。 |

高度設定會影響 3D 柱狀圖與條形圖，包括圓柱、圓錐與金字塔變體，以及 3D 折線圖、面積圖、餅圖與曲面圖。上述比較使用已驗證的 `Column3D` 類型。此設定不會改變 2D `ClusteredColumn` 圖表或 `BubbleWith3D` 圖表的外觀；這些名稱皆為 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 類別的成員。欲了解其他圖表外觀設定，請參閱 [Chart Formatting](/slides/zh-hant/python-java/chart-formatting/)。

## **調整系列之間的間隙**

使用 [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) 來控制 3D 圖表中資料系列沿深度軸的間距，該值以標記寬度的百分比表示。可接受 **0 到 500**（含）之間的值：`0` 會移除間隙，較大的值則會增加間距。若圖表深度固定，增加間隙會使標記在深度軸上變得較細。

透過 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) 取得群組。此設定會套用到該群組中的所有系列，而不僅限於存取它的那個系列。[ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) 會回傳深度間隙，並反映父群組的設定。

此設定會影響 3D 柱狀圖與條形圖，包括其圓柱、圓錐與金字塔變體，以及 3D 折線圖與面積圖。外觀會依系列在深度、群組或堆疊方式而異。若要清楚比較不同系列之間的間隙，請使用來自 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 類別的 `ChartType.Column3D`。

以下方法控制圖表的不同面向：

| 方法 | 效果 |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | 系列沿深度軸的間距，以標記寬度的百分比表示。 |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | 相鄰條形或柱狀群組之間的間距，以條形或柱狀寬度的百分比表示。 |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | 整體圖表深度，佔圖表寬度的百分比。 |

以下獨立範例使用預設圖表資料（包含三個系列與四個類別），儲存兩個簡報，資料、旋轉、間距寬度與圖表深度皆相同，唯一不同的是間距深度。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

以下圖片說明了在等效 .NET 範例中相同的間距深度設定，這些圖片是使用 Microsoft PowerPoint 匯出的。

| 間距深度：0% | 間距深度：500% |
| --- | --- |
| ![系列在深度軸上無間隙的 3D 柱狀圖](gap_depth_0.png) | ![系列在深度軸上有 500% 間隙的 3D 柱狀圖](gap_depth_500.png) |

## **變更 3D 系列類型與條形形狀**

在群組式圓柱圖中，第一個系列預設為圓柱形條。範例會在每次變更前後印出 [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) 與 [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) 回傳的整數值。下表列出相對應的常數名稱。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| 變更第一個系列 | 系列類型 | 條形形狀 |
| --- | --- | --- |
| 建立圖表 | `ClusteredCylinder` | `Cylinder` |
| 設定系列類型為 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 設定條形形狀為 `Box` | `ClusteredColumn3D` | `Box` |

將形狀設定為 `Box` 也會將系列類型變更為 `ClusteredColumn3D`。如果您的程式碼根據系列類型分支，請在變更形狀後呼叫 `series.getType()`。在指派前緩存的值仍會選擇 `ClusteredCone` 分支。

![PowerPoint 比較圖，顯示第一個系列從圓柱、圓錐到矩形柱狀的變化（由左至右）](series-shapes.png)

## **FAQ**

**哪些圖表類型在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援柱狀圖的 3D 變體，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 與 100% Stacked Column 3D，並透過 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 類別提供其他相關 3D 類型。欲取得完整且最新的清單，請檢查 API 參考中您所安裝版本的 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖，用於報告或網頁嗎？**

可以。您可以使用 [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) 將圖表匯出為圖像，或將整張投影片[轉換為 PNG](/slides/zh-hant/python-java/convert-powerpoint-to-png/) 等格式。這在需要點陣預覽或將圖表嵌入文件、儀表板或網頁，而不必依賴 PowerPoint 時非常有用。

**建構與渲染大型 3D 圖表的效能如何？**

效能取決於資料量與視覺複雜度。為取得最佳結果，建議盡量減少 3D 效果、避免在牆面與繪圖區使用大量紋理、在可能的情況下限制每個系列的資料點數量，並將輸出解析度與尺寸設定為符合目標顯示或列印需求的大小。