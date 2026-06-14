---
title: 在 JavaScript 中建立或更新 PowerPoint 簡報圖表
linktitle: 建立或更新圖表
type: docs
weight: 10
url: /zh-hant/nodejs-java/create-chart/
keywords:
- 新增圖表
- 建立圖表
- 編輯圖表
- 變更圖表
- 更新圖表
- 散佈圖表
- 圓餅圖表
- 折線圖表
- 樹狀圖表
- 證券圖表
- 箱形圖與鬚圖
- 漏斗圖表
- 旭日圖表
- 直方圖表
- 雷達圖表
- 多類別圖表
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 PowerPoint 簡報中建立並自訂圖表。使用實用的 JavaScript 程式碼範例新增、格式化與編輯圖表。"
---
## **概述**

本文提供使用 Aspose.Slides 建立與自訂圖表的完整指南。您將學會如何以程式方式將圖表加入投影片、填入資料，並套用各種格式設定以符合特定設計需求。整篇文章以詳細程式碼範例說明每一步，從初始化簡報與圖表物件到設定系列、座標軸與圖例。依循本指南，您將能深入了解如何在應用程式中整合動態圖表產生，簡化資料驅動簡報的製作流程。

## **建立圖表**
圖表可協助人們快速視覺化資料並獲得洞見，這些資訊往往不易從表格或試算表直接看出。

**為何建立圖表？**

使用圖表，您可以

* 在簡報的單一投影片上彙總、濃縮或概括大量資料
* 揭露資料中的模式與趨勢
* 推斷資料隨時間或特定測量單位的方向與動能
* 找出異常值、偏差、錯誤、荒謬資料等
* 傳達或呈現複雜資料

在 PowerPoint 中，您可以透過「插入」功能建立圖表，該功能提供許多圖表類型的範本。使用 Aspose.Slides，您可以建立常規圖表（基於流行圖表類型）以及自訂圖表。

{{% alert color="primary" %}} 

為了讓您建立圖表，Aspose.Slides 提供 [ChartType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartType) 類別。此類別下的欄位對應不同的圖表類型。

{{% /alert %}} 

### **建立一般圖表**

_步驟：建立圖表_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 圖表</em></strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>步驟：在 JavaScript 中建立簡報圖表</em></strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 簡報圖表</em></strong></a>

**程式碼步驟：**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
2. 透過索引取得投影片的參考。
3. 加入帶有資料的圖表，並指定您偏好的圖表類型。 
4. 為圖表添加標題。 
5. 存取圖表資料工作表。 
6. 清除所有預設的系列和類別。 
7. 新增系列和類別。 
8. 為圖表系列新增一些圖表資料。 
9. 為圖表系列添加填色。 
10. 為圖表系列添加標籤。 
11. 將修改後的簡報寫入 PPTX 檔案。 

此 JavaScript 程式碼示範如何建立一般圖表：

