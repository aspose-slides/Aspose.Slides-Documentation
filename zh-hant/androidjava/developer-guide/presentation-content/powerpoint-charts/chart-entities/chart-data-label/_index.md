---
title: 在 Android 上管理簡報中的圖表資料標籤
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
description: "學習如何在 PowerPoint 簡報中使用 Aspose.Slides for Android（Java）新增與格式化圖表資料標籤，打造更具吸引力的投影片。"
---
## **簡介**

資料標籤會顯示圖表系列與個別資料點的資訊，協助讀者辨識數值並理解圖表。本文說明如何格式化數值、顯示百分比、讀取標籤文字、調整類別軸標籤間距，以及設定圓餅圖標籤的位置。

## **在圖表資料標籤中設定資料精度**

使用 [setNumberFormatOfValues](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) 來格式化系列的數值。此範例建立一個具有預設資料的折線圖，顯示其資料表，並為第一個系列啟用數值標籤。格式 `#,##0.00` 會顯示千位分隔符與兩位小數，而不會更改底層的實際數值。

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

對於堆疊直條圖，將每個數值計算為其類別總和的百分比，並將文字指派給由 [getTextFrameForOverriding](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) 回傳的文字框。此範例使用預設圖表資料，並以 8 點字型、兩位小數的方式顯示百分比。當類別總和為零時會跳過該類別，以避免除以零的錯誤。若圖表資料變更，請重新計算自訂標籤文字。

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

## **使用圖表資料標籤設定百分比符號**

當數值以分數形式儲存時，使用 [setNumberFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) 來顯示百分比。將 `false` 傳遞給 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) 可使標籤格式獨立於來源儲存格。

此範例建立一個 100% 堆疊直條圖，四個類別各有紅色與藍色系列。每對數值加總為 1。標籤格式 `0.0%` 會將 0.30 顯示為 30.0%，而縱軸則使用兩位小數。兩個系列皆使用白色、10 點字型的標籤文字。

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

使用 [getActualLabelText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) 取得由資料標籤設定產生的文字。當需要將標籤抽取為報表、搜尋簡報內容，或驗證產生的圖表時，此功能相當有用。以下範例中，預設的 [資料標籤格式](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatalabelformat/) 結合了每個類別名稱、系列名稱與數值。某一資料點將其數值格式化為百分比，另一個則使用由 [getTextFrameForOverriding](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) 取得的自訂文字。

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

即使標籤顯示 `75%` 並附帶類別與系列名稱，資料點中儲存的數值仍為 `0.75`。自訂文字會取代產生的標籤文字。無論哪種情況，[getActualLabelText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) 都會回傳最終的標籤字串。若只想抽取可見標籤，請另行檢查 [isVisible](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatalabel/#isVisible--)，如上例所示。

## **設定標籤與坐標軸的距離**

使用 [setLabelOffset](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iaxis/#setLabelOffset-int-) 控制類別軸標籤與坐標軸之間的距離。此值為類別軸標籤最大字型大小的百分比。此範例建立一個群組直條圖，並將水平軸標籤偏移設定為 500。此設定會影響類別軸標籤，而非個別資料點的標籤。

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

在圓餅圖上，調整資料標籤位置以改善間距並為引線留出空間。

此範例顯示第一個資料點的數值，將其標籤放在切片外側，並使用 [setX](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutable/#setX-float-) 與 [setY](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilayoutable/#setY-float-) 調整水平與垂直偏移。這些偏移值分別相對於圖表的寬度與高度。

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

![調整後資料標籤位置的圓餅圖](pie-chart-adjusted-label.png)

## **常見問題**

**如何防止在密集圖表中資料標籤重疊？**

結合自動標籤布局、引線以及縮小字型大小；必要時隱藏部分欄位（例如類別），或僅為極端值或關鍵點顯示標籤。

**如何僅對零、負值或空值停用標籤？**

在啟用標籤之前篩選資料點，並根據設定的規則關閉零值、負值或缺失值的顯示。

**如何確保匯出為 PDF/圖片時標籤樣式一致？**

明確設定字型系列與大小，並確認渲染環境中已安裝該字型，以避免使用備援字型。