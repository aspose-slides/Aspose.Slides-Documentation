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
description: "使用 Aspose.Slides for Java 在 PowerPoint 簡報中建立 3D 圖表。透過 Java 範例調整旋轉、 高度比例、 圖表深度 以及 系列之間的間距。"
---
## **概述**

Aspose.Slides for Java 允許您透過 [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) 方法自訂 3D 圖表的檢視方式。本文示範如何調整旋轉、 高度比例、深度、直角坐標軸，以及系列之間的間距，然後將簡報儲存為 PPTX 格式。

## **設定 3D 圖表的旋轉與深度**

以下範例會建立一個 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 並使用 [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) 在其第一張投影片中新增堆疊 3D 柱狀圖。它會將預設的系列與類別取代為兩個系列，每個系列包含三個值。工作表索引 `0` 表示圖表的第一個資料工作表；第 `0` 列保存系列名稱，第 `0` 欄保存類別標籤。

[setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) 與 [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) 方法分別將圖表的旋轉設定為 40° 與 270°。[setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) 將其深度設定為寬度的 150%，而 [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) 則啟用直角坐標軸取代透視。產生的簡報包含使用這些 3D 觀察設定的填充圖表。

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

## **對 3D 圖表表面套用圖片填充**

3D 圖表有三個表面可分別填充：[side wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getSideWall--)、[back wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--)，以及 [floor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--)。將表面的 [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) 設為 `Picture` 並指派圖片。將 [picture fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) 與表面的 [picture type](https://reference.aspose.com/slides/java/com.aspose.slides/ichartwall/#setPictureType-int-) 皆設為 `Stretch`，使單一圖片跨越整個表面。

將 [arrow.png](arrow.png) 儲存在工作目錄中。範例會旋轉圖表並提升垂直軸的最大值，使底面在柱子之間可見。接著將投影片複製兩次，並在每張投影片的不同表面套用箭頭。三個圖表均保留相同的資料、檢視角度與背景。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    byte[] imageBytes = Files.readAllBytes(Paths.get("arrow.png"));
    IPPImage arrow = presentation.getImages().addImage(imageBytes);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint 會如下顯示這三張投影片。

| 側牆 | 背牆 | 底面 |
| --- | --- | --- |
| ![箭頭指向圖表側牆內部](side-wall.png) | ![箭頭向右指向背牆](back-wall.png) | ![箭頭向右指向柱子之間的底面](floor.png) |

## **調整 3D 圖表的高度比例**

使用 [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) 可將 3D 圖表的高度設定為寬度的百分比。這會在不調整投影片上圖表物件大小的情況下改變 3D 場景的比例。

以下範例會建立一個 [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) 圖表，使用預設資料：三個系列與四個類別。它會儲存三個簡報，高度比例分別為 50%、100% 與 200%。圖表的位置、寬度與高度保持不變。資料、旋轉、深度、系列間距與格式在所有檔案中皆相同；唯有高度百分比不同。

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

以下影像說明了等效 .NET 範例中相同的高度設定，皆由 Microsoft PowerPoint 匯出。較小的百分比會產生較平坦的場景，而較大的百分比則在相同圖表物件內產生較高的場景。PowerPoint 也可能會調整坐標軸刻度間隔與標籤位置以適應場景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![寬度的 50% 高度設定的 3D 柱狀圖](height_percent_50.png) | ![寬度的 100% 高度設定的 3D 柱狀圖](height_percent_100.png) | ![寬度的 200% 高度設定的 3D 柱狀圖](height_percent_200.png) |

These methods control different aspects of the chart:

| 方法 | 效果 |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | 3D 場景的高度，以寬度的百分比表示。 |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | 投影片上圖表物件的高度，以點為單位。 |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 3D 場景的深度，以寬度的百分比表示。 |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | 系列在深度軸上的間距，以標記寬度的百分比表示。 |

高度設定會影響 3D 柱狀圖與條形圖，包括圓柱、圓錐與金字塔變體，亦包括 3D 折線圖、面積圖、圓餅圖與曲面圖。上述比較使用已驗證的 `Column3D` 型別。此設定不會改變 2D `ClusteredColumn` 圖表或 `BubbleWith3D` 圖表的外觀；這些名稱是 [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) 類別的成員。欲了解其他圖表外觀設定，請參閱 [Chart Formatting](/slides/zh-hant/java/chart-formatting/)。

## **調整系列之間的間隙**

使用 [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) 可控制 3D 圖表中資料系列沿深度軸的距離，表達為標記寬度的百分比。使用值從 **0 to 500**（含），`0` 會移除間隙，較大的值會增加間距。在固定圖表深度下，增加間隙會使標記在深度軸上變得較細。

透過 [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) 取得群組。此設定會套用至該群組中的每個系列，而不僅限於用來存取它的系列。[IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) 會回傳深度間隙並反映父群組的設定。

此設定會影響 3D 柱狀圖與條形圖，包括其圓柱、圓錐與金字塔變體，亦包括 3D 折線圖與面積圖。外觀取決於系列是以深度、叢集或堆疊方式排列。若要清楚比較不同系列之間的間隙，請使用 [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) 類別中的 `ChartType.Column3D`。

| 方法 | 效果 |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | 系列在深度軸上的間距，以標記寬度的百分比表示。 |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | 相鄰柱或條叢之間的間距，以柱或條寬度的百分比表示。 |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 整體圖表深度，以圖表寬度的百分比表示。 |

以下自包含範例使用預設圖表資料，包含三個系列與四個類別。它會儲存兩個簡報，資料、旋轉、間距寬度與圖表深度皆相同，唯有間隙深度不同。

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

以下影像說明了等效 .NET 範例中相同的間隙深度設定，皆由 Microsoft PowerPoint 匯出。

| 間隙深度：0% | 間隙深度：500% |
| --- | --- |
| ![3D 柱狀圖在深度軸上系列間無間隙](gap_depth_0.png) | ![3D 柱狀圖在深度軸上系列間有 500% 的間隙](gap_depth_500.png) |

## **變更 3D 系列類型與條形狀態**

在叢集圓柱圖中，第一系列起始為圓柱條形狀態。範例會在每次變更前後印出由 [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) 與 [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) 回傳的整數值。下表提供相對應的常數名稱。

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

| 對第一系列的變更 | 系列類型 | 條形狀態 |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

將形狀設為 `Box` 也會將系列類型變更為 `ClusteredColumn3D`。如果您的程式碼依系列類型分支，請在變更形狀後呼叫 `series.getType()`。在指派之前快取的值仍會選擇 `ClusteredCone` 分支。

![PowerPoint 比較圖，顯示第一系列從左至右分別為圓柱、圓錐與矩形柱形](series-shapes.png)

## **常見問題**

**哪種圖表類型在 Aspose.Slides 中支援 3D 模式？**

Aspose.Slides 支援柱狀圖的 3D 變體，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 以及 100% Stacked Column 3D，並透過 [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) 類別揭露相關的 3D 類型。欲取得完整且最新的列表，請檢查已安裝版本的 API 參考中 [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖用於報告或網頁嗎？**

可以。您可以使用 [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) 或將整張投影片 [render the entire slide](/slides/zh-hant/java/convert-powerpoint-to-png/) 為 PNG 或 JPEG 等格式匯出。此功能在需要點陣預覽或將圖表嵌入文件、儀表板或網頁，而不需 PowerPoint 時非常有用。

**建立與呈現大型 3D 圖表的效能如何？**

效能取決於資料量與視覺複雜度。為取得最佳結果，請盡量減少 3D 效果，避免在牆面與繪圖區使用大量紋理，盡可能限制每個系列的資料點數量，並將輸出解析度與尺寸設定為符合目標顯示或列印需求的大小。