```javascript
// 實例化代表 PPTX 檔案的簡報類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 新增帶有預設資料的圖表
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // 設定圖表標題
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    // 設定第一個系列顯示值
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // 設定圖表資料工作表的索引
    var defaultWorksheetIndex = 0;
    // 取得圖表資料工作表
    var fact = chart.getChartData().getChartDataWorkbook();
    // 刪除預設產生的系列和類別
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // 新增系列
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // 新增類別
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // 取得第一個圖表系列
    var series = chart.getChartData().getSeries().get_Item(0);
    // 立即填入系列資料
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // 設定系列的填色
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // 取得第二個圖表系列
    series = chart.getChartData().getSeries().get_Item(1);
    // 填入系列資料
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // 設定系列的填色
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // 為新系列的每個類別建立自訂標籤
    // 設定第一個標籤顯示類別名稱
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // 讓第三個標籤顯示值
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // 儲存包含圖表的簡報
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **建立散佈圖表**
散佈圖表（亦稱散點圖或 X‑Y 圖）常用於檢查模式或展示兩個變數之間的相關性。

您可能會在以下情況使用散佈圖表

* 具備配對的數值資料
* 兩個變數彼此相配
* 想判斷兩個變數是否相關
* 有一個自變數對應多個因變數值

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>步驟：在 JavaScript 中建立散佈圖表</em></strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 散佈圖表</em></strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 簡報散佈圖表</em></strong></a>

1. 請遵循上方 [建立一般圖表](#creating-normal-charts) 的步驟  
2. 在第三步，加入圖表時將圖表類型指定為下列之一  
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _代表散佈圖（含標記）。_  
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _代表以曲線連接、帶有資料標記的散佈圖。_  
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _代表以曲線連接、無資料標記的散佈圖。_  
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _代表以直線連接、帶有資料標記的散佈圖。_  
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _代表以直線連接、無資料標記的散佈圖。_  

此 JavaScript 程式碼示範如何使用不同標記系列建立散佈圖表：

```javascript
// 實例化代表 PPTX 檔案的簡報類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 建立預設圖表
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // 取得預設圖表資料工作表索引
    var defaultWorksheetIndex = 0;
    // 取得圖表資料工作表
    var fact = chart.getChartData().getChartDataWorkbook();
    // 刪除示範系列
    chart.getChartData().getSeries().clear();
    // 新增系列
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // 取得第一個圖表系列
    var series = chart.getChartData().getSeries().get_Item(0);
    // 為系列新增一個新點 (1:3)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // 新增一個新點 (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // 變更系列類型
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // 變更圖表系列標記
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // 取得第二個圖表系列
    series = chart.getChartData().getSeries().get_Item(1);
    // 在此新增一個新點 (5:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // 新增一個新點 (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // 新增一個新點 (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // 新增一個新點 (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // 變更圖表系列標記
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **建立圓餅圖表**

圓餅圖表最適合顯示資料中部分與整體的關係，尤其當資料包含具有數值的類別標籤時。然而，若資料的部分或標籤過多，建議改用長條圖。

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>步驟：在 JavaScript 中建立圓餅圖表</em></strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 圓餅圖表</em></strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 簡報圓餅圖表</em></strong></a>

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 加入預設資料的圖表，並指定類型為 [ChartType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartType).Pie。  
4. 存取圖表資料 [ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataWorkbook)。  
5. 清除預設的系列和類別。  
6. 新增系列和類別。  
7. 為圖表系列新增圖表資料。  
8. 為圓餅圖的區塊新增點並設定自訂顏色。  
9. 為系列設定標籤。  
10. 為系列標籤設定引線。  
11. 設定圓餅圖的旋轉角度。  
12. 將修改後的簡報寫入 PPTX 檔案  

此 JavaScript 程式碼示範如何建立圓餅圖表：

