---
title: 在 Java 中為簡報圖表新增趨勢線
linktitle: 趨勢線
type: docs
url: /zh-hant/java/trend-line/
keywords:
- 圖表
- 趨勢線
- 指數趨勢線
- 線性趨勢線
- 對數趨勢線
- 移動平均趨勢線
- 多項式趨勢線
- 乘方趨勢線
- 自訂趨勢線
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "快速在 PowerPoint 圖表中使用 Aspose.Slides for Java 添加並自訂趨勢線 — 實用指南，協助您吸引觀眾。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 為簡報圖表新增趨勢線。它展示如何建立圖表、為圖表系列新增趨勢線，並處理多種趨勢線類型，包括指數、線性、對數、移動平均、多項式和乘方。

它也說明如何透過插入線條形狀為圖表新增自訂線，並包含一段簡短的常見問題，說明趨勢線的向前與向後投射值以及在匯出為 PDF 或 SVG、以及將圖表渲染為影像時，趨勢線是否會被保留。

## **新增趨勢線**

使用 [ITrendlineCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/itrendlinecollection/#add-int-) 為圖表系列新增趨勢線，並透過 [TrendlineType](https://reference.aspose.com/slides/java/com.aspose.slides/trendlinetype/) 選擇其類型。此範例會建立一個具有預設資料的群組柱狀圖，並為其三個系列中的每一個新增兩條趨勢線。

指數趨勢線透過 [setDisplayEquation](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) 和 [setDisplayRSquaredValue](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-) 隱藏其公式與 R 平方值，而線性趨勢線則為紅色。對數趨勢線使用 [addTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) 來設定自訂標籤。移動平均使用 [setPeriod](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setPeriod-byte-) 設為三個資料點，並使用自訂的 [setTrendlineName](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-)。

多項式趨勢線的 [setOrder](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setOrder-byte-) 為三，且透過 [setForward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setForward-double-) 向前延伸一個類別。乘方趨勢線則透過 [setBackward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setBackward-double-) 向後延伸一個類別。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **設定趨勢線截距**

使用 [setIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#setIntercept-double-) 於 X = 0 時固定趨勢線的 Y 值。此設定支援線性、指數與多項式趨勢線。

例如，生產成本模型可能需要在已知的固定成本 100 開始，即使在非零產量的量測值顯示不同的基線。對於線性趨勢線，固定截距會將方程式 `y = ax + b` 約束為 `b = 100`；斜率在此限制下擬合資料。這不會僅僅移動已經擬合好的線。座標軸交叉設定控制圖表軸相交的位置，而非擬合趨勢線的係數。

以下範例建立一個散佈圖（XY），產量從 1 到 4，成本分別為 170、200、230 與 260。它先以預設的自動截距儲存圖表，然後將截距設定為 100 再儲存第二個 PPTX。兩個檔案唯一的差異在於截距設定。趨勢線會顯示其公式，且延伸回 X = 0。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

透過自動計算，這些資料會產生 `y = 30x + 140`。將截距設定為 100 則大約會得到 `y = 43.33x + 100`：零點的擬合值符合已知的基線，但此時線條不再通過每個資料點。

| 自動截距 | 截距固定為 100 |
| --- | --- |
| ![線性趨勢線，截距自動計算為 140](intercept-automatic.png) | ![線性趨勢線，截距固定為 100](intercept-fixed.png) |

兩張影像使用相同的資料與座標軸比例。趨勢線向後延伸至 X = 0 以顯示其截距。

預設情況下，[getIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#getIntercept--) 會回傳 `Double.NaN`，表示截距未指定而非零。之後會根據資料自動計算截距。

## **新增自訂線**

自訂線是繪製在圖表之上的形狀，而非由系列資料計算出的趨勢線。本範例使用 [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) 在圖表上方的投影片新增水平線。線條的位置以投影片座標（點數）指定，因而從圖表左邊緣開始，並位於圖表高度的一半處。其寬度與圖表寬度相同。[getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) 為線條設定實心紅色。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**趨勢線的「向前」與「向後」意味著什麼？**

它們是趨勢線向前或向後投射的長度：對於散佈圖（XY）以座標軸單位計算；對於非散佈圖則以類別數計算。僅允許非負值。

**匯出簡報為 PDF 或 SVG，或將投影片渲染為影像時，趨勢線會被保留嗎？**

會。Aspose.Slides 可將簡報轉換為 [PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/) 或 [SVG](/slides/zh-hant/java/render-a-slide-as-an-svg-image/)，並將圖表渲染為影像；趨勢線作為圖表的一部分，在這些操作中會被保留。亦提供方法可 [匯出圖表影像](/slides/zh-hant/java/create-shape-thumbnails/)。