---
title: 在 Android 上客製化簡報中的 3D 圖表
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
## **概觀**

Aspose.Slides for Android via Java 讓您透過 [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) 方法自訂 3D 圖表的視圖。本文章示範如何調整旋轉、 高度比例、 深度、 直角座標軸 與 系列間距，然後將簡報儲存為 PPTX 格式。

## **設定 3D 圖表的旋轉與深度**

以下範例建立一個 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ，並使用 [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) 在第一張投影片上加入堆疊式 3D 柱狀圖。它以兩個系列、每個系列三個值取代預設的系列與類別。工作表索引 `0` 指向圖表的第一個資料工作表；第 `0` 列保存系列名稱，第 `0` 欄保存類別標籤。

[setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) 與 [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) 方法分別將圖表的旋轉設為 40 與 270 度。[setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) 將深度設為寬度的 150%，而 [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) 則啟用直角座標軸以取代透視。最終產生的簡報包含已套用上述 3D 視圖設定的圖表。

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

3D 圖表有三個可分別填充的表面： [side wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getSideWall--)、[back wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) 與 [floor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--)。將表面的 [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) 設為 `Picture` 並指派影像。將 [picture fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) 以及表面的 [picture type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartwall/#setPictureType-int-) 設為 `Stretch`，即可在表面上以單一影像填滿。

將 [arrow.png](arrow.png) 存於工作目錄。範例會旋轉圖表並提升垂直軸的最大值，使底面在柱狀圖之間可見。接著將投影片複製兩次，分別將箭頭套用於不同表面。三個圖表保持相同資料、觀察角度與背景。

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try (FileInputStream image = new FileInputStream("arrow.png")) {
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

    IPPImage arrow = presentation.getImages().addImage(image);

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

Microsoft PowerPoint 會如下顯示三張投影片。

| 側牆 | 背牆 | 地板 |
| --- | --- | --- |
| ![Arrow pointing into the chart along the side wall](side-wall.png) | ![Arrow pointing right across the back wall](back-wall.png) | ![Arrow pointing right across the floor between the columns](floor.png) |

## **調整 3D 圖表的高度比例**

使用 [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) 以寬度的百分比設定 3D 圖表的高度。此方式會在不改變投影片上圖表物件大小的前提下，調整 3D 場景的比例。

下列範例建立一個預設資料的 [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 圖表：三個系列與四個類別。它會產生三個簡報，分別使用 50%、100% 與 200% 的高度比例。圖表的位置、寬度與高度保持不變。資料、旋轉、深度、系列間距與格式在三個檔案中皆相同，僅高度百分比不同。

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

以下影像說明 .NET 等價範例中相同高度設定的呈現，皆以 Microsoft PowerPoint 匯出。較小的百分比會產生較平坦的場景，較大的百分比則會在相同圖表物件內呈現較高的場景。PowerPoint 可能也會調整座標軸刻度間隔與標籤位置以適應場景。

| 高度: 50% | 高度: 100% | 高度: 200% |
| --- | --- | --- |
| ![3D column chart with height set to 50 percent of its width](height_percent_50.png) | ![3D column chart with height set to 100 percent of its width](height_percent_100.png) | ![3D column chart with height set to 200 percent of its width](height_percent_200.png) |

以下方法控制圖表的不同面向：

| 方法 | 影響 |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | 3D 場景的高度比例（相對於寬度）。 |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | 投影片上圖表物件的高度（點數）。 |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 3D 場景的深度比例（相對於寬度）。 |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | 系列沿深度軸的間距，作為標記寬度的百分比。 |

高度設定影響 3D 柱狀與條形圖（包括圓柱、圓錐與金字塔變體），以及 3D 折線、面積、圓餅與曲面圖。上述比較使用已驗證的 `Column3D` 類型。此設定不會改變 2D `ClusteredColumn` 或 `BubbleWith3D` 圖表的外觀；這些名稱皆屬於 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 類別的成員。如需其他圖表外觀設定，請參閱 [Chart Formatting](/slides/zh-hant/androidjava/chart-formatting/)。

## **調整系列間的間距**

使用 [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) 控制 3D 圖表中資料系列沿深度軸的距離，以標記寬度的百分比表示。允許的值為 **0 到 500**（含），`0` 代表移除間距，值越大間距越寬。若圖表深度固定，增大間距會使標記在深度軸上變得更細。

透過 [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) 取得群組。此設定會套用到該群組內的所有系列，而不僅限於存取它的那一個系列。[IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) 會回傳深度間距，並反映父群組的設定。

此設定影響 3D 柱狀與條形圖（含圓柱、圓錐、金字塔等變體），以及 3D 折線與面積圖。外觀會因系列排列方式（深度、分群或堆疊）而異。若要直觀比較不同系列之間的間距，請使用 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 類別中的 `ChartType.Column3D`。

以下方法控制圖表的不同面向：

| 方法 | 影響 |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | 系列沿深度軸的間距，作為標記寬度的百分比。 |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | 相鄰條形或柱狀叢集之間的間距，作為條形或柱狀寬度的百分比。 |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 圖表的整體深度，作為圖表寬度的百分比。 |

以下範例使用預設圖表資料（三個系列、四個類別），產生兩個簡報，資料、旋轉、間距寬度與圖表深度皆相同，僅間距深度不同。

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

以下影像說明 .NET 等價範例中相同間距深度設定的呈現。

| 間距深度: 0% | 間距深度: 500% |
| --- | --- |
| ![3D column chart with no gap between series along the depth axis](gap_depth_0.png) | ![3D column chart with a 500 percent gap between series along the depth axis](gap_depth_500.png) |

## **變更 3D 系列類型與條形形狀**

在分群圓柱圖中，第一個系列預設為圓柱條形。範例在每次變更前後，分別印出 [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) 與 [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) 回傳的整數值。表格列出相對應的常數名稱。

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
| 將系列類型設為 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 將條形形狀設為 `Box` | `ClusteredColumn3D` | `Box` |

將形狀設為 `Box` 也會將系列類型改為 `ClusteredColumn3D`。如果程式碼依系列類型分支，請在變更形狀後呼叫 `series.getType()`，否則在指派前快取的值仍會選擇 `ClusteredCone` 分支。

![PowerPoint comparison showing the first series as cylinders, cones, and rectangular columns from left to right](series-shapes.png)

## **常見問題集**

**哪些圖表類型支援 Aspose.Slides 的 3D 模式？**

Aspose.Slides 支援多種 3D 柱狀圖變體，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 與 100% Stacked Column 3D，亦可透過 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 類別取得其他相關 3D 類型。欲取得完整且最新的清單，請檢查您安裝版本的 API 參考中 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 成員。

**我可以取得 3D 圖表的點陣圖供報告或網頁使用嗎？**

可以。您可以使用 [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) 將圖表匯出為影像，或將整張投影片以 PNG、JPEG 等格式匯出（請參閱 [render the entire slide](/slides/zh-hant/androidjava/convert-powerpoint-to-png/)）。此方式適合需要點陣預覽，或在文件、儀表板、網頁中嵌入圖表，而不必安裝 PowerPoint。

**大量 3D 圖表的建置與呈現效能如何？**

效能受資料量與視覺複雜度影響。為取得最佳效能，建議盡量減少 3D 效果、避免在牆面與繪圖區使用大量紋理、在可能的情況下限制每個系列的資料點數，並將輸出解析度與尺寸設定為符合目標顯示或列印需求的大小。