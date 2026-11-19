---
title: 使用 Java 在簡報中自訂 3D 圖表
linktitle: 3D 圖表
type: docs
url: /zh-hant/java/3d-chart/
keywords:
- 3D 圖表
- 旋轉
- 深度
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 簡報中建立 3D 圖表。透過 Java 範例調整旋轉、 高度比例、 圖表深度以及系列間的間距。"
---
## **概述**

Aspose.Slides for Java 讓您透過 [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) 方法自訂 3D 圖表的檢視。本文章示範如何調整旋轉、 高度比例、 深度、 直角座標軸以及系列之間的間距，然後以 PPTX 格式儲存簡報。

## **設定 3D 圖表的旋轉與深度**

以下範例建立一個 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)，並使用 [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) 在第一張投影片中加入堆疊式 3D 柱狀圖。它以兩個每含三個值的系列取代預設的系列與類別。工作表索引 `0` 表示圖表的第一個資料工作表；列 `0` 保存系列名稱，欄 `0` 保存類別標籤。

[setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) 與 [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) 方法分別將圖表的旋轉設定為 40° 與 270°。[setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) 將深度設為寬度的 150%，而 [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) 則啟用直角座標軸取代透視。最終的簡報包含套用這些 3D 檢視設定的圖表。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **調整 3D 圖表的高度比例**

使用 [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) 以寬度的百分比設定 3D 圖表的高度。此方式會在不調整投影片上圖表物件大小的前提下，變更 3D 場景的比例。

以下範例建立一個預設資料的 [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) 圖表（包含三個系列與四個類別），分別以 50%、100% 與 200% 的高度比例儲存三個簡報。圖表的位置、寬度與高度保持不變。資料、旋轉、深度、系列間距與格式在三個檔案中皆相同，僅高度百分比不同。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

以下圖片示範相同高度設定在等效的 .NET 範例中，並以 Microsoft PowerPoint 匯出。較小的百分比產生較平坦的場景，較大的百分比則在相同圖表物件內產生較高的場景。PowerPoint 也可能會調整座標軸刻度間隔與標籤位置以配合場景。

| Height: 50% | Height: 100% | Height: 200% |
| --- | --- | --- |
| ![3D 柱狀圖，高度設定為其寬度的 50%](height_percent_50.png) | ![3D 柱狀圖，高度設定為其寬度的 100%](height_percent_100.png) | ![3D 柱狀圖，高度設定為其寬度的 200%](height_percent_200.png) |

這些方法控制圖表的不同層面：

| 方法 | 效果 |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | 3D 場景的高度佔寬度的百分比。 |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | 投影片上圖表物件的高度（點數）。 |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 3D 場景的深度佔寬度的百分比。 |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | 系列沿深度軸的間距，以標記寬度的百分比表示。 |

高度設定會影響 3D 柱狀圖與條狀圖（包含圓柱、圓錐與金字塔變體），以及 3D 折線圖、區域圖、圓餅圖與曲面圖。上方比較使用已驗證的 `Column3D` 型別。此設定不會改變 2D `ClusteredColumn` 圖表或 `BubbleWith3D` 圖表的外觀；這些名稱皆為 [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) 類別的成員。欲了解其他圖表外觀設定，請參閱 [Chart Formatting](/slides/zh-hant/java/chart-formatting/)。

## **調整系列之間的間隙**

使用 [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) 以標記寬度的百分比控制 3D 圖表中資料系列沿深度軸的距離。可接受的值為 **0 到 500**（含），其中 `0` 代表移除間隙，較大的值則增加間距。當圖表深度固定時，增大間隙會使標記在深度軸上變得較細。

透過 [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) 取得群組。此設定會套用到該群組內的所有系列，而不僅是取得群組的那一個系列。[IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) 會回傳深度間隙，並反映父群組的設定。

此設定會影響 3D 柱狀圖與條狀圖（含圓柱、圓錐與金字塔變體），以及 3D 折線圖與區域圖。外觀會依系列是依深度排列、群聚或堆疊而異。若要清楚比較不同系列之間的間隙，請使用 [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) 類別中的 `ChartType.Column3D`。

這些方法控制圖表的不同層面：

| 方法 | 效果 |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | 系列沿深度軸的間距，以標記寬度的百分比表示。 |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | 相鄰條或柱叢集之間的間距，佔條或柱寬度的百分比。 |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 整體圖表的深度，佔圖表寬度的百分比。 |

以下自行完整的範例使用預設圖表資料（三個系列、四個類別），儲存兩個簡報，資料、旋轉、間距寬度與圖表深度皆相同，僅間距深度不同。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

以下圖片示範相同間距深度設定在等效的 .NET 範例中，並以 Microsoft PowerPoint 匯出。

| Gap depth: 0% | Gap depth: 500% |
| --- | --- |
| ![3D 柱狀圖，系列沿深度軸之間無間隙](gap_depth_0.png) | ![3D 柱狀圖，系列沿深度軸之間有 500% 的間隙](gap_depth_500.png) |

## **變更 3D 系列類型與條形形狀**

在群聚圓柱圖中，第一個系列預設為圓柱形條。範例會在每次變更前後印出 [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) 與 [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) 回傳的整數值。下表列出相對應的常數名稱。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 變更第一個系列 | 系列類型 | 條形形狀 |
| --- | --- | --- |
| 建立圖表 | `ClusteredCylinder` | `Cylinder` |
| 將系列類型設定為 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 將條形形狀設定為 `Box` | `ClusteredColumn3D` | `Box` |

將形狀設定為 `Box` 同時會把系列類型改為 `ClusteredColumn3D`。如果您的程式碼依系列類型分支，請在變更形狀後呼叫 `series.getType()`。在指派前已快取的值仍會選取 `ClusteredCone` 分支。

![PowerPoint 比較圖，顯示第一個系列分別為圓柱、圓錐與矩形柱（由左至右）](series-shapes.png)

## **常見問題**

**Which chart types support 3D mode in Aspose.Slides?**

Aspose.Slides 支援 3D 變體的柱狀圖，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 與 100% Stacked Column 3D，以及透過 [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) 類別公開的相關 3D 類型。欲取得最新且精確的清單，請檢視您所安裝版本的 API 參考文件中 [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) 成員。

**Can I get a raster image of a 3D chart for a report or the web?**

可以。您可以使用 [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) 將圖表匯出為影像，或將整個投影片 [render the entire slide](/slides/zh-hant/java/convert-powerpoint-to-png/) 為 PNG、JPEG 等格式。這在需要光柵預覽、或想將圖表嵌入文件、儀表板或網頁，而不需 PowerPoint 時特別實用。

**How performant is building and rendering large 3D charts?**

效能取決於資料量與視覺複雜度。為獲得最佳結果，建議盡量減少 3D 效果、避免在牆面與繪圖區使用大量紋理、盡可能限制每個系列的資料點數，並以符合目標顯示或列印需求的解析度與尺寸輸出。