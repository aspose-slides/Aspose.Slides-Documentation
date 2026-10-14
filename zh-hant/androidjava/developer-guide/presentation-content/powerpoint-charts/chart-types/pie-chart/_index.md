---
title: 在 Android 上的簡報中自訂圓餅圖
linktitle: 圓餅圖
type: docs
url: /zh-hant/androidjava/pie-chart/
keywords:
- 圓餅圖
- 管理圖表
- 自訂圖表
- 圖表選項
- 圖表設定
- 繪圖選項
- 切片顏色
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides for Android via Java 建立並自訂圓餅圖。設定次要圖表、顯示資料標籤，並在 PowerPoint 中套用自動切片顏色。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圓餅圖。它展示了如何為 Pie of Pie 和 Bar of Pie 圖表配置次要圖表選項，以及如何為標準圓餅圖啟用自動切片著色。

範例聚焦於圖表自訂工作，例如將圖表新增至投影片、調整系列與標籤設定、以自訂類別與數值取代預設圖表資料，並儲存更新後的簡報。

## **Pie of Pie 與 Bar of Pie 圖表的次要圖表選項**

Aspose.Slides for Android via Java 支援 Pie of Pie 與 Bar of Pie 圖表的次要圖表選項。這些選項可控制次要圖表的大小以及資料點在兩個圖表之間的分割方式。

以下範例在新簡報中建立一個 Pie of Pie 圖表，並將資料點值顯示為標籤。 [setSecondPieSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) 方法將次要圖表大小設定為主圖表的 149%。 [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) 選擇以百分比為基礎的分割，且 [setPieSplitPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) 將閾值設定為 53%。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // 顯示值並配置次要圖表。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **選取次要圖表的類別**

當您希望將特定類別在次要圖表中分組，而不論其百分比值時，可使用自訂分割。例如，銷售報告可能會將 Online 與 Events 合併顯示，使讀者能比較這兩個渠道，即使它們分別佔總銷售的 35% 和 10%。

呼叫 [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) 並傳入 [PieSplitType.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplittype/#Custom) 以選擇自訂分割，並透過 [getPieSplitCustomPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--) 取得點集合。集合的 [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#add-int-) 方法接受系列中的零基索引；使用 [addItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) 以加入資料點物件。在此範例中，索引 1 選取 Online，索引 3 的點選取 Events。Partners 也暫時加入，然後使用 [removeItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-) 移除。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // 以渠道的銷售額取代預設資料。
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // 依零基索引選取 Online，並以資料點物件選取 Events。
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // 從選取中排除 Partners，但不刪除其來源資料。
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) 與 Events (10) 在次要圖表中顯示為獨立的切片。在主要圖表中，它們以一個結合切片（值為 45）表示，並與 Retail (40) 和 Partners (15) 共同顯示。從自訂選取中移除 Partners 後，該類別仍保留在主要圖表中；不會從圖表的來源資料中移除該類別或其數值。

以下圖示顯示在 PowerPoint 中儲存的簡報：
![次要圖表中包含 Online 與 Events，主要圖表中其結合值為 45 的 Pie of Pie 圖表](pie_of_pie_custom.png)

## **設定自動圓餅圖切片顏色**

Aspose.Slides for Android via Java 能自動為圓餅圖切片指派不同的顏色。以下範例建立一個具有置中標題的圓餅圖，並以三個季度類別及其數值取代預設資料。 [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) 方法將值 20、50、30 顯示為標籤，而 [setColorVaried](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) 為每個切片啟用不同的顏色。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // 新增置中的圖表標題。
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // 使用第一個工作表取代預設資料。
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // 顯示值並為切片指派不同的顏色。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**是否支援 Pie of Pie 與 Bar of Pie 變體？**

是的，該函式庫[支援](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 圓餅圖的次要圖表，包括 Pie of Pie 與 Bar of Pie 類型。

**我可以只將圖表匯出為影像（例如 PNG）嗎？**

是的，您可以[將圖表本身匯出為影像](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--)（例如 PNG），而不必匯出整個簡報。