---
title: 在 Android 上自訂簡報中的 3D 圖表
linktitle: 3D 圖表
type: docs
url: /zh-hant/androidjava/3d-chart/
keywords:
- 3D 圖表
- 旋轉
- 深度
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 在 PowerPoint 簡報中建立 3D 圖表。透過 Java 範例調整旋轉、 高度比例、 圖表深度 與 系列間距。"
---
## **概覽**

Aspose.Slides for Android via Java 讓您可以透過 [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) 方法自訂 3D 圖表的檢視方式。本篇說明如何調整旋轉、 高度比例、 深度、 直角坐標軸 以及 系列間距，並將簡報儲存為 PPTX 格式。

## **設定 3D 圖表的旋轉與深度**

以下示例建立一個 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)，並使用 [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) 在第一張投影片加入 3D 堆疊直條圖。它會以兩個系列（各三個數值）取代預設的系列與類別。工作表索引 `0` 表示圖表的第一個資料工作表；第 `0` 列保存系列名稱，第 `0` 欄保存類別標籤。

[setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) 與 [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) 方法分別將圖表的旋轉設為 40 與 270 度。[setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) 將深度設定為寬度的 150%，而 [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) 則啟用直角坐標軸（取代透視）。最終的簡報包含套用上述 3D 觀景設定的圖表。

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

使用 [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) 以寬度的百分比設定 3D 圖表的高度。此操作會在不改變投影片上圖表物件大小的前提下，改變 3D 場景的比例。

以下示例建立一個使用預設資料（三個系列、四個類別）的 [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 圖表，並分別以 50%、100% 與 200% 的高度比例儲存三個簡報。圖表的位置、寬度與高度保持不變，資料、旋轉、深度、系列間距與格式在三個檔案中皆相同，僅高度百分比不同。

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

以下圖片說明在等效的 .NET 範例中相同的高度設定，並由 Microsoft PowerPoint 匯出。較小的百分比會產生較平坦的場景，較大的百分比則會在相同圖表物件內產生較高的場景。PowerPoint 也可能會調整坐標軸刻度間隔與標籤位置以適應場景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![3D 直條圖高度設定為寬度的 50%](height_percent_50.png) | ![3D 直條圖高度設定為寬度的 100%](height_percent_100.png) | ![3D 直條圖高度設定為寬度的 200%](height_percent_200.png) |

這些方法會控制圖表的不同面向：

| 方法 | 效果 |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | 3D 場景的高度佔寬度的百分比。 |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | 投影片上圖表物件的高度（點數）。 |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 3D 場景的深度佔寬度的百分比。 |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | 依標記寬度的百分比，設定沿深度軸的系列間距。 |

高度設定會影響 3D 直條圖與橫條圖（包括圓柱、圓錐與金字塔變體），以及 3D 折線圖、面積圖、餅圖與曲面圖。上表使用已驗證的 `Column3D` 類型。此設定不會改變 2D `ClusteredColumn` 圖表或 `BubbleWith3D` 圖表的外觀；這些名稱皆屬於 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 類別的成員。其他圖表外觀設定請參閱 [Chart Formatting](/slides/zh-hant/androidjava/chart-formatting/)。

## **調整系列間的間距**

使用 [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) 以標記寬度的百分比控制 3D 圖表中資料系列沿深度軸的間距。可接受 **0 到 500**（含）的值：`0` 移除間距，較大的數值會增加間距。若圖表深度固定，增加間距會使標記在深度軸上變得較薄。

透過 [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) 取得群組。此設定會套用到該群組中的所有系列，而不僅限於取得群組的那個系列。[IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) 會回傳深度間距，並反映父群組的設定。

此設定會影響 3D 直條圖與橫條圖（包括圓柱、圓錐與金字塔變體），以及 3D 折線圖與面積圖。外觀取決於系列在深度、叢集或堆疊模式下的排列方式。若要清楚比較不同系列之間的間距，請使用來自 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 類別的 `ChartType.Column3D`。

這些方法會控制圖表的不同面向：

| 方法 | 效果 |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | 依標記寬度的百分比，設定沿深度軸的系列間距。 |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | 依條形或直條寬度的百分比，設定相鄰叢集之間的間距。 |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 以圖表寬度的百分比設定整體圖表深度。 |

以下自包含範例使用預設圖表資料（三個系列、四個類別），分別以相同的資料、旋轉、間距寬度與圖表深度儲存兩個簡報，唯一不同的是間距深度。

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

以下圖片說明在等效的 .NET 範例中相同的間距深度設定，並由 Microsoft PowerPoint 匯出。

| 間距深度：0% | 間距深度：500% |
| --- | --- |
| ![3D 直條圖在深度軸上系列之間無間距](gap_depth_0.png) | ![3D 直條圖在深度軸上系列之間有 500% 的間距](gap_depth_500.png) |

## **變更 3D 系列類型與條形外觀**

在叢集圓柱圖中，第一個系列預設使用圓柱形條。範例分別在每次變更前後列印由 [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) 與 [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) 回傳的整數值。下表列出對應的常數名稱。

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

| 變更第一個系列 | 系列類型 | 條形外觀 |
| --- | --- | --- |
| 建立圖表 | `ClusteredCylinder` | `Cylinder` |
| 設定系列類型為 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 設定條形外觀為 `Box` | `ClusteredColumn3D` | `Box` |

將外觀設定為 `Box` 亦會將系列類型變更為 `ClusteredColumn3D`。若您的程式碼依系列類型分支，請在變更外觀後再次呼叫 `series.getType()`。在指派前快取的值仍會選擇 `ClusteredCone` 分支。

![PowerPoint 比較圖，顯示第一個系列依序為圓柱、圓錐與矩形柱形](series-shapes.png)

## **常見問題集**

**哪些圖表類型在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援 3D 變體的直條圖，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 與 100% Stacked Column 3D，並可透過 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 類別取得相關的 3D 類型。欲取得完整且即時的清單，請檢查您所安裝版本 API 參考中的 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖以用於報告或網頁嗎？**

可以。您可以使用 [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) 將圖表匯出為影像，或將整張投影片 [render the entire slide](/slides/zh-hant/androidjava/convert-powerpoint-to-png/) 為 PNG、JPEG 等格式。這在需要點陣預覽或將圖表嵌入文件、儀表板或網頁，而不必安裝 PowerPoint 時相當有用。

**建立與呈現大型 3D 圖表的效能如何？**

效能取決於資料量與視覺複雜度。為獲得最佳結果，請盡量減少 3D 效果、避免在牆面與繪圖區使用大量紋理、在可能的情況下限制每個系列的資料點數量，並依目標顯示或列印需求將輸出解析度與尺寸設定為適當大小。