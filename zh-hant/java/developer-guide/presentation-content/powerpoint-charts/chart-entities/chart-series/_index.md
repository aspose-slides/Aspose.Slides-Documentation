---
title: 在 Java 中管理簡報的圖表資料系列
linktitle: 資料系列
type: docs
url: /zh-hant/java/chart-series/
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
- Java
- Aspose.Slides
description: "學習如何在 Java 中管理 PowerPoint (PPT/PPTX) 的圖表系列，提供實用程式碼範例與最佳實踐，提升您的資料簡報。"
---
## **概觀**

本文說明了 [ChartSeries](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chartseries/) 在 Aspose.Slides 中的角色，重點在於資料如何在簡報中結構化與可視化。這些物件提供了定義圖表中個別資料點、分類與外觀參數的基礎元素。透過使用 [ChartSeries](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chartseries/)，開發人員可以無縫整合底層資料來源，並完整掌控資訊的顯示方式，從而產生動態、資料驅動的簡報，清晰傳達洞見與分析。

系列是以列或欄方式排列的數字，在圖表中繪製。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列的重疊程度**

使用 [IChartSeriesOverlap](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/properties/overlap) 屬性，您可以指定在 2D 圖表上條狀與柱狀的重疊比例（範圍：-100 至 100）。此屬性套用於父系列群組的所有系列：它是相應群組屬性的投影。因此，此屬性為唯讀。

請使用 `ParentSeriesGroup.Overlap` 可讀寫屬性來設定 `Overlap` 的首選值。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
1. 在投影片上新增一個群組式柱狀圖。  
1. 取得第一個圖表系列。  
1. 取得圖表系列的 `ParentSeriesGroup`，並為該系列設定首選的重疊值。  
1. 將修改後的簡報寫入 PPTX 檔案。

以下 Java 程式碼示範如何為圖表系列設定重疊：

```java
Presentation pres = new Presentation();
try {
    // 新增圖表
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // 設定系列重疊
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // 將簡報檔寫入磁碟
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **變更系列顏色**
Aspose.Slides for Java 允許您以以下方式變更系列的顏色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
1. 在投影片上新增圖表。  
1. 取得要變更顏色的系列。  
1. 設定您偏好的填充類型與填充顏色。  
1. 儲存修改後的簡報。

以下 Java 程式碼示範如何變更系列的顏色：

```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **變更系列分類顏色**
Aspose.Slides for Java 允許您以以下方式變更系列分類的顏色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
1. 在投影片上新增圖表。  
1. 取得要變更顏色的系列分類。  
1. 設定您偏好的填充類型與填充顏色。  
1. 儲存修改後的簡報。

以下 Java 程式碼示範如何變更系列分類的顏色：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **變更系列名稱** 

預設情況下，圖表的圖例名稱來源於每個資料欄或列上方的儲存格內容。

在我們的範例（示例圖）中，

* 欄位分別為 *Series 1、Series 2、Series 3*；  
* 列分別為 *Category 1、Category 2、Category 3、Category 4*。

Aspose.Slides for Java 允許您在圖表資料與圖例中更新或變更系列名稱。

以下 Java 程式碼示範如何在 `ChartDataWorkbook` 中變更系列名稱：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

以下 Java 程式碼示範如何透過 `Series` 在圖例中變更系列名稱：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```

## **設定圖表系列的填充顏色**

Aspose.Slides for Java 允許您以以下方式為圖表區域內的系列設定自動填充顏色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
1. 依索引取得投影片參考。  
1. 依您偏好的類型新增帶有預設資料的圖表（以下範例使用 `ChartType.ClusteredColumn`）。  
1. 取得圖表系列並將填充顏色設定為 Automatic。  
1. 將簡報儲存為 PPTX 檔案。

以下 Java 程式碼示範如何為圖表系列設定自動填充顏色：

```java
Presentation pres = new Presentation();
try {
    // 建立群組式柱狀圖
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // 設定系列填充格式為自動
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // 將簡報檔寫入磁碟
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **為圖表系列設定反轉填充顏色**
Aspose.Slides 允許您以以下方式為圖表區域內的系列設定反轉填充顏色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
1. 依索引取得投影片參考。  
1. 依您偏好的類型新增帶有預設資料的圖表（以下範例使用 `ChartType.ClusteredColumn`）。  
1. 取得圖表系列並將填充顏色設定為 invert。  
1. 將簡報儲存為 PPTX 檔案。

以下 Java 程式碼示範此操作：

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // 新增系列與類別
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // 取得第一個圖表系列並填入其系列資料。
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **當值為負時將系列設定為反轉**
Aspose.Slides 允許您透過 `IChartDataPoint.InvertIfNegative` 及 `ChartDataPoint.InvertIfNegative` 屬性設定反轉。當使用這些屬性設定反轉時，資料點在取得負值時會反轉其顏色。

以下 Java 程式碼示範此操作：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **清除特定資料點**
Aspose.Slides for Java 允許您以以下方式清除特定圖表系列的 `DataPoints` 資料：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
2. 依索引取得投影片參考。  
3. 依索引取得圖表參考。  
4. 迭代圖表的所有 `DataPoints`，將 `XValue` 與 `YValue` 設為 null。  
5. 清除特定圖表系列的全部 `DataPoints`。  
6. 將修改後的簡報寫入 PPTX 檔案。

以下 Java 程式碼示範此操作：

```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **設定系列的間隙寬度**
Aspose.Slides for Java 允許您透過 **`GapWidth`** 屬性為系列設定間隙寬度：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
1. 取得第一張投影片。  
1. 新增帶有預設資料的圖表。  
1. 取得任一圖表系列。  
1. 設定 `GapWidth` 屬性。  
1. 將修改後的簡報寫入 PPTX 檔案。

以下 Java 程式碼示範如何設定系列的間隙寬度：

```java
// 建立空白簡報 
Presentation pres = new Presentation();
try {
    // 取得簡報的第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 新增帶有預設資料的圖表
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // 設定圖表資料工作表的索引
    int defaultWorksheetIndex = 0;
    
    // 取得圖表資料工作表
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // 新增系列
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // 新增類別
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // 取得第二個圖表系列
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // 填入系列資料
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // 設定 GapWidth 值
    series.getParentSeriesGroup().setGapWidth(50);
    
    // 將簡報儲存至磁碟
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**單一圖表可容納的系列數量是否有限制？**

Aspose.Slides 對您加入的系列數量沒有固定上限。實際上限取決於圖表的可讀性與應用程式可用的記憶體。

**如果叢集內的柱狀過於接近或過於分離該怎麼辦？**

調整該系列（或其父系列群組）的 `GapWidth` 設定。增大數值會拉寬柱狀間距，減少數值則會使柱狀更靠近。