```javascript
// 實例化代表 PPTX 檔案的簡報類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var slides = pres.getSlides().get_Item(0);
    // 新增帶有預設資料的圖表
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // 設定圖表標題
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // 設定第一個系列顯示值
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // 設定圖表資料工作表的索引
    var defaultWorksheetIndex = 0;
    // 取得圖表資料工作表
    var fact = chart.getChartData().getChartDataWorkbook();
    // 刪除預設產生的系列和類別
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // 新增類別
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // 新增系列
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // 填入系列資料
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // 在新版本中無法運作
    // 新增點並設定區塊顏色
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // 設定區塊邊框
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // 設定區塊邊框
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDot);
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // 設定區塊邊框
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDotDot);
    // 為新系列的每個類別建立自訂標籤
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // 顯示圖表的引線
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // 設定圓餅圖區塊的旋轉角度
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // 儲存含有圖表的簡報
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **建立折線圖表**

折線圖（亦稱折線圖）最適合用於顯示隨時間變化的數值。使用折線圖，您可以一次比較大量資料、追蹤時間趨勢、突出資料系列中的異常等。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 加入預設資料的圖表，並指定類型為 `ChartType.Line`。  
1. 存取圖表資料 IChartDataWorkbook。  
1. 清除預設的系列和類別。  
1. 新增系列和類別。  
1. 為圖表系列新增圖表資料。  
1. 將修改後的簡報寫入 PPTX 檔案  

此 JavaScript 程式碼示範如何建立折線圖表：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

預設情況下，折線圖的點以直線連接。若想改為虛線，可如下指定首選的虛線樣式：

```javascript
var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
    let series = lineChart.getChartData().getSeries().get_Item(i);
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Dash);
});
```

### **建立樹狀圖表**

樹狀圖表最適合用於銷售資料，當您想同時顯示資料類別的相對大小並快速突顯對每個類別貢獻度較大的項目時。

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>步驟：在 JavaScript 中建立樹狀圖表</em></strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 樹狀圖表</em></strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 簡報樹狀圖表</em></strong></a>

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 加入預設資料的圖表，並指定類型為 [ChartType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartType).TreeMap。  
4. 存取圖表資料 [ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataWorkbook)。  
5. 清除預設的系列和類別。  
6. 新增系列和類別。  
7. 為圖表系列新增圖表資料。  
8. 將修改後的簡報寫入 PPTX 檔案  

此 JavaScript 程式碼示範如何建立樹狀圖表：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // 分支 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // 分支 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **建立證券圖表**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>步驟：在 JavaScript 中建立證券圖表</em></strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 證券圖表</em></strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 簡報證券圖表</em></strong></a>

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 加入預設資料的圖表，並指定類型為 [ChartType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartType).OpenHighLowClose。  
4. 存取圖表資料 [ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataWorkbook)。  
5. 清除預設的系列和類別。  
6. 新增系列和類別。  
7. 為圖表系列新增圖表資料。  
8. 指定 HiLowLines 格式。  
9. 將修改後的簡報寫入 PPTX 檔案  

建立證券圖表的範例 JavaScript 程式碼：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);
  
    var wb = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));
    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));
    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));
    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));
    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **建立箱形圖與鬚圖**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>步驟：在 JavaScript 中建立箱形圖與鬚圖</em></strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 箱形圖與鬚圖</em></strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 簡報箱形圖與鬚圖</em></strong></a>

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 加入預設資料的圖表，並指定類型為 [ChartType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartType).BoxAndWhisker。  
4. 存取圖表資料 [ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataWorkbook)。  
5. 清除預設的系列和類別。  
6. 新增系列和類別。  
7. 為圖表系列新增圖表資料。  
8. 將修改後的簡報寫入 PPTX 檔案  

此 JavaScript 程式碼示範如何建立箱形圖與鬚圖：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **建立漏斗圖表**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>步驟：在 JavaScript 中建立漏斗圖表</em></strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 漏斗圖表</em></strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 簡報漏斗圖表</em></strong></a>

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 加入預設資料的圖表，並指定類型為 [ChartType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartType).Funnel。  
4. 將修改後的簡報寫入 PPTX 檔案  

此 JavaScript 程式碼示範如何建立漏斗圖表：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **建立旭日圖表**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>步驟：在 JavaScript 中建立旭日圖表</em></strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 旭日圖表</em></strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 簡報旭日圖表</em></strong></a>

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 加入預設資料的圖表，並指定類型為 [ChartType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartType).sunburst。  
4. 將修改後的簡報寫入 PPTX 檔案  

此 JavaScript 程式碼示範如何建立旭日圖表：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // 分支 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // 分支 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **建立直方圖表**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>步驟：在 JavaScript 中建立直方圖表</em></strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 直方圖表</em></strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 簡報直方圖表</em></strong></a>

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 加入預設資料的圖表，並指定類型為 [ChartType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartType).Histogram。  
4. 存取圖表資料 [ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataWorkbook)。  
5. 清除預設的系列和類別。  
6. 新增系列和類別。  
7. 將修改後的簡報寫入 PPTX 檔案  

此 JavaScript 程式碼示範如何建立直方圖表：

```javascript
var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```

### **建立雷達圖表**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>步驟：在 JavaScript 中建立雷達圖表</em></strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 雷達圖表</em></strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 簡報雷達圖表</em></strong></a>

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 加入帶有資料的圖表，並指定類型為 `ChartType.Radar`。  
4. 將修改後的簡報寫入 PPTX 檔案  

此 JavaScript 程式碼示範如何建立雷達圖表：

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **建立多類別圖表**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>步驟：在 JavaScript 中建立多類別圖表</em></strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 多類別圖表</em></strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 簡報多類別圖表</em></strong></a>

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 加入預設資料的圖表，並指定類型為 [ChartType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartType).ClusteredColumn。  
4. 存取圖表資料 [ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartDataWorkbook)。  
5. 清除預設的系列和類別。  
6. 新增系列和類別。  
7. 為圖表系列新增圖表資料。  
8. 將修改後的簡報寫入 PPTX 檔案。  

此 JavaScript 程式碼示範如何建立多類別圖表：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));
    // 添加系列
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // 儲存帶有圖表的簡報
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **建立地圖圖表**

地圖圖表是顯示包含資料的區域的視覺化圖形。地圖圖表最適合比較不同地理區域的資料或數值。

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>步驟：在 JavaScript 中建立地圖圖表</em></strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 地圖圖表</em></strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>步驟：在 JavaScript 中建立 PowerPoint 簡報地圖圖表</em></strong></a>

此 JavaScript 程式碼示範如何建立地圖圖表：

```javascript
let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **建立組合圖表**

