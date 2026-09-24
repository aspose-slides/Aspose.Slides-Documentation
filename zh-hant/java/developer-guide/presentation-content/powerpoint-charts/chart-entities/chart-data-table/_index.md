---
title: 使用 Java 在簡報中自訂圖表資料表格
linktitle: 資料表格
type: docs
url: /zh-hant/java/chart-data-table/
keywords:
- 圖表資料
- 資料表格
- 字型屬性
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 簡報中自訂圖表資料表格的字型、邊框與圖例鍵。"
---
## **概觀**

Aspose.Slides for Java 可讓您顯示圖表的資料表格，並自訂其文字格式、邊框與圖例鍵。本文說明如何啟用資料表、格式化文字、分別控制三種邊框，以及顯示或隱藏圖例鍵。範例會將設定好的圖表儲存為 PPTX 檔案。

## **設定字型屬性**

若要顯示圖表的資料表，請將 `true` 傳遞給[setDataTable](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chart/#setDataTable-boolean-)。使用[getChartDataTable](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chart/#getChartDataTable--) 取得資料表並設定文字格式。

1. 使用[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/)類別載入簡報。  
2. 在第一張投影片新增一個群組直條圖。  
3. 啟用圖表的資料表。  
4. 透過[setFontBold](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) 設定粗體，並將 `20` 傳遞給[setFontHeight](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) 以使用 20 點字體。  
5. 儲存已修改的簡報。

以下範例需要工作目錄中有 `test.pptx`（至少包含一張投影片），它會在座標 (50, 50) 放置一個寬 600 點、高 400 點的預設資料圖表。儲存的 `output.pptx` 會包含已啟用資料表且套用指定字型設定的圖表。

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

使用[IChart.setDataTable](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichart/#setDataTable-boolean-) 啟用資料表，並透過[IChart.getChartDataTable](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichart/#getChartDataTable--) 取得。您可以分別控制三種邊框：

- [setBorderHorizontal](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) 控制水平儲存格邊框。  
- [setBorderVertical](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) 控制垂直儲存格邊框。  
- [setBorderOutline](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) 控制表格的外框。

將 `true` 傳遞給相應方法即可顯示該邊框，傳遞 `false` 則隱藏。以下範例建立一個預設資料的群組直條圖，顯示水平邊框與外框，隱藏垂直邊框。此範例不需要輸入檔案，圖表的位置與大小均以點為單位指定。

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

下表比較了四種情況下相同的圖表資料與圖例鍵設定。從全部邊框啟用開始，每個變體僅關閉一種邊框設定。左下角的變體與範例的邊框設定相同。

![Chart data tables with all borders enabled, no horizontal borders, no vertical borders, and no outer border](data-table-borders.png)

## **顯示或隱藏圖例鍵**

圖例鍵是資料表中系列名稱旁的小彩色標記，可協助讀者將表格列對應到圖表系列。將 `true` 傳遞給[setShowLegendKey](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) 以顯示這些標記，傳遞 `false` 則隱藏。

圖表本身的獨立圖例由[IChart.setLegend](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichart/#setLegend-boolean-) 控制。這兩項設定互相獨立：隱藏獨立圖例不會影響資料表中的鍵，隱藏資料表鍵亦不會隱藏獨立圖例。

以下範例建立一個預設資料的圖表，啟用其資料表，顯示表格內的圖例鍵並隱藏獨立圖例。所有表格邊框皆明確啟用，且不需要輸入簡報。若只想隱藏表格鍵，將 `false` 傳遞給[setShowLegendKey](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) 即可。

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

下圖比較了同一表格在圖例鍵顯示與隱藏兩種狀態下的差異。所有邊框均保持啟用，且兩種情況下的獨立圖例均被隱藏。

![Chart data tables with legend keys shown on the left and hidden on the right](data-table-legend-keys.png)

## **常見問題**

**我可以在圖表的資料表中顯示圖例鍵嗎？**

可以。將 `true` 傳遞給[setShowLegendKey](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) 以顯示圖例鍵，傳遞 `false` 以隱藏。

**將簡報匯出為 PDF、HTML 或影像時，資料表會被保留嗎？**

會。Aspose.Slides 會在匯出為 [PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/)、[HTML](/slides/zh-hant/java/convert-powerpoint-to-html/) 或 [images](/slides/zh-hant/java/convert-powerpoint-to-png/) 時，將圖表及其顯示的資料表作為投影片的一部分渲染。

**我可以在從範本載入的圖表上操作資料表嗎？**

可以。對於從現有簡報或範本載入的圖表，使用[hasDataTable](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chart/#hasDataTable--) 和[setDataTable](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chart/#setDataTable-boolean-) 來檢查或變更資料表是否顯示。

**我要如何找出已啟用資料表的圖表？**

遍歷每張投影片上的形狀，識別圖表後呼叫其[hasDataTable](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chart/#hasDataTable--) 方法。返回 `true` 表示該圖表的資料表已啟用。