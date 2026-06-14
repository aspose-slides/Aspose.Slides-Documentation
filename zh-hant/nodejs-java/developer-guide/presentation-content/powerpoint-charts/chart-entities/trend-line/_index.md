---
title: 在 JavaScript 中為簡報圖表新增趨勢線
linktitle: 趨勢線
type: docs
url: /zh-hant/nodejs-java/trend-line/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "快速在 PowerPoint 圖表中使用 JavaScript 與 Aspose.Slides for Node.js via Java 新增並自訂趨勢線 — 實用指南，助您吸引觀眾。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 為簡報圖表新增趨勢線。它展示如何建立圖表、為圖表系列新增趨勢線，並使用多種趨勢線類型，包括指數、線性、對數、移動平均、多項式和冪次。

本文亦說明如何透過插入線條圖形為圖表新增自訂線，並包含關於前向與後向趨勢線投射值的簡短 FAQ，以及趨勢線在匯出為 PDF 或 SVG，或將圖表渲染為影像時是否會被保留的說明。

## **新增趨勢線**

Aspose.Slides for Node.js via Java 提供簡易的 API，以管理圖表的各種趨勢線：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的執行個體。
2. 依索引取得投影片的參考。
3. 加入包含預設資料的圖表，並使用任意所需類型（本範例使用 ChartType.ClusteredColumn）。
4. 為圖表系列 1 新增指數趨勢線。
5. 為圖表系列 1 新增線性趨勢線。
6. 為圖表系列 2 新增對數趨勢線。
7. 為圖表系列 2 新增移動平均趨勢線。
8. 為圖表系列 3 新增多項式趨勢線。
9. 為圖表系列 3 新增冪次趨勢線。
10. 將修改後的簡報寫入 PPTX 檔案。

以下程式碼用於建立帶有趨勢線的圖表。

```javascript
// 建立 Presentation 類別的執行個體
var pres = new aspose.slides.Presentation();
try {
    // 建立叢集柱狀圖表
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // 為圖表系列 1 新增指數趨勢線
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // 為圖表系列 1 新增線性趨勢線
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // 為圖表系列 2 新增對數趨勢線
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // 為圖表系列 2 新增移動平均趨勢線
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // 為圖表系列 3 新增多項式趨勢線
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // 為圖表系列 3 新增冪次趨勢線
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // 儲存簡報
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **新增自訂線**

Aspose.Slides for Node.js via Java 提供簡易的 API，以在圖表中新增自訂線。若要在簡報的特定投影片上加入簡單的直線，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的執行個體
- 使用索引取得投影片的參考
- 使用 Shapes 物件提供的 AddChart 方法建立新圖表
- 使用 Shapes 物件提供的 AddAutoShape 方法加入線條類型的 AutoShape
- 設定圖形線條的顏色。
- 將修改後的簡報寫入 PPTX 檔案

以下程式碼用於建立帶有自訂線的圖表。

```javascript
// 建立 Presentation 類別的執行個體
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**趨勢線的「前向」與「後向」是什麼意思？**

它們是趨勢線向前或向後延伸的長度：對於散佈圖 (XY) 為坐標軸單位；對於非散佈圖則為類別數。僅允許非負值。

**匯出簡報為 PDF 或 SVG，或將投影片渲染為影像時，趨勢線會被保留嗎？**

會。Aspose.Slides 會將簡報轉換為 [PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/zh-hant/nodejs-java/render-a-slide-as-an-svg-image/) 並將圖表渲染為影像；作為圖表一部分的趨勢線在這些操作中會被保留。亦提供方法可[匯出圖表影像](/slides/zh-hant/nodejs-java/create-shape-thumbnails/)。