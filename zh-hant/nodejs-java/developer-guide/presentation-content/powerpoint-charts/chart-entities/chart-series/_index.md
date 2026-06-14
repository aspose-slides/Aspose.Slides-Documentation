---
title: 使用 JavaScript 在簡報中管理圖表資料系列
linktitle: 資料系列
type: docs
url: /zh-hant/nodejs-java/chart-series/
keywords:
- 圖表系列
- 系列重疊
- 系列顏色
- 類別顏色
- 系列名稱
- 資料點
- 系列間隙
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何在 PowerPoint (PPT/PPTX) 中使用 JavaScript 管理圖表系列，並提供實用程式碼範例與最佳實踐，以提升您的資料簡報。"
---
## **概觀**

本文說明了 [ChartSeries](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/) 在 Aspose.Slides 中的角色，重點在於資料於簡報中的結構與視覺化方式。這些物件提供了定義圖表中單一資料點集合、類別以及外觀參數的基礎元素。透過使用 [ChartSeries](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/)，開發人員能夠無縫整合底層資料來源，並完全掌控資訊的呈現方式，從而產生具備動態、資料驅動且能清晰傳達見解與分析的簡報。

系列是圖表中繪製的一列或一欄數字。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列重疊**

使用 [ChartSeries.getOverlap](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#getOverlap) 方法，可指定 2D 圖表中長條與柱狀之間的重疊程度（範圍：-100 到 100）。此屬性套用於父系列群組的所有系列：屬於相應群組屬性的投射。因此，該屬性為唯讀。

使用 `ParentSeriesGroup.getOverlap` 可讀寫屬性來設定 `Overlap` 的偏好值。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 在投影片上新增一個聚集柱狀圖。  
3. 取得第一個圖表系列。  
4. 取得該系列的 `ParentSeriesGroup`，並為系列設定偏好的重疊值。  
5. 將修改後的簡報寫入 PPTX 檔案。

以下 JavaScript 程式碼示範如何為圖表系列設定重疊：

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 新增圖表
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // 設定系列重疊
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // 將簡報檔案寫入磁碟
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **變更系列顏色**

Aspose.Slides for Node.js via Java 允許您以以下方式變更系列的顏色：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 在投影片上新增圖表。  
3. 取得要變更顏色的系列。  
4. 設定您偏好的填滿類型與填滿顏色。  
5. 儲存修改後的簡報。

以下 JavaScript 程式碼示範如何變更系列顏色：

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **變更系列類別的顏色**

Aspose.Slides for Node.js via Java 允許您以以下方式變更系列類別的顏色：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 在投影片上新增圖表。  
3. 取得要變更顏色的系列類別。  
4. 設定您偏好的填滿類型與填滿顏色。  
5. 儲存修改後的簡報。

以下 JavaScript 程式碼示範如何變更系列類別的顏色：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **變更系列名稱** 

預設情況下，圖表的圖例名稱是每個資料列或欄上方儲存格的內容。

在我們的範例（示例圖片）中，

* 欄位分別為 *Series 1、Series 2* 與 *Series 3*；  
* 列則為 *Category 1、Category 2、Category 3* 與 *Category 4*。

Aspose.Slides for Node.js via Java 允許您在圖表資料與圖例中更新或變更系列名稱。

以下 JavaScript 程式碼示範如何在 `ChartDataWorkbook` 中變更系列名稱：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

以下 JavaScript 程式碼示範如何透過 `Series` 在圖例中變更系列名稱：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **設定圖表系列填滿顏色**

Aspose.Slides for Node.js via Java 允許您以以下方式為圖表區域內的系列設定自動填滿顏色：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 依您偏好的類型新增含預設資料的圖表（以下範例使用 `ChartType.ClusteredColumn`）。  
4. 取得圖表系列，將填滿顏色設為 Automatic。  
5. 將簡報保存為 PPTX 檔案。

以下 JavaScript 程式碼示範如何為圖表系列設定自動填滿顏色：

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 建立聚集柱狀圖
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // 設定系列填滿格式為自動
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // 將簡報檔案寫入磁碟
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **設定圖表系列反轉填滿顏色**

Aspose.Slides 允許您以以下方式為圖表區域內的系列設定反轉填滿顏色：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 依您偏好的類型新增含預設資料的圖表（以下範例使用 `ChartType.ClusteredColumn`）。  
4. 取得圖表系列，將填滿顏色設為 invert。  
5. 將簡報保存為 PPTX 檔案。

以下 JavaScript 程式碼示範此操作：

```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // 新增系列與類別
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // 取得第一個圖表系列並填充其資料
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **當值為負時設定系列反轉**

Aspose.Slides 允許您透過 `ChartDataPoint.setInvertIfNegative` 方法設定反轉。當透過此屬性設定反轉後，資料點在取得負值時會自動反轉顏色。

以下 JavaScript 程式碼示範此操作：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **清除特定資料點的資料**

Aspose.Slides for Node.js via Java 允許您以以下方式清除特定圖表系列的 `DataPoints` 資料：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 依索引取得圖表的參考。  
4. 迭代所有圖表 `DataPoints`，將 `XValue` 與 `YValue` 設為 null。  
5. 清除特定圖表系列的所有 `DataPoints`。  
6. 將修改後的簡報寫入 PPTX 檔案。

以下 JavaScript 程式碼示範此操作：

```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **設定系列間隙寬度**

Aspose.Slides for Node.js via Java 允許您透過 **`GapWidth`** 屬性設定系列的間隙寬度：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 取得第一張投影片。  
3. 新增含預設資料的圖表。  
4. 取得任意圖表系列。  
5. 設定 `GapWidth` 屬性。  
6. 將修改後的簡報寫入 PPTX 檔案。

以下 JavaScript 程式碼示範如何設定系列的間隙寬度：

```javascript
// 建立空白簡報
var pres = new aspose.slides.Presentation();
try {
    // 取得簡報的第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 新增具有預設資料的圖表
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // 設定圖表資料工作表的索引
    var defaultWorksheetIndex = 0;
    // 取得圖表資料工作表
    var fact = chart.getChartData().getChartDataWorkbook();
    // 新增系列
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // 新增類別
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // 取得第二個圖表系列
    var series = chart.getChartData().getSeries().get_Item(1);
    // 填充系列資料
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // 設定 GapWidth 值
    series.getParentSeriesGroup().setGapWidth(50);
    // 將簡報儲存至磁碟
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題集**

**單一圖表可以包含的系列數量是否有限制？**

Aspose.Slides 對您可新增的系列數量沒有固定上限。實務上受到圖表可讀性以及應用程式可用記憶體的限制。

**如果群組內的柱狀過於靠近或過於分離該怎麼辦？**

調整該系列（或其父系列群組）的間隙寬度設定。增大數值會擴大柱狀之間的間距，減小則會使其更靠近。