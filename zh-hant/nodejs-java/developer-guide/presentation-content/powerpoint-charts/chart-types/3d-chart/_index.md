---
title: 帶 JavaScript 的簡報中自訂 3D 圖表
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
description: "使用 Aspose.Slides for Node.js via Java 在 PowerPoint 簡報中建立 3D 圖表。透過 JavaScript 範例調整旋轉角度、高度比例、圖表深度以及系列之間的間距。"
---
## **概述**

Aspose.Slides for Node.js via Java 讓您透過 [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) 方法自訂 3D 圖表的檢視方式。本文示範如何調整旋轉角度、高度比例、深度、直角坐標軸以及系列之間的間距，然後將簡報儲存為 PPTX 格式。

## **設定 3D 圖表的旋轉與深度**

以下範例建立一個 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)，並使用 [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) 在第一張投影片中加入堆疊式 3D 柱狀圖。它會以兩個各有三個值的系列取代預設的系列與類別。工作表索引 `0` 表示圖表的第一個資料工作表；列 `0` 儲存系列名稱，欄 `0` 儲存類別標籤。

[setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) 與 [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) 方法分別將圖表的旋轉設定為 40 度與 270 度。[setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) 將其深度設定為寬度的 150%，而 [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) 則啟用直角坐標軸取代透視。最終的簡報會包含套用這些 3D 視圖設定的圖表。

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

## **將圖片填滿套用至 3D 圖表表面**

您可以分別為 3D 圖表的 [side wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/)、[back wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/) 與 [floor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) 設定填滿。將表面的 [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) 設為 `Picture` 並指派圖像。同時將 [picture fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/) 與表面的 [picture type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) 設為 `Stretch`，即可讓單一圖像平鋪整個表面。

將 [arrow.png](arrow.png) 儲存於工作目錄中。範例會旋轉圖表並提升垂直軸的最大值，使底面在柱子之間可見。接著會將投影片複製兩次，並在每張投影片的不同表面套用箭頭。三個圖表保留相同的資料、檢視角度與背景。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint 會顯示下列三張投影片。

| 側牆 | 背牆 | 底面 |
| --- | --- | --- |
| ![指向圖表側牆的箭頭](side-wall.png) | ![指向背牆右側的箭頭](back-wall.png) | ![指向柱子之間底面右側的箭頭](floor.png) |

## **調整 3D 圖表的高度比例**

使用 [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) 可將 3D 圖表的高度設定為寬度的百分比。此動作會在不改變投影片上圖表物件尺寸的情況下，調整 3D 場景的比例。

以下範例建立一個預設資料的 [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 圖表（包含三個系列與四個類別），並分別以 50%、100% 與 200% 的高度比例儲存三個簡報。圖表的位置、寬度與高度保持不變。資料、旋轉、深度、系列間距與格式在三個檔案中皆相同，唯一變動的是高度百分比。

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

以下圖像說明在等效的 .NET 範例中相同的高度設定，並由 Microsoft PowerPoint 匯出。較小的百分比會產生較平的場景，較大的百分比則在相同圖表物件內呈現較高的場景。PowerPoint 也可能會調整坐標軸刻度間隔與標籤位置以符合場景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![3D 柱狀圖，高度設定為寬度的 50%](height_percent_50.png) | ![3D 柱狀圖，高度設定為寬度的 100%](height_percent_100.png) | ![3D 柱狀圖，高度設定為寬度的 200%](height_percent_200.png) |

以下方法控制圖表的不同面向：

| 方法 | 效果 |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | 3D 場景的高度佔寬度的百分比。 |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | 投影片上圖表物件的高度（點數）。 |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | 3D 場景的深度佔寬度的百分比。 |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | 系列在深度軸上的間距，佔標記寬度的百分比。 |

此高度設定會影響 3D 柱狀圖與條形圖，包括圓柱、圓錐與金字塔變體，以及 3D 折線圖、區域圖、圓餅圖與曲面圖。上表以驗證過的 `Column3D` 類型為例。此設定不會改變 2D `ClusteredColumn` 圖表或 `BubbleWith3D` 圖表的外觀；這些名稱屬於 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 類別的成員。欲了解其他圖表外觀設定，請參閱 [Chart Formatting](/slides/zh-hant/nodejs-java/chart-formatting/)。

## **調整系列間的間距**

使用 [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) 可控制 3D 圖表中資料系列在深度軸上的間距，以標記寬度的百分比表示。可使用 **0 到 500**（含）之間的值：`0` 會移除間距，較大的值則會增加間距。若圖表深度固定，增大間距會使標記在深度軸上變得較細。

透過 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) 取得群組。此設定會套用至該群組內的所有系列，而不僅限於呼叫它的系列。[ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) 會回傳深度間距並反映父群組的設定。

此設定會影響 3D 柱狀圖與條形圖，包括其圓柱、圓錐與金字塔變體，以及 3D 折線圖與區域圖。外觀會根據系列是以深度排列、群集或堆疊而有所不同。若要清楚比較不同系列之間的間距，請使用來自 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 類別的 `ChartType.Column3D`。

以下方法控制圖表的不同面向：

| 方法 | 效果 |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | 系列在深度軸上的間距，佔標記寬度的百分比。 |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | 相鄰柱或條形群組之間的間距，佔柱或條形寬度的百分比。 |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | 整體圖表深度，佔圖表寬度的百分比。 |

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

以下範例使用預設圖表資料（包含三個系列與四個類別），並以相同的資料、旋轉、間距寬度與圖表深度儲存兩個簡報，唯一變更的是間距深度。

| 間距深度：0% | 間距深度：500% |
| --- | --- |
| ![3D 柱狀圖，系列在深度軸上沒有間距](gap_depth_0.png) | ![3D 柱狀圖，系列在深度軸上有 500% 的間距](gap_depth_500.png) |

## **變更 3D 系列類型與條形形狀**

在群集圓柱圖中，第一個系列的條形形狀預設為圓柱。範例會在每次變更前後列印 [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) 與 [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) 所回傳的整數值。下表列出相對應的常數名稱。

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
| 將系列類型設為 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 將條形形狀設為 `Box` | `ClusteredColumn3D` | `Box` |

將形狀設為 `Box` 同時也會將系列類型變更為 `ClusteredColumn3D`。若您的程式碼依賴系列類型分支，請在變更形狀後呼叫 `series.getType()`。在指派之前快取的值仍會選擇 `ClusteredCone` 分支。

![PowerPoint 比較圖，顯示第一系列從左到右分別為圓柱形、錐形和矩形柱狀](series-shapes.png)

## **常見問題**

**哪些圖表類型在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援柱狀圖的 3D 變體，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 與 100% Stacked Column 3D，以及透過 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 類別公開的其他相關 3D 類型。欲取得精確且即時的清單，請查閱您安裝版本的 API 參考中 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖，用於報告或網路嗎？**

可以。您可以使用 [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 將圖表匯出為影像，或使用 [render the entire slide](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/) 產生 PNG、JPEG 等格式。這在需要點陣預覽或想將圖表嵌入文件、儀表板或網頁，而不需 PowerPoint 時特別有用。

**大型 3D 圖表的建立與渲染效能如何？**

效能受資料量與視覺複雜度影響。為獲得最佳結果，建議盡量減少 3D 效果、避免在牆面與繪圖區使用大量紋理、在可能的情況下限制每個系列的資料點數，並將輸出解析度與尺寸設定為符合目標顯示或列印需求的大小。