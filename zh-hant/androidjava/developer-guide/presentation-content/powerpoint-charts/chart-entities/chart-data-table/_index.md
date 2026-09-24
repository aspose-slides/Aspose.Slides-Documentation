---
title: 在 Android 上的簡報中自訂圖表資料表格
linktitle: 資料表格
type: docs
url: /zh-hant/androidjava/chart-data-table/
keywords:
- 圖表資料
- 資料表格
- 字型屬性
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 在 PowerPoint 簡報中自訂圖表資料表格的字型、邊框與圖例鍵。"
---
## **概觀**

Aspose.Slides for Android via Java 讓您顯示圖表的資料表格，並自訂文字格式、邊框與圖例鍵。本文章說明如何啟用資料表格、設定文字格式、控制各類邊框，以及顯示或隱藏圖例鍵。範例會將設定好的圖表儲存為 PPTX 檔案。

## **設定字型屬性**

要顯示圖表的資料表格，請將 `true` 傳遞給[setDataTable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chart/#setDataTable-boolean-)。使用[getChartDataTable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chart/#getChartDataTable--) 取得表格並設定文字格式。

1. 使用[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別載入簡報。
2. 在第一張投影片加入叢集柱狀圖。
3. 啟用圖表的資料表格。
4. 透過[setFontBold](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseportionformat/#setFontBold-byte-) 設定粗體，並將`20` 傳遞給[setFontHeight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) 以使用 20 點字型。
5. 儲存已修改的簡報。

以下範例需要工作目錄中有 `test.pptx`（至少一張投影片）。它會在位置 (50, 50) 新增一個寬 600 點、高 400 點、使用預設資料的圖表。儲存的 `output.pptx` 內含已啟用資料表格且套用指定字型設定的圖表。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **自訂資料表格邊框**

使用[IChart.setDataTable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichart/#setDataTable-boolean-) 啟用表格，並透過[IChart.getChartDataTable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichart/#getChartDataTable--) 取得。您可以獨立控制三種邊框：

- [setBorderHorizontal](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) 控制水平儲存格邊框。
- [setBorderVertical](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatatable/#setBorderVertical-boolean-) 控制垂直儲存格邊框。
- [setBorderOutline](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatatable/#setBorderOutline-boolean-) 控制表格的外框。

將 `true` 傳遞給各方法即可顯示相應邊框，傳遞 `false` 則隱藏。以下範例建立一個使用預設資料的叢集柱狀圖，顯示水平邊框與外框，隱藏垂直邊框。此範例不需要任何輸入檔案，圖表位置與大小以點為單位指定。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下比較使用相同的圖表資料與圖例鍵設定，分別呈現四種情況。從全部邊框啟用開始，每個變體僅關閉一種邊框設定。左下角的變體與範例中的邊框設定相同。

![所有邊框啟用、無水平邊框、無垂直邊框、且無外框的圖表資料表格](data-table-borders.png)

## **顯示或隱藏圖例鍵**

圖例鍵是資料表格中系列名稱旁的彩色標記，可協助讀者將每一列對應到圖表系列。將 `true` 傳遞給[setShowLegendKey](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) 以顯示這些標記，傳遞 `false` 則隱藏。

圖表的獨立圖例由[IChart.setLegend](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) 控制。這兩項設定互相獨立：隱藏獨立圖例不會影響資料表格內的圖例鍵，隱藏資料表格的鍵也不會隱藏獨立圖例。

以下範例建立一個使用預設資料的圖表，啟用資料表格，並在表格內顯示圖例鍵，同時隱藏獨立圖例。所有表格邊框皆明確啟用。此範例不需要輸入簡報。若僅想隱藏表格的鍵，請將 `false` 傳遞給[setShowLegendKey](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-)。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下比較展示相同的表格，左側顯示圖例鍵，右側隱藏圖例鍵。所有邊框仍保持啟用，兩種情況下獨立圖例皆被隱藏。

![左側顯示圖例鍵、右側隱藏圖例鍵的圖表資料表格](data-table-legend-keys.png)

## **常見問題**

**我可以在圖表的資料表格中顯示圖例鍵嗎？**

可以。將 `true` 傳遞給[setShowLegendKey](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) 以顯示圖例鍵，傳遞 `false` 則隱藏。

**將簡報匯出為 PDF、HTML 或影像時，資料表格會被保留嗎？**

會。Aspose.Slides 會在匯出至[PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)、[HTML](/slides/zh-hant/androidjava/convert-powerpoint-to-html/)或[images](/slides/zh-hant/androidjava/convert-powerpoint-to-png/) 時，將圖表及其顯示的資料表格作為投影片的一部份渲染。

**我能在從範本載入的圖表上使用資料表格嗎？**

可以。對於從現有簡報或範本載入的圖表，使用[hasDataTable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chart/#hasDataTable--) 與[setDataTable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chart/#setDataTable-boolean-) 來檢查或變更其資料表格的顯示狀態。

**我要如何找出哪些圖表已啟用資料表格？**

遍歷每張投影片上的形狀，辨識出圖表後呼叫其[hasDataTable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chart/#hasDataTable--) 方法。回傳 `true` 表示該圖表已啟用資料表格。