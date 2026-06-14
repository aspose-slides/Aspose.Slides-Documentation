---
title: 在 Java 中為簡報圖表加入趨勢線
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
- 冪次趨勢線
- 自訂趨勢線
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "快速在 PowerPoint 圖表中加入並自訂趨勢線，使用 Aspose.Slides for Java — 實用指南，幫助您吸引觀眾。"
---
## **概述**

本文說明如何使用 Aspose.Slides 在簡報圖表中加入趨勢線。示範如何建立圖表、將趨勢線加入圖表系列，並說明多種趨勢線類型，包括指數、線性、對數、移動平均、多項式與冪次。

此外，本文也說明如何透過插入線條形狀的方式在圖表中加入自訂線，並包含關於趨勢線前向與後向投射值以及在匯出為 PDF 或 SVG、將圖表渲染為圖像時趨勢線是否會保留的簡短 FAQ。

## **新增趨勢線**
Aspose.Slides for Java 提供簡易的 API 來管理圖表的不同趨勢線：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
1. 依索引取得投影片的參考。
1. 使用任意想要的類型（本例使用 ChartType.ClusteredColumn）加入預設資料的圖表。
1. 為圖表系列 1 加入指數趨勢線。
1. 為圖表系列 1 加入線性趨勢線。
1. 為圖表系列 2 加入對數趨勢線。
1. 為圖表系列 2 加入移動平均趨勢線。
1. 為圖表系列 3 加入多項式趨勢線。
1. 為圖表系列 3 加入冪次趨勢線。
1. 將修改後的簡報寫入 PPTX 檔案。

以下程式碼用於建立帶有趨勢線的圖表。

```java
// 建立 Presentation 類別的實例
Presentation pres = new Presentation();
try {
    // 建立叢集柱狀圖表
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // 為圖表系列 1 加入指數趨勢線
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // 為圖表系列 1 加入線性趨勢線
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // 為圖表系列 2 加入對數趨勢線
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // 為圖表系列 2 加入移動平均趨勢線
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // 為圖表系列 3 加入多項式趨勢線
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // 為圖表系列 3 加入冪次趨勢線
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // 儲存簡報
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **新增自訂線**
Aspose.Slides for Java 提供簡易的 API 於圖表中加入自訂線。若要在簡報的特定投影片上加入一條簡單的直線，請依照下列步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例
- 使用 Index 取得投影片的參考
- 透過 Shapes 物件的 AddChart 方法建立新圖表
- 透過 Shapes 物件的 AddAutoShape 方法加入 Line 類型的 AutoShape
- 設定圖形線條的顏色
- 將修改後的簡報寫入 PPTX 檔案

以下程式碼用於建立帶有自訂線的圖表。

```java
// 建立 Presentation 類別的實例
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**「前向」與「後向」在趨勢線中代表什麼意思？**

它們是趨勢線向前或向後投射的長度：對散佈 (XY) 圖表而言，以座標軸單位表示；對非散佈圖表而言，以類別數量表示。僅允許非負值。

**將簡報匯出為 PDF 或 SVG，或將投影片渲染為圖像時，趨勢線會被保留嗎？**

會。Aspose.Slides 會將簡報轉換為 [PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/)/[SVG](/slides/zh-hant/java/render-a-slide-as-an-svg-image/) 並渲染圖表為圖像；趨勢線作為圖表的一部份，會在這些操作中保留下來。亦提供方法可 [匯出圖表的圖像](/slides/zh-hant/java/create-shape-thumbnails/)。