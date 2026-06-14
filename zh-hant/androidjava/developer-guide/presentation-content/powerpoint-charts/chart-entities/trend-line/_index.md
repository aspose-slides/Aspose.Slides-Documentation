---
title: 在 Android 上的簡報圖表中加入趨勢線
linktitle: 趨勢線
type: docs
url: /zh-hant/androidjava/trend-line/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 快速在 PowerPoint 圖表中加入並自訂趨勢線——一本實用指南，助您吸引觀眾。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 為簡報圖表加入趨勢線。它展示了如何建立圖表、將趨勢線加入圖表系列，以及如何使用多種趨勢線類型，包括指數、線性、對數、移動平均、多項式和冪次。

它還描述了如何透過插入線條形狀為圖表新增自訂線，並包含一段關於趨勢線向前與向後投射值以及趨勢線在匯出為 PDF 或 SVG、或將圖表渲染為影像時是否保留的簡短 FAQ。

## **新增趨勢線**
Aspose.Slides for Android via Java 提供簡單的 API 以管理不同圖表的趨勢線：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
2. 依據索引取得投影片的參考。
3. 加入一個具有預設資料的圖表，並設定為任意所需類型（此範例使用 ChartType.ClusteredColumn）。
4. 為圖表系列 1 新增指數趨勢線。
5. 為圖表系列 1 新增線性趨勢線。
6. 為圖表系列 2 新增對數趨勢線。
7. 為圖表系列 2 新增移動平均趨勢線。
8. 為圖表系列 3 新增多項式趨勢線。
9. 為圖表系列 3 新增冪次趨勢線。
10. 將修改後的簡報寫入 PPTX 檔案。

以下程式碼用於建立帶有趨勢線的圖表。

```java
// 建立 Presentation 類別的實例
Presentation pres = new Presentation();
try {
    // 建立叢集柱狀圖表
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // 為圖表系列 1 新增指數趨勢線
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // 為圖表系列 1 新增線性趨勢線
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // 為圖表系列 2 新增對數趨勢線
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // 為圖表系列 2 新增移動平均趨勢線
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // 為圖表系列 3 新增多項式趨勢線
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // 為圖表系列 3 新增冪次趨勢線
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
Aspose.Slides for Android via Java 提供簡單的 API 以在圖表中加入自訂線。若要在簡報的特定投影片上加入一條簡單的純線，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例
- 依照其 Index 取得投影片的參考
- 使用 Shapes 物件所提供的 AddChart 方法建立新圖表
- 使用 Shapes 物件所提供的 AddAutoShape 方法加入類型為 Line 的 AutoShape
- 設定形狀線條的顏色。
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

**趨勢線的「forward」與「backward」是什麼意思？**

它們是趨勢線向前或向後投射的長度：對於散佈圖 (XY) 為軸單位；對於非散佈圖則為類別數。僅允許非負值。

**匯出簡報為 PDF 或 SVG，或將投影片渲染為影像時，趨勢線會被保留嗎？**

會。Aspose.Slides 可將簡報轉換為 [PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/zh-hant/androidjava/render-a-slide-as-an-svg-image/) 並將圖表渲染為影像；作為圖表一部份的趨勢線在這些操作中會被保留。亦提供方法可[匯出圖表影像](/slides/zh-hant/androidjava/create-shape-thumbnails/)。