組合圖表（或稱 combo 圖表）在同一圖形中結合兩種或以上的圖表類型。此圖表讓您突顯、比較或檢視多組資料集之間的差異，協助辨識其關聯性。

![組合圖表](combination_chart.png)

以下 JavaScript 程式碼示範如何在 PowerPoint 簡報中建立上述組合圖表：

```js
function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // 設定圖表標題。
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // 設定圖表圖例。
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // 刪除預設產生的系列與類別。
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // 新增類別。
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // 新增第一個系列。
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // 設定水平軸。
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // 設定垂直軸。
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // 設定垂直主要格線顏色。
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // 設定次要水平軸。
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // 設定次要垂直軸。
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```

## **更新圖表**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>步驟：在 JavaScript 中更新 PowerPoint 圖表</em></strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>步驟：在 JavaScript 中更新簡報圖表</em></strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>步驟：在 JavaScript 中更新 PowerPoint 簡報圖表</em></strong></a>

1. 實例化代表含有目標圖表之簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別。  
2. 透過索引取得投影片的參考。  
3. 遍歷所有形狀以找到目標圖表。  
4. 存取圖表資料工作表。  
5. 變更系列值以修改圖表資料系列。  
6. 新增系列並填入資料。  
7. 將修改後的簡報寫入 PPTX 檔案。  

此 JavaScript 程式碼示範如何更新圖表：

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 取得預設資料的圖表
    var chart = sld.getShapes().get_Item(0);
    // 設定圖表資料工作表的索引
    var defaultWorksheetIndex = 0;
    // 取得圖表資料工作表
    var fact = chart.getChartData().getChartDataWorkbook();
    // 變更圖表類別名稱
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // 取得第一個圖表系列
    var series = chart.getChartData().getSeries().get_Item(0);
    // 正在更新系列資料
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// 修改系列名稱
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // 取得第二個圖表系列
    series = chart.getChartData().getSeries().get_Item(1);
    // 正在更新系列資料
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// 修改系列名稱
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // 正在新增系列
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // 取得第三個圖表系列
    series = chart.getChartData().getSeries().get_Item(2);
    // 正在填入系列資料
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // 儲存包含圖表的簡報
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **設定圖表資料範圍**

設定圖表的資料範圍，請執行以下步驟：

1. 實例化代表含有目標圖表之簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別。  
2. 透過索引取得投影片的參考。  
3. 遍歷所有形狀以找到目標圖表。  
4. 存取圖表資料並設定範圍。  
5. 將修改後的簡報存為 PPTX 檔案。  

此 JavaScript 程式碼示範如何設定圖表的資料範圍：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **在圖表中使用預設標記**

當您在圖表中使用預設標記時，每個圖表系列會自動取得不同的預設標記符號。

此 JavaScript 程式碼示範如何自動設定圖表系列標記：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // 取得第二個圖表系列
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // 正在填入系列資料
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問與答**

**Aspose.Slides 支援哪些圖表類型？**

Aspose.Slides 支援廣泛的圖表類型，包括長條圖、折線圖、圓餅圖、區域圖、散佈圖、直方圖、雷達圖等，讓您可依資料視覺化需求選擇最適合的圖表類型。

**如何在投影片上新增圖表？**

首先建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例，使用索引取得目標投影片，然後呼叫新增圖表的方法，指定圖表類型與初始資料，即可將圖表直接加入簡報。

**如何更新圖表中顯示的資料？**

您可以透過存取圖表的資料工作簿（[ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdataworkbook/)），清除預設的系列與類別，然後加入自訂資料，以程式方式重新整理圖表顯示最新資料。

**是否可以自訂圖表的外觀？**

可以，Aspose.Slides 提供豐富的自訂選項，您可以修改顏色、字型、標籤、圖例及其他格式元素，以符合特定的設計需求。