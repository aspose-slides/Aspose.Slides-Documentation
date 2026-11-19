---
title: 使用 Python 客製化簡報中的 3D 圖表
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
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 簡報中建立 3D 圖表。透過 Python 範例調整旋轉、 高度比例、 圖表深度 以及 系列之間的間距。"
---
## **概觀**

Aspose.Slides for Python via Java 讓您能透過 [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D) 方法自訂 3D 圖表的檢視。本文章示範如何調整旋轉、**高度比例**、深度、直角座標軸以及系列之間的間距，最後將簡報儲存為 PPTX 格式。

## **設定 3D 圖表的旋轉與深度**

以下範例建立一個 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)，並使用 [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) 在其第一張投影片加入堆疊式 3D 柱狀圖。它會以兩個系列（每個系列各有三個值）取代預設的系列與類別。工作表索引 `0` 為圖表的第一個資料工作表；第 `0` 列保存系列名稱，第 `0` 欄保存類別標籤。

[setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) 與 [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) 方法分別將圖表的旋轉角度設為 40 度與 270 度。[setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) 將深度設為寬度的 150%，而 [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) 則啟用直角座標軸取代透視效果。最終的簡報包含套用了這些 3D 觀點設定的完整圖表。

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

## **調整 3D 圖表的高度比例**

使用 [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) 可將 3D 圖表的高度設定為寬度的百分比。此操作會改變 3D 場景的比例，卻不會改變投影片上圖表物件的大小。

以下範例建立一個使用預設資料（三個系列與四個類別）的 [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 圖表。它會分別以 50%、100% 和 200% 的高度比例儲存三個簡報。圖表的位置、寬度與高度皆保持不變。資料、旋轉、深度、系列間距與格式在三個檔案中完全相同，唯一改變的只有高度百分比。

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

以下影像說明了在等效的 .NET 範例中相同的高度設定，皆由 Microsoft PowerPoint 匯出。較小的百分比會產生較平坦的場景，較大的百分比則會在相同的圖表物件內產生較高的場景。PowerPoint 也可能會調整座標軸刻度間隔與標籤位置以適應場景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![3D 柱狀圖，將高度設定為寬度的 50%](height_percent_50.png) | ![3D 柱狀圖，將高度設定為寬度的 100%](height_percent_100.png) | ![3D 柱狀圖，將高度設定為寬度的 200%](height_percent_200.png) |

以下方法控制圖表的不同面向：

| 方法 | 效果 |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | 3D 場景的高度，以寬度的百分比表示。 |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | 投影片上圖表物件的高度，單位為點。 |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | 3D 場景的深度，以寬度的百分比表示。 |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | 依標記寬度的百分比，設定系列沿深度軸的間距。 |

此高度設定會影響 3D 欄與條形圖（包括圓柱、圓錐與金字塔變體），以及 3D 折線圖、面積圖、圓餅圖與曲面圖。上表以驗證過的 `Column3D` 類型作比較。此設定不會改變 2D `ClusteredColumn` 圖表或 `BubbleWith3D` 圖表的外觀；這些名稱均為 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 類別的成員。其他圖表外觀設定請參考 [圖表格式化](/slides/zh-hant/python-java/chart-formatting/)。

## **調整系列之間的間隙**

使用 [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) 以百分比（相對於標記寬度）控制 3D 圖表中資料系列沿深度軸的間距。可使用 **0 到 500**（含）之間的值：`0` 會移除間隙，較大的值則會增加間距。若圖表深度固定，增加間隙會使標記在深度軸上變得較細。

透過 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) 取得群組。此設定會套用到該群組內的所有系列，而不僅限於取得群組的那個系列。[ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) 會回傳深度間隙，並反映父群組的設定。

此設定會影響 3D 欄與條形圖（包括圓柱、圓錐與金字塔變體），以及 3D 折線圖與面積圖。外觀會依系列的深度排列、叢集或堆疊方式而異。若要清楚比較不同系列之間的間隙，請使用來自 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 類別的 `ChartType.Column3D`。

以下方法控制圖表的不同面向：

| 方法 | 效果 |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | 依標記寬度的百分比，設定系列沿深度軸的間距。 |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | 依條或欄寬度的百分比，設定相鄰條或欄叢集之間的間距。 |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | 以寬度的百分比表示的整體圖表深度。 |

以下獨立範例使用預設圖表資料（包含三個系列與四個類別），儲存兩個簡報，資料、旋轉、間距寬度與圖表深度皆相同，唯一改變的是間隙深度。

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

以下影像說明了在等效的 .NET 範例中相同的間隙深度設定，皆由 Microsoft PowerPoint 匯出。

| 間隙深度：0% | 間隙深度：500% |
| --- | --- |
| ![3D 柱狀圖，系列在深度軸上沒有間隙](gap_depth_0.png) | ![3D 柱狀圖，系列在深度軸上有 500% 的間隙](gap_depth_500.png) |

## **變更 3D 系列類型和條形形狀**

在叢集圓柱圖中，第一系列預設為圓柱形條狀。範例會在每次變更前後印出 [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) 與 [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) 回傳的整數值。下表列出相對應的常數名稱。

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

| 對第一系列的變更 | 系列類型 | 條形形狀 |
| --- | --- | --- |
| 建立圖表 | `ClusteredCylinder` | `Cylinder` |
| 將系列類型設為 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 將條形形狀設為 `Box` | `ClusteredColumn3D` | `Box` |

將形狀設定為 `Box` 也會將系列類型改為 `ClusteredColumn3D`。如果您的程式碼依系列類型分支，請在變更形狀後呼叫 `series.getType()`。在指派之前快取的值仍可能導致選擇 `ClusteredCone` 分支。

![PowerPoint 比較，從左至右依序顯示第一系列為圓柱、圓錐與矩形欄位](series-shapes.png)

## **常見問題**

**Which chart types support 3D mode in Aspose.Slides?**

Aspose.Slides 支援柱狀圖的 3D 變體，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 與 100% Stacked Column 3D，此外還有透過 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 類別公開的相關 3D 類型。欲取得最新、完整的清單，請檢查您安裝版本之 API 參考中的 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 成員。

**Can I get a raster image of a 3D chart for a report or the web?**

可以。您可以使用 [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) 將圖表匯出為影像，或使用 [render the entire slide](/slides/zh-hant/python-java/convert-powerpoint-to-png/) 產生 PNG、JPEG 等格式。這在您需要光柵預覽或想將圖表嵌入文件、儀表板或網頁，而不必依賴 PowerPoint 時非常實用。

**How performant is building and rendering large 3D charts?**

效能會受到資料量與視覺複雜度的影響。為取得最佳效能，建議盡量減少 3D 效果、避免在牆面與圖表區域使用大量紋理、在可能的情況下限制每個系列的資料點數量，並將輸出解析度與尺寸設定為符合目標顯示或列印需求的大小。