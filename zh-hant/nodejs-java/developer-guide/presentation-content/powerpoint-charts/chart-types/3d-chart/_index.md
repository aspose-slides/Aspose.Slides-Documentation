---
title: 使用 JavaScript 自訂簡報中的 3D 圖表
linktitle: 3D 圖表
type: docs
url: /zh-hant/nodejs-java/3d-chart/
keywords:
- 3D 圖表
- 旋轉
- 深度
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 在 PowerPoint 簡報中建立 3D 圖表。透過 JavaScript 範例調整旋轉、 高度比例、 圖表深度以及系列之間的間距。"
---
## **概觀**

Aspose.Slides for Node.js via Java 讓您可以透過 [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) 方法自訂 3D 圖表的檢視。本文示範如何調整旋轉、 高度比例、深度、直角座標軸以及系列之間的間距，然後將簡報儲存為 PPTX 格式。

## **設定 3D 圖表的旋轉與深度**

下列範例會建立一個 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 並使用 [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) 在其第一張投影片加入堆疊 3D 柱狀圖。它會以兩個各含三個數值的系列取代預設的系列與類別。工作表索引 `0` 表示圖表的第一個資料工作表；第 `0` 列保存系列名稱，第 `0` 欄保存類別標籤。

[setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) 與 [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) 方法分別將圖表的旋轉設定為 40 與 270 度。[setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) 將深度設定為寬度的 150%，而 [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) 則啟用直角座標軸取代透視。最終產生的簡報包含具有上述 3D 檢視設定的圖表。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **調整 3D 圖表的高度比例**

使用 [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) 可將 3D 圖表的高度設定為寬度的百分比。此操作會改變 3D 場景的比例，而不會改變投影片上圖表物件的大小。

以下範例建立一個預設資料的 [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 圖表（三個系列、四個類別），並分別以 50%、100% 與 200% 的高度比例儲存三個簡報。圖表的位置、寬度與高度保持不變，資料、旋轉、深度、系列間距與格式在三個檔案中皆相同，僅高度百分比不同。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

以下圖像說明相同的高度設定在相應的 .NET 範例中之呈現，均以 Microsoft PowerPoint 匯出。較小的百分比會產生較平坦的場景，較大的百分比則在相同圖表物件內產生較高的場景。PowerPoint 可能會同時調整座標軸刻度間隔與標籤位置以適應場景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![3D 柱狀圖，高度設定為寬度的 50%](height_percent_50.png) | ![3D 柱狀圖，高度設定為寬度的 100%](height_percent_100.png) | ![3D 柱狀圖，高度設定為寬度的 200%](height_percent_200.png) |

這些方法控制圖表的不同面向：

| 方法 | 效果 |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | 3D 場景的高度，以寬度的百分比表示。 |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | 投影片上圖表物件的高度（以點為單位）。 |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | 3D 場景的深度，以寬度的百分比表示。 |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | 系列在深度軸上的間距，以標記寬度的百分比表示。 |

高度設定會影響 3D 柱狀圖與條形圖，包括圓柱、圓錐與金字塔變體，以及 3D 折線、區域、圓餅與曲面圖。上述比較使用已驗證的 `Column3D` 類型。此設定不會變更 2D `ClusteredColumn` 圖表或 `BubbleWith3D` 圖表的外觀；這些名稱屬於 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 類別的成員。其他圖表外觀設定，請參閱 [圖表格式化](/slides/zh-hant/nodejs-java/chart-formatting/)。

## **調整系列之間的間距**

使用 [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) 可控制 3D 圖表中資料系列沿深度軸的間距，比例以標記寬度的百分比表示。可使用 **0 到 500**（含）的值：`0` 代表無間距，較大的值則增加間距。若圖表深度固定，增大間距會使標記在深度軸上變得較薄。

透過 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) 取得群組。此設定會套用至該群組中的所有系列，而不僅是取得群組的那個系列。[ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) 會回傳深度間距並反映父群組的設定。

此設定會影響 3D 柱狀圖與條形圖，包括其圓柱、圓錐與金字塔變體，以及 3D 折線與區域圖。外觀會因系列排列方式（深度、叢集或堆疊）而異。若要清楚比較不同系列之間的間距，請使用 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 類別中的 `Column3D`。

這些方法控制圖表的不同面向：

| 方法 | 效果 |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | 系列在深度軸上的間距，以標記寬度的百分比表示。 |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | 相鄰條形或柱形叢集之間的間距，以條形或柱形寬度的百分比表示。 |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | 整體圖表深度，以圖表寬度的百分比表示。 |

以下自包含範例使用預設圖表資料（包含三個系列與四個類別），儲存兩個簡報，資料、旋轉、間距寬度與圖表深度皆相同，僅間距深度不同。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

以下圖像說明相同的間距深度設定在相應的 .NET 範例中之呈現，均以 Microsoft PowerPoint 匯出。

| 間距深度：0% | 間距深度：500% |
| --- | --- |
| ![3D 柱狀圖，系列在深度軸上之間沒有間隙](gap_depth_0.png) | ![3D 柱狀圖，系列在深度軸上之間有 500% 的間隙](gap_depth_500.png) |

## **變更 3D 系列類型與條形形狀**

在叢集圓柱圖中，第一個系列預設為圓柱形條狀。範例會在每次變更前後列印 [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) 與 [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) 回傳的整數值。下表列出對應的常數名稱。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 變更第一系列 | 系列類型 | 條形形狀 |
| --- | --- | --- |
| 建立圖表 | `ClusteredCylinder` | `Cylinder` |
| 將系列類型設定為 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 將條形形狀設定為 `Box` | `ClusteredColumn3D` | `Box` |

將形狀設定為 `Box` 亦會將系列類型改為 `ClusteredColumn3D`。如果程式碼依系列類型分支，請在變更形狀後再次呼叫 `series.getType()`。在指派之前快取的值仍會選取 `ClusteredCone` 分支。

![PowerPoint 比較圖，顯示第一系列從左至右分別為圓柱、圓錐與矩形柱狀](series-shapes.png)

## **常見問題**

**哪些圖表類型在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援柱狀圖的 3D 變體，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 與 100% Stacked Column 3D，以及透過 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 類別公開的相關 3D 類型。欲取得完整且即時的列表，請檢查您所安裝版本的 API 參考中的 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖檔以用於報告或網站嗎？**

可以。您可以使用 [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 將圖表匯出為影像，或將整個投影片 [render the entire slide](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/) 為 PNG、JPEG 等格式。這在需要點陣預覽或想將圖表嵌入文件、儀表板或網頁，而不需 PowerPoint 時相當實用。

**建立與呈現大型 3D 圖表的效能如何？**

效能會受到資料量與視覺複雜度的影響。為取得最佳結果，建議盡量減少 3D 效果、避免在牆面與繪圖區使用大量紋理、盡可能限制每個系列的資料點數，並將輸出解析度與尺寸設定為符合目標顯示或列印需求的大小。