---
title: 在 Android 上優化簡報的圖表計算
linktitle: 圖表計算
type: docs
weight: 50
url: /zh-hant/androidjava/chart-calculations/
keywords:
- 圖表計算
- 圖表元素
- 元素位置
- 實際位置
- 子元素
- 父元素
- 圖表數值
- 實際數值
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解在 Android 上的 Aspose.Slides 中的圖表計算、資料更新與精度控制，適用於 PPT 與 PPTX，並附有實作的 Java 程式碼範例。"
---
## **概述**

Aspose.Slides 提供用於在簡報中處理圖表計算與版面資料的 API。本文說明如何取得圖表元素的實際值，包括實作 `IActualLayout` 的元素的實際位置與大小，以及圖表座標軸的實際值。同時也說明這些值會在圖表版面驗證之後填充。

此外，本文示範如何取得父圖表元素的實際位置，以及如何隱藏圖表元件（例如標題、座標軸、圖例和格線）。這些範例可協助您以程式方式檢查圖表版面資訊，並控制 PowerPoint 簡報中圖表元素的可見性。

## **計算圖表元素的實際值**
Aspose.Slides for Android via Java 提供簡單的 API 以取得這些屬性。[IAxis](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAxis) 介面的屬性提供關於座標軸圖表元素實際位置的資訊（[IAxis.getActualMaxValue](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAxis#getActualMaxValue--)、[IAxis.getActualMinValue](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAxis#getActualMinValue--)、[IAxis.getActualMajorUnit](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--)、[IAxis.getActualMinorUnit](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--)、[IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--)、[IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--))。必須先呼叫方法 [IChart.validateChartLayout()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChart#validateChartLayout--) 以在屬性中填入實際值。

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```

## **計算父圖表元素的實際位置**
Aspose.Slides for Android via Java 提供簡單的 API 以取得這些屬性。[IActualLayout](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IActualLayout) 介面的屬性提供有關父圖表元素實際位置的資訊（[IActualLayout.getActualX](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IActualLayout#getActualX--)、[IActualLayout.getActualY](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IActualLayout#getActualY--)、[IActualLayout.getActualWidth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IActualLayout#getActualWidth--)、[IActualLayout.getActualHeight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IActualLayout#getActualHeight--)）。必須先呼叫方法 [IChart.validateChartLayout()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChart#validateChartLayout--) 以在屬性中填入實際值。

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **隱藏圖表元素**
本主題說明如何隱藏圖表中的資訊。使用 Aspose.Slides for Android via Java，您可以隱藏圖表的 **標題、垂直座標軸、水平座標軸** 與 **格線**。以下程式碼範例展示如何使用這些屬性。

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //隱藏圖表標題
    chart.setTitle(false);

    ///隱藏值軸
    chart.getAxes().getVerticalAxis().setVisible(false);

    //類別軸可見性
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //隱藏圖例
    chart.setLegend(false);

    //隱藏主要格線
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //Setting series line color
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**Do external Excel workbooks work as a data source, and how does that affect recalculation?**  
是。圖表可以參照外部工作簿：當您連接或重新整理外部來源時，公式和數值會從該工作簿取得，且圖表在開啟或編輯時會反映更新。API 允許您[指定外部工作簿](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) 路徑並管理連結的資料。

**Can I compute and display trendlines without implementing regression myself?**  
是。[趨勢線](/slides/zh-hant/androidjava/trend-line/)（線性、指數等）由 Aspose.Slides 添加並自動更新；其參數會根據系列資料重新計算，您無需自行實作回歸計算。

**If a presentation has multiple charts with external links, can I control which workbook each chart uses for computed values?**  
是。每個圖表皆可指向各自的[外部工作簿](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-)，或者您也可以為每個圖表獨立建立或取代外部工作簿，而不受其他圖表影響。