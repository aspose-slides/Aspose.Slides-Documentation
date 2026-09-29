---
title: 在 Android 簡報中管理圖表資料標籤
linktitle: 資料標籤
type: docs
url: /zh-hant/androidjava/chart-data-label/
keywords:
- 圖表
- 資料標籤
- 資料精度
- 百分比
- 標籤距離
- 標籤位置
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "學習如何在 PowerPoint 簡報中使用 Aspose.Slides for Android (Java) 新增並格式化圖表資料標籤，以打造更具吸引力的投影片。"
---
## **簡介**

資料標籤顯示圖表系列與個別資料點的資訊，協助讀者辨識數值並了解圖表。本文說明如何格式化數值、顯示百分比、讀取標籤文字、在軸最大值之外控制標籤、調整類別軸標籤間距，以及設定餅圖標籤的位置。

## **設定圖表資料標籤的資料精度**

使用 [setNumberFormatOfValues](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) 來格式化系列值。此範例建立一個具有預設資料的折線圖，顯示其資料表，並為第一個系列啟用數值標籤。格式 `#,##0.00` 會顯示千位分隔符與兩位小數，且不會變更底層數值。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **以百分比作為標籤顯示**

對於堆疊直條圖，將每個值計算為其類別總和的百分比，並將文字指派給 [getTextFrameForOverriding](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) 回傳的文字框。此範例使用預設圖表資料，並以 8 點字型顯示兩位小數的百分比。總和為零的類別會被跳過，以避免除以零。若圖表資料變更，請重新計算自訂標籤文字。

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);

    double[] categoryTotals = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            IChartSeries series = chart.getChartData().getSeries().get_Item(i);
            Number pointValue = (Number) series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += pointValue.doubleValue();
        }
    }

    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            Number pointValue = (Number) series.getDataPoints().get_Item(j).getValue().getData();
            double dataPointPercent = (pointValue.doubleValue() / categoryTotals[j]) * 100;

            IPortion portion = new Portion();
            portion.setText(String.format(Locale.US, "%.2f %%", dataPointPercent));
            portion.getPortionFormat().setFontHeight(8f);

            label.getTextFrameForOverriding().setText("");
            IParagraph paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在圖表資料標籤中設定百分比符號**

當值以分數形式儲存時，使用 [setNumberFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) 來顯示百分比。將 `false` 傳遞給 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-)，使標籤格式獨立於來源儲存格。

此範例建立一個 100% 堆疊直條圖，包含紅色與藍色系列，跨越四個類別。每對值相加為 1。標籤格式 `0.0%` 會將 0.30 顯示為 30.0%，而垂直軸則使用兩位小數。兩個系列的標籤文字皆為白色、10 點大小。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    for (int i = 0; i < 4; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    String[] seriesNames = { "Reds", "Blues" };
    int[] seriesColors = { Color.RED, Color.BLUE };
    double[][] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

    for (int i = 0; i < seriesNames.length; i++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (int j = 0; j < 4; j++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **讀取資料標籤的實際文字**

使用 [getActualLabelText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) 取得資料標籤設定所產生的文字。這在擷取標籤以供報告、搜尋簡報內容或驗證產生的圖表時相當有用。以下範例中，預設的 [data label format](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatalabelformat/) 會結合每個類別名稱、系列名稱與數值。一個資料點將其數值格式化為百分比，另一個則使用來自 [getTextFrameForOverriding](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) 的自訂文字。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    IChartDataCell secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    IChartDataCell northSeriesCell = workbook.getCell(0, 0, 1, "North");
    IChartSeries north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    IChartDataCell northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    IChartDataCell northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    IChartDataCell southSeriesCell = workbook.getCell(0, 0, 2, "South");
    IChartSeries south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    IChartDataCell southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    IChartDataCell southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (IChartSeries series : chart.getChartData().getSeries()) {
        for (IChartDataPoint point : series.getDataPoints()) {
            IDataLabel label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            System.out.println("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

資料點中儲存的數值仍為 `0.75`，即使其標籤顯示 `75%` 並附加類別與系列名稱。自訂文字會取代產生的標籤文字。[getActualLabelText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) 在兩種情況下皆返回結果標籤字串。若只想擷取可見標籤，請如上例般另外檢查 [isVisible](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatalabel/#isVisible--)。

## **在軸最大值之外控制資料標籤**

手動限制軸範圍時，某些資料點可能會超過其最大值。使用 [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) 來控制是否顯示其資料標籤。此設定會變更標籤可見性；不會改變軸範圍或底層資料值。

以下範例建立一個 2D 群組直條圖，數值為 60 與 120。它將 `false` 傳遞給 [setAutomaticMaxValue](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-)，並在垂直軸上使用 [setMaxValue](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iaxis/#setMaxValue-double-) 設定最大值為 100。第一張投影片允許標籤超出最大值；其副本則停用此功能。兩張投影片皆儲存在 `DataLabelsOverMaximum.pptx` 中。

使用 [setShowValue](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) 啟用數值標籤。圖表層級的設定本身不會啟用數值顯示，也不會覆寫個別標籤已停用的數值顯示。此範例為整個系列啟用數值，並使用 [setPosition](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatalabelformat/#setPosition-int-) 將標籤放置於每個柱狀的外側端點。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell firstCategory = workbook.getCell(0, 1, 0, "Within range");
    IChartDataCell secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Values");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    IChartDataCell firstValue = workbook.getCell(0, 1, 1, 60);
    IChartDataCell secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    ISlide secondSlide = presentation.getSlides().addClone(slide);
    IChart secondChart = (IChart) secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下圖片顯示 Microsoft PowerPoint 呈現的已儲存投影片。設定為 `true` 時，標籤 **120** 會在上邊界可見；設定為 `false` 時，則隱藏。標籤 **60** 仍保持可見，軸最大值仍為 **100**，且第二個資料點在兩種情況下皆為 **120**。

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
此範例使用具有數值軸的 2D 直條圖。沒有數值軸的圖表，如餅圖與環形圖，沒有可此方式限制的軸最大值。
{{% /alert %}}

## **設定標籤與軸的距離**

使用 [setLabelOffset](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iaxis/#setLabelOffset-int-) 來控制類別軸標籤與軸之間的距離。該值為軸標籤最大字型大小的百分比。此範例建立一個群組直條圖，並將水平軸標籤偏移設定為 500。此設定會影響類別軸標籤，而非附加於個別資料點的標籤。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **調整標籤位置**

在餅圖上，調整資料標籤位置以改善間距並為指示線留出空間。

此範例顯示第一個資料點的數值，將其標籤放置於切片外側，並使用 [setX](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutable/#setX-float-) 與 [setY](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutable/#setY-float-) 調整水平與垂直偏移。這些偏移分別相對於圖表的寬度與高度。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **FAQ**

**如何防止資料標籤在密集圖表中重疊？**

結合自動標籤放置、指示線與較小字型；如有需要，可隱藏某些欄位（例如類別），或僅顯示極端值或關鍵點的標籤。

**如何僅對零值、負值或空值停用標籤？**

在啟用標籤之前先篩選資料點，並根據定義的規則對 0、負值或缺失值關閉顯示。

**如何在匯出為 PDF/影像時確保標籤樣式一致？**

明確設定字型系列與大小，並確保該字型在渲染環境中可用，以避免